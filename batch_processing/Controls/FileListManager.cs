using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace batch_processing.Controls
{
    public partial class FileListManager : UserControl
    {
        public List<string> ExtPattern { get; set; }
        private List<ListControl> lists;
        private bool first;

        public FileListManager()
        {
            InitializeComponent();
            first = true;
            ExtPattern = new List<string>();
            lists = new();
        }

        public List<string> getSelectedFiles()
        {
            List<string> result = new List<string>();

            foreach (ListControl list in lists)
                result.AddRange(list.getSelectedFiles());

            return result;
        }

        public void clear()
        {
            lists.Clear();
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowCount = 1;
        }

        public void addListControl(string workingDir)
        {
            tableLayoutPanel1.SuspendLayout();

            if (!first)
                tableLayoutPanel1.RowCount += 1;
            else
                first = false;

            tableLayoutPanel1.RowStyles.Clear();
            for (int i = 0; i < tableLayoutPanel1.RowCount; ++i)
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 300.0F));

            TableLayoutPanel panel = createItem(workingDir, ExtPattern);

            tableLayoutPanel1.Controls.Add(panel, 0, tableLayoutPanel1.RowCount - 1);

            tableLayoutPanel1.ResumeLayout(true);
            tableLayoutPanel1.Update();
        }

        private TableLayoutPanel createItem(string workingDir, List<string> extPattern)
        {
            Label label = new Label();
            label.Text = workingDir;
            label.Dock = DockStyle.Fill;

            Button button = new Button();
            button.Text = "Delete";
            button.Dock = DockStyle.Right;
            button.Click += new System.EventHandler(this.deleteItem);

            ListControl listControl = new ListControl();
            listControl.setWorkingDir(workingDir);
            listControl.setExtPattern(extPattern);
            listControl.Dock = DockStyle.Fill;
            lists.Add(listControl);

            TableLayoutPanel panel = new TableLayoutPanel();
            panel.SuspendLayout();

            panel.Dock = DockStyle.Fill;
            panel.RowCount = 2;
            panel.ColumnCount = 2;

            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));

            panel.Controls.Add(label, 0, 0);
            panel.Controls.Add(button, 1, 0);
            panel.Controls.Add(listControl, 0, 1);
            panel.SetColumnSpan(listControl, 2);

            panel.ResumeLayout(true);
            panel.Update();

            return panel;
        }

        private void deleteItem(object sender, EventArgs args)
        {

        }
    }
}
