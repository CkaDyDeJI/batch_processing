using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace batch_processing.Audio
{
    internal class AudioWindow : ModuleWindow
    {
        public AudioWindow() : base()
        {
            InitializeComponent();

            base.setWorkingModule(aModule);
            base.setWorkingParams(aParams);
            base.disablePreview();
        }

        public override void Run()
        {
            //if (!aParams.rename)
            //{
            //    if (MessageBox.Show("You are about to rewrite all original files. Are you sure?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
            //        return;
            //}

            base.Run();
        }

        private void InitializeComponent()
        {
            aParams = new AudioParameters();
            aModule = new AudioModule();
        }

        private AudioModule aModule;
        private AudioParameters aParams;
    }
}
