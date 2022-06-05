using System.ComponentModel;

using Xabe.FFmpeg;

namespace batch_processing.Audio
{
    internal class AudioParameters : Common.Parameters
    {
        [Category("Change speed"), DisplayName("Speed multiplier")]
        public int speedUp { get; set; } = 1;
        [Category("Reverse"), DisplayName("reverse")]
        public bool reverse { get; set; } = false;
        [Category("Cut"), DisplayName("cut from")]
        public int cutStart { get; set; } = 0;
        [Category("Cut"), DisplayName("cut length (sec)")]
        public int cutLength { get; set; } = -1;
        [Category("Set codec"), DisplayName("Codec")]
        public AudioCodec codec { get; set; } = AudioCodec.aac;
        [Category("Set codec"), DisplayName("enable")]
        public bool changeCodec { get; set; } = false;
        [Category("Set Bitrate"), DisplayName("bitrate")]
        public int bitrate { get; set; } = -1;
        [Category("Rename"), DisplayName("rename")]
        public bool rename { get; set; } = false;
        [Category("Rename"), DisplayName("new path")]
        public string output { get; set; }
    }
}
