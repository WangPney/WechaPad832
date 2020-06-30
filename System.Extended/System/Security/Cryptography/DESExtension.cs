using System.IO;
using System.Text;

namespace System.Security.Cryptography
{
    public static class DESExtension
    {
        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="data">加密数据</param>
        /// <param name="key">8位字符的密钥字符串</param>
        /// <returns></returns>
        public static byte[] DesEncrypt(this string data, string key)
        {
            return DesEncrypt(Encoding.UTF8.GetBytes(data), key);
        }
        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="data">加密数据</param>
        /// <param name="key">8位字符的密钥字符串</param>
        /// <returns></returns>
        public static byte[] DesEncrypt(this byte[] data, string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (key.Length != 8)
            {
                throw new ArgumentException("key length must be 8",nameof(key));
            }
            return DesEncrypt(data,Encoding.UTF8.GetBytes(key.Substring(0, 8)));
        }
        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="data">加密数据</param>
        /// <param name="keyBytes">8位字符的密钥字符串 UTF8 bytes</param>
        /// <returns></returns>
        public static byte[] DesEncrypt(this byte[] data, byte[] keyBytes)
        {
            byte[] keyIv = keyBytes;
            using (DESCryptoServiceProvider provider = new DESCryptoServiceProvider())
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, provider.CreateEncryptor(keyBytes, keyIv), CryptoStreamMode.Write))
                    {
                        cStream.Write(data, 0, data.Length);
                        cStream.FlushFinalBlock();
                        return mStream.ToArray();
                    }
                }
            }
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="data">解密数据</param>
        /// <param name="key">8位字符的密钥字符串(需要和加密时相同)</param>
        /// <returns></returns>
        public static byte[] DesDecrypt(string data, string key)
        {
            return DesDecrypt(Encoding.UTF8.GetBytes(data), key);
        }
        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="data">解密数据</param>
        /// <param name="key">8位字符的密钥字符串(需要和加密时相同) </param>
        /// <returns></returns>
        public static byte[] DesDecrypt(this byte[] data, string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (key.Length != 8)
            {
                throw new ArgumentException("key length must be 8", nameof(key));
            }
            return DesDecrypt(data, Encoding.UTF8.GetBytes(key.Substring(0, 8)));
        }
        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="data">解密数据</param>
        /// <param name="key">8位字符的密钥字符串(需要和加密时相同) UTF8 bytes</param>
        /// <returns></returns>
        public static byte[] DesDecrypt(this byte[] data, byte[] keyBytes)
        {
            byte[] keyIv = keyBytes;
            using (DESCryptoServiceProvider provider = new DESCryptoServiceProvider())
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, provider.CreateDecryptor(keyBytes, keyIv), CryptoStreamMode.Write))
                    {
                        cStream.Write(data, 0, data.Length);
                        cStream.FlushFinalBlock();
                        return mStream.ToArray();
                    }
                }
            }
        }
    }
}
