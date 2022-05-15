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

        abstract protected string generateFileName(); 
    }
}
