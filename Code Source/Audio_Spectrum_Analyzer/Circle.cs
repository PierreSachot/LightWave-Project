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
    /// <summary>
    /// Classe permettant de générer un effet de cercle avec les basses de la musique en cours de lecture.
    /// </summary>
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

        /// <summary>
        /// Permet de générer une instance unique de cercle.
        /// </summary>
        /// <param name="myPanel">Panel sur lequel afficher le cercle</param>
        /// <returns>retourne l'instance du cercle</returns>
        public static Circle CircleFactory(Panel myPanel)
        {
            if (singleton == null)
                singleton = new Circle(myPanel);
            return singleton;
        }

        /// <summary>
        /// Permet de générer un cercle d'une taille entrée
        /// </summary>
        /// <param name="size">Taille du cercle à générer</param>
        public void GenerateCircle(int size)
        {
            int i = 1;
            if(size > nbDrawnLines)
            {
                i = nbDrawnLines;
            }
            myPanel.SuspendLayout();
            graphics = myPanel.CreateGraphics();
            myPanel.Refresh();
            myPen.Color = Color.White;
            Rectangle rect = new Rectangle(myPanel.Width / 2 - 50, myPanel.Height / 2 - 50, startSize, startSize);
            myPen.Width = 10;
            graphics.DrawEllipse(myPen, rect);
            graphics.DrawImage(img, rect);
            if (nbDrawnLines !=size && size > 2)
            {
                nbColors = size % 10;
                nbDrawnLines = size;
                for (i = 0; i < size % 10; i++)
                {
                    myPen.Width = i*3;
                    myPen = new Pen(GenerateColor(i), i);
                    // Create rectangle for circle.
                    increment += i * 5;
                    Rectangle rect2 = new Rectangle((myPanel.Width / 2) - (increment / 2), (myPanel.Height / 2) - (increment / 2), increment, increment);
                    // Draw circle.
                    graphics.DrawEllipse(myPen, rect2);
                }
                Thread.Sleep(20);
            }   
            else
            {
                //graphics.DrawImage(img, rect);
                increment = INCREMENT_SIZE;
            }
            myPanel.ResumeLayout();
        }

        /// <summary>
        /// Permet de générer un dégradé de couleur en fonction du paramètre index.
        /// </summary>
        /// <param name="index">index actuel de l'affichage</param>
        /// <returns>Couleur générée</returns>
        private Color GenerateColor(int i)
        {
            return Color.FromArgb(255, i * 255 / nbColors, 0);
        }

        /// <summary>
        /// Implémentation de l'interface, génère une fractal en fonction de la musique.
        /// </summary>
        /// <param name="size">Taille de la fractal à générer</param>
        public void GenerateEffect(int size)
        {
            if(size>20)
             GenerateCircle(size);
        }
    }
}
