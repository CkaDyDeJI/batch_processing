using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Xabe.FFmpeg.Downloader;

namespace batch_processing
{
    internal class Loader
    {
        public Loader()
        {
            LoadServices();
            LoadSkeleton();
            GetFfmPeg();
            Run();
        }

        void LoadServices()
        {
        }

        void LoadSkeleton()
        {
            _mainMenu = new MainForm();
        }
        void GetFfmPeg()
        {
            FFmpegDownloader.GetLatestVersion(FFmpegVersion.Official);
        }

        void Run()
        {
            Application.Run(_mainMenu);
        }

        private Form _mainMenu;
    }
}
