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

namespace Audio_Spectrum_Analyzer
{
    public partial class Form1 : Form
    {
        private Analyzer analyzer;
        private Fractal fractal;

        public Form1()
        {
            InitializeComponent();

            analyzer = new Analyzer(this, progressBar1, progressBar2, spectrum1, comboBox1, chart1);
            fractal = new Fractal(getFractalDisplayPanel());
            analyzer.Enable = true;
            analyzer.DisplayEnable = true;
            timer1.Enabled = true;
        }

        public void generateFractal()
        {
            fractal.generateFractal(int.Parse(angleTextBox.Text), int.Parse(incrementTextBox.Text), int.Parse(linesTextBox.Text), int.Parse(lengthTextBox.Text));
        }

        public Panel getFractalDisplayPanel()
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
            ShockWavePLayer shockwavePlayer = new ShockWavePLayer();
            analyzer.setParent(shockwavePlayer);
            shockwavePlayer.ShowDialog();
            this.Hide();
        }
    }
}
