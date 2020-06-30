using System;
using System.IO;
using System.Text;

namespace System.Security.Cryptography
{
    public static class RSAExtension
    {
		/// <summary>
		/// RSA算法类型
		/// </summary>
		public enum RSAType
		{
			/// <summary>
			/// SHA1
			/// </summary>
			RSA = 0,
			/// <summary>
			/// RSA2 密钥长度至少为2048
			/// SHA256
			/// </summary>
			RSA2
		}

		#region 使用私钥签名
		/// <summary>
		/// 使用私钥签名
		/// </summary>
		/// <param name="data">原始数据</param>
		/// <param name="privateKeyString">私钥</param>
		/// <param name="rsaType"></param>
		/// <returns></returns>
		public static string RSASignBase64(this string data, string privateKeyString, RSAType rsaType = RSAType.RSA2)
		{
			return Convert.ToBase64String( RSASign(Convert.FromBase64String(data), privateKeyString, rsaType));
		}
		/// <summary>
		/// 使用私钥签名
		/// </summary>
		/// <param name="dataBytes">原始数据</param>
		/// <param name="privateKeyString">私钥</param>
		/// <param name="rsaType"></param>
		/// <returns></returns>
		public static string RSASignBase64(this byte[] dataBytes, string privateKeyString, RSAType rsaType = RSAType.RSA2)
		{
			return Convert.ToBase64String(RSASign(dataBytes, privateKeyString, rsaType));
		}
		/// <summary>
		/// 使用私钥签名
		/// </summary>
		/// <param name="dataBytes">原始数据</param>
		/// <param name="privateKeyString">私钥</param>
		/// <param name="rsaType"></param>
		/// <returns></returns>
		public static string RSASignBase64(this byte[] dataBytes, byte[] privateKey, RSAType rsaType = RSAType.RSA2)
		{
			return Convert.ToBase64String(RSASign(dataBytes, privateKey, rsaType));
		}
		/// <summary>
		/// 使用私钥签名
		/// </summary>
		/// <param name="data">原始数据</param>
		/// <param name="privateKeyString">私钥</param>
		/// <param name="rsaType"></param>
		/// <returns></returns>
		public static byte[] RSASign(this string data,  string privateKeyString, RSAType rsaType=RSAType.RSA2)
        {
			return RSASign(Convert.FromBase64String(data), privateKeyString, rsaType);
        }
		/// <summary>
		/// 使用私钥签名
		/// </summary>
		/// <param name="dataBytes">原始数据</param>
		/// <param name="privateKeyString">私钥</param>
		/// <param name="rsaType"></param>
		/// <returns></returns>
		public static byte[] RSASign(this byte[] dataBytes,  string privateKeyString,RSAType rsaType=RSAType.RSA2)
		{
			return RSASign(dataBytes, Convert.FromBase64String(privateKeyString), rsaType);
		}

		/// <summary>
		/// 使用私钥签名
		/// </summary>
		/// <param name="data">原始数据</param>
		/// <returns></returns>
		public static byte[] RSASign(this byte[] dataBytes,  byte[] privateKey ,RSAType rsaType = RSAType.RSA2)
		{
			using (RSA rsa = CreateRsaFromPrivateKey(privateKey))
			{
				var encoding = Encoding.UTF8;
				var hashAlgorithmName = rsaType == RSAType.RSA ? HashAlgorithmName.SHA1 : HashAlgorithmName.SHA256;
				return rsa.SignData(dataBytes, hashAlgorithmName, RSASignaturePadding.Pkcs1);
			}
		}

		#endregion

		#region 使用公钥验证签名


		public static bool RsaVerify(this string data, string sign,string publicKeyString, RSAType rsaType)
        {
			return RsaVerify(Encoding.UTF8.GetBytes(data),Convert.FromBase64String(sign),Convert.FromBase64String(publicKeyString),rsaType);
		}
		public static bool RsaVerify(this string data, byte[] signBytes, string publicKeyString, RSAType rsaType)
		{
			return RsaVerify(Encoding.UTF8.GetBytes(data), signBytes, Convert.FromBase64String(publicKeyString), rsaType);
		}
		public static bool RsaVerify(this string data, byte[] signBytes, byte[] publicKey, RSAType rsaType)
		{
			return RsaVerify(Encoding.UTF8.GetBytes(data), signBytes, publicKey, rsaType);
		}
		public static bool RsaVerify(this byte[] data, string sign, string publicKeyString, RSAType rsaType)
		{
			return RsaVerify(data, Convert.FromBase64String(sign), Convert.FromBase64String(publicKeyString), rsaType);
		}
		public static bool RsaVerify(this byte[] data, string sign, byte[] publicKey, RSAType rsaType)
		{
			return RsaVerify(data, Convert.FromBase64String(sign), publicKey, rsaType);
		}

		/// <summary>
		/// 使用公钥验证签名
		/// </summary>
		/// <param name="dataBytes">原始数据</param>
		/// <param name="signBytes">签名</param>
		/// <param name="publicKey">公钥</param>
		/// <param name="rsaType"></param>
		/// <returns></returns>
		public static bool RsaVerify(this byte[] dataBytes, byte[] signBytes, byte[] publicKey, RSAType rsaType=RSAType.RSA2)
		{
			using (RSA rsa = CreateRsaFromPublicKey(publicKey))
			{
				var encoding = Encoding.UTF8;
				var hashAlgorithmName = rsaType == RSAType.RSA ? HashAlgorithmName.SHA1 : HashAlgorithmName.SHA256;
				return rsa.VerifyData(dataBytes, signBytes, hashAlgorithmName, RSASignaturePadding.Pkcs1);
			}
		}
		#endregion

		#region 加密
		public static string RSAEncryptBase64(this string data, string publicKey)
		{
			return RSAEncryptBase64(Encoding.UTF8.GetBytes(data), Convert.FromBase64String(publicKey));
		}
		public static string RSAEncryptBase64(this byte[] data, string publicKey)
		{
			return RSAEncryptBase64(data,Convert.FromBase64String(publicKey));
		}

		public static string RSAEncryptBase64(this byte[] data, byte[] publicKey)
		{
			using (RSA rsa= CreateRsaFromPublicKey(publicKey))
			{
				return RSAEncryptBase64(data, rsa);
			}
		}

		public static string RSAEncryptBase64(this string data, RSA rsa)
		{
			return RSAEncryptBase64(Encoding.UTF8.GetBytes(data), rsa);
		}

		public static string RSAEncryptBase64(this byte[] data, RSA rsa)
		{
			return Convert.ToBase64String(RSAEncrypt(data, rsa));
		}
		/// <summary>
		/// RSA加密
		/// </summary>
		/// <param name="data">要加密的数据</param>
		/// <param name="publicKey">加密公钥</param>
		/// <returns></returns>
		public static byte[] RSAEncrypt(this string data,string publicKey)
        {
			return RSAEncrypt(Encoding.UTF8.GetBytes(data), publicKey);
		}
		/// <summary>
		/// RSA加密
		/// </summary>
		/// <param name="data">要加密的数据</param>
		/// <param name="publicKey">加密公钥</param>
		/// <returns></returns>
		public static byte[] RSAEncrypt(this byte[] data, string publicKey)
		{
			return RSAEncrypt(data, Convert.FromBase64String(publicKey));
		}
		public static byte[] RSAEncrypt(this byte[] data, byte[] publicKey)
		{
			using (RSA rsa = CreateRsaFromPublicKey(publicKey))
			{
				return rsa.Encrypt(data, RSAEncryptionPadding.Pkcs1);
			}
		}

		public static byte[] RSAEncrypt(this string plainTextBse64, RSA rsa)
		{
			return RSAEncrypt(Convert.FromBase64String(plainTextBse64), rsa);
		}

		public static byte[] RSAEncrypt(this byte[] data, RSA rsa)
		{
			return rsa.Encrypt(data, RSAEncryptionPadding.Pkcs1);
		}
		#endregion

		#region 解密
		public static string RSADecryptBase64(this string data, string privateKey)
		{
			return RSADecryptBase64(Encoding.UTF8.GetBytes(data), privateKey);
		}
		public static string RSADecryptBase64(this byte[] data, string privateKey)
		{
			return RSADecryptBase64(data, Convert.FromBase64String(privateKey));
		}
		public static string RSADecryptBase64(this byte[] data, byte[] privateKey)
		{
			return Convert.ToBase64String(RSADecrypt(data, privateKey));
		}
		/// <summary>
		/// RSA解密
		/// </summary>
		/// <param name="cipherTextBase64">密文</param>
		/// <param name="privateKey">私钥</param>
		/// <returns></returns>

		public static byte[] RSADecrypt(string cipherTextBase64, string privateKey)
		{
			return RSADecrypt(Convert.FromBase64String(cipherTextBase64), privateKey);
		}
		/// <summary>
		/// RSA解密
		/// </summary>
		/// <param name="cipherText">密文数据</param>
		/// <param name="privateKey">私钥</param>
		/// <returns></returns>
		public static byte[] RSADecrypt(this byte[] data, string privateKeyString)
		{
			return RSADecrypt(data, Convert.FromBase64String(privateKeyString));
		}
		/// <summary>
		/// RSA解密
		/// </summary>
		/// <param name="cipherText">密文数据</param>
		/// <param name="privateKey">私钥</param>
		/// <returns></returns>
		public static byte[] RSADecrypt(this byte[] data, byte[] privateKey)
		{
			using (RSA rsa = CreateRsaFromPrivateKey(privateKey))
			{
				return RSADecrypt(data, rsa);
			}
		}

		public static byte[] RSADecrypt(this string cipherTextBse64, RSA rsa)
		{
			return RSADecrypt(Convert.FromBase64String(cipherTextBse64), rsa);
		}

		public static byte[] RSADecrypt(this byte[] data, RSA rsa)
        {
            return rsa.Decrypt(data, RSAEncryptionPadding.Pkcs1);
        }

        #endregion

        #region 使用私钥创建RSA实例

        public static RSA PrivateKeyToRSA(this string privateKeyString)
		{
			return CreateRsaFromPrivateKey(privateKeyString);
		}
		public static RSA PrivateKeyToRSA(this byte[] privateKeyBytes)
		{
			return CreateRsaFromPrivateKey(privateKeyBytes);
		}
		public static RSA CreateRsaFromPrivateKey(string privateKeyString) {
			return CreateRsaFromPrivateKey(Convert.FromBase64String(privateKeyString));
		}
		public static RSA CreateRsaFromPrivateKey(byte[] privateKeyBytes)
		{
			var rsa = RSA.Create();
			var rsaParameters = new RSAParameters();
			using (BinaryReader binr = new BinaryReader(new MemoryStream(privateKeyBytes)))
			{
				byte bt = 0;
				ushort twobytes = 0;
				twobytes = binr.ReadUInt16();
				if (twobytes == 0x8130)
					binr.ReadByte();
				else if (twobytes == 0x8230)
					binr.ReadInt16();
				else
					throw new Exception("Unexpected value read binr.ReadUInt16()");

				twobytes = binr.ReadUInt16();
				if (twobytes != 0x0102)
					throw new Exception("Unexpected version");

				bt = binr.ReadByte();
				if (bt != 0x00)
					throw new Exception("Unexpected value read binr.ReadByte()");

				rsaParameters.Modulus = binr.ReadBytes(GetIntegerSize(binr));
				rsaParameters.Exponent = binr.ReadBytes(GetIntegerSize(binr));
				rsaParameters.D = binr.ReadBytes(GetIntegerSize(binr));
				rsaParameters.P = binr.ReadBytes(GetIntegerSize(binr));
				rsaParameters.Q = binr.ReadBytes(GetIntegerSize(binr));
				rsaParameters.DP = binr.ReadBytes(GetIntegerSize(binr));
				rsaParameters.DQ = binr.ReadBytes(GetIntegerSize(binr));
				rsaParameters.InverseQ = binr.ReadBytes(GetIntegerSize(binr));
			}

			rsa.ImportParameters(rsaParameters);
			return rsa;
		}
		#endregion

		#region 使用公钥创建RSA实例

		public static RSA PublicKeyToRSA(this byte[] publicKey)
		{
			return CreateRsaFromPublicKey(publicKey);
		}

		public static RSA PublicKeyToRSA(this string publicKeyString)
		{
			return CreateRsaFromPublicKey(publicKeyString);
		}

		public static RSA CreateRsaFromPublicKey(string publicKeyString)
		{
			return CreateRsaFromPublicKey(Convert.FromBase64String(publicKeyString));
		}

		public static RSA CreateRsaFromPublicKey(byte[] publicKey)
		{
			// encoded OID sequence for  PKCS #1 rsaEncryption szOID_RSA_RSA = "1.2.840.113549.1.1.1"
			byte[] seqOid = { 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 0x00 };
			byte[] seq = new byte[15];

			// ---------  Set up stream to read the asn.1 encoded SubjectPublicKeyInfo blob  ------
			using (MemoryStream mem = new MemoryStream(publicKey))
			{
				using (BinaryReader binr = new BinaryReader(mem))  //wrap Memory Stream with BinaryReader for easy reading
				{
					byte bt = 0;
					ushort twobytes = 0;

					twobytes = binr.ReadUInt16();
					if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
						binr.ReadByte();    //advance 1 byte
					else if (twobytes == 0x8230)
						binr.ReadInt16();   //advance 2 bytes
					else
						return null;

					seq = binr.ReadBytes(15);       //read the Sequence OID
					if (!CompareBytearrays(seq, seqOid))    //make sure Sequence for OID is correct
						return null;

					twobytes = binr.ReadUInt16();
					if (twobytes == 0x8103) //data read as little endian order (actual data order for Bit String is 03 81)
						binr.ReadByte();    //advance 1 byte
					else if (twobytes == 0x8203)
						binr.ReadInt16();   //advance 2 bytes
					else
						return null;

					bt = binr.ReadByte();
					if (bt != 0x00)     //expect null byte next
						return null;

					twobytes = binr.ReadUInt16();
					if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
						binr.ReadByte();    //advance 1 byte
					else if (twobytes == 0x8230)
						binr.ReadInt16();   //advance 2 bytes
					else
						return null;

					twobytes = binr.ReadUInt16();
					byte lowbyte = 0x00;
					byte highbyte = 0x00;

					if (twobytes == 0x8102) //data read as little endian order (actual data order for Integer is 02 81)
						lowbyte = binr.ReadByte();  // read next bytes which is bytes in modulus
					else if (twobytes == 0x8202)
					{
						highbyte = binr.ReadByte(); //advance 2 bytes
						lowbyte = binr.ReadByte();
					}
					else
						return null;
					byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };   //reverse byte order since asn.1 key uses big endian order
					int modsize = BitConverter.ToInt32(modint, 0);

					int firstbyte = binr.PeekChar();
					if (firstbyte == 0x00)
					{   //if first byte (highest order) of modulus is zero, don't include it
						binr.ReadByte();    //skip this null byte
						modsize -= 1;   //reduce modulus buffer size by 1
					}

					byte[] modulus = binr.ReadBytes(modsize);   //read the modulus bytes

					if (binr.ReadByte() != 0x02)            //expect an Integer for the exponent data
						return null;
					int expbytes = (int)binr.ReadByte();        // should only need one byte for actual exponent data (for all useful values)
					byte[] exponent = binr.ReadBytes(expbytes);

					// ------- create RSACryptoServiceProvider instance and initialize with public key -----
					var rsa = RSA.Create();
					RSAParameters rsaKeyInfo = new RSAParameters
					{
						Modulus = modulus,
						Exponent = exponent
					};
					rsa.ImportParameters(rsaKeyInfo);

					return rsa;
				}
			}
		}

		#endregion

		public static RSA CreateRSA(this RSAParameters parameters)
		{
			var rsa = RSA.Create();
			rsa.ImportParameters(parameters);
			return rsa;
		}

		#region 导入密钥算法

		private static int GetIntegerSize(BinaryReader binr)
		{
			byte bt = 0;
			int count = 0;
			bt = binr.ReadByte();
			if (bt != 0x02)
				return 0;
			bt = binr.ReadByte();

			if (bt == 0x81)
				count = binr.ReadByte();
			else
			if (bt == 0x82)
			{
				var highbyte = binr.ReadByte();
				var lowbyte = binr.ReadByte();
				byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };
				count = BitConverter.ToInt32(modint, 0);
			}
			else
			{
				count = bt;
			}

			while (binr.ReadByte() == 0x00)
			{
				count -= 1;
			}
			binr.BaseStream.Seek(-1, SeekOrigin.Current);
			return count;
		}

		private static bool CompareBytearrays(byte[] a, byte[] b)
		{
			if (a.Length != b.Length)
				return false;
			int i = 0;
			foreach (byte c in a)
			{
				if (c != b[i])
					return false;
				i++;
			}
			return true;
		}
		#endregion
    }
}
