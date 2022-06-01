using batch_processing.Common;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xabe.FFmpeg;
using Xabe.FFmpeg.Events;

namespace batch_processing.Video
{
    internal class VideoModule : Common.ProcessModule
    {
        static List<string> pattern = new List<string> { "*.mp4", "*.mkv" };
        int currentPercentage;

        enum State { PREPARING = 0, CUTTING, SPEEDINGUP, REVERSING, FRAMERATE, CODEC, BITRATE, WATERMARK, SIZING, GENERATING, DONE, UNKNOWN = -1 };

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

                string path = paths[i];
                if (vid_param.rename)
                    path = Path.GetDirectoryName(path) + "\\" + vid_param.output + i.ToString() + Path.GetExtension(path);
                else
                    path = Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path) + i.ToString() + Path.GetExtension(path);

                if (File.Exists(path))
                    File.Delete(path);

                processFile(paths[i], path, vid_param);
            }

            return;
        }

        private async void processFile(string input_path, string output_path, VideoParameters param)
        {
            IMediaInfo inputFile = await FFmpeg.GetMediaInfo(input_path);

            //
            OnProgressChanged(input_path, State.PREPARING);
            //

            IVideoStream videoStream = inputFile.VideoStreams.First();
            IAudioStream audioStream = inputFile.AudioStreams.First();

            //
            OnProgressChanged(input_path, State.WATERMARK);
            //

            if (param.watermark)
            {
                videoStream.SetWatermark(param.pathToWatermark, param.position);
            }

            //
            OnProgressChanged(input_path, State.CUTTING);
            //

            if (param.cutLength != -1)
            {
                videoStream.Split(new TimeSpan(0, 0, param.cutStart), new TimeSpan(0, 0, param.cutLength));
                audioStream.Split(new TimeSpan(0, 0, param.cutStart), new TimeSpan(0, 0, param.cutLength));
            }

            //
            OnProgressChanged(input_path, State.SPEEDINGUP);
            //

            if (param.speedUp != 1)
            {
                videoStream.ChangeSpeed(param.speedUp);
                audioStream.ChangeSpeed(param.speedUp);
            }

            //
            OnProgressChanged(input_path, State.REVERSING);
            //

            if (param.reverse)
            {
                videoStream.Reverse();
                audioStream.Reverse();
            }

            //
            OnProgressChanged(input_path, State.FRAMERATE);
            //

            if (param.changeFramerate)
            {
                videoStream.SetFramerate(param.framerate);
            }

            //
            OnProgressChanged(input_path, State.CODEC);
            //

            if (param.changeCodec)
            {
                videoStream.SetCodec(param.codec);
            }

            //
            OnProgressChanged(input_path, State.BITRATE);
            //

            if (param.bitrate != -1)
            {
                videoStream.SetBitrate(param.bitrate);
                audioStream.SetBitrate(param.bitrate);
            }

            //
            OnProgressChanged(input_path, State.SIZING);
            //

            if (param.resize)
            {
                videoStream.SetSize(param.width, param.height);
            }

            //
            OnProgressChanged(input_path, State.GENERATING);
            //

            var converion = FFmpeg.Conversions.New().AddStream(videoStream).SetOutput(output_path);

            if (!param.deleteAudio)
                converion.AddStream(audioStream);

            var res = await converion.Start();

            //
            OnProgressChanged(input_path, State.DONE);
            //
        }

        void OnProgressChanged(string path, State state)
        {
            const int num_of_states = State.DONE - State.PREPARING;
            int current_state = state - State.PREPARING;

            int percentage = (int)(((double)current_state / num_of_states) * 100);

            base.OnProgressChanged(new ProgressEventArgs(path, state.ToString(), currentPercentage, percentage));
        }

        public override string createPreview(Parameters param, string path)
        {
            throw new NotImplementedException();
        }

        public override List<string> getFilesPattern()
        {
            return pattern;
        }
    }
}
