using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace batch_processing
{
    internal class PictureParameters : Parameters
    {
        public enum Position 
        {
            BL,
            BR,
            UL,
            UR
        }

        public enum Rotate
        {
            ROTATE_90,
            ROTATE_180,
            ROTATE_90_NEG
        }

        public bool waterMark { get; set; }
        public string wmPath { get; set; }
        public Position position {  get; set; }

        public bool rename { get; set; }
        public string name {  get; set; }

        public bool rotate { get; set; }
        public Rotate angle { get; set; }

        public bool negative {  get; set; }
        public bool edges {  get; set; }
    }
}
