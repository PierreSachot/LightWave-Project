using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Audio_Spectrum_Analyzer
{
    public partial class MainForm : Form
    {
        private int currentMenu;
        public Effect CurrentEffect { get; set; }
        private Analyzer analyzer;
        private Size formSize, panelSize;
        public const int MAIN_MENU = 0, FRACTAL_MENU = 1, SHOCKWAVE_MENU = 2, CIRCLE_MENU = 3; 

        public MainForm()
        {
            InitializeComponent();
            mainPanel.MaximumSize = formSize;

            currentMenu = 0;
            analyzer = new Analyzer(this);
            CurrentEffect = Fractal.FractalFactory(mainPanel);
            timer1.Enabled = true;
            analyzer.Enable = true;
            analyzer.DisplayEnable = true;
            formSize = new Size(this.Width, this.Height);
            panelSize = new Size(mainPanel.Width, mainPanel.Height);
            timer1.Enabled = true;
            //ChangeEffect(SHOCKWAVE_MENU);
            ChangeEffect(CIRCLE_MENU);
        }

        public void ChangeEffect(int menuNb)
        {
            analyzer.Enable = false;
            timer1.Enabled = false;
            switch(menuNb)
            {
                case MAIN_MENU:
                    break;
                case FRACTAL_MENU:
                    CurrentEffect = Fractal.FractalFactory(mainPanel);
                    break;
                case SHOCKWAVE_MENU:
                    CurrentEffect = new TransitShockwave(mainPanel, timer2);
                    break;
                case CIRCLE_MENU:
                    CurrentEffect = Circle.FractalFactory(mainPanel);
                    break;
                default:
                    analyzer.Enable = true;
                    timer1.Enabled = true;
                    return;
            }
            analyzer.Enable = true;
            timer1.Enabled = true;
            currentMenu = menuNb;
        }

        public void GenerateEffect(int size)
        {
            CurrentEffect.GenerateEffect(size);
        }
    }
}
