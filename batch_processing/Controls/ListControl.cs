using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace batch_processing
{
    public partial class ListControl : UserControl
    {
        private string workingDir;
        private List<string> extPattern;
        private List<ListItem> checkedItem;

        public ListControl()
        {
            InitializeComponent();

            extPattern = new();
            checkedItem = new();
        }

        public List<string> getSelectedFiles()
        {
            List<string> res = new();

            foreach (var item in checkedItem)
                res.Add(item.FullName);

            return res;
        }

        public void setWorkingDir(string newWD)
        {
            workingDir = newWD;
            reloadList();
        }

        public string getWorkingDir() { return workingDir; }

        public void setExtPattern(List<string> newPatttern)
        {
            extPattern = newPatttern;
            reloadList();
        }

        private void reloadList()
        {
            checkedListBox1.Items.Clear();

            if (workingDir == null)
                return;

            DirectoryInfo d = new DirectoryInfo(workingDir);

            foreach (string ext in extPattern)
            {
                FileInfo[] files = d.GetFiles(ext);

                foreach (FileInfo file in files)
                {
                    checkedListBox1.Items.Add(file.Name);
                }
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ListItem newItem = new ListItem(workingDir, checkedListBox1.SelectedItem.ToString());

            if (e.NewValue == CheckState.Checked)
                checkedItem.Add(newItem);
            else
                checkedItem.Remove(newItem);
        }
    }
}
