using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace batch_processing
{
    internal class StackedLayout : Panel
    {
        public StackedLayout() : base()
        {
            _windows = new List<Window>();
        }

        public void RegisterNewWindow(Window new_window)
        {
            _windows.Add(new_window);
        }

        public void SetCurrentIndex(int index)
        {
            if (index < 0 || index >= _windows.Count)
                return;

            _currentWindow = _windows[index];

            this.Controls.Clear();
            this.Controls.Add(_currentWindow);

            _currentWindow.Dock = DockStyle.Fill;
            _currentWindow.BringToFront();
            this.Update();
        }

        public void SetCurrentWindow(Window wnd)
        {
            if (!_windows.Contains(wnd))
                _windows.Add(wnd);

            _currentWindow = wnd;

            this.Controls.Clear();
            this.Controls.Add(_currentWindow);

            _currentWindow.Dock = DockStyle.Fill;
            _currentWindow.BringToFront();
            this.Update();
        }

        public Window GetСurrentWindow()
        {
            return _currentWindow;    
        }

        public T GetWindowOfType<T>() where T : Window
        {
            foreach (var wnd in _windows)
            {
                if (wnd.GetType() == typeof(T))
                    return (wnd as T);
            }

            return default(T);
        }

        private Window _currentWindow;
        private List<Window> _windows;
    }
}
