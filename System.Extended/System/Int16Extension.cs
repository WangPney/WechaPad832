namespace System
{
    public static class Int16Extension
    {
        public static string ToString(this short value, int radix)
        {
            return ((ulong)value).ToString(radix);
        }

        public static byte[] ToByteArray(this short value, Endian endian)
        {
            return ((ushort)value).ToByteArray(endian);
        }

        public static short Reverse(this short value)
        {
            return (short)((ushort)value).Reverse();
        }
    }
}
