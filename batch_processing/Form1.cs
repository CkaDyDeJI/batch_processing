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
                //tableLayoutPanel1.Controls.Add(pictureControl, 1, 0);
            }
            else if (cbModuleChoice.SelectedIndex == 1)
            {
                //tableLayoutPanel1.Controls.Add(videoControl, 1, 0);
                activeControl = videoControl;
                activeModule = vidModule;
            }

            listControl1.setExtPattern(activeModule.getFilesPattern());
            tableLayoutPanel1.Controls.Add((UserControl)activeControl, 1, 0);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() != DialogResult.OK)
                return;

            listControl1.setWorkingDir(folderBrowserDialog1.SelectedPath);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            activeModule.process(activeControl.getParameters(), listControl1.getSelectedFiles());
        }
    }
}
