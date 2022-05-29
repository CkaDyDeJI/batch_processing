using DevExpress.XtraEditors;

using System;
using System.Drawing;
using System.Windows.Forms;

namespace batch_processing
{
    public partial class MainForm : Form
    {
        

        public MainForm()
        {
            InitializeComponent();
            setupWindows();
            Update();

            cbModuleChoice.SelectedIndex = 0;
        }
        
        private void setupWindows()
        {
            Audio.AudioWindow aud_win = new Audio.AudioWindow();
            Photo.PictureWindow pic_win = new Photo.PictureWindow();
            Video.VideoWindow vid_win = new Video.VideoWindow();
            Common.SelectionWindow sel_win = new Common.SelectionWindow();

            SimpleButton ph_bt = new SimpleButton();
            initButton(ph_bt);
            ph_bt.Text = pic_win.GetModule().ModuleName;
            ph_bt.Tag = 1;
            ph_bt.Click += changeButton_Click;

            SimpleButton vd_bt = new SimpleButton();
            initButton(vd_bt);
            vd_bt.Text = vid_win.GetModule().ModuleName;
            vd_bt.Tag = 2;
            vd_bt.Click += changeButton_Click;

            SimpleButton aud_bt = new SimpleButton();
            initButton(aud_bt);
            aud_bt.Text = aud_win.GetModule().ModuleName;
            aud_bt.Tag = 3;
            aud_bt.Click += changeButton_Click;

            sel_win.AddButton(ph_bt);
            sel_win.AddButton(vd_bt);
            sel_win.AddButton(aud_bt);

            stackedLayout.RegisterNewWindow(sel_win);   //0
            stackedLayout.RegisterNewWindow(pic_win);   //1
            stackedLayout.RegisterNewWindow(vid_win);   //2
            stackedLayout.RegisterNewWindow(aud_win);   //3

            stackedLayout.SetCurrentIndex(0);
        }

        private void progress_Changed(object sender, Common.ProcessModule.ProgressEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.FileName))
                statusLabel.Text = e.FileName;
            if (!string.IsNullOrEmpty(e.FileName))
                fileStatusLabel.Text = e.State;
            if (e.CommonProgress != -1)
                firstProgress.Value = e.CommonProgress;
            secondProgress.Value = e.FileProgress;
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            int module_index = (int)((SimpleButton)sender).Tag;
            
            cbModuleChoice.SelectedIndex = module_index;

            (stackedLayout.GetСurrentWindow() as ModuleWindow).OnProgressChanged -= progress_Changed;
            stackedLayout.SetCurrentIndex(module_index);
            (stackedLayout.GetСurrentWindow() as ModuleWindow).OnProgressChanged += progress_Changed;
        }

        private void cbModuleChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (stackedLayout.GetСurrentWindow() is not Common.SelectionWindow)
                (stackedLayout.GetСurrentWindow() as ModuleWindow).OnProgressChanged -= progress_Changed;

            stackedLayout.SetCurrentIndex(cbModuleChoice.SelectedIndex);

            if (stackedLayout.GetСurrentWindow() is not Common.SelectionWindow)
                (stackedLayout.GetСurrentWindow() as ModuleWindow).OnProgressChanged += progress_Changed;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() != DialogResult.OK)
                return;

            stackedLayout.GetСurrentWindow().SetWorkingDir(folderBrowserDialog1.SelectedPath);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "Processing...";
            firstProgress.Visible = true;
            secondProgress.Visible = true;
            fileStatusLabel.Visible = true;

            stackedLayout.GetСurrentWindow().Run();

            fileStatusLabel.Visible = false;
            firstProgress.Visible = false;
            secondProgress.Visible = false;
            statusLabel.Text = "Ready";
        }

        private void stackedLayout_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                stackedLayout.SetCurrentIndex(0);
        }

        private static void initButton(SimpleButton bt)
        {
            bt.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            bt.MinimumSize = new Size(100, 75);
            bt.Margin = new Padding(50, 50, 50, 0);
        }
    }
}
