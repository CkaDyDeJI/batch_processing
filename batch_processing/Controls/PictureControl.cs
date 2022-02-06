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
    public partial class PictureControl : UserControl, IParametersControl
    {
        private PictureParameters param;

        public PictureControl()
        {
            InitializeComponent();
            param = new PictureParameters();
        }

        public Parameters getParameters()
        {
            param.waterMark = cbWatermark.Checked;
            param.wmPath = tbWmPath.Text;
            param.position = (PictureParameters.Position)cmbPosition.SelectedIndex;

            param.rename = cbRename.Checked;
            param.name = tbName.Text;

            param.rotate = cbRotatre.Checked;
            param.angle = (PictureParameters.Rotate)cmbRotate.SelectedIndex;

            param.negative = cbNegate.Checked;
            param.edges = cbEdges.Checked;

            return param;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            tbWmPath.Text = openFileDialog1.FileName;
        }
    }
}
