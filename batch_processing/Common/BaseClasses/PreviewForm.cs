using System.Drawing;
using System.Windows.Forms;

namespace batch_processing.Common
{
    public partial class PreviewForm : Form
    {
        public PreviewForm()
        {
            InitializeComponent();
            pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
        }

        public void SetPicture(string img_path)
        {
            pictureEdit1.Image = Image.FromFile(img_path);
            pictureEdit1.Show();
        }
        
        public void SetPicture(Image image)
        {
            pictureEdit1.Image = image;
            pictureEdit1.Show();
        }
    }
}
