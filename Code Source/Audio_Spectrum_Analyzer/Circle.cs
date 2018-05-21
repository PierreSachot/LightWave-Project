using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Audio_Spectrum_Analyzer
{
    class Circle : IEffect
    {
        //fractal elements
        private Pen myPen;
        private Panel myPanel;
        private Graphics graphics = null;
        private bool isRainbow;
        private int nbColors;
        private static Circle singleton;
        private int increment, startSize, nbDrawnLines;
        private Image img;
        private const int INCREMENT_SIZE = 200;

        private Circle(Panel myPanel)
        {
            this.myPen = new Pen(Color.White);
            this.myPanel = myPanel;
            this.myPanel.BackColor = Color.Black;
            this.myPen.Width = 1;
            graphics = myPanel.CreateGraphics();
            isRainbow = false;
            startSize = 100;
            nbDrawnLines = 0;
            FileStream fs = new FileStream(@"E:\ENSC\S6\TransDisciplinaire\LightWave-Project\Logo\logo2.png", FileMode.Open);
            img = Image.FromStream(fs);
            fs.Close();
            myPen.Color = Color.White;
            Rectangle rect = new Rectangle(myPanel.Width / 2 - 50, myPanel.Height / 2 - 50, startSize, startSize);
            graphics.DrawEllipse(myPen, rect);
            graphics.DrawImage(img, rect);
            increment = INCREMENT_SIZE;
        }

        public static Circle FractalFactory(Panel myPanel)
        {
            if (singleton == null)
                singleton = new Circle(myPanel);
            return singleton;
        }

        public void GenerateCircle(int size)
        {
            int i = 1;
            if(size > nbDrawnLines)
            {
                i = nbDrawnLines;
            }
            myPanel.SuspendLayout();
            graphics = myPanel.CreateGraphics();
            if(nbDrawnLines !=size && size > 2)
            {
                nbDrawnLines = nbColors = size;
                myPen.Width = 3;
                for (i = i; i < size % 10; i++)
                {
                    myPen = new Pen(GenerateColor(i), 5 * i);
                    // Create rectangle for circle.
                    increment += i * 5;
                    Rectangle rect = new Rectangle((myPanel.Width / 2) - (increment / 2), (myPanel.Height / 2) - (increment / 2), increment, increment);
                    // Draw circle.
                    graphics.DrawEllipse(myPen, rect);
                }
                Thread.Sleep(20);
            }   
            else
            {
                myPanel.Refresh();
                myPen.Color = Color.White;
                Rectangle rect = new Rectangle(myPanel.Width / 2 - 50, myPanel.Height / 2 - 50, startSize, startSize);
                myPen.Width = 10;
                graphics.DrawEllipse(myPen, rect);
                //graphics.DrawImage(img, rect);
                increment = INCREMENT_SIZE;
            }
            myPanel.ResumeLayout();
        }

        private Color GenerateColor(int i)
        {
            return Color.FromArgb(255, i * 255 / nbColors, 0);
        }

        public void GenerateEffect(int size)
        {
            if(size>5)
             GenerateCircle(size);
        }
    }
}
