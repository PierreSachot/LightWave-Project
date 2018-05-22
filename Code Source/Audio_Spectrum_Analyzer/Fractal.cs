using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Audio_Spectrum_Analyzer
{
    /// <summary>
    /// Classe permettant de générer un effet de fractal avec les basses de la musique en cours de lecture.
    /// </summary>
    class Fractal : IEffect
    {
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

        /// <summary>
        /// Permet de générer une instance unique de la fractal.
        /// </summary>
        /// <param name="myPanel">Panel sur lequel afficher la fractal</param>
        /// <returns>retourne l'instance de la Fractal</returns>
        public static Fractal FractalFactory(Panel myPanel)
        {
            if (singleton == null)
                singleton = new Fractal(myPanel);
            return singleton;
        }

        /// <summary>
        /// Permet de générer une fractal et de l'afficher sur le panel de la mainform.
        /// </summary>
        /// <param name="_angle">Angle de la fractal</param>
        /// <param name="_increment">Taille a incrémenter à chaque lignes</param>
        /// <param name="_numberOfLines">Nombre de lignes à générer</param>
        /// <param name="_length">Longueur initial de la fractal</param>
        public void GenerateFractal(int _angle, int _increment, int _numberOfLines, int _length)
        {
            angle = _angle;
            changeAngle = angle;
            length = _length;
            changeLength = length;
            numberOfLines = _numberOfLines;
            increment = _increment;
            myPen.Width = 3;
            fractalGraphics = myPanel.CreateGraphics();
            int startX = myPanel.Width / 2;
            int startY = myPanel.Height / 2;
            nbColors = _numberOfLines;
            for (int i = 0; i < numberOfLines; i++)
            {
                myPen.Color = generateColor(i);
                drawnLinesNb++;
                drawLine(ref changeAngle, angle, increment, ref changeLength, length, ref startX, ref startY);
            }
            Thread.Sleep(60);
            myPanel.Refresh();
        }
        
        /// <summary>
        /// Permet de tracer une ligne à l'écran
        /// </summary>
        /// <param name="_angleToChange">angle à modifier</param>
        /// <param name="_angle">angle initial</param>
        /// <param name="_increment">incrément à appliquer</param>
        /// <param name="_lengthToChange">longueur à changer</param>
        /// <param name="_length">longueur</param>
        /// <param name="startX">position en X</param>
        /// <param name="startY">position en Y</param>
        private void drawLine(ref int _angleToChange, int _angle, int _increment, ref int _lengthToChange, int _length, ref int startX, ref int startY)
        {
            myPanel.SuspendLayout();
            if (isRainbow)
            {
                Random alea = new Random();
                myPen.Color = Color.FromArgb(alea.Next(255), alea.Next(255), alea.Next(255));
            }
            _angleToChange += _angle;
            _lengthToChange += _length;

            int endX = (int)(startX + Math.Cos(_angleToChange * .017453292519) * _lengthToChange);
            int endY = (int)(startY + Math.Sin(_angleToChange * .017453292519) * _lengthToChange);

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

        /// <summary>
        /// Permet de générer un dégradé de couleur en fonction du paramètre index.
        /// </summary>
        /// <param name="index">index actuel de l'affichage</param>
        /// <returns>Couleur générée</returns>
        private Color generateColor(int index)
        {
            return Color.FromArgb(255, index * 255 / nbColors, 0);
        }

        /// <summary>
        /// Implémentation de l'interface, génère une fractal en fonction de la musique.
        /// </summary>
        /// <param name="size">Taille de la fractal à générer</param>
        public void GenerateEffect(int size)
        {
            GenerateFractal(192, 1, size, 10);
        }
    }
}
