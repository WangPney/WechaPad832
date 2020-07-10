using System.Collections.Generic;
using System.Linq;

namespace Wechat.Protocol.Andriod
{
	public class ConstructPacket
	{
		public static byte[] AuthRequestPacket(int lengthBeforeZip, int lengthAfterZip, byte[] rsaDataPacket, string deviceID, ushort cmd)
		{
			byte[] first = new byte[10]
			{
				78,
				112,
				38,
				5,
				16,
				52,
				0,
				0,
				0,
				0
			};
			byte[] second = new byte[3]
			{
				174,
				1,
				2
			};
			byte[] array = first.Concat(toVariant(cmd)).Concat(toVariant(lengthBeforeZip)).Concat(toVariant(lengthAfterZip))
				.Concat(second)
				.ToArray();
			int num = array.Length;
			array[0] = (byte)(num * 4 + 2);
			return array.Concat(rsaDataPacket).ToArray();
		}

		public static byte[] QRCodeRequestPacket(int lengthBeforeZip, int lengthAfterZip, byte[] rsaDataPacket, string deviceID, ushort cmd)
		{
			byte[] first = new byte[10]
			{
				78,
				112,
				38,
				5,
				16,
				52,
				0,
				0,
				0,
				0
			};
			byte[] second = new byte[3]
			{
				137,
				1,
				2
			};
			byte[] array = first.Concat(toVariant(cmd)).Concat(toVariant(lengthBeforeZip)).Concat(toVariant(lengthAfterZip))
				.Concat(second)
				.ToArray();
			int num = array.Length;
			array[0] = (byte)(num * 4 + 1);
			return array.Concat(rsaDataPacket).ToArray();
		}

		public static byte[] RegRequestPacket(int lengthBeforeZip, int lengthAfterZip, byte[] rsaDataPacket, string deviceID, int cmd)
		{
			byte[] first = new byte[11]
			{
				191,
				133,
				16,
				38,
				6,
				6,
				54,
				0,
				0,
				0,
				0
			};
			byte[] second = new byte[8]
			{
				174,
				1,
				2,
				0,
				1,
				35,
				50,
				32
			};
			byte[] array = first.Concat(toVariant(cmd)).Concat(toVariant(lengthBeforeZip)).Concat(toVariant(lengthAfterZip))
				.Concat(second)
				.ToArray();
			int num = array.Length;
			array[1] = (byte)(num * 4 + 1);
			return array.Concat(rsaDataPacket).ToArray();
		}

		public static byte[] CommonRequestPacket(int lengthBeforeZip, int lengthAfterZip, byte[] aesDataPacket, uint uin, string deviceID, short cmd, short cmd2, byte[] cookie, uint check)
		{
			byte[] first = new byte[7]
			{
				191,
				98,
				80,
				38,
				6,
				6,
				54
			};
			byte[] second = new byte[1]
			{
				2
			};
			byte[] array = first.Concat(new byte[4]
			{
				(byte)(((uint)((int)uin & -16777216) >> 24) & 0xFF),
				(byte)(((uin & 0xFF0000) >> 16) & 0xFF),
				(byte)(((uin & 0xFF00) >> 8) & 0xFF),
				(byte)(uin & 0xFF & 0xFF)
			}).Concat(cookie).Concat(toVariant(cmd2))
				.Concat(toVariant(lengthBeforeZip))
				.Concat(toVariant(lengthAfterZip))
				.Concat(toVariant(10000))
				.Concat(second)
				.Concat(toVariant((int)check))
				.Concat(toVariant(16794983))
				.ToArray();
			int num = array.Length;
			array[1] = (byte)(num * 4 + 1);
			array[2] = (byte)(80 + cookie.Length);
			return array.Concat(aesDataPacket).ToArray();
		}

		private static byte[] toVariant(int toValue)
		{
			uint num = (uint)toValue;
			List<byte> list = new List<byte>();
			while (num >= 128)
			{
				list.Add((byte)(128 + num % 128u));
				num /= 128u;
			}
			list.Add((byte)(num % 128u));
			return list.ToArray();
		}
	}
}
