using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace batch_processing
{
    public partial class ListControl : UserControl
    {
        private string workingDir;
        private List<string> extPattern;
        private List<string> checkedPaths;

        public ListControl()
        {
            InitializeComponent();

            extPattern = new();
            checkedPaths = new();
        }

        public List<string> getSelectedFiles()
        {
            //List<string> res = new();

            //foreach (var item in checkedListBox1.CheckedItems)
            //{
            //    CheckBox temp = item as CheckBox;
            //    res.Add(temp.Text);
            //}

            //return res;
            return checkedPaths;
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
            if (e.NewValue == CheckState.Checked)
            {
                checkedPaths.Add(workingDir + "\\" + checkedListBox1.SelectedItem.ToString());
            }
            else
            {
                checkedPaths.Remove(workingDir + "\\" + checkedListBox1.SelectedItem.ToString());
            }
        }
    }
}
