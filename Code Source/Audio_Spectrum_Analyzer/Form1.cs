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
       
        /*private Fractal fractal;
        private MainForm parentForm;
        private Size formSize;
        private Size panelSize;

        public Form1(MainForm parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            analyzer = new Analyzer(this, progressBar1, progressBar2, spectrum1, comboBox1, chart1);
            //analyzer = new Analyzer(this, 9);
            analyzer.Enable = true;
            analyzer.DisplayEnable = true;
            formSize = new Size(this.Width, this.Height);
            panelSize = new Size(GetFractalDisplayPanel().Width, GetFractalDisplayPanel().Height);
            fractal = new Fractal(GetFractalDisplayPanel());
            timer1.Enabled = true;
            this.KeyPreview = true;
        }
        public Form1(MainForm parentForm, Analyzer analyzer)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            this.analyzer = analyzer;*/
            /*analyzer.Enable = true;
            analyzer.DisplayEnable = true;*/
            
            /*fractal = new Fractal(GetFractalDisplayPanel());
            timer1.Enabled = true;
        }

        public Analyzer GetAnalyzer()
        {
            return analyzer;
        }

        public void generateFractal()
        {
            fractal.generateFractal(int.Parse(angleTextBox.Text), int.Parse(incrementTextBox.Text), int.Parse(linesTextBox.Text), int.Parse(lengthTextBox.Text));
        }

        public Panel GetFractalDisplayPanel()
        {
            return fractalDisplayPanel;
        }


        private void goButton_Click_1(object sender, EventArgs e)
        {
            generateFractal();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            parentForm.ChangeForm(1);
        }

        private void btnFullscreen_Click(object sender, EventArgs e)
        {
            setInFullScreen();
        }

        private void setInFullScreen()
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            audioPanel.Hide();
            fractalOptionPanel.Hide();
        }
        private void form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                //exit full screen when escape is pressed
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
                audioPanel.Show();
                fractalOptionPanel.Show();
            }
        }*/
    }
}
