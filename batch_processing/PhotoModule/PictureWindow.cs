using batch_processing.Common;

using DevExpress.XtraEditors;

using System;
using System.Drawing;
using System.Windows.Forms;

namespace batch_processing.Photo
{
    internal class PictureWindow : ModuleWindow
    {
        public PictureWindow() : base()
        {
            InitializeComponent();

            base.setWorkingModule(pModule);
            base.setWorkingParams(pParams);
        }
        
        public override void Run()
        {
            if (!pParams.rename)
            {
                MessageBox.Show("You haven't changed a file names. They are will be written with number postfix (0, 1 and so on).", "Warning", MessageBoxButtons.OK);
            }

            base.Run();
        }

        private void InitializeComponent()
        {
            pParams = new PictureParameters();
            pModule = new PictureModule();
        }

        private PictureModule pModule;
        private PictureParameters pParams;
    }
}
