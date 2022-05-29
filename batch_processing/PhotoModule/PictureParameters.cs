using System.ComponentModel;

namespace batch_processing.Photo
{
    internal class PictureParameters : Common.Parameters
    {
        [Category("WaterMark"), DisplayName("Watermark:")]
        public bool waterMark { get; set; }

        [Category("WaterMark"), DisplayName("Path to watermark file:")]
        [EditorAttribute(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string wmPath { get; set; }

        [Category("WaterMark"), DisplayName("Watermark position:")]
        public Common.Constants.Position position {  get; set; }

        [Category("Rename"), DisplayName("Rename:")]
        public bool rename { get; set; }
        
        [Category("Rename"), DisplayName("New name:")]
        public string name {  get; set; }

        [Category("Settings"), DisplayName("Rotate Angle:")]
        public Common.Constants.Rotate angle { get; set; } = Common.Constants.Rotate.NONE;

        [Category("Settings"), DisplayName("Negative:")]        
        public bool negative {  get; set; }
        [Category("Settings"), DisplayName("Edges:")]        
        public bool edges {  get; set; }
        [Category("Settings"), DisplayName("Flip:")]
        public Common.Constants.Flip flip { get; set; } = Common.Constants.Flip.NONE;
        [Category("Settings"), DisplayName("Blur:")]
        public int blur { get; set; } = 0;

        [Category("Settings"), DisplayName("Hue (0, 180):")]
        public double hue { get; set; } = 1;
        [Category("Settings"), DisplayName("Saturation (0, 100):")]
        public double saturation { get; set; } = 1;
        [Category("Settings"), DisplayName("Brightness (0, 100):")]
        public double brightness { get; set; } = 1;
    }
}
