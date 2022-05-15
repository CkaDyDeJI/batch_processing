using System;

namespace batch_processing.Common.Constants
{
    internal static class Paths
    {
        public static string BINARY_PATH;
        public static string INPUT_PATH;
        public static string OUTPUT_PATH;
        public static string TEMP_PATH;

        static Paths()
        {
            BINARY_PATH = AppDomain.CurrentDomain.BaseDirectory;
            INPUT_PATH = BINARY_PATH;
            OUTPUT_PATH = BINARY_PATH;
            TEMP_PATH = BINARY_PATH + "temp\\";
        }
    }
}
