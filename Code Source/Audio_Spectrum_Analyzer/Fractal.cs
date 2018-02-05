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
        private Panel monPanel;
        private Graphics fractalGraphics = null;
        private int startX, startY, endX, endY, numberOfLines, angle = 0, length = 0, increment = 0;
        private bool isRainbow;

        public Fractal(Panel monPanel, int length, int angle, int increment, int numberOfLines, bool isRainbow, int startX, int startY)
        {
            this.myPen = new Pen(Color.Black);
            this.monPanel = monPanel;
            this.numberOfLines = numberOfLines;
            this.angle = angle;
            this.length = length;
            this.increment = increment;
            this.isRainbow = isRainbow;
            this.startX = startX;
            this.startY = startY;
        }

        public void drawFractal()
        {
            myPen.Width = 1;
            fractalGraphics = monPanel.CreateGraphics();
            for (int i = 0; i < numberOfLines; i++)
                drawLine();
        }

        private void drawLine()
        {
            if (isRainbow)
            {
                Random alea = new Random();
                myPen.Color = Color.FromArgb(alea.Next(255), alea.Next(255), alea.Next(255));
            }
            angle += angle;
            length += increment;

            endX = (int)(startX + Math.Cos(angle * .017453292519) * length);
            endY = (int)(startY + Math.Sin(angle * .017453292519) * length);

            Point[] points = 
            {
                new Point(startX, startY),
                new Point(endX, endY)
            };

            startX = endX;
            startY = endY;
            fractalGraphics.DrawLines(myPen, points);
        }
    }
}
