using System.Windows.Forms;

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
            if (!aParams.rename)
            {
                MessageBox.Show("You haven't changed a file names. They are will be written with number postfix (0, 1 and so on).", "Warning", MessageBoxButtons.OK);
            }

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
