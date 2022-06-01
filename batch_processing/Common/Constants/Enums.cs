namespace batch_processing.Common.Constants
{
    public enum ModuleType
    {
        Photo,
        Video,
        Audio
    }

    public enum Position
    {
        BottomLeft,
        BottomRight,
        TopLeft,
        TopRight
    }

    public enum Rotate
    {
        ROTATE_90,
        ROTATE_180,
        ROTATE_90_NEG,
        NONE
    }

    public enum Flip
    {
        HORIZONTAL = 0,
        VERTICAL = 1,
        BOTH = -1,
        NONE = -2
    }

    public enum Convert
    {
        MP4,
        MKV,
        NONE = -1
    }

    public enum CutPosition
    {
        START,
        END,
        MIDDLE,
        NONE = -1
    }
}
