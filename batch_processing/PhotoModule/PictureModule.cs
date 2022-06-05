using batch_processing.Common;
using batch_processing.Common.Constants;

using OpenCvSharp;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace batch_processing.Photo
{
    internal class PictureModule : Common.ProcessModule
    {
        static List<string> pattern = new List<string> { "*.png", "*.jpg" };
        int currentPercentage;

        enum State { PREPARING = 0, ROTATING, HSVING, MIRRORING, NEGATIVING, EDGING, WATERMARKING, BLURRING, WRITING, DONE, UNKNOWN = -1 };

        public PictureModule()
        {
            ModuleName = "Picture";
            DefaultExt = ".png";
        }

        public override void process(Common.Parameters param, List<string> paths)
        {
            PictureParameters ac_param = (PictureParameters)param;

            for (int i = 0; i < paths.Count; ++i)
            {
                currentPercentage = (int)(((double)i / paths.Count) * 100);
                string path = paths[i];
                
                if (ac_param.rename)
                    path = Path.GetDirectoryName(path) + "\\" + ac_param.name + i.ToString() + Path.GetExtension(path);
                else
                    path = Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path) + i.ToString() + Path.GetExtension(path);

                processFile(paths[i], path, ac_param);
            }

            return;
        }

        public override string createPreview(Parameters param, string path, bool filters)
        {
            if (!filters)
                return path;

            PictureParameters ac_param = (PictureParameters)param;

            string output_path = Common.Constants.Paths.TEMP_PATH;
            if (!Directory.Exists(output_path))
                Directory.CreateDirectory(output_path);

            return processFile(path, output_path + generateFileName(), ac_param);
        }

        public override List<string> getFilesPattern()
        {
            return pattern;
        }

        void OnProgressChanged(string path, State state)
        {
            const int num_of_states = State.DONE - State.PREPARING;
            int current_state = state - State.PREPARING;

            int percentage = (int)(((double)current_state / num_of_states) * 100);

            base.OnProgressChanged(new ProgressEventArgs(path, state.ToString(), currentPercentage, percentage));
        }

        private string processFile(string path, string out_path, PictureParameters param)
        {
            var img = Cv2.ImRead(path);

            //
            OnProgressChanged(path, State.PREPARING);
            //

            addChannels(ref img);

            //
            OnProgressChanged(path, State.ROTATING);
            //

            rotateImg(ref img, param.angle);

            //
            OnProgressChanged(path, State.HSVING);
            //

            saturateImg(ref img, param.hue, param.saturation, param.brightness);

            //
            OnProgressChanged(path, State.MIRRORING);
            //

            mirrorImg(ref img, param.flip);

            //
            OnProgressChanged(path, State.NEGATIVING);
            //

            if (param.negative)
                negativeImg(ref img);

            //
            OnProgressChanged(path, State.EDGING);
            //

            if (param.edges && !param.negative)
                edgeImg(ref img);

            //
            OnProgressChanged(path, State.WATERMARKING);
            //

            blurImg(ref img, param.blur);

            //
            OnProgressChanged(path, State.BLURRING);
            //

            if (param.waterMark)
                addWaterMark(ref img, param.wmPath, param.position);

            //
            OnProgressChanged(path, State.WRITING);
            //

            File.Delete(path);

            Cv2.ImWrite(out_path, img);

            //
            OnProgressChanged(path, State.DONE);
            //

            return out_path;
        }

        private void addChannels(ref Mat img)
        {
            if (img.Channels() == 3)
                Cv2.CvtColor(img, img, ColorConversionCodes.RGB2RGBA);
            else if (img.Channels() == 1)
                Cv2.CvtColor(img, img, ColorConversionCodes.GRAY2RGBA);
        }

        private void addWaterMark(ref Mat img, string wmPath, Position pos)
        {
            if (!File.Exists(wmPath))
                return;

            var watermark = Cv2.ImRead(wmPath, ImreadModes.Unchanged);

            var height = img.Height;
            var width = img.Width;
            var blank = (Mat)Mat.Zeros(height, width, MatType.CV_8UC4);

            int x_start_pos = 0, y_start_pos = 0;

            if (pos == Position.TopRight)
            {
                x_start_pos = Math.Max(0, width - watermark.Width);
                y_start_pos = 0;
            }
            else if (pos == Position.BottomRight)
            {
                x_start_pos = Math.Max(0, width - watermark.Width);
                y_start_pos = Math.Max(0, height - watermark.Height);
            }
            else if (pos == Position.BottomLeft)
            {
                x_start_pos = 0;
                y_start_pos = Math.Max(0, height - watermark.Height);
            }

            watermark.CopyTo(blank[new Rect(x_start_pos, y_start_pos, watermark.Width, watermark.Height)]);

            Cv2.CvtColor(img, img, ColorConversionCodes.RGB2RGBA);
            Cv2.CvtColor(blank, watermark, ColorConversionCodes.RGB2RGBA);

            Cv2.AddWeighted(watermark, 0.4, img, 1.0, 0, img);
        }

        private void rotateImg(ref Mat img, Rotate angle)
        {
            if (angle != Rotate.NONE)
                Cv2.Rotate(img, img, (RotateFlags)angle);
        }

        private void negativeImg(ref Mat img)
        {
            Cv2.CvtColor(img, img, ColorConversionCodes.RGBA2GRAY);

            img = ~img;

            Cv2.CvtColor(img, img, ColorConversionCodes.GRAY2RGBA);
        }

        private void edgeImg(ref Mat img)
        {
            img = img.Canny(50, 200);
        }

        private void saturateImg(ref Mat img, double hue_param, double sat_param, double br_param)
        {
            Cv2.CvtColor(img, img, ColorConversionCodes.RGB2HSV);
            Cv2.Split(img, out Mat[] mv);

            mv[0] = mv[0] * hue_param;
            mv[1] = mv[1] * sat_param;
            mv[2] = mv[2] * br_param;

            Cv2.Merge(mv, img);
            Cv2.CvtColor(img, img, ColorConversionCodes.HSV2RGB);
        }

        private void mirrorImg(ref Mat img, Flip flip)
        {
            if (flip == Flip.NONE)
                return;

            Cv2.Flip(img, img, (FlipMode)flip);
        }

        private void blurImg(ref Mat img, int blur_num)
        {
            blur_num |= 0b1;
            Cv2.GaussianBlur(img, img, new Size(blur_num, blur_num), 0);
        }
    }
}
