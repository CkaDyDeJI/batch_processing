using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace batch_processing
{
    public partial class Form1 : Form
    {
        private IParametersControl activeControl;
        private VideoControl videoControl;
        private PictureControl pictureControl;

        private ProcessModule activeModule;
        private PictureModule picModule;
        private VideoModule vidModule;

        public Form1()
        {
            InitializeComponent();

            activeControl = null;
            activeModule = null;

            videoControl = new VideoControl();
            pictureControl = new PictureControl();
            vidModule = new VideoModule();
            picModule = new PictureModule();

            cbModuleChoice.SelectedIndex = 0;
        }

        private void cbModuleChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbModuleChoice.SelectedIndex == 0)
            {
                activeControl = pictureControl;
                activeModule = picModule;
            }
            else if (cbModuleChoice.SelectedIndex == 1)
            {
                activeControl = videoControl;
                activeModule = vidModule;
            }

            fileListManager1.clear();
            fileListManager1.ExtPattern = activeModule.getFilesPattern();
            tableLayoutPanel1.Controls.Add((UserControl)activeControl, 1, 0);
            ((UserControl)activeControl).Dock = DockStyle.Fill;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() != DialogResult.OK)
                return;

            fileListManager1.addListControl(folderBrowserDialog1.SelectedPath);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            activeModule.process(activeControl.getParameters(), fileListManager1.getSelectedFiles());
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            fileListManager1.clear();
        }
    }
}
