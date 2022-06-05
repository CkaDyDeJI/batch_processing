using DevExpress.XtraEditors;

using System.Collections.Generic;
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

            this.Controls.Add(_table);
        }

        public void AddButton(SimpleButton button)
        {
            button.Margin = new Padding(50, 0, 50, 0);

            _buttons.Add(button);
            _table.Controls.Add(button, 0, _buttons.Count - 1);
        }

        public void EndInit()
        {
            _table.RowCount = _buttons.Count;

            double height = 100 / _table.RowCount;
            for (int i = 0; i < _table.RowCount; i++)
            {
                RowStyle style = new RowStyle();
                style.SizeType = SizeType.Percent;
                style.Height = (int)height;

                _table.RowStyles.Add(style);
            }
        }

        private TableLayoutPanel _table;
        private List<SimpleButton> _buttons;
    }
}
