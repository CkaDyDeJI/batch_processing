using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace batch_processing.Video
{
    internal class VideoWindow : Window
    {
        public VideoWindow() : base()
        {
            InitializeComponents();
            _listControl.setExtPattern(_vModule.getFilesPattern());
            _listControl.setWorkingDir(Common.Constants.Paths.INPUT_PATH);
        }

        public override void SetWorkingDir(string path)
        {
            _listControl.setWorkingDir(path);
        }

        public override void Run()
        {
            _vModule.process(_vParams, _listControl.getSelectedFiles());
        }

        private void InitializeComponents()
        {
            _cont = new SplitContainer();
            _listControl = new ListControl();
            _prGrid = new PropertyGrid();
            _vModule = new VideoModule();
            _vParams = new VideoParameters();

            this.SuspendLayout();

            _cont.Dock = DockStyle.Fill;
            _listControl.Dock = DockStyle.Fill;
            _prGrid.Dock = DockStyle.Fill;
            _prGrid.SelectedObject = _vParams;

            _cont.Panel1.Controls.Add(_listControl);
            _cont.Panel2.Controls.Add(_prGrid);

            this.Controls.Add(_cont);

            this.ResumeLayout(false);
        }

        private SplitContainer _cont;
        private ListControl _listControl;
        private PropertyGrid _prGrid;
        private VideoModule _vModule;
        private VideoParameters _vParams;
    }
}
