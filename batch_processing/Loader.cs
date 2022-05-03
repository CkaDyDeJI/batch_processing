using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace batch_processing
{
    internal class Loader
    {
        public Loader()
        {
            LoadServices();
            LoadSkeleton();
            Run();
        }

        void LoadServices()
        {

        }

        void LoadSkeleton()
        {
            _mainMenu = new MainForm();
        }

        void Run()
        {
            Application.Run(_mainMenu);
        }

        private Form _mainMenu;
    }
}
