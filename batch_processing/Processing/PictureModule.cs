using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenCvSharp;
using Numpy;

namespace batch_processing
{
    internal class PictureModule : ProcessModule
    {
        public override void process(Parameters param, List<string> paths)
        {
            PictureParameters ac_param = (PictureParameters)param;

            for (int i = 0; i < paths.Count; ++i)
            {
                processFile(paths[i], ac_param, i);
            }

            return;
        }

        public override List<string> getFilesPattern()
        {
            return new List<string> { "*.png", "*.jpg" };
        }

        private void processFile(string path, PictureParameters param, int num)
        { 
            var img = Cv2.ImRead(path);
            if (img.Channels() == 3)
            {
                Cv2.CvtColor(img, img, ColorConversionCodes.RGB2RGBA);
            }

            if (param.waterMark)
                addWaterMark(ref img, param.wmPath, param.position);

            if (param.rename)
                path = Path.GetDirectoryName(path) + "\\" + param.name + num.ToString() + Path.GetExtension(path);

            if (param.rotate)
                rotateImg(ref img, param.angle);

            if (param.negative)
                negativeImg(ref img);

            if (param.edges && !param.negative)
                edgeImg(ref img);

            Cv2.ImWrite(path, img);
        }

        private void addWaterMark(ref Mat img, string wmPath, PictureParameters.Position pos)
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

        private void rotateImg(ref Mat img, PictureParameters.Rotate angle)
        {
            Cv2.Rotate(img, img, (RotateFlags)angle);
        }

        private void negativeImg(ref Mat img)
        {
            img = 255 - img;
        }

        private void edgeImg(ref Mat img)
        {
            Cv2.Canny(img, img, 50, 200);
        }

        private Mat addAlpha(Mat src, Mat alpha)
        {
            if (src.Channels() == 4)
            {
                return src;
            }
            else if (src.Channels() == 1)
            {
                Cv2.CvtColor(src, src, ColorConversionCodes.GRAY2RGB);
            }

            Mat dst = new Mat(src.Rows, src.Cols, MatType.CV_8UC4);

            Mat[] srcChannels;
            Mat[] dstChannels = new Mat[4];

            Cv2.Split(src, out srcChannels);

            dstChannels[0] = srcChannels[0];
            dstChannels[1] = srcChannels[1];
            dstChannels[2] = srcChannels[2];
            dstChannels[3] = alpha;

            Cv2.Merge(dstChannels, dst);

            return dst;
        }

        private Mat createAlpha(Mat src)
        {
            Mat alpha = Mat.Zeros(src.Rows, src.Cols, MatType.CV_8UC1);
            Mat gray = Mat.Zeros(src.Rows, src.Cols, MatType.CV_8UC1);

            Cv2.CvtColor(src, gray, ColorConversionCodes.RGB2GRAY);

            alpha = 255 - gray;

            return alpha;
        }
    }
}
