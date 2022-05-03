using DevExpress.XtraEditors;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace batch_processing.Common
{
    internal class SelectionWindow : Window
    {
        public SelectionWindow() : base()
        {
            _buttons = new List<SimpleButton>();
            _table = new TableLayoutPanel();
            _table.Dock = DockStyle.Fill;
            _table.RowCount = 1;
            _table.ColumnCount = 1;

            this.Controls.Add(_table);
        }

        public void AddButton(SimpleButton button)
        {
            _buttons.Add(button);
            _table.Controls.Add(button, 0, _table.RowCount - 1);
        }

        private TableLayoutPanel _table;
        private List<SimpleButton> _buttons;
    }
}
