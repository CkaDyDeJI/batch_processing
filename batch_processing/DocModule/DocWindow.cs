using System.Windows.Forms;

namespace batch_processing.Doc
{
    internal class DocWindow : ModuleWindow
    {
        public DocWindow() : base()
        {
            InitializeComponent();

            base.setWorkingModule(dModule);
            base.setWorkingParams(dParams);
            base.disablePreview();
        }

        public override void Run()
        {
            if (!dParams.rename)
            {
                MessageBox.Show("You haven't changed a file names. They are will be written with number postfix (0, 1 and so on).", "Warning", MessageBoxButtons.OK);
            }

            base.Run();
        }

        private void InitializeComponent()
        {
            dParams = new DocParameters();
            dModule = new DocModule();

            if (!dModule.LicenseIt())
                this.Enabled = false;
        }

        private DocModule dModule;
        private DocParameters dParams;
    }
}
