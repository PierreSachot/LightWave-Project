using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX.AudioVideoPlayback;
using System.IO;
using System.Threading.Tasks;

namespace Audio_Spectrum_Analyzer
{
    public partial class ShockWavePLayer : Form
    {
        //Fonctionne uniquement sous windows x86 à causes des librairies directX
        private Video video;
        private string[] shockwavePath;
        private string folderPath = @".\Videos";
        private int selectedIndex = 0;
        private Size formSize;
        private Size panelSize;
        private bool isInFullScreen;
        private List<string> lstVideos;
        private int currentVideo = 0;
        private MainForm parent;

        public ShockWavePLayer(MainForm parent)
        {
            InitializeComponent();
            pnlVideo.BackColor = Color.Black;
            this.parent = parent;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            parent.ChangeForm(0);
        }

        private void ShockWavePLayer_Load(object sender, EventArgs e)
        {
            isInFullScreen = false;
            formSize = new Size(this.Width, this.Height);
            panelSize = new Size(pnlVideo.Width, pnlVideo.Height);
            lstVideos = new List<string>();
            try
            {
                shockwavePath = Directory.GetFiles(folderPath, "*.wmv");
                if (shockwavePath != null)
                {
                    foreach (string path in shockwavePath)
                    {
                        string vid = path.Replace(folderPath, string.Empty);
                        lstVideos.Add(vid);
                    }
                }
                currentVideo = selectedIndex;
                try
                {
                    video.Stop();
                    video.Dispose();
                }
                catch { }
                selectedIndex = currentVideo;
                video = new Video(shockwavePath[selectedIndex], false);
                video.Owner = pnlVideo;
                pnlVideo.Size = panelSize;
                video.Play();
                tmrVideo.Enabled = true;
                btnPlayPause.Text = "Pause";
                video.Ending += Video_Ending;
                lblVideo.Text = lstVideos[currentVideo];
            }
            catch(Exception)
            {

            }
        }

        public void playVideo()
        {
            try
            {
                video.Stop();
                video.Dispose();
            }
            catch { }
            selectedIndex = currentVideo;
            video = new Video(shockwavePath[selectedIndex], false);
            video.Owner = pnlVideo;
            if (isInFullScreen)
            {
                setInFullScreen();
            }
            else
            {
                pnlVideo.Size = panelSize;
            }
            video.Play();
            tmrVideo.Enabled = true;
            btnPlayPause.Text = "Pause";
            video.Ending += Video_Ending;
            lblVideo.Text = lstVideos[currentVideo];
            video.Play();
            Task.Factory.StartNew(() =>
            {
                System.Threading.Thread.Sleep(2000);

                if (InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        NextVideo();
                    }));
                }
            });
        }


        private void Video_Ending(object sender, EventArgs e)
        {
            /*Task.Factory.StartNew(() =>
            {
                System.Threading.Thread.Sleep(2000);

                if (InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        NextVideo();
                    }));
                }
            });*/
        }

        private void NextVideo()
        {
            int index = currentVideo;
            index++;
            if (index > shockwavePath.Length - 1)
                index = 0;
            selectedIndex = index;
            currentVideo = index;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            NextVideo();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            PreviousVideo();
        }

        private void PreviousVideo()
        {
            int index = currentVideo;
            index--;
            if (index == -1)
                index = shockwavePath.Length - 1;
            selectedIndex = index;
            currentVideo = index;
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            if (!video.Playing)
            {
                video.Play();
                tmrVideo.Enabled = true;
                btnPlayPause.Text = "Pause";
            }
            else if (video.Playing)
            {
                video.Pause();
                tmrVideo.Enabled = false;
                btnPlayPause.Text = "Play";
            }
        }

        private void btnFullscreen_Click(object sender, EventArgs e)
        {
            setInFullScreen();
            isInFullScreen = true;
        }

        private void setInFullScreen()
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            this.BackColor = Color.Black;
            btnFullscreen.BackColor = Color.Black;
            btnNext.BackColor = Color.Black;
            btnPlayPause.BackColor = Color.Black;
            btnPrevious.BackColor = Color.Black;
            btnVolume.BackColor = Color.Black;
            lblVideoPosition.BackColor = Color.Black;

            video.Owner = this;
        }

        private void shockWave_KeyDown(object sender, KeyEventArgs e)
        {
            if(isInFullScreen)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    //exit full screen when escape is pressed
                    FormBorderStyle = FormBorderStyle.Sizable;
                    WindowState = FormWindowState.Normal;
                    this.Size = formSize;
                    this.BackColor = Color.White;
                    video.Owner = pnlVideo;
                    pnlVideo.Size = panelSize;
                    btnFullscreen.BackColor = Color.White;
                    btnNext.BackColor = Color.White;
                    btnPlayPause.BackColor = Color.White;
                    btnPrevious.BackColor = Color.White;
                    btnVolume.BackColor = Color.White;
                    lblVideoPosition.BackColor = Color.White;
                    isInFullScreen = false;
                }
            }            
        }

        private void trackVolume_Scroll(object sender, EventArgs e)
        {
            video.Audio.Volume = trackVolume.Value;
        }

        private void btnVolume_Click(object sender, EventArgs e)
        {
            trackVolume.Visible = !trackVolume.Visible;
        }

        private void tmrVideo_Tick(object sender, EventArgs e)
        {
            int currentTime = Convert.ToInt32(video.CurrentPosition);
            int maxTime = Convert.ToInt32(video.Duration);

            lblVideoPosition.Text = string.Format("{0:00}:{1:00}:{2:00}", currentTime / 3600, (currentTime / 60) % 60, currentTime % 60)
                                    + " / " +
                                    string.Format("{0:00}:{1:00}:{2:00}", maxTime / 3600, (maxTime / 60) % 60, maxTime % 60);
        }
    }
}
