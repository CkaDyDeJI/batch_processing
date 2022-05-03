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
    public class ListControl : CheckedListBox
    {
        private string workingDir;
        private List<string> extPattern;
        private List<string> checkedPaths;

        public ListControl() : base()
        {
            //InitializeComponent();

            extPattern = new();
            checkedPaths = new();
        }

        public string GetCurrentItemPath()
        {
            return workingDir + "\\" + SelectedItem.ToString();
        }

        public List<string> getSelectedFiles()
        {
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
            Items.Clear();

            if (workingDir == null)
                return;

            DirectoryInfo d = new DirectoryInfo(workingDir);
            
            foreach (string ext in extPattern)
            {
                FileInfo[] files = d.GetFiles(ext);

                foreach (FileInfo file in files)
                {
                    Items.Add(file.Name);
                }
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                checkedPaths.Add(workingDir + "\\" + SelectedItem.ToString());
            }
            else
            {
                checkedPaths.Remove(workingDir + "\\" + SelectedItem.ToString());
            }
        }
    }
}
