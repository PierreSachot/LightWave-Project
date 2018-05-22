namespace Audio_Spectrum_Analyzer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.mainPanel = new System.Windows.Forms.Panel();
            this.panelEffect = new System.Windows.Forms.Panel();
            this.panelNavigation = new System.Windows.Forms.Panel();
            this.buttonRetour = new System.Windows.Forms.Button();
            this.buttonFullScreen = new System.Windows.Forms.Button();
            this.buttonShockwave = new System.Windows.Forms.Button();
            this.buttonFractale = new System.Windows.Forms.Button();
            this.buttonCircle = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.panelEffect.SuspendLayout();
            this.panelNavigation.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.AutoSize = true;
            this.mainPanel.Controls.Add(this.panelEffect);
            this.mainPanel.Controls.Add(this.buttonShockwave);
            this.mainPanel.Controls.Add(this.buttonFractale);
            this.mainPanel.Controls.Add(this.buttonCircle);
            this.mainPanel.Location = new System.Drawing.Point(4, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1205, 595);
            this.mainPanel.TabIndex = 0;
            // 
            // panelEffect
            // 
            this.panelEffect.AutoSize = true;
            this.panelEffect.Controls.Add(this.panelNavigation);
            this.panelEffect.Location = new System.Drawing.Point(-3, 0);
            this.panelEffect.Margin = new System.Windows.Forms.Padding(4);
            this.panelEffect.Name = "panelEffect";
            this.panelEffect.Size = new System.Drawing.Size(1204, 525);
            this.panelEffect.TabIndex = 1;
            // 
            // panelNavigation
            // 
            this.panelNavigation.Controls.Add(this.buttonRetour);
            this.panelNavigation.Controls.Add(this.buttonFullScreen);
            this.panelNavigation.Location = new System.Drawing.Point(3, 3);
            this.panelNavigation.Name = "panelNavigation";
            this.panelNavigation.Size = new System.Drawing.Size(1186, 54);
            this.panelNavigation.TabIndex = 2;
            // 
            // buttonRetour
            // 
            this.buttonRetour.Location = new System.Drawing.Point(18, 6);
            this.buttonRetour.Name = "buttonRetour";
            this.buttonRetour.Size = new System.Drawing.Size(90, 39);
            this.buttonRetour.TabIndex = 0;
            this.buttonRetour.Text = "Retour";
            this.buttonRetour.UseVisualStyleBackColor = true;
            this.buttonRetour.Click += new System.EventHandler(this.buttonRetour_Click);
            // 
            // buttonFullScreen
            // 
            this.buttonFullScreen.Location = new System.Drawing.Point(1047, 6);
            this.buttonFullScreen.Name = "buttonFullScreen";
            this.buttonFullScreen.Size = new System.Drawing.Size(131, 39);
            this.buttonFullScreen.TabIndex = 1;
            this.buttonFullScreen.Text = "Plein écran";
            this.buttonFullScreen.UseVisualStyleBackColor = true;
            this.buttonFullScreen.Click += new System.EventHandler(this.buttonFullScreen_Click);
            // 
            // buttonShockwave
            // 
            this.buttonShockwave.Location = new System.Drawing.Point(849, 150);
            this.buttonShockwave.Name = "buttonShockwave";
            this.buttonShockwave.Size = new System.Drawing.Size(160, 94);
            this.buttonShockwave.TabIndex = 4;
            this.buttonShockwave.Text = "Shockwaves";
            this.buttonShockwave.UseVisualStyleBackColor = true;
            this.buttonShockwave.Click += new System.EventHandler(this.buttonShockwave_Click);
            // 
            // buttonFractale
            // 
            this.buttonFractale.Location = new System.Drawing.Point(479, 150);
            this.buttonFractale.Name = "buttonFractale";
            this.buttonFractale.Size = new System.Drawing.Size(160, 94);
            this.buttonFractale.TabIndex = 3;
            this.buttonFractale.Text = "Fractales";
            this.buttonFractale.UseVisualStyleBackColor = true;
            this.buttonFractale.Click += new System.EventHandler(this.buttonFractale_Click);
            // 
            // buttonCircle
            // 
            this.buttonCircle.Location = new System.Drawing.Point(151, 150);
            this.buttonCircle.Name = "buttonCircle";
            this.buttonCircle.Size = new System.Drawing.Size(160, 94);
            this.buttonCircle.TabIndex = 2;
            this.buttonCircle.Text = "Cercles";
            this.buttonCircle.UseVisualStyleBackColor = true;
            this.buttonCircle.Click += new System.EventHandler(this.buttonCircle_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 553);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "LightWave";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.panelEffect.ResumeLayout(false);
            this.panelNavigation.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button buttonRetour;
        private System.Windows.Forms.Button buttonFullScreen;
        private System.Windows.Forms.Panel panelEffect;
        private System.Windows.Forms.Button buttonShockwave;
        private System.Windows.Forms.Button buttonFractale;
        private System.Windows.Forms.Button buttonCircle;
        private System.Windows.Forms.Panel panelNavigation;
    }
}