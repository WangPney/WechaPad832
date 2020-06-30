using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace System.Security.Cryptography
{
    public static class AESExtension
    {
		public static byte[] AESEncrypt(this byte[] data, byte[] password, CipherMode mode = CipherMode.CBC)
		{
			byte[] result;
			try
			{
				using (Aes aes = new AesManaged())
				{
					aes.Mode = mode;
					aes.Key = password;
					aes.IV = password;
					using (MemoryStream memoryStream = new MemoryStream())
					{
						using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
						{
							cryptoStream.Write(data, 0, data.Length);
							cryptoStream.FlushFinalBlock();
						}
						result = memoryStream.ToArray();
					}
				}
			}
			catch (Exception ex)
			{
                Debug.Print("aes encryption failed ", new object[] { ex });
                result = null;
			}
			return result;
		}
		public static byte[] AESDecrypt(this byte[] data, byte[] password, CipherMode mode = CipherMode.CBC)
		{
			byte[] result;
			try
			{
				using (Aes aes = new AesManaged())
				{
					aes.Mode = mode;
					aes.Key = password;
					aes.IV = password;
					using (MemoryStream memoryStream = new MemoryStream())
					{
						using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
						{
							cryptoStream.Write(data, 0, data.Length);
							cryptoStream.FlushFinalBlock();
						}
						result = memoryStream.ToArray();
					}
				}
			}
			catch (Exception ex)
			{
                Debug.Print("aes encryption failed ", new object[] { ex });
                result = null;
			}
			return result;
		}

	}
}
