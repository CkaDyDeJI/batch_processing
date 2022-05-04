using batch_processing.Common;

using DevExpress.XtraEditors;

using System;
using System.Drawing;
using System.Windows.Forms;

namespace batch_processing.Photo
{
    internal class PictureWindow : Window
    {
        public PictureWindow() : base()
        {
            InitializeComponent();
            
            listCntrol.setExtPattern(pModule.getFilesPattern());
            listCntrol.setWorkingDir(Common.Constants.Paths.INPUT_PATH);
            
            listCntrol.SelectedIndexChanged += selectionChanged;

            imageEdit.DoubleClick += imageDoubleClick;

            cbPreview.CheckedChanged += CbPreview_CheckedChanged;
        }

        private void CbPreview_CheckedChanged(object sender, EventArgs e)
        {
            innerPanel.Panel1Collapsed = !cbPreview.Checked;
        }

        public override void SetWorkingDir(string path)
        {
            listCntrol.setWorkingDir(path);
        }

        public override void Run()
        {
            pModule.process(pParams, listCntrol.getSelectedFiles());
        }
        
        private void imageDoubleClick(object sender, EventArgs e)
        {
            if (imageEdit.Image == null)
                return;

            PreviewForm form = new PreviewForm();
            form.SetPicture(imageEdit.Image);
            form.Show();
            
        }

        private void selectionChanged(object sender, EventArgs e)
        {
            if (listCntrol.SelectedItem == null)
                return;

            imageEdit.Image = Image.FromFile(listCntrol.GetCurrentItemPath());
            imageEdit.Show();
        }

        private void InitializeComponent()
        {
            imageEdit = new PictureEdit();
            cbPreview = new CheckBox();
            mainPanel = new SplitContainer();
            innerPanel = new SplitContainer();
            listCntrol = new ListControl();
            prGrid = new PropertyGrid();
            pParams = new PictureParameters();
            pModule = new PictureModule();

            this.SuspendLayout();

            cbPreview.Text = "Preview";
            cbPreview.Checked = true;
            imageEdit.Dock = DockStyle.Fill;
            imageEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            innerPanel.Dock = DockStyle.Fill;
            innerPanel.Orientation = Orientation.Horizontal;
            mainPanel.Dock = DockStyle.Fill;
            listCntrol.Dock = DockStyle.Fill;
            prGrid.Dock = DockStyle.Fill;
            prGrid.SelectedObject = pParams;

            innerPanel.Panel1.Controls.Add(imageEdit);
            innerPanel.Panel2.Controls.Add(prGrid);

            mainPanel.Panel1.Controls.Add(listCntrol);
            mainPanel.Panel2.Controls.Add(cbPreview);
            mainPanel.Panel2.Controls.Add(innerPanel);

            this.Controls.Add(mainPanel);

            this.ResumeLayout(false);
        }

        private CheckBox cbPreview;
        private PictureEdit imageEdit;
        private PictureModule pModule;
        private PictureParameters pParams;
        private SplitContainer mainPanel;
        private SplitContainer innerPanel;
        private ListControl listCntrol;
        private PropertyGrid prGrid;
    }
}
