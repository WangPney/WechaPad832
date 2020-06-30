using System.Text;

namespace System.Security.Cryptography
{
	public static class MD5Extension
    {
		/// <summary>
		/// 计算MD5
		/// </summary>
		/// <param name="data">数据</param>
		/// <param name="upperCase">是否转大写</param>
		/// <returns></returns>
		public static string HexMd5Hash(this string data, bool upperCase = false)
		{
			if (data == null) { return ""; }
			return HexMd5Hash(Encoding.UTF8.GetBytes(data), upperCase);
		}
		/// <summary>
		/// 计算MD5
		/// </summary>
		/// <param name="data">数据</param>
		/// <param name="upperCase">是否转大写</param>
		/// <returns></returns>
		public static string HexMd5Hash(this byte[] data, bool upperCase = false)
		{
			byte[] md5Bytes = Md5Hash(data);
			if (md5Bytes == null) { return ""; }
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < md5Bytes.Length; i++)
			{
				sb.Append(md5Bytes[i].ToString($"{(upperCase ? "X2" : "x2")}"));
			}
			return sb.ToString();
		}
		/// <summary>
		/// 计算MD5
		/// </summary>
		/// <param name="data">数据</param>
		/// <returns></returns>
		public static byte[] Md5Hash(this string data)
        {
			return Md5Hash(Encoding.UTF8.GetBytes(data));
		}
		/// <summary>
		/// 计算MD5
		/// </summary>
		/// <param name="data">数据</param>
		/// <returns></returns>
		public static byte[] Md5Hash(this byte[] data)
		{
			MD5 md5 = MD5.Create();
			return md5.ComputeHash(data);
		}
	}
}
