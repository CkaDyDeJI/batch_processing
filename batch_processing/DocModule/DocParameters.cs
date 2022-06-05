using Aspose.Words;

using System;
using System.ComponentModel;
using System.Drawing;

namespace batch_processing.Doc
{
    internal class DocParameters : Common.Parameters
    {
        [Category("Watermark Text"), DisplayName("text watermark")]
        public bool watermarkEnableText { get; set; } = false;
        [Category("Watermark Text"), DisplayName("text")]
        public string watermarkText { get; set; } = "CONFIDENTIAL";
        [Category("Watermark Text"), DisplayName("font family")]
        public string watermarkFontFamily { get; set; } = "";
        [Category("Watermark Text"), DisplayName("font size")]
        public int watermarkFontSize { get; set; } = 32;
        [Category("Watermark Text"), DisplayName("text color")]
        public Color watermarkColor { get; set; } = Color.Black;
        [Category("Watermark Text"), DisplayName("semi transparent")]
        public bool watermarkTrans { get; set; } = true;
        [Category("Watermark Text"), DisplayName("Orientation")]
        public WatermarkLayout watermarkLayout { get; set; } = WatermarkLayout.Diagonal;

        [Category("Watermark Image"), DisplayName("image")]
        public bool watermarkEnableImage { get; set; } = false;
        [Category("Watermark Image"), DisplayName("image path")]
        [EditorAttribute(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string watermarkImagePath { get; set; } = "";
        [Category("Watermark Image"), DisplayName("washout")]
        public bool watermarkWashOut { get; set; } = false;
        
        [Category("Rename"), DisplayName("rename")]
        public bool rename { get; set; } = false;
        [Category("Rename"), DisplayName("new path")]
        public string output { get; set; }

        [Category("Merge"), DisplayName("merge")]
        public bool appendDoc { get; set; } = false;
        [Category("Merge"), DisplayName("path to doc")]
        public string appendDocPath { get; set; } = "";
        [Category("Merge"), DisplayName("append mode")]
        public ImportFormatMode appendMode { get; set; } = ImportFormatMode.KeepSourceFormatting;

        [Category("Author"), DisplayName("change author")]
        public bool changeAuthor { get; set; } = false;
        [Category("Author"), DisplayName("new author")]
        public string newAuthor { get; set; } = "";

        [Category("Page Setup"), DisplayName("numbering from")]
        public int numberingFrom { get; set; } = 1;
        [Category("Page Setup"), DisplayName("Page numbering style")]
        public NumberStyle number { get; set; } = NumberStyle.Arabic;
        [Category("Page Setup"), DisplayName("Borders")]
        public bool borders { get; set; } = false;
        [Category("Page Setup"), DisplayName("Borders Line Style")]
        public LineStyle bordersLineStyle { get; set; } = LineStyle.None;
        [Category("Page Setup"), DisplayName("Borders Line Width")]
        public double bordersLineWidth { get; set; } = 1;
        [Category("Page Setup"), DisplayName("Footer Distance")]
        public double footerDist { get; set; } = -1;
        [Category("Page Setup"), DisplayName("Header Distance")]
        public double headerDist { get; set; } = -1;
        [Category("Page Setup"), DisplayName("Orientation")]
        public Orientation orientation { get; set; } = Orientation.Portrait;
        [Category("Page Setup"), DisplayName("change page margins")]
        public bool changeMargins { get; set; } = false;
        [Category("Page Setup"), DisplayName("Margin Bottom")]
        public double marginBottom { get; set; } = -1;
        [Category("Page Setup"), DisplayName("Margin Top")]
        public double marginTop { get; set; } = -1;
        [Category("Page Setup"), DisplayName("Margin Left")]
        public double marginLeft { get; set; } = -1;
        [Category("Page Setup"), DisplayName("Margin Right")]
        public double marginRight { get; set; } = -1;

    }
}
