using batch_processing.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace batch_processing.Audio
{
    internal class AudioModule : Common.ProcessModule
    {
        public AudioModule() : base()
        {
            ModuleName = "Audio";
            DefaultExt = ".mp3";
        }

        public override string createPreview(Parameters param, string path)
        {
            throw new NotImplementedException();
        }

        public override List<string> getFilesPattern()
        {
            return new List<string>();
        }

        public override void process(Parameters param, List<string> paths)
        {
            throw new NotImplementedException();
        }
    }
}
