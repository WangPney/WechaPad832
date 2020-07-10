using System.Linq;
using System.Runtime.InteropServices;

namespace Wechat.Protocol.Andriod
{
	public class DeflateCompression
	{
		[DllImport("Common.dll")]
		private static extern int Zip(byte[] srcByte, int srcLen, byte[] dstByte, int dstLen);

		[DllImport("Common.dll")]
		private static extern int UnZip(byte[] srcByte, int srcLen, byte[] dstByte, int dstLen);

		public static byte[] DeflateZip(byte[] srcByte)
		{
			byte[] array = new byte[srcByte.Length + 100];
			int count = Zip(srcByte, srcByte.Length, array, array.Length);
			return array.Take(count).ToArray();
		}

		public static byte[] DeflateUnZip(byte[] srcByte)
		{
			byte[] array = new byte[204800];
			int count = UnZip(srcByte, srcByte.Length, array, array.Length);
			return array.Take(count).ToArray();
		}

		public static byte[] DeflateLBSUnzip(byte[] srcByte)
		{
			byte[] array = new byte[256000];
			int count = UnZip(srcByte, srcByte.Length, array, array.Length);
			return array.Take(count).ToArray();
		}
	}
}
