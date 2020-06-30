using System;
using System.Security.Cryptography;
using System.Text;

namespace CRYPT
{
	public static class MD5Core
	{
		public static string GetMd5Hash(string input)
		{
			bool flag = input == null;
			string result;
			if (flag)
			{
				result = null;
			}
			else
			{
				MD5 mD = MD5.Create();
				byte[] array = mD.ComputeHash(Encoding.UTF8.GetBytes(input));
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < array.Length; i++)
				{
					stringBuilder.Append(array[i].ToString("x2"));
				}
				result = stringBuilder.ToString();
			}
			return result;
		}

		public static byte[] GetMd5Hash(byte[] input)
		{
			bool flag = input == null;
			byte[] result;
			if (flag)
			{
				result = null;
			}
			else
			{
				MD5 mD = MD5.Create();
				byte[] array = mD.ComputeHash(input);
				result = array;
			}
			return result;
		}
	}
}
