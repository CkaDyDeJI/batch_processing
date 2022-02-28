using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace batch_processing
{
    abstract class ProcessModule
    {
        abstract public void process(Parameters param, List<string> paths);
        abstract public List<string> getFilesPattern();
        abstract public void deleteFiles(List<string> files) 
        {
            foreach(string file_name in files)
                File.Delete(file_name);
        }

        abstract public void renameFiles(List<string> files, string prefix)
        {
            if (files.Count == 0)
                return;

            const string dir = Path.GetDirectoryName(files[0]);
            
            for (int i = 0; i < files.Count; ++i)
            {
                string ext = Path.GetExtension(files[i]);
                File.Move(file_name, dir + "\\" + prefix + i.ToString() + ext);
            }
        }
    }
}
