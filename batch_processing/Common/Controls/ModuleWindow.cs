using batch_processing.Common;

using DevExpress.XtraEditors;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace batch_processing
{
    internal class ModuleWindow : Window    
    {
        public event EventHandler<ProcessModule.ProgressEventArgs> OnProgressChanged;

        public ModuleWindow() : base()
        {
            InitializeComponent();

            imageEdit.DoubleClick += imageDoubleClick;
            listCntrol.SelectedIndexChanged += selectionChanged;
            cbPreview.CheckedChanged += CbPreview_CheckedChanged;
            prGrid.PropertyValueChanged += selectionChanged;

            isTaken = false;
        }

        public ProcessModule GetModule()
        {
            return pModule;
        }
        
        protected void setWorkingModule(ProcessModule module)
        {
            pModule = module;
            pModule.ProgressChanged += progress_Changed;
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
            form.ShowDialog();
        }

        private void selectionChanged(object sender, EventArgs e)
        {
            if (listCntrol.SelectedItem == null || !cbPreview.Checked)
                return;

            string temp = currentFilterPath;
            imageEdit.Image?.Dispose();
            imageEdit.Image = null;
            
            if (cbFilters.Checked)
            {
                currentFilterPath = pModule.createPreview(pParams, listCntrol.GetCurrentItemPath());
                imageEdit.Image = Image.FromFile(currentFilterPath);
            }
            else
            {
                currentFilterPath = "";
                imageEdit.Image = Image.FromFile(listCntrol.GetCurrentItemPath());
            }

            imageEdit.Show();

            if (!string.IsNullOrEmpty(temp))
                File.Delete(temp);
        }

        private void progress_Changed(object sender, ProcessModule.ProgressEventArgs e)
        {
            OnProgressChanged(sender, e);
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

        protected override void Dispose(bool disposing)
        {
            imageEdit.Image?.Dispose();
            imageEdit.Image = null;

            DirectoryInfo dir = new DirectoryInfo(Common.Constants.Paths.TEMP_PATH);
            var files_list = dir.GetFiles();

            foreach (var file in files_list)
                file.Delete();

            base.Dispose(disposing);
        }

        bool isTaken;
        private string currentFilterPath;
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
