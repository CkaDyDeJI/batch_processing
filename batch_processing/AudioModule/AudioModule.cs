using batch_processing.Common;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Xabe.FFmpeg;

namespace batch_processing.Audio
{
    internal class AudioModule : Common.ProcessModule
    {
        static List<string> pattern = new List<string> { "*.mp3", "*.wav" };
        int currentPercentage;

        enum State { PREPARING = 0, CUTTING, SPEEDINGUP, REVERSING, CODEC, BITRATE, GENERATING, DONE, UNKNOWN = -1 };

        public AudioModule() : base()
        {
            ModuleName = "Audio";
            DefaultExt = ".mp3";
        }

        public override void process(Parameters param, List<string> paths)
        {
            AudioParameters ac_param = (AudioParameters)param;

            for (int i = 0; i < paths.Count; ++i)
            {
                currentPercentage = (int)(((double)i / paths.Count) * 100);

                string path = paths[i];
                if (ac_param.rename)
                    path = Path.GetDirectoryName(path) + "\\" + ac_param.output + i.ToString() + Path.GetExtension(path);
                else
                    path = Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path) + i.ToString() + Path.GetExtension(path);

                if (File.Exists(path))
                    File.Delete(path);

                processFile(paths[i], path, ac_param);
            }

            return;
        }

        private void processFile(string input_path, string output_path, AudioParameters param)
        {
            var task = Task.Run(() => FFmpeg.GetMediaInfo(input_path));
            task.Wait();

            IMediaInfo inputFile = task.Result;

            //
            OnProgressChanged(input_path, State.PREPARING);
            //

            IAudioStream audioStream = inputFile.AudioStreams.First();

            //
            OnProgressChanged(input_path, State.CUTTING);
            //

            if (param.cutLength != -1)
                audioStream.Split(new TimeSpan(0, 0, param.cutStart), new TimeSpan(0, 0, param.cutLength));

            //
            OnProgressChanged(input_path, State.SPEEDINGUP);
            //

            if (param.speedUp != 1)
                audioStream.ChangeSpeed(param.speedUp);

            //
            OnProgressChanged(input_path, State.REVERSING);
            //

            if (param.reverse)
                audioStream.Reverse();

            //
            OnProgressChanged(input_path, State.CODEC);
            //

            if (param.changeCodec)
                audioStream.SetCodec(param.codec);

            //
            OnProgressChanged(input_path, State.BITRATE);
            //

            if (param.bitrate != -1)
                audioStream.SetBitrate(param.bitrate);

            //
            OnProgressChanged(input_path, State.GENERATING);
            //

            var res_task = Task.Run(() => FFmpeg.Conversions.New().AddStream(audioStream).SetOutput(output_path).Start());
            res_task.Wait();

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

        public override string createPreview(Parameters param, string path, bool filters)
        {
            throw new NotImplementedException();
        }

        public override List<string> getFilesPattern()
        {
            return pattern;
        }        
    }
}
