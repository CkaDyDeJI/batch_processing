using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace batch_processing.Video
{
    internal class VideoWindow : ModuleWindow
    {
        public VideoWindow() : base()
        {
            InitializeComponents();

            base.setWorkingModule(_vModule);
            base.setWorkingParams(_vParams);
            base.disablePreview();
        }

        public override void Run()
        {
            base.Run();
        }

        private void InitializeComponents()
        {
            _vModule = new VideoModule();
            _vParams = new VideoParameters();
        }

        private VideoModule _vModule;
        private VideoParameters _vParams;
    }
}
