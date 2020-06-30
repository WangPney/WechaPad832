namespace System
{
    public static class Int32Extension
    {
        public static string ToString(this int value, int radix)
        {
            return ((ulong)value).ToString(radix);
        }

        public static byte[] ToByteArray(this int value, Endian endian)
        {
            return ((uint)value).ToByteArray(endian);
        }

        public static int Reverse(this int value)
        {
            return (int)((uint)value).Reverse();
        }
    }
}
