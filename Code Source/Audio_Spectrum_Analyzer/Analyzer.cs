using System;
using System.Collections.Generic;
using System.IO.Ports;
//using System.Windows;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;
using Un4seen.Bass;
using Un4seen.BassWasapi;
using System.Windows.Forms.DataVisualization.Charting;
using System.Runtime.InteropServices;
using NAudio.CoreAudioApi;


namespace Audio_Spectrum_Analyzer
{
    public class Analyzer
    {
        private bool _enable;               //enabled status
        private DispatcherTimer _t;         //timer that refreshes the display
        public float[] _fft;               //buffer for fft data
        private ProgressBar _l, _r;         //progressbars for left and right channel intensity
        private WASAPIPROC _process;        //callback function to obtain data
        private int _lastlevel;             //last output level
        private int _hanctr;                //last output level counter
        public List<byte> _spectrumdata;   //spectrum data buffer
        private Spectrum _spectrum;         //spectrum dispay control
        private ComboBox _devicelist;       //device list
        private bool _initialized;          //initialized flag
        private int devindex;               //used device index
        private Chart _chart;

        private Form parent;

        private int _lines = 64;        // number of spectrum lines
        private float _soundLevel;


        // fonction qui utilise la fonction système waveOutGetVolume et qui renvoie un tableau de deux entiers : [volumeGauche, volumeDroit]

        //ctor

        public Analyzer()
        {
            _fft = new float[8192];
            _lastlevel = 0;
            _hanctr = 0;
            _t = new DispatcherTimer();
            _t.Tick += _t_Tick;
            _t.Interval = TimeSpan.FromMilliseconds(25); //40hz refresh rate//25 //a changer ??
            _t.IsEnabled = false;
            _process = new WASAPIPROC(Process);
            _spectrumdata = new List<byte>();
            _devicelist = new ComboBox();
            _l = new ProgressBar();
            _r = new ProgressBar();
            _spectrum = new Spectrum();
            _chart = new Chart();

            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();


            t.Interval = 15000; // specify interval time as you want
            t.Tick += new EventHandler(timer_Tick);
            t.Start();
        }

        public Analyzer(Form parent, ProgressBar left, ProgressBar right, Spectrum spectrum, ComboBox devicelist, Chart chart)
        {
            _fft = new float[8192];
            _lastlevel = 0;
            _hanctr = 0;
            _t = new DispatcherTimer();
            _t.Tick += _t_Tick;
            _t.Interval = TimeSpan.FromMilliseconds(25); //40hz refresh rate//25 //a changer ??
            _t.IsEnabled = false;
            _l = left;
            _r = right;
            _l.Minimum = 0;
            _r.Minimum = 0;
            _r.Maximum = (ushort.MaxValue);
            _l.Maximum = (ushort.MaxValue);
            _process = new WASAPIPROC(Process);
            _spectrumdata = new List<byte>();
            _spectrum = spectrum;
            _chart = chart;
            _devicelist = devicelist;
            _initialized = false;
            this.parent = parent;

            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();


            t.Interval = 15000; // specify interval time as you want
            t.Tick += new EventHandler(timer_Tick);
            t.Start();


            chart.Series.Add("wave");
            chart.Series["wave"].ChartType = SeriesChartType.FastLine;
            chart.Series["wave"].ChartArea = "ChartArea1";

            chart.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            chart.ChartAreas["ChartArea1"].AxisY.Maximum = 255;
            chart.ChartAreas["ChartArea1"].AxisY.Minimum = 0;
            chart.ChartAreas["ChartArea1"].AxisX.Maximum = 64;
            chart.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
            for (int i = 0; i < chart.ChartAreas["ChartArea1"].AxisX.Maximum; i++)
            {
                chart.Series["wave"].Points.Add(0);
            }

            Init();
            
        }


        void timer_Tick(object sender, EventArgs e)
        {
            _soundLevel = GetSoundLevel();
        }
        // Serial port for arduino output


        // flag for display enable
        public bool DisplayEnable { get; set; }

        //flag for enabling and disabling program functionality
        public bool Enable
        {
            get { return _enable; }
            set
            {
                _enable = value;
                if (value)
                {
                    if (!_initialized)
                    {
                        var array = (_devicelist.Items[_devicelist.SelectedIndex] as string).Split(' ');
                        devindex = Convert.ToInt32(array[0]);
                        bool result = BassWasapi.BASS_WASAPI_Init(devindex, 0, 0, BASSWASAPIInit.BASS_WASAPI_BUFFER, 1f, 0.05f, _process, IntPtr.Zero);
                        if (!result)
                        {
                            var error = Bass.BASS_ErrorGetCode();
                            MessageBox.Show(error.ToString());
                        }
                        else
                        {
                            _initialized = true;
                            _devicelist.Enabled = false;
                        }
                    }
                    BassWasapi.BASS_WASAPI_Start();
                }
                else BassWasapi.BASS_WASAPI_Stop(true);
                System.Threading.Thread.Sleep(500); //a enlever ??
                _t.IsEnabled = value;
            }
        }


        // initialization
        private void Init()
        {
            bool result = false;
            for (int i = 0; i < BassWasapi.BASS_WASAPI_GetDeviceCount(); i++)
            {
                var device = BassWasapi.BASS_WASAPI_GetDeviceInfo(i);
                if (device.IsEnabled && device.IsLoopback)
                {
                    _devicelist.Items.Add(string.Format("{0} - {1}", i, device.name));
                }
            }
            _devicelist.SelectedIndex = 0;
            Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_UPDATETHREADS, false);
            result = Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            if (!result) throw new Exception("Init Error");
        }

        private float GetSoundLevel()
        {
            MMDeviceEnumerator devEnum = new MMDeviceEnumerator();
            MMDevice defaultDevice = devEnum.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            return defaultDevice.AudioEndpointVolume.MasterVolumeLevelScalar;
        }

        //timer 
        private void _t_Tick(object sender, EventArgs e)
        {
            int ret = BassWasapi.BASS_WASAPI_GetData(_fft, (int)BASSData.BASS_DATA_FFT8192);  //get ch.annel fft data
            if (ret < -1) return;
            int x, y;
            int b0 = 0;

            var enumerator = new MMDeviceEnumerator();
            var device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            int level = BassWasapi.BASS_WASAPI_GetLevel();
            //computes the spectrum data, the code is taken from a bass_wasapi sample.
            for (x = 0; x < _lines; x++)
            {
                float peak = 0;
                int b1 = (int)Math.Pow(2, x * 10.0 / (_lines - 1));
                if (b1 > 1023) b1 = 1023;
                if (b1 <= b0) b1 = b0 + 1;
                for (; b0 < b1; b0++)
                {
                    if (peak < _fft[1 + b0]) peak = _fft[1 + b0];
                }
                y = (int)(Math.Sqrt(peak) * 3 * 255 - 4);
                if (y > 255) y = 255;
                if (y < 0) y = 0;
                y *= (int)(Math.Exp((int)GetSoundLevel()));
                _spectrumdata.Add((byte)y);
            }

            if (DisplayEnable) _spectrum.Set(_spectrumdata);
            for (int i = 0; i < _spectrumdata.ToArray().Length; i++)
            {
                if (i == 18)
                {
                    if(parent.GetType() == typeof(Form1))
                    {
                        Fractal fractal = new Fractal(((Form1)parent).GetFractalDisplayPanel());
                        fractal.generateFractal(192, 1, 3*((int)GetAverage(0, 20)), 10);
                        //((Form1)parent).generateFractal();
                    }
                    if (parent.GetType() == typeof(ShockWavePLayer) && (int)GetAverage(0, 20) > 30)
                    {
                        ((ShockWavePLayer)parent).playVideo();
                    }
                }
                try
                {
                    _chart.Series["wave"].Points.Add(_spectrumdata[i]);
                }
                catch (Exception)
                {

                }
                try
                {
                    _chart.Series["wave"].Points.RemoveAt(0);
                }
                catch (Exception)
                {
                }

            }
            _spectrumdata.Clear();

            // on affiche le niveau de chaque côtés
            _l.Value = (Utils.LowWord32(level));
            _r.Value = (Utils.HighWord32(level));
            if (level == _lastlevel && level != 0) _hanctr++;
            _lastlevel = level;

            //Required, because some programs hang the output. If the output hangs for a 75ms
            //this piece of code re initializes the output so it doesn't make a gliched sound for long.
            if (_hanctr > 3)
            {
                _hanctr = 0;
                _l.Value = (0);
                _r.Value = (0);
                Free();
                Bass.BASS_Init(0, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
                _initialized = false;
                Enable = true;
            }

        }

        private float GetAverage(int start, int stop)
        {
            float average = 0;
            for (int i = start; i < stop; i++)
                average += _spectrumdata[i];
            return average/(stop-start);
        }

        // WASAPI callback, required for continuous recording
        private int Process(IntPtr buffer, int length, IntPtr user)
        {
            return length;
        }

        public void setParent(Form parent)
        {
            this.parent = parent;
        }

        //cleanup
        public void Free()
        {
            BassWasapi.BASS_WASAPI_Free();
            Bass.BASS_Free();
        }
    }
}
