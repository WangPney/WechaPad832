namespace System
{
    public static class ArrayExtension
    {
        public static T[] Resize<T>(this T[] array, int size)
        {
            Array.Resize<T>(ref array, size);
            return array;
        }

        public static T[] Copy<T>(this T[] array)
        {
            return array.Copy<T>(0L, array.LongLength);
        }

        public static T[] Copy<T>(this T[] array, int length)
        {
            return array.Copy<T>(0, length);
        }

        public static T[] Copy<T>(this T[] array, long length)
        {
            return array.Copy<T>(0L, length);
        }

        public static T[] Copy<T>(this T[] array, int index, int length)
        {
            return array.Copy<T>((long)index, (long)length);
        }

        public static T[] Copy<T>(this T[] array, long index, long length)
        {
            T[] objArray = new T[length];
            Array.Copy((Array)array, index, (Array)objArray, 0L, length);
            return objArray;
        }

        public static T[] ReverseCopy<T>(this T[] array)
        {
            return array.ReverseCopy<T>(array.LongLength - 1L, array.LongLength);
        }

        public static T[] ReverseCopy<T>(this T[] array, int length)
        {
            return array.ReverseCopy<T>(length - 1, length);
        }

        public static T[] ReverseCopy<T>(this T[] array, long length)
        {
            return array.ReverseCopy<T>(length - 1L, length);
        }

        public static T[] ReverseCopy<T>(this T[] array, int index, int length)
        {
            return array.ReverseCopy<T>((long)index, (long)length);
        }

        public static T[] ReverseCopy<T>(this T[] array, long index, long length)
        {
            T[] objArray = new T[length];
            for (int index1 = 0; (long)index1 < length; ++index1)
                objArray[index1] = array[index--];
            return objArray;
        }

        public static T[] Reverse<T>(this T[] array)
        {
            Array.Reverse((Array)array);
            return array;
        }

        public static T[] Reverse<T>(this T[] array, int index, int count)
        {
            Array.Reverse((Array)array, index, count);
            return array;
        }

        public static int IndexOf<T>(this T[] array, T[] value)
        {
            return array.IndexOf<T>(value, 0, array.Length);
        }

        public static int IndexOf<T>(this T[] array, T[] value, ref int[] next)
        {
            return array.IndexOf<T>(value, 0, array.Length, ref next);
        }

        public static int IndexOf<T>(this T[] array, T[] value, int index)
        {
            return array.IndexOf<T>(value, index, array.Length - index);
        }

        public static int IndexOf<T>(this T[] array, T[] value, int index, ref int[] next)
        {
            return array.IndexOf<T>(value, index, array.Length - index, ref next);
        }

        public static int IndexOf<T>(this T[] array, T[] value, int index, int count)
        {
            int[] next = (int[])null;
            return array.IndexOf<T>(value, index, count, ref next);
        }

        public static int IndexOf<T>(this T[] array, T[] value, int index, int count, ref int[] next)
        {
            int index1 = 0;
            int startIndex1 = -1;
            if (next == null)
            {
                next = new int[value.Length];
                next[0] = -1;
                while (index1 < value.Length - 1)
                {
                    if (startIndex1 == -1 || Array.IndexOf<T>(value, value[index1], startIndex1, 1) >= 0)
                        next[index1] = Array.IndexOf<T>(value, value[++index1], ++startIndex1, 1) < 0 ? startIndex1 : next[startIndex1];
                    else
                        startIndex1 = next[startIndex1];
                }
            }
            int startIndex2 = index;
            int index2 = 0;
            while (startIndex2 < index + count && index2 < value.Length)
            {
                if (index2 == -1 || Array.IndexOf<T>(array, value[index2], startIndex2, 1) >= 0)
                {
                    ++startIndex2;
                    ++index2;
                }
                else
                    index2 = next[index2];
            }
            return index2 < value.Length ? -1 : startIndex2 - value.Length;
        }
    }
}
