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
            base.disableFiltering();
        }

        public override void Run()
        {
            if (!_vParams.rename)
            {
                MessageBox.Show("You haven't changed a file names. They are will be written with number postfix (0, 1 and so on).", "Warning", MessageBoxButtons.OK);
            }

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
