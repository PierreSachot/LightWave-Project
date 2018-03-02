using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Audio_Spectrum_Analyzer
{
    class Fractal
    {
        //fractal elements
        private Pen myPen;
        private Panel myPanel;
        private Graphics fractalGraphics = null;
        private bool isRainbow;
        private int nbColors;

        public Fractal(Panel myPanel)
        {
            this.myPen = new Pen(Color.Black);
            this.myPanel = myPanel;
            this.myPanel.BackColor = Color.Black;
            this.myPen.Width = 1;
            isRainbow = false;
        }

        public void generateFractal(int fractalAngle, int fractalIncrement, int fractalNumberOfLines, int fractalLength)
        {
            int angle = fractalAngle;
            int length = fractalLength;
            int numberOfLines = fractalNumberOfLines;
            myPen.Width = 2;
            fractalGraphics = myPanel.CreateGraphics();
            int startX = myPanel.Width / 2;
            int startY = myPanel.Height / 2;
            nbColors = fractalNumberOfLines;
            for (int i = 0; i < numberOfLines; i++)
            {
                myPen.Color = generateColor(i);
                drawLine(ref angle, fractalAngle, fractalIncrement, ref length, fractalLength, ref startX, ref startY);
            }
            myPanel.Refresh();
        }

        private void drawLine(ref int fractalAngleToChange, int fractalAngle, int fractalIncrement, ref int fractalLengthToChange, int fractalLength, ref int startX, ref int startY)
        {
            if (isRainbow)
            {
                Random alea = new Random();
                myPen.Color = Color.FromArgb(alea.Next(255), alea.Next(255), alea.Next(255));
            }
            fractalAngleToChange += fractalAngle;
            fractalLengthToChange += fractalLength;

            int endX = (int)(startX + Math.Cos(fractalAngleToChange * .017453292519) * fractalLengthToChange);
            int endY = (int)(startY + Math.Sin(fractalAngleToChange * .017453292519) * fractalLengthToChange);

            Point[] points = 
            {
                new Point(startX, startY),
                new Point(endX, endY)
            };

            startX = endX;
            startY = endY;
            fractalGraphics.DrawLines(myPen, points);
        }

        private Color generateColor(int i)
        {
            return Color.FromArgb(255, i * 255 / nbColors, 0);
        }
    }
}
