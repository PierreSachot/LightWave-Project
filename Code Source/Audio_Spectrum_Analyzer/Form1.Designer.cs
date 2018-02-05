namespace Audio_Spectrum_Analyzer
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.goButton = new System.Windows.Forms.Button();
            this.incrementTextBox = new System.Windows.Forms.TextBox();
            this.lengthTextBox = new System.Windows.Forms.TextBox();
            this.angleTextBox = new System.Windows.Forms.TextBox();
            this.linesTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fractalDisplayPanel = new System.Windows.Forms.Panel();
            this.fractalOptionPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.fractalPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.audioPanel = new System.Windows.Forms.Panel();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.spectrum1 = new Audio_Spectrum_Analyzer.Spectrum();
            this.label2 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.fractalOptionPanel.SuspendLayout();
            this.fractalPanel.SuspendLayout();
            this.audioPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(763, 9);
            this.goButton.Margin = new System.Windows.Forms.Padding(4);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(100, 28);
            this.goButton.TabIndex = 8;
            this.goButton.Text = "Go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click_1);
            // 
            // incrementTextBox
            // 
            this.incrementTextBox.Location = new System.Drawing.Point(665, 11);
            this.incrementTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.incrementTextBox.Name = "incrementTextBox";
            this.incrementTextBox.Size = new System.Drawing.Size(56, 22);
            this.incrementTextBox.TabIndex = 7;
            this.incrementTextBox.Text = "1";
            this.incrementTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lengthTextBox
            // 
            this.lengthTextBox.Location = new System.Drawing.Point(471, 11);
            this.lengthTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.lengthTextBox.Name = "lengthTextBox";
            this.lengthTextBox.Size = new System.Drawing.Size(56, 22);
            this.lengthTextBox.TabIndex = 6;
            this.lengthTextBox.Text = "50";
            this.lengthTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // angleTextBox
            // 
            this.angleTextBox.Location = new System.Drawing.Point(272, 11);
            this.angleTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.angleTextBox.Name = "angleTextBox";
            this.angleTextBox.Size = new System.Drawing.Size(56, 22);
            this.angleTextBox.TabIndex = 5;
            this.angleTextBox.Text = "96";
            this.angleTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // linesTextBox
            // 
            this.linesTextBox.Location = new System.Drawing.Point(111, 11);
            this.linesTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.linesTextBox.Name = "linesTextBox";
            this.linesTextBox.Size = new System.Drawing.Size(56, 22);
            this.linesTextBox.TabIndex = 4;
            this.linesTextBox.Text = "100";
            this.linesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(557, 12);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Increment";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(391, 12);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Length";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(27, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "# Lines";
            // 
            // fractalDisplayPanel
            // 
            this.fractalDisplayPanel.BackColor = System.Drawing.SystemColors.Window;
            this.fractalDisplayPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fractalDisplayPanel.Location = new System.Drawing.Point(0, 46);
            this.fractalDisplayPanel.Margin = new System.Windows.Forms.Padding(4);
            this.fractalDisplayPanel.Name = "fractalDisplayPanel";
            this.fractalDisplayPanel.Size = new System.Drawing.Size(884, 476);
            this.fractalDisplayPanel.TabIndex = 1;
            // 
            // fractalOptionPanel
            // 
            this.fractalOptionPanel.BackColor = System.Drawing.SystemColors.MenuBar;
            this.fractalOptionPanel.Controls.Add(this.goButton);
            this.fractalOptionPanel.Controls.Add(this.incrementTextBox);
            this.fractalOptionPanel.Controls.Add(this.lengthTextBox);
            this.fractalOptionPanel.Controls.Add(this.angleTextBox);
            this.fractalOptionPanel.Controls.Add(this.linesTextBox);
            this.fractalOptionPanel.Controls.Add(this.label6);
            this.fractalOptionPanel.Controls.Add(this.label5);
            this.fractalOptionPanel.Controls.Add(this.label4);
            this.fractalOptionPanel.Controls.Add(this.label3);
            this.fractalOptionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.fractalOptionPanel.Location = new System.Drawing.Point(0, 0);
            this.fractalOptionPanel.Margin = new System.Windows.Forms.Padding(4);
            this.fractalOptionPanel.Name = "fractalOptionPanel";
            this.fractalOptionPanel.Size = new System.Drawing.Size(884, 46);
            this.fractalOptionPanel.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(200, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Angle";
            // 
            // fractalPanel
            // 
            this.fractalPanel.Controls.Add(this.fractalDisplayPanel);
            this.fractalPanel.Controls.Add(this.fractalOptionPanel);
            this.fractalPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fractalPanel.Location = new System.Drawing.Point(799, 0);
            this.fractalPanel.Margin = new System.Windows.Forms.Padding(4);
            this.fractalPanel.Name = "fractalPanel";
            this.fractalPanel.Size = new System.Drawing.Size(884, 522);
            this.fractalPanel.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(582, 486);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 32);
            this.button1.TabIndex = 7;
            this.button1.Text = "GoToShockWavePlayer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // audioPanel
            // 
            this.audioPanel.Controls.Add(this.button1);
            this.audioPanel.Controls.Add(this.elementHost1);
            this.audioPanel.Controls.Add(this.label2);
            this.audioPanel.Controls.Add(this.chart1);
            this.audioPanel.Controls.Add(this.progressBar1);
            this.audioPanel.Controls.Add(this.comboBox1);
            this.audioPanel.Controls.Add(this.progressBar2);
            this.audioPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.audioPanel.Location = new System.Drawing.Point(0, 0);
            this.audioPanel.Margin = new System.Windows.Forms.Padding(4);
            this.audioPanel.Name = "audioPanel";
            this.audioPanel.Size = new System.Drawing.Size(799, 522);
            this.audioPanel.TabIndex = 10;
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(39, 25);
            this.elementHost1.Margin = new System.Windows.Forms.Padding(4);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(720, 177);
            this.elementHost1.TabIndex = 6;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.spectrum1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 236);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "R";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(36, 279);
            this.chart1.Margin = new System.Windows.Forms.Padding(4);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(723, 185);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(61, 236);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(169, 18);
            this.progressBar1.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(459, 231);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(299, 24);
            this.comboBox1.TabIndex = 4;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(267, 236);
            this.progressBar2.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(169, 18);
            this.progressBar2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 247);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "L";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1683, 522);
            this.Controls.Add(this.fractalPanel);
            this.Controls.Add(this.audioPanel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LightWave";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.fractalOptionPanel.ResumeLayout(false);
            this.fractalOptionPanel.PerformLayout();
            this.fractalPanel.ResumeLayout(false);
            this.audioPanel.ResumeLayout(false);
            this.audioPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.TextBox incrementTextBox;
        private System.Windows.Forms.TextBox lengthTextBox;
        private System.Windows.Forms.TextBox angleTextBox;
        private System.Windows.Forms.TextBox linesTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel fractalDisplayPanel;
        private System.Windows.Forms.Panel fractalOptionPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel fractalPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private Spectrum spectrum1;
        private System.Windows.Forms.Panel audioPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;

    }
}

