using System;
using System.Linq;
using System.Security.Cryptography;

namespace CRYPT
{
	public static class LBS_RSA
	{
		private static byte[] LBSPubKey = "E8AA7E72F02D43D20F0B56BFCB4A608188D242E1374FB076BEA9606EABFC4486FD35315CC8A0DE5573C519D2A2E30DE5A1E3AD8EBB63ECE84E8ED42F95493071B4BAE9CC13B107F88050A830E707B81BC90D8A3795BA656BA3F028BD47AA50946B31591204C6E9FCED5665F88AEDB40DD14C45CE941ED23F0767D8701969E349".ToByteArray(16, 2);

		public static byte[] EncodeKey(byte[] data)
		{
			byte[] result;
			using (RSA rSA = RSA.Create())
			{
				byte[] array = new byte[0];
				rSA.ImportParameters(new RSAParameters
				{
					Exponent = "010001".ToByteArray(16, 2),
					Modulus = LBS_RSA.LBSPubKey
				});
				int num = rSA.KeySize;
				num /= 8;
				bool flag = data.Length > num - 12;
				if (flag)
				{
					int num2 = data.Length / (num - 12) + ((data.Length % (num - 12) == 0) ? 0 : 1);
					for (int i = 0; i < num2; i++)
					{
						int num3 = num - 12;
						bool flag2 = i == num2 - 1;
						if (flag2)
						{
							num3 = data.Length - i * num3;
						}
						byte[] data2 = data.Copy(i * (num - 12), num3);
						array = array.Concat(rSA.Encrypt(data2, RSAEncryptionPadding.Pkcs1)).ToArray<byte>();
					}
					result = array;
				}
				else
				{
					result = rSA.Encrypt(data, RSAEncryptionPadding.Pkcs1);
				}
			}
			return result;
		}
	}
}
