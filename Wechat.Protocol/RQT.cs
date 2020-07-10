using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace System
{
	public static class RQT
	{

		public static byte[] MD5(this byte[] data)
		{
			using (MD5 provider = new MD5CryptoServiceProvider()) { return provider.ComputeHash(data); }
		}

		/// <summary>
		/// SHA1计算
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public static byte[] SHA1(this byte[] data)
		{
			using (SHA1 provider = new SHA1CryptoServiceProvider()) { return provider.ComputeHash(data); }
		}


		/// <summary>
		/// RQT签名
		/// </summary>
		/// <param name="md5"></param>
		/// <param name="pixels"></param>
		/// <param name="key"></param>
		/// <param name="r1"></param>
		/// <returns></returns>
		private static int SignRqtBufByAutoChosenKey(string md5, byte[] pixels, int key, int r1)
		{
			var ms = new MemoryStream();
			var block = new byte[48 + pixels.Length];
			var md5bs = Encoding.UTF8.GetBytes(md5);

			Buffer.BlockCopy(pixels, 0, block, 0, pixels.Length);
			for (int i = 0; i < block.Length; i++)
			{
				block[i] ^= 0x36;
			}
			ms.Write(block, 0, block.Length);
			ms.Write(md5bs, 0, md5bs.Length);

			byte[] tmp = ms.ToArray();
			block = new byte[48 + pixels.Length];
			Buffer.BlockCopy(pixels, 0, block, 0, pixels.Length);
			for (int i = 0; i < block.Length; i++)
			{
				block[i] ^= 0x5c;
			}
			byte[] sha = tmp.SHA1();
			ms = new MemoryStream();
			ms.Write(block, 0, block.Length);
			ms.Write(sha, 0, sha.Length);
			tmp = ms.ToArray();
			sha = tmp.SHA1();
			int t1 = 0, t2 = 0, t3 = 0;
			for (int i = 2; i < sha.Length; i++)
			{
				int v1 = sha[i - 2] & 0xff;
				int v2 = sha[i - 1] & 0xff;
				int v3 = sha[i] & 0xff;
				t1 = 0x83 * t1 + v1;
				t2 = 0x83 * t2 + v2;
				t3 = 0x83 * t3 + v3;
			}
			int r3 = t1 & 0x7f;
			int r4 = (t3 << 16) & 0x7f0000;
			int r5 = (t2 << 8) & 0x7f00;
			return r3 | r4 | r5 | ((r1 << 5 | key & 0x1f) << 24);
		}

		/// <summary>
		/// RQT签名
		/// </summary>
		/// <param name="body">包体</param>
		/// <returns></returns>
		public static int SignRqt(this byte[] body)
		{
			var key = "6a664d5d537c253f736e48273a295e4f";
			return SignRqtBufByAutoChosenKey(body.MD5().ToString(16, 2).ToLower(), key.ToByteArray(16, 2), 1, 1);
		}
	}
}
