namespace Audio_Spectrum_Analyzer
{
    partial class ShockWavePLayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShockWavePLayer));
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnVolume = new System.Windows.Forms.Button();
            this.trackVolume = new System.Windows.Forms.TrackBar();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.lblVideoPosition = new System.Windows.Forms.Label();
            this.btnPlayPause = new System.Windows.Forms.Button();
            this.btnFullscreen = new System.Windows.Forms.Button();
            this.lstVideos = new System.Windows.Forms.ListBox();
            this.pnlVideo = new System.Windows.Forms.Panel();
            this.tmrVideo = new System.Windows.Forms.Timer(this.components);
            this.lblVideo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(1167, 556);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(168, 17);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Retour au menu Principal";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnVolume
            // 
            this.btnVolume.Location = new System.Drawing.Point(454, 466);
            this.btnVolume.Margin = new System.Windows.Forms.Padding(4);
            this.btnVolume.Name = "btnVolume";
            this.btnVolume.Size = new System.Drawing.Size(100, 28);
            this.btnVolume.TabIndex = 29;
            this.btnVolume.Text = "Volume";
            this.btnVolume.UseVisualStyleBackColor = true;
            // 
            // trackVolume
            // 
            this.trackVolume.Location = new System.Drawing.Point(562, 466);
            this.trackVolume.Margin = new System.Windows.Forms.Padding(4);
            this.trackVolume.Maximum = 0;
            this.trackVolume.Minimum = -10000;
            this.trackVolume.Name = "trackVolume";
            this.trackVolume.Size = new System.Drawing.Size(204, 56);
            this.trackVolume.TabIndex = 28;
            this.trackVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackVolume.Visible = false;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(238, 466);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 28);
            this.btnNext.TabIndex = 27;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(22, 466);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(100, 28);
            this.btnPrevious.TabIndex = 26;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            // 
            // lblVideoPosition
            // 
            this.lblVideoPosition.AutoSize = true;
            this.lblVideoPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVideoPosition.Location = new System.Drawing.Point(774, 468);
            this.lblVideoPosition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVideoPosition.Name = "lblVideoPosition";
            this.lblVideoPosition.Size = new System.Drawing.Size(152, 20);
            this.lblVideoPosition.TabIndex = 25;
            this.lblVideoPosition.Text = "00:00:00 / 00:00:00";
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.Location = new System.Drawing.Point(130, 466);
            this.btnPlayPause.Margin = new System.Windows.Forms.Padding(4);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.Size = new System.Drawing.Size(100, 28);
            this.btnPlayPause.TabIndex = 24;
            this.btnPlayPause.Text = "Play/Pause";
            this.btnPlayPause.UseVisualStyleBackColor = true;
            // 
            // btnFullscreen
            // 
            this.btnFullscreen.Location = new System.Drawing.Point(346, 466);
            this.btnFullscreen.Margin = new System.Windows.Forms.Padding(4);
            this.btnFullscreen.Name = "btnFullscreen";
            this.btnFullscreen.Size = new System.Drawing.Size(100, 28);
            this.btnFullscreen.TabIndex = 23;
            this.btnFullscreen.Text = "Fullscreen";
            this.btnFullscreen.UseVisualStyleBackColor = true;
            // 
            // lstVideos
            // 
            this.lstVideos.FormattingEnabled = true;
            this.lstVideos.ItemHeight = 16;
            this.lstVideos.Location = new System.Drawing.Point(934, 9);
            this.lstVideos.Margin = new System.Windows.Forms.Padding(4);
            this.lstVideos.Name = "lstVideos";
            this.lstVideos.Size = new System.Drawing.Size(269, 532);
            this.lstVideos.TabIndex = 22;
            this.lstVideos.SelectedIndexChanged += new System.EventHandler(this.lstVideos_SelectedIndexChanged);
            // 
            // pnlVideo
            // 
            this.pnlVideo.Location = new System.Drawing.Point(22, 9);
            this.pnlVideo.Margin = new System.Windows.Forms.Padding(4);
            this.pnlVideo.Name = "pnlVideo";
            this.pnlVideo.Size = new System.Drawing.Size(904, 437);
            this.pnlVideo.TabIndex = 21;
            // 
            // lblVideo
            // 
            this.lblVideo.Font = new System.Drawing.Font("Verdana", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVideo.Location = new System.Drawing.Point(0, 498);
            this.lblVideo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVideo.Name = "lblVideo";
            this.lblVideo.Size = new System.Drawing.Size(904, 80);
            this.lblVideo.TabIndex = 30;
            this.lblVideo.Text = "Video Name";
            this.lblVideo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ShockWavePLayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 582);
            this.Controls.Add(this.lblVideo);
            this.Controls.Add(this.btnVolume);
            this.Controls.Add(this.trackVolume);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.lblVideoPosition);
            this.Controls.Add(this.btnPlayPause);
            this.Controls.Add(this.btnFullscreen);
            this.Controls.Add(this.lstVideos);
            this.Controls.Add(this.pnlVideo);
            this.Controls.Add(this.linkLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "ShockWavePLayer";
            this.Text = "ShockWave Menu";
            this.Load += new System.EventHandler(this.ShockWavePLayer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnVolume;
        private System.Windows.Forms.TrackBar trackVolume;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblVideoPosition;
        private System.Windows.Forms.Button btnPlayPause;
        private System.Windows.Forms.Button btnFullscreen;
        private System.Windows.Forms.ListBox lstVideos;
        private System.Windows.Forms.Panel pnlVideo;
        private System.Windows.Forms.Timer tmrVideo;
        private System.Windows.Forms.Label lblVideo;
    }
}