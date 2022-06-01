using batch_processing.Common;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xabe.FFmpeg;
using Xabe.FFmpeg.Events;

namespace batch_processing.Video
{
    internal class VideoModule : Common.ProcessModule
    {
        static List<string> pattern = new List<string> { "*.mp4", "*.mkv" };
        int currentPercentage;
        string currentFile;

        public VideoModule()
        {
            ModuleName = "Video";
            DefaultExt = ".mp4";
        }

        public override void process(Common.Parameters param, List<string> paths)
        {
            VideoParameters vid_param = (VideoParameters)param;

            for (int i = 0; i < paths.Count; ++i)
            {
                currentPercentage = (int)(((double)i / paths.Count) * 100);
                currentFile = paths[i];

                string path = paths[i];
                if (vid_param.rename)
                    path = Path.GetDirectoryName(path) + "\\" + vid_param.output + i.ToString();

                processFile(paths[i], path, vid_param);
            }

            return;
        }

        private async void processFile(string input_path, string output_path, VideoParameters param)
        {
            IMediaInfo inputFile = await FFmpeg.GetMediaInfo(input_path);

            IVideoStream videoStream = inputFile.VideoStreams.First();
            IAudioStream audioStream = inputFile.AudioStreams.First();

            if (param.cutLength != -1)
            {
                videoStream.Split(new TimeSpan(0, 0, param.cutStart), new TimeSpan(0, 0, param.cutLength));
                audioStream.Split(new TimeSpan(0, 0, param.cutStart), new TimeSpan(0, 0, param.cutLength));
            }

            if (param.speedUp != 1)
            {
                videoStream.ChangeSpeed(param.speedUp);
                audioStream.ChangeSpeed(param.speedUp);
            }

            if (param.reverse)
            {
                videoStream.Reverse();
                audioStream.Reverse();
            }

            if (param.changeFramerate)
            {
                videoStream.SetFramerate(param.framerate);
            }

            if (param.changeCodec)
            {
                videoStream.SetCodec(param.codec);
            }

            if (param.bitrate != -1)
            {
                videoStream.SetBitrate(param.bitrate);
                audioStream.SetBitrate(param.bitrate);
            }    

            if (param.watermark)
            {
                videoStream.SetWatermark(param.pathToWatermark, param.position);
            }

            if (param.resize)
            {
                videoStream.SetSize(param.width, param.height);
            }

            var converion = FFmpeg.Conversions.New().AddStream(videoStream);
            converion.OnProgress += OnProgressChanged;
    
            if (param.rename)
                converion.SetOutput(output_path + ".mp4");
            else
                converion.SetOutput(input_path);

            if (!param.deleteAudio)
                converion.AddStream(audioStream);

            var res = await converion.Start();
        }

        void OnProgressChanged(object sender, ConversionProgressEventArgs e)
        {
            //base.OnProgressChanged(new ProgressEventArgs(currentFile, "", currentPercentage, e.Percent));
        }

        public override string createPreview(Parameters param, string path)
        {
            return "";
        }

        public override List<string> getFilesPattern()
        {
            return pattern;
        }
    }
}
