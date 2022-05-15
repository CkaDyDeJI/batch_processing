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
                if (MessageBox.Show("You are about to rewrite all original files. Are you sure?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
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
