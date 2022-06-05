using Aspose.Words;

using batch_processing.Common;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace batch_processing.Doc
{
    internal class DocModule : Common.ProcessModule
    {
        static List<string> pattern = new List<string> { "*.docx" };
        int currentPercentage;

        enum State { PREPARING = 0, WATERMARK, MERGING, AUTHORING, PAGESETUPING, DONE, UNKNOWN = -1 };

        public DocModule() : base()
        {
            ModuleName = "Document";
            DefaultExt = ".docx";
        }

        public bool LicenseIt()
        {
            try
            {
                License license = new License();
                license.SetLicense(@"License.txt");

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public override string createPreview(Parameters param, string path, bool filters)
        {
            return "";
        }

        public override List<string> getFilesPattern()
        {
            return pattern;
        }

        public override void process(Parameters param, List<string> paths)
        {
            DocParameters ac_param = (DocParameters)param;

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

        private void processFile(string input_path, string output_path, DocParameters doc_param)
        {
            //
            OnProgressChanged(input_path, State.PREPARING);
            //

            Document doc = new Document(input_path);

            //
            OnProgressChanged(input_path, State.WATERMARK);
            //

            if (doc_param.watermarkEnableText)
                AddWaterMarkText(ref doc, doc_param);

            if (doc_param.watermarkEnableImage)
                AddWaterMarkImage(ref doc, doc_param);

            //
            OnProgressChanged(input_path, State.MERGING);
            //

            if (doc_param.appendDoc)
                AddDocument(ref doc, doc_param);

            //
            OnProgressChanged(input_path, State.AUTHORING);
            //

            if (doc_param.changeAuthor)
                SetAuthor(ref doc, doc_param);

            //
            OnProgressChanged(input_path, State.PAGESETUPING);
            //

            if (doc_param.changeAuthor)
                SetPageSetup(ref doc, doc_param);

            //
            OnProgressChanged(input_path, State.DONE);
            //

            doc.Save(output_path);
        }

        private void OnProgressChanged(string path, State state)
        {
            const int num_of_states = State.DONE - State.PREPARING;
            int current_state = state - State.PREPARING;

            int percentage = (int)(((double)current_state / num_of_states) * 100);

            base.OnProgressChanged(new ProgressEventArgs(path, state.ToString(), currentPercentage, percentage));
        }

        private void AddWaterMarkText(ref Document doc, DocParameters doc_param)
        {
            TextWatermarkOptions options = new TextWatermarkOptions()
            {
                FontFamily = doc_param.watermarkFontFamily,
                FontSize = doc_param.watermarkFontSize,
                Color = doc_param.watermarkColor,
                Layout = doc_param.watermarkLayout,
                IsSemitrasparent = doc_param.watermarkTrans
            };

            doc.Watermark.SetText(doc_param.watermarkText, options);
        }

        private void AddWaterMarkImage(ref Document doc, DocParameters doc_param)
        {
            if (!File.Exists(doc_param.watermarkImagePath))
                return;

            ImageWatermarkOptions options = new ImageWatermarkOptions()
            {
                IsWashout = doc_param.watermarkWashOut
            };

            doc.Watermark.SetImage(Image.FromFile(doc_param.watermarkImagePath), options);
        }

        private void AddDocument(ref Document doc, DocParameters doc_param)
        {
            if (!File.Exists(doc_param.appendDocPath))
                return;

            Document append_doc = new Document(doc_param.appendDocPath);

            doc.AppendDocument(append_doc, doc_param.appendMode);
        }

        private void SetPageSetup(ref Document doc, DocParameters doc_param)
        {
            foreach (Section section in doc.Sections)
            {
                section.PageSetup.PageStartingNumber = doc_param.numberingFrom;
                section.PageSetup.PageNumberStyle = doc_param.number;
                
                if (doc_param.borders)
                {
                    section.PageSetup.Borders.LineStyle = doc_param.bordersLineStyle;
                    section.PageSetup.Borders.LineWidth = doc_param.bordersLineWidth;
                }

                if (doc_param.footerDist != -1)
                    section.PageSetup.FooterDistance = doc_param.footerDist;

                if (doc_param.headerDist != -1)
                    section.PageSetup.HeaderDistance = doc_param.headerDist;

                section.PageSetup.Orientation = doc_param.orientation;

                if (doc_param.changeMargins)
                {
                    section.PageSetup.BottomMargin = doc_param.marginBottom;
                    section.PageSetup.TopMargin = doc_param.marginTop;
                    section.PageSetup.LeftMargin = doc_param.marginLeft;
                    section.PageSetup.RightMargin = doc_param.marginRight;
                }
            }
        }

        private void SetAuthor(ref Document doc, DocParameters doc_param)
        {
            doc.BuiltInDocumentProperties.Author = doc_param.newAuthor;
        }
    }
}
