using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Audio_Spectrum_Analyzer
{
    class Fractal : IEffect
    {
        //fractal elements
        private Pen myPen;
        private Panel myPanel;
        private Graphics fractalGraphics = null;
        private bool isRainbow;
        private int nbColors;
        private int drawnLinesNb;
        private static Fractal singleton;

        private int angle, changeAngle, length, changeLength, numberOfLines, increment;

        private Fractal(Panel myPanel)
        {
            this.myPen = new Pen(Color.Black);
            this.myPanel = myPanel;
            this.myPanel.BackColor = Color.Black;
            isRainbow = false;
        }

        public static Fractal FractalFactory(Panel myPanel)
        {
            if (singleton == null)
                singleton = new Fractal(myPanel);
            return singleton;
        }

        public void generateFractal(int fractalAngle, int fractalIncrement, int fractalNumberOfLines, int fractalLength)
        {
            angle = fractalAngle;
            changeAngle = angle;
            length = fractalLength;
            changeLength = length;
            numberOfLines = fractalNumberOfLines;
            increment = fractalIncrement;
            myPen.Width = 3;
            fractalGraphics = myPanel.CreateGraphics();
            int startX = myPanel.Width / 2;
            int startY = myPanel.Height / 2;
            nbColors = fractalNumberOfLines;
            for (int i = 0; i < numberOfLines; i++)
            {
                myPen.Color = generateColor(i);
                drawnLinesNb++;
                drawLine(ref changeAngle, angle, increment, ref changeLength, length, ref startX, ref startY);
            }
            Thread.Sleep(60);
            myPanel.Refresh();
        }

        private int GetDrawnLinesNb()
        {
            return drawnLinesNb;
        }
        private void drawLine(ref int fractalAngleToChange, int fractalAngle, int fractalIncrement, ref int fractalLengthToChange, int fractalLength, ref int startX, ref int startY)
        {
            myPanel.SuspendLayout();
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

            myPanel.ResumeLayout();
        }

        private Color generateColor(int i)
        {
            return Color.FromArgb(255, i * 255 / nbColors, 0);
        }

        public void GenerateEffect(int size)
        {
            generateFractal(192, 1, size, 10);
        }
    }
}
