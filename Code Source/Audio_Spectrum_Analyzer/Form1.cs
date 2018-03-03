using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Un4seen.Bass;
using Un4seen.BassWasapi;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Audio_Spectrum_Analyzer
{
    public partial class Form1 : Form
    {
        private Analyzer analyzer;
        private Fractal fractal;
        private MainForm parentForm;

        public Form1(MainForm parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            analyzer = new Analyzer(this, progressBar1, progressBar2, spectrum1, comboBox1, chart1);
            analyzer.Enable = true;
            analyzer.DisplayEnable = true;
            
            fractal = new Fractal(GetFractalDisplayPanel());
            timer1.Enabled = true;
        }

        public ProgressBar GetProgressBar1()
        {
            return progressBar1;
        }
        public ProgressBar GetProgressBar2()
        {
            return progressBar2;
        }

        public Spectrum GetSpectrum()
        {
            return spectrum1;
        }
        public ComboBox GetComboBox()
        {
            return comboBox1;
        }
        public Chart GetChart()
        {
            return chart1;
        }

        public void SetAnalyzer(Analyzer a)
        {
            analyzer = a;
            analyzer.Enable = true;
            analyzer.DisplayEnable = true;
        }

        public void generateFractal()
        {
            fractal.generateFractal(int.Parse(angleTextBox.Text), int.Parse(incrementTextBox.Text), int.Parse(linesTextBox.Text), int.Parse(lengthTextBox.Text));
        }

        public Panel GetFractalDisplayPanel()
        {
            return fractalDisplayPanel;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void goButton_Click_1(object sender, EventArgs e)
        {
            generateFractal();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            parentForm.ChangeForm(1);
        }
    }
}
