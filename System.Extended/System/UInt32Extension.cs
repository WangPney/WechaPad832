namespace System
{
    public static class UInt32Extension
    {
        public static string ToString(this uint value, int radix)
        {
            return ((ulong)value).ToString(radix);
        }

        public static byte[] ToByteArray(this uint value, Endian endian)
        {
            return endian == Endian.Little ? new byte[4]
            {
        (byte) value,
        (byte) (value >> 8),
        (byte) (value >> 16),
        (byte) (value >> 24)
            } : new byte[4]
            {
        (byte) (value >> 24),
        (byte) (value >> 16),
        (byte) (value >> 8),
        (byte) value
            };
        }

        public static uint Reverse(this uint value)
        {
            uint num = 0;
            for (int index = 0; index < 32; ++index)
            {
                num = num << 1 | value & 1U;
                value >>= 1;
            }
            return num;
        }
    }
}
