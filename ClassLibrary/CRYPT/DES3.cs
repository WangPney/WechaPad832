using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CRYPT
{
	public static class DES3
	{
		private static byte[] tenpaykey = new byte[]
		{
			62,
			202,
			47,
			111,
			250,
			109,
			73,
			82,
			171,
			186,
			202,
			90,
			123,
			6,
			125,
			35
		};

		public static string Des3EncodeStr(string @in)
		{
			byte[] array = Encoding.UTF8.GetBytes(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(@in)).ToString(16, 2));
			array = DES3.Des3EncodeECB(array, DES3.tenpaykey, null).Copy(32);
			return array.ToString(16, 2);
		}

		public static byte[] Des3DecodeECB(byte[] data)
		{
			return DES3.Des3DecodeECB(data, DES3.tenpaykey, null);
		}

		public static byte[] Des3EncodeECB(byte[] data, byte[] key, byte[] iv)
		{
			byte[] result;
			try
			{
				MemoryStream memoryStream = new MemoryStream();
				CryptoStream cryptoStream = new CryptoStream(memoryStream, new TripleDESCryptoServiceProvider
				{
					Mode = CipherMode.ECB,
					Padding = PaddingMode.PKCS7
				}.CreateEncryptor(key, iv), CryptoStreamMode.Write);
				cryptoStream.Write(data, 0, data.Length);
				cryptoStream.FlushFinalBlock();
				byte[] array = memoryStream.ToArray();
				cryptoStream.Close();
				memoryStream.Close();
				result = array;
			}
			catch (CryptographicException ex)
			{
				Console.WriteLine("A Cryptographic error occurred: {0}", ex.Message);
				result = null;
			}
			return result;
		}

		public static byte[] Des3DecodeECB(byte[] data, byte[] key, byte[] iv = null)
		{
			byte[] result;
			try
			{
				MemoryStream stream = new MemoryStream(data);
				CryptoStream cryptoStream = new CryptoStream(stream, new TripleDESCryptoServiceProvider
				{
					Mode = CipherMode.ECB,
					Padding = PaddingMode.PKCS7
				}.CreateDecryptor(key, iv), CryptoStreamMode.Read);
				byte[] array = new byte[data.Length];
				cryptoStream.Read(array, 0, array.Length);
				result = array;
			}
			catch (CryptographicException ex)
			{
				Console.WriteLine("A Cryptographic error occurred: {0}", ex.Message);
				result = null;
			}
			return result;
		}
	}
}
