using System;
using System.IO;
using zlib;

namespace CRYPT
{
	public static class ZipUtils
	{
		public static void CopyStream(Stream input, Stream output)
		{
			byte[] buffer = new byte[2000];
			int count;
			while ((count = input.Read(buffer, 0, 2000)) > 0)
			{
				output.Write(buffer, 0, count);
			}
			output.Flush();
		}

		public static byte[] compressBytes(byte[] sourceByte)
		{
			MemoryStream memoryStream = new MemoryStream(sourceByte);
			Stream stream = ZipUtils.compressStream(memoryStream);
			byte[] array = new byte[stream.Length];
			stream.Position = 0L;
			stream.Read(array, 0, array.Length);
			stream.Close();
			memoryStream.Close();
			return array;
		}

		public static byte[] deCompressBytes(byte[] sourceByte)
		{
			MemoryStream memoryStream = new MemoryStream(sourceByte);
			Stream stream = ZipUtils.deCompressStream(memoryStream);
			byte[] array = new byte[stream.Length];
			stream.Position = 0L;
			stream.Read(array, 0, array.Length);
			stream.Close();
			memoryStream.Close();
			return array;
		}

		public static Stream compressStream(Stream sourceStream)
		{
			MemoryStream memoryStream = new MemoryStream();
			ZOutputStream zOutputStream = new ZOutputStream(memoryStream, -1);
			ZipUtils.CopyStream(sourceStream, zOutputStream);
			zOutputStream.finish();
			return memoryStream;
		}

		public static Stream deCompressStream(Stream sourceStream)
		{
			MemoryStream memoryStream = new MemoryStream();
			ZOutputStream zOutputStream = new ZOutputStream(memoryStream);
			ZipUtils.CopyStream(sourceStream, zOutputStream);
			zOutputStream.finish();
			return memoryStream;
		}
	}
}
