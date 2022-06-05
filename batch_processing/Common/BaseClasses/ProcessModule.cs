using System;
using System.Collections.Generic;
using System.Text;

namespace batch_processing.Common
{
    abstract class ProcessModule
    {
        abstract public void process(Parameters param, List<string> paths);
        abstract public string createPreview(Parameters param, string path, bool filters);
        abstract public List<string> getFilesPattern();

        private static Random rnd = new Random();
        private static string SYMBOLS = "abcdefghijklmnopqrstuvwxyz0123456789";

        public string ModuleName;
        public string DefaultExt;

        public event EventHandler<ProgressEventArgs> ProgressChanged;

        public virtual void OnProgressChanged(ProgressEventArgs e)
        {
            ProgressChanged(this, e);
        }

        public class ProgressEventArgs : EventArgs
        {
            public string FileName { get; private set; }
            public string State { get; private set; }
            public int CommonProgress { get; private set; }
            public int FileProgress { get; private set; }


            public ProgressEventArgs(string t1, string t2, int t3, int t4)
            {
                FileName = t1;
                State = t2;
                CommonProgress = t3;
                FileProgress = t4;
            }
        }

        protected string generateFileName()
        {
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < 16; ++i)
                str.Append(SYMBOLS[rnd.Next(0, SYMBOLS.Length)]);

            return "temp_" + ModuleName + "_" + str.ToString() + DefaultExt;
        }
    }
}
