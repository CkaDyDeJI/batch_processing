using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace batch_processing.Common
{
    abstract class ProcessModule
    {
        abstract public void process(Parameters param, List<string> paths);
        abstract public string createPreview(Parameters param, string path);
        abstract public List<string> getFilesPattern();

        private static Random rnd = new Random();
        private static string SYMBOLS = "abcdefghijklmnopqrstuvwxyz0123456789";

        public string ModuleName;
        public string DefaultExt;

        protected string generateFileName()
        {
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < 16; ++i)
                str.Append(SYMBOLS[rnd.Next(0, SYMBOLS.Length)]);

            return "temp_" + ModuleName + "_" + str.ToString() + DefaultExt;
        }
    }
}
