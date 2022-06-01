using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xabe.FFmpeg;

namespace batch_processing.Video
{
    internal class VideoParameters : Common.Parameters
    {
        [Category("Convert"), DisplayName("Convert")]
        public Common.Constants.Convert convert { get; set; } = Common.Constants.Convert.NONE;
        [Category("Change speed"), DisplayName("Speed multiplier")]
        public int speedUp { get; set; } = 1;
        [Category("Delete audio"), DisplayName("deletion")]
        public bool deleteAudio { get; set; } = false;
        [Category("Reverse"), DisplayName("reverse")]
        public bool reverse { get; set; } = false;
        [Category("Set Framerate"), DisplayName("framerate")]
        public int framerate { get; set; } = 30;
        [Category("Set Framerate"), DisplayName("enable")]
        public bool changeFramerate { get; set; } = false;
        [Category("Cut"), DisplayName("cut from")]
        public int cutStart { get; set; } = 0;
        [Category("Cut"), DisplayName("cut length (sec)")]
        public int cutLength { get; set; } = -1; 
        [Category("Set codec"), DisplayName("Codec")]
        public VideoCodec codec { get; set; } = VideoCodec.h264;
        [Category("Set codec"), DisplayName("enable")]
        public bool changeCodec { get; set; } = false;
        [Category("Set Bitrate"), DisplayName("bitrate")]
        public int bitrate { get; set; } = -1;
        [Category("Watermark"), DisplayName("path")]
        [EditorAttribute(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string pathToWatermark { get; set; }
        [Category("Watermark"), DisplayName("place")]
        public bool watermark { get; set; } = false;
        [Category("Watermark"), DisplayName("Position")]
        public Position position { get; set; } = Position.UpperLeft;
        [Category("Size"), DisplayName("Width")]
        public int width { get; set; }
        [Category("Size"), DisplayName("Height")]
        public int height { get; set; }
        [Category("Size"), DisplayName("Resize")]
        public bool resize { get; set; } = false;
        [Category("Rename"), DisplayName("rename")]
        public bool rename { get; set; } = false; 
        [Category("Rename"), DisplayName("new path")]
        public string output { get; set; }
    }
}
