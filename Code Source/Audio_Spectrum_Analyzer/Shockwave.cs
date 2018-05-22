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
using System.Threading;

namespace Audio_Spectrum_Analyzer
{
    /// <summary>
    /// Classe permettant de générer un effet de shockwave avec les basses.
    /// </summary>
    class Shockwave : IEffect
    {
        private Video video;
        private string[] shockwavePath;
        private string folderPath = @".\Videos";
        private int selectedIndex = 0;
        private bool isDone;
        private List<string> lstVideos;
        private int currentVideo = 0;
        private MainForm parentF;
        private static Shockwave singleton;
        private System.Windows.Forms.Timer TimerVideo { get; set; }

        private Shockwave(MainForm parentF, System.Windows.Forms.Timer parentTimer)
        {
            isDone = true;
            this.parentF = parentF;
            TimerVideo = parentTimer;
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
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Permet de fabriquer une instance unique de la shockwave
        /// </summary>
        /// <param name="parentF">Form parente</param>
        /// <param name="parent">Panel parent</param>
        /// <param name="parentTimer">Timer de la form parente</param>
        /// <returns></returns>
        public static Shockwave ShockwaveFactory(MainForm parentF, System.Windows.Forms.Timer parentTimer)
        {
            if (singleton == null)
                singleton = new Shockwave(parentF, parentTimer);
            return singleton;
        }

        /// <summary>
        /// Implémentation de l'interface, lis une shockwave  lors d'une basse.
        /// </summary>
        /// <param name="size"></param>
        public void GenerateEffect(int size)
        {
            if (size > 40 && isDone)
            {
                new Thread(() => PlayVideo()).Start();
            }
        }

        /// <summary>
        /// Permet de lire un fichier vidéo et de le lire sur le panel de la MainForm
        /// </summary>
        public void PlayVideo()
        {
            isDone = false;
            selectedIndex = currentVideo;
            Console.WriteLine(shockwavePath[selectedIndex]);
            video = new Video(shockwavePath[selectedIndex], false);
            parentF.Invoke((Action)(() => parentF.SetVideoOwner(video)));
            TimerVideo.Enabled = true;
            try
            {
                video.Play();
                NextVideo();
            }
            catch
            {

            }
            Task.Factory.StartNew(() =>
            {
                System.Threading.Thread.Sleep(500);
                isDone = true;
            });
        }

        /// <summary>
        /// Permet de passer à la vidéo suivante chargée dans la liste.
        /// </summary>
        private void NextVideo()
        {
            int index = currentVideo;
            index++;
            if (index > shockwavePath.Length - 1)
                index = 0;
            selectedIndex = index;
            currentVideo = index;
        }
    }
}
