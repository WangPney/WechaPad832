using System.Text;

namespace System
{
    public static class UInt64Extension
    {
        public static string ToString(this ulong value, int radix)
        {
            if (radix < 2 && radix > 36)
                throw new ArgumentException("The radix was not supported.");
            StringBuilder stringBuilder = new StringBuilder();
            do
            {
                ulong num1 = value / (ulong)radix;
                ulong num2 = value - num1 * (ulong)radix;
                if (num2 < 10UL)
                    stringBuilder.Insert(0, num2);
                else
                    stringBuilder.Insert(0, (char)(65UL + num2 - 10UL));
                value = num1;
            }
            while (value > 0UL);
            return stringBuilder.ToString();
        }

        public static byte[] ToByteArray(this ulong value, Endian endian)
        {
            return endian == Endian.Little ? new byte[8]
            {
        (byte) value,
        (byte) (value >> 8),
        (byte) (value >> 16),
        (byte) (value >> 24),
        (byte) (value >> 32),
        (byte) (value >> 40),
        (byte) (value >> 48),
        (byte) (value >> 56)
            } : new byte[8]
            {
        (byte) (value >> 56),
        (byte) (value >> 48),
        (byte) (value >> 40),
        (byte) (value >> 32),
        (byte) (value >> 24),
        (byte) (value >> 16),
        (byte) (value >> 8),
        (byte) value
            };
        }

        public static ulong Reverse(this ulong value)
        {
            ulong num = 0;
            for (int index = 0; index < 64; ++index)
            {
                num = num << 1 | value & 1UL;
                value >>= 1;
            }
            return num;
        }
    }
}
