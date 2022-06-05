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
            GetAdditionalLibraries();
            Run();
        }

        void LoadServices()
        {
        }

        void LoadSkeleton()
        {
            _mainMenu = new MainForm();
        }

        void GetAdditionalLibraries()
        {
            var task = Task.Run(() => FFmpegDownloader.GetLatestVersion(FFmpegVersion.Official));
            task.Wait();
        }

        void Run()
        {
            Application.Run(_mainMenu);
        }

        private Form _mainMenu;
    }
}
