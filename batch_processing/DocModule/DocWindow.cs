using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private DocModule dModule;
        private DocParameters dParams;
    }
}
