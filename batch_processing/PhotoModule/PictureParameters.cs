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

        [Category("Settings"), DisplayName("Rotate:")]        
        public bool rotate { get; set; }
        
        [Category("Settings"), DisplayName("Rotate Angle:")]        
        public Common.Constants.Rotate angle { get; set; }

        
        [Category("Settings"), DisplayName("Negative:")]        
        public bool negative {  get; set; }
        [Category("Settings"), DisplayName("Edges:")]        
        public bool edges {  get; set; }

        public bool previewPath { get; set; }
    }
}
