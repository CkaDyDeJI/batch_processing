using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace batch_processing
{
    internal class VideoModule : ProcessModule
    {
        public override void process(Parameters param, List<string> paths)
        {
            VideoParameters ac_param = (VideoParameters)param;

            return;
        }

        public override List<string> getFilesPattern()
        {
            return new List<string> { "*.mp4" };
        }
    }
}
