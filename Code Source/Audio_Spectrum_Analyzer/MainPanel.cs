using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Audio_Spectrum_Analyzer
{
    class MainPanel : Panel
    {
        private Label Affichage;

        private Button fractalButton;
        private MainForm Parent { get; set; }

        public MainPanel(MainForm parent) : base()
        {
            Parent = parent;
            this.BackColor = Color.Blue;
            this.Size = parent.Size;
            this.AutoSize = true;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "mainPanel";
            this.Size = new System.Drawing.Size(898, 449);
            this.TabIndex = 0;



        }

        private void InitializeComponent()
        {
            this.fractalButton = new System.Windows.Forms.Button();
            this.Affichage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fractalButton
            // 
            this.fractalButton.Location = new System.Drawing.Point(0, 0);
            this.fractalButton.Name = "fractalButton";
            this.fractalButton.Size = new System.Drawing.Size(75, 23);
            this.fractalButton.TabIndex = 0;
            this.fractalButton.Text = "Affichage fractal";
            this.fractalButton.UseVisualStyleBackColor = true;
            this.fractalButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Affichage
            // 
            this.Affichage.AutoSize = true;
            this.Affichage.Location = new System.Drawing.Point(0, 0);
            this.Affichage.Name = "Affichage";
            this.Affichage.Size = new System.Drawing.Size(100, 23);
            this.Affichage.TabIndex = 0;
            this.Affichage.Text = "label1";
            this.ResumeLayout(false);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Parent.ChangeEffect(MainForm.FRACTAL_MENU);
        }
    }
}
