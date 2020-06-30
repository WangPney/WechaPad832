using System.Text;
using System.IO;

namespace System.Security.Cryptography
{
	public static class DES3Extension
    {
		public static string Des3Encrypt(string @in,byte[] key)
		{
			byte[] array = Encoding.UTF8.GetBytes(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(@in)).ToString(16, 2));
			array = Des3DecryptECB(array, key, null).Copy(32);
			return array.ToString(16, 2);
		}

		public static byte[] Des3DecryptECB(this byte[] data, byte[] key)
		{
			return Des3EncryptECB(data, key, null);
		}
		/// <summary>
		/// 3 DES 加密
		/// </summary>
		/// <param name="data"></param>
		/// <param name="key"></param>
		/// <param name="iv"></param>
		/// <returns></returns>
		public static byte[] Des3EncryptECB(this byte[] data, byte[] key, byte[] iv)
		{
			byte[] result;
			try
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, new TripleDESCryptoServiceProvider
					{
						Mode = CipherMode.ECB,
						Padding = PaddingMode.PKCS7}.CreateEncryptor(key, iv), CryptoStreamMode.Write))
					{
						cryptoStream.Write(data, 0, data.Length);
						cryptoStream.FlushFinalBlock();
						byte[] array = memoryStream.ToArray();
						cryptoStream.Close();
						memoryStream.Close();
						result = array;
					}
				}
			}
			catch (CryptographicException ex)
			{
				Console.WriteLine("A Cryptographic error occurred: {0}", ex.Message);
				result = null;
			}
			return result;
		}
		/// <summary>
		/// 3 DES 解密
		/// </summary>
		/// <param name="data"></param>
		/// <param name="key"></param>
		/// <param name="iv"></param>
		/// <returns></returns>
		public static byte[] Des3DecryptECB(this byte[] data, byte[] key, byte[] iv = null)
		{
			byte[] result;
			try
			{
				using (MemoryStream stream = new MemoryStream(data))
				{
					using (CryptoStream cryptoStream = new CryptoStream(stream, new TripleDESCryptoServiceProvider
					{
						Mode = CipherMode.ECB,
						Padding = PaddingMode.PKCS7
					}.CreateDecryptor(key, iv), CryptoStreamMode.Read))
					{
						byte[] array = new byte[data.Length];
						cryptoStream.Read(array, 0, array.Length);
						result = array;
					}
				}
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
