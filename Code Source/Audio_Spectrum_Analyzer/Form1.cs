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

        //fractal elements
        Pen fractalPen = new Pen(Color.Black);
        Graphics fractalGraphics = null;
        static int fractalStartX, fractalStartY, fractalEndX, fractalEndY, fractalNumberOfLines = 0, fractalAngle = 0, fractalLength = 0, fractalIncrement = 0;
        static bool isRainbow = true;

        public Form1()
        {
            InitializeComponent();
            fractalStartX = fractalPanel.Width / 2;
            fractalStartY = fractalPanel.Height / 2;

            analyzer = new Analyzer(this, progressBar1, progressBar2, spectrum1, comboBox1, chart1);
            analyzer.Enable = true;
            analyzer.DisplayEnable = true;
            timer1.Enabled = true;
        }

        public void generateFractal()
        {
            fractalAngle = int.Parse(angleTextBox.Text);
            fractalIncrement = int.Parse(incrementTextBox.Text);
            fractalNumberOfLines = int.Parse(linesTextBox.Text);
            fractalLength = int.Parse(lengthTextBox.Text);
            fractalPen.Width = 1;
            fractalLength = int.Parse(lengthTextBox.Text);
            fractalGraphics = fractalDisplayPanel.CreateGraphics();
            fractalStartX = fractalPanel.Width / 2;
            fractalStartY = fractalPanel.Height / 2;
            for (int i = 0; i < fractalNumberOfLines; i++)
                drawLine();
            getFractalDisplayPanel().Refresh();
        }

        private void drawLine()
        {
            if (isRainbow)
            {
                Random alea = new Random();
                fractalPen.Color = Color.FromArgb(alea.Next(255), alea.Next(255), alea.Next(255));
            }
            fractalAngle += int.Parse(angleTextBox.Text);
            fractalLength += int.Parse(incrementTextBox.Text);

            fractalEndX = (int)(fractalStartX + Math.Cos(fractalAngle * .017453292519) * fractalLength);
            fractalEndY = (int)(fractalStartY + Math.Sin(fractalAngle * .017453292519) * fractalLength);

            Point[] points = 
            {
                new Point(fractalStartX, fractalStartY),
                new Point(fractalEndX, fractalEndY)
            };

            fractalStartX = fractalEndX;
            fractalStartY = fractalEndY;
            fractalGraphics.DrawLines(fractalPen, points);
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
            shockwavePlayer.ShowDialog();
            this.Hide();
        }
    }
}
