using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenCvSharp;
using Numpy;
using batch_processing.Common.Constants;
using batch_processing.Common;

namespace batch_processing.Photo
{
    internal class PictureModule : Common.ProcessModule
    {
        const string symbols = "abcdefghijklmnopqrstuvwxyz0123456789";
        static Random rnd = new Random();
        static List<string> pattern = new List<string> { "*.png", "*.jpg" };

        public override void process(Common.Parameters param, List<string> paths)
        {
            PictureParameters ac_param = (PictureParameters)param;

            for (int i = 0; i < paths.Count; ++i)
            {
                string path = paths[i];
                
                if (ac_param.rename)
                    path = Path.GetDirectoryName(path) + "\\" + ac_param.name + i.ToString() + Path.GetExtension(path);

                processFile(paths[i], path, ac_param);
            }

            return;
        }

        public override string createPreview(Parameters param, string path)
        {
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

        private string processFile(string path, string out_path, PictureParameters param)
        {
            var img = Cv2.ImRead(path);

            if (img.Channels() == 3)
                Cv2.CvtColor(img, img, ColorConversionCodes.RGB2RGBA);
            else if (img.Channels() == 1)
                Cv2.CvtColor(img, img, ColorConversionCodes.GRAY2RGBA);

            if (param.waterMark)
                addWaterMark(ref img, param.wmPath, param.position);

            if (param.rotate)
                rotateImg(ref img, param.angle);

            if (param.negative)
                negativeImg(ref img);

            if (param.edges && !param.negative)
                edgeImg(ref img);

            Cv2.ImWrite(out_path, img);

            return out_path;
        }

        protected override string generateFileName()
        {
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < 16; ++i)
                str.Append(symbols[rnd.Next(0, symbols.Length)]);

            return "temp_picture_" + str.ToString() + ".png";
        }

        private void addWaterMark(ref Mat img, string wmPath, Position pos)
        {
            var watermark = Cv2.ImRead(wmPath, ImreadModes.Unchanged);

            var height = img.Height;
            var width = img.Width;
            var blank = Mat.Zeros(img.Rows, img.Cols, MatType.CV_8UC4);

            var M = Cv2.GetRotationMatrix2D(new Point2f(watermark.Cols, watermark.Rows), 0, 1);

            Cv2.WarpAffine(watermark, watermark, M, new Size(width, height));
            Cv2.CvtColor(watermark, watermark, ColorConversionCodes.RGB2RGBA);
            Cv2.Add(blank, watermark, watermark);

            Cv2.AddWeighted(watermark, 0.4, img, 1.0, 0, img);
        }

        private void rotateImg(ref Mat img, Rotate angle)
        {
            Cv2.Rotate(img, img, (RotateFlags)angle);
        }

        private void negativeImg(ref Mat img)
        {
            img = 255 - img;
        }

        private void edgeImg(ref Mat img)
        {
            img = img.Canny(50, 200);
            //Cv2.Canny(img, img, 50, 200);
        }
    }
}
