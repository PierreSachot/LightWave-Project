using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX.AudioVideoPlayback;

namespace Audio_Spectrum_Analyzer
{
    /// <summary>
    /// Form principal gérant l'ensemble de l'affichage
    /// </summary>
    public partial class MainForm : Form
    {
        private int currentMenu;
        public IEffect CurrentEffect { get; set; }
        private Analyzer analyzer;
        private Size formSize, panelSize;
        public const int MAIN_MENU = 0, FRACTAL_MENU = 1, SHOCKWAVE_MENU = 2, CIRCLE_MENU = 3;
        private bool isInFullScreen;

        /// <summary>
        /// Permet de réagir lors d'un clique sur le bouton "Retour"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRetour_Click(object sender, EventArgs e)
        {
            ChangeEffect(MAIN_MENU);
        }

        /// <summary>
        /// Permet de réagir au clique du bouton "Plein écran"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFullScreen_Click(object sender, EventArgs e)
        {
            setInFullScreen();
            isInFullScreen = true;
        }

        /// <summary>
        /// Permet de mettre le panelEffect en plein écran
        /// </summary>
        private void setInFullScreen()
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            panelEffect.Size = Screen.PrimaryScreen.Bounds.Size;
            panelNavigation.Hide();
        }

        /// <summary>
        /// Permet de sortir du plein écran lors d'un clique sur la touche "Echap"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (isInFullScreen)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    //exit full screen when escape is pressed
                    FormBorderStyle = FormBorderStyle.Sizable;
                    WindowState = FormWindowState.Normal;
                    this.Size = formSize;
                    this.BackColor = Color.White;
                    isInFullScreen = false;
                    panelNavigation.Show();
                    panelEffect.Size = mainPanel.Size;
                }
            }
        }

        /// <summary>
        /// Permet de passer à l'affichage de l'effet cercle.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCircle_Click(object sender, EventArgs e)
        {
            ChangeEffect(CIRCLE_MENU);
        }

        /// <summary>
        /// Permet de passer à l'affichage de l'effet fractale.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFractale_Click(object sender, EventArgs e)
        {
            ChangeEffect(FRACTAL_MENU);
        }

        /// <summary>
        /// Permet de passer à l'affichage de l'effet shockwave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonShockwave_Click(object sender, EventArgs e)
        {
            ChangeEffect(SHOCKWAVE_MENU);
        }

        /// <summary>
        /// Permet de set le panel comme propriétaire de la vidéo passée en entrée
        /// </summary>
        /// <param name="v">Vidéo à afficher sur le panel</param>
        public void SetVideoOwner(Video v)
        {
            if(v != null)
            {
                v.Owner = panelEffect;
                Point pt = panelNavigation.PointToScreen(new Point(0, 0));
                panelNavigation.Parent = this;
                panelNavigation.Location = this.PointToClient(pt);
                panelNavigation.BringToFront();
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            mainPanel.MaximumSize = formSize;
            currentMenu = 0;
            mainPanel.Dock = DockStyle.Fill;
            panelEffect.Dock = DockStyle.Fill;
            panelNavigation.Dock = DockStyle.Top;
            analyzer = new Analyzer(this);
            timer1.Enabled = false;
            analyzer.Enable = false;
            analyzer.DisplayEnable = false;
            formSize = new Size(this.Width, this.Height);
            panelSize = new Size(mainPanel.Width, mainPanel.Height);
            timer1.Enabled = true;
            panelEffect.Hide();
            this.SizeChanged += new EventHandler(delegate (Object o, EventArgs a)
            {
                RefreshPanelSize();
            });
        }

        private void RefreshPanelSize()
        {
            panelEffect.Refresh();
            Pen myPen = new Pen(Color.Blue);
            Point point = new Point(panelEffect.Size.Height, panelEffect.Size.Width);
            Point[] points =
            {
                new Point(panelEffect.Size.Width-100, panelEffect.Size.Height-100),
                 new Point(panelEffect.Size.Width, panelEffect.Size.Height),
            };
            panelEffect.CreateGraphics().DrawLines(myPen, points);
        }

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Permet de changer l'affichage de la form
        /// </summary>
        /// <param name="menuNb">Numéro du menu à charger</param>
        public void ChangeEffect(int menuNb)
        {
            switch(menuNb)
            {
                case MAIN_MENU:
                    analyzer.DisplayEnable = false;
                    analyzer.Enable = false;
                    timer1.Enabled = false;
                    panelEffect.Hide();
                    this.BackColor = Color.White;
                    break;
                case FRACTAL_MENU:
                    CurrentEffect = Fractal.FractalFactory(panelEffect);
                    timer1.Enabled = true;
                    analyzer.DisplayEnable = true;
                    analyzer.Enable = true;
                    panelEffect.Show();
                    break;
                case SHOCKWAVE_MENU:
                    CurrentEffect = Shockwave.ShockwaveFactory(this, timer2);
                    timer1.Enabled = true;
                    analyzer.DisplayEnable = true;
                    analyzer.Enable = true;
                    panelEffect.Show();
                    break;
                case CIRCLE_MENU:
                    CurrentEffect = Circle.CircleFactory(panelEffect);
                    timer1.Enabled = true;
                    analyzer.DisplayEnable = true;
                    analyzer.Enable = true;
                    panelEffect.Show();
                    break;
            }
            currentMenu = menuNb;
        }

        /// <summary>
        /// Permet de générer un effet
        /// </summary>
        /// <param name="size">taille à envoyer</param>
        public void GenerateEffect(int size)
        {
            if(CurrentEffect != null)
                CurrentEffect.GenerateEffect(size);
        }
    }
}
