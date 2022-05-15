using batch_processing.Common;

using DevExpress.XtraEditors;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace batch_processing
{
    internal class ModuleWindow : Window
    {
        public ModuleWindow() : base()
        {
            InitializeComponent();

            imageEdit.DoubleClick += imageDoubleClick;
            listCntrol.SelectedIndexChanged += selectionChanged;
            cbPreview.CheckedChanged += CbPreview_CheckedChanged;
            prGrid.PropertyValueChanged += selectionChanged;
        }
        
        protected void setWorkingModule(ProcessModule module)
        {
            pModule = module;
            listCntrol.setExtPattern(pModule.getFilesPattern());
            listCntrol.setWorkingDir(Common.Constants.Paths.INPUT_PATH);
        }

        protected void setWorkingParams(Parameters pars)
        {
            pParams = pars;
            prGrid.SelectedObject = pParams;
        }

        protected void disablePreview()
        {
            cbPreview.Checked = false;
            cbPreview.Visible = false;
        }

        private void CbPreview_CheckedChanged(object sender, EventArgs e)
        {
            innerPanel.Panel1Collapsed = !cbPreview.Checked;
            cbFilters.Visible = cbPreview.Checked;
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
            if (listCntrol.SelectedItem == null || !cbPreview.Checked)
                return;

            if (cbFilters.Checked)
                imageEdit.Image = Image.FromFile(pModule.createPreview(pParams, listCntrol.GetCurrentItemPath()));
            else
                imageEdit.Image = Image.FromFile(listCntrol.GetCurrentItemPath());

            imageEdit.Show();
        }

        private void InitializeComponent()
        {
            imageEdit = new PictureEdit();
            cbPreview = new CheckBox();
            cbFilters = new CheckBox();
            mainPanel = new SplitContainer();
            innerPanel = new SplitContainer();
            listCntrol = new ListControl();
            prGrid = new PropertyGrid();
            pParams = null;
            pModule = null;

            this.SuspendLayout();

            cbPreview.Text = "Preview";
            cbFilters.Text = "With Filters";
            cbFilters.Location = new Point(cbPreview.Right, 0);
            cbPreview.Checked = true;
            imageEdit.Dock = DockStyle.Fill;
            imageEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            innerPanel.Dock = DockStyle.Fill;
            innerPanel.Orientation = Orientation.Horizontal;
            mainPanel.Dock = DockStyle.Fill;
            listCntrol.Dock = DockStyle.Fill;
            prGrid.Dock = DockStyle.Fill;

            innerPanel.Panel1.Controls.Add(imageEdit);
            innerPanel.Panel2.Controls.Add(prGrid);

            mainPanel.Panel1.Controls.Add(listCntrol);
            mainPanel.Panel2.Controls.Add(cbPreview);
            mainPanel.Panel2.Controls.Add(cbFilters);
            mainPanel.Panel2.Controls.Add(innerPanel);

            this.Controls.Add(mainPanel);

            this.ResumeLayout(false);
        }

        private CheckBox cbPreview;
        private CheckBox cbFilters;
        private PictureEdit imageEdit;
        private ProcessModule pModule;
        private Parameters pParams;
        private SplitContainer mainPanel;
        private SplitContainer innerPanel;
        private ListControl listCntrol;
        private PropertyGrid prGrid;
    }
}
