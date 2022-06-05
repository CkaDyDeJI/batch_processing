using System.Windows.Forms;

namespace batch_processing
{
    internal class Window : Panel
    {
        public Window() : base()
        { }

        public virtual void SetWorkingDir(string path)
        { }

        public virtual void Run()
        { }
    }
}
