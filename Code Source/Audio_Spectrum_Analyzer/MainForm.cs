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
    public partial class MainForm : Form
    {
        private int currentMenu;
        public IEffect CurrentEffect { get; set; }
        private Analyzer analyzer;
        private Size formSize, panelSize;
        public const int MAIN_MENU = 0, FRACTAL_MENU = 1, SHOCKWAVE_MENU = 2, CIRCLE_MENU = 3;
        private bool isInFullScreen;

        private void buttonRetour_Click(object sender, EventArgs e)
        {
            ChangeEffect(MAIN_MENU);
        }
        private void buttonFullScreen_Click(object sender, EventArgs e)
        {
            setInFullScreen();
            isInFullScreen = true;
        }
        private void setInFullScreen()
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            panelEffect.Size = Screen.PrimaryScreen.Bounds.Size;
            panelNavigation.Hide();
        }

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

        private void buttonCircle_Click(object sender, EventArgs e)
        {
            ChangeEffect(CIRCLE_MENU);
        }

        private void buttonFractale_Click(object sender, EventArgs e)
        {
            ChangeEffect(FRACTAL_MENU);
        }

        private void buttonShockwave_Click(object sender, EventArgs e)
        {
            ChangeEffect(SHOCKWAVE_MENU);
        }

        public void SetVideoOwner(Video v)
        {
            if(v != null)
                v.Owner = panelEffect;
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
        }

        public MainForm()
        {
            InitializeComponent();
        }

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
                    CurrentEffect = new TransitShockwave(this, panelEffect, timer2);
                    timer1.Enabled = true;
                    analyzer.DisplayEnable = true;
                    analyzer.Enable = true;
                    panelEffect.Show();
                    break;
                case CIRCLE_MENU:
                    CurrentEffect = Circle.FractalFactory(panelEffect);
                    timer1.Enabled = true;
                    analyzer.DisplayEnable = true;
                    analyzer.Enable = true;
                    panelEffect.Show();
                    break;
            }
            currentMenu = menuNb;
        }

        public void GenerateEffect(int size)
        {
            if(CurrentEffect != null)
                CurrentEffect.GenerateEffect(size);
        }
    }
}
