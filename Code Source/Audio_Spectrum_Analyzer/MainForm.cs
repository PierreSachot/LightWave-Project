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
        private Form currentForm;
        private Form1 principalForm;
        private Analyzer analyzer;

        public MainForm()
        {
            InitializeComponent();
            currentMenu = 0;
            currentForm = new Form1(this);
            currentForm.Show();
            /*analyzer = new Analyzer(currentForm, ((Form1)currentForm).GetProgressBar1(), ((Form1)currentForm).GetProgressBar2(), ((Form1)currentForm).GetSpectrum(), ((Form1)currentForm).GetComboBox(), ((Form1)currentForm).GetChart());
            ((Form1)currentForm).SetAnalyzer(analyzer);
            principalForm = (Form1)currentForm;
            principalForm.Show();*/
        }

        public void ChangeForm(int menu)
        {
            currentMenu = menu;
            Form form;
            switch(currentMenu)
            {
                case 0:
                    analyzer.setParent(principalForm);
                    principalForm.Show();
                    currentForm.Hide();
                    currentForm = principalForm;
                    break;
                case 1:
                    form = new ShockWavePLayer(this);
                    currentForm.Hide();
                    analyzer.setParent(form);
                    form.Show();
                    currentForm.Hide();
                    currentForm = form;
                    break;
            }
        }
    }
}
