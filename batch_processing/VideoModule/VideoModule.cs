using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace batch_processing.Video
{
    internal class VideoModule : Common.ProcessModule
    {
        public override void process(Common.Parameters param, List<string> paths)
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
