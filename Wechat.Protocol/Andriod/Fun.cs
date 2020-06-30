using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Security;

namespace Wechat.Protocol.Andriod
{
	public class Fun
	{
		private static Random r = new Random();

		public userInfo deviceInfo()
		{
			userInfo _userInfo = default(userInfo);
			_userInfo.imei = GenIEMI(_userInfo.imei);
			_userInfo.deviceID = GenDeviceID();
			return _userInfo;
		}

		public static string Encrypt3DES(string strString)
		{
			byte[] key = new byte[16]
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
			TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
			tripleDESCryptoServiceProvider.Key = key;
			tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
			ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateEncryptor();
			byte[] bytes = Encoding.ASCII.GetBytes(strString);
			return toHexStr(cryptoTransform.TransformFinalBlock(bytes, 0, bytes.Length));
		}

		public static string GenMac(string p)
		{
			if (p.Length > 14)
			{
				return p;
			}
			Random random = new Random();
			string[] array = new string[16]
			{
				"0",
				"1",
				"2",
				"3",
				"4",
				"5",
				"6",
				"7",
				"8",
				"9",
				"a",
				"b",
				"c",
				"d",
				"e",
				"f"
			};
			StringBuilder stringBuilder = new StringBuilder(p);
			stringBuilder.Append(array[random.Next(array.Length)]);
			stringBuilder.Append(array[random.Next(array.Length)]);
			stringBuilder.Append(":");
			stringBuilder.Append(array[random.Next(array.Length)]);
			stringBuilder.Append(array[random.Next(array.Length)]);
			stringBuilder.Append(":");
			stringBuilder.Append(array[random.Next(array.Length)]);
			stringBuilder.Append(array[random.Next(array.Length)]);
			return stringBuilder.ToString();
		}

		public static string GenSerial(string p, int len)
		{
			Random random = new Random();
			string[] array = new string[10]
			{
				"0",
				"1",
				"2",
				"3",
				"4",
				"5",
				"6",
				"7",
				"8",
				"9"
			};
			StringBuilder stringBuilder = new StringBuilder(p);
			for (int i = 0; i < len; i++)
			{
				stringBuilder.Append(array[random.Next(array.Length)]);
			}
			return stringBuilder.ToString();
		}

		public static string toHexStr(byte[] data)
		{
			string text = "0123456789abcdef";
			StringBuilder stringBuilder = new StringBuilder();
			foreach (byte b in data)
			{
				int index = (int)b / 16;
				int index2 = (int)b % 16;
				stringBuilder.Append(text[index]).Append(text[index2]);
			}
			return stringBuilder.ToString();
		}

		public static byte[] toBin(string data)
		{
			byte[] array = new byte[data.Length / 2];
			int num = 0;
			for (int i = 0; i < data.Length; i += 2)
			{
				num = ((data[i] < '0' || data[i] > '9') ? (data[i] - 97 + 10) : (data[i] - 48));
				num *= 16;
				num = ((data[i + 1] < '0' || data[i + 1] > '9') ? (num + (data[i + 1] - 97 + 10)) : (num + (data[i + 1] - 48)));
				array[i / 2] = (byte)num;
			}
			return array;
		}

		public static byte[] MD5(byte[] src)
		{
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			return mD5CryptoServiceProvider.ComputeHash(src);
		}

		public static string CumputeMD5(string msg)
		{
			return FormsAuthentication.HashPasswordForStoringInConfigFile(msg, "MD5").ToLower();
		}

		public static string TimeMd5()
		{
			return FormsAuthentication.HashPasswordForStoringInConfigFile(DateTime.Now.ToString(), "MD5").ToLower();
		}

		public static ImgSX imgsx(string imgPath)
		{
			Bitmap bitmap = new Bitmap(imgPath);
			ImgSX result = default(ImgSX);
			result.Height = bitmap.Height;
			result.Width = bitmap.Width;
			return result;
		}

		public static string GenIEMI(string srcIMEI)
		{
			byte[] array = new byte[15];
			int i;
			for (i = 0; i < srcIMEI.Length; i++)
			{
				array[i] = (byte)(Convert.ToInt32(srcIMEI[i]) - 48);
			}
			for (; i < 14; i++)
			{
				array[i] = (byte)r.Next(10);
			}
			int num = 0;
			for (i = 0; i < 14; i += 2)
			{
				num += array[i];
				int num2 = array[i + 1] * 2;
				num += num2 / 10;
				num += num2 % 10;
			}
			if (num % 10 == 0)
			{
				array[14] = 0;
			}
			else
			{
				array[14] = (byte)(10 - num % 10);
			}
			for (i = 0; i < 15; i++)
			{
				array[i] += 48;
			}
			return Encoding.ASCII.GetString(array);
		}

		public static string GenDeviceID()
		{
			Random random = new Random();
			string text = "A";
			string[] array = new string[16]
			{
				"0",
				"1",
				"2",
				"3",
				"4",
				"5",
				"6",
				"7",
				"8",
				"9",
				"a",
				"b",
				"c",
				"d",
				"e",
				"f"
			};
			for (int i = 0; i < 14; i++)
			{
				text += array[random.Next(16)].ToString();
			}
			return text;
		}

		public float[] gpsRamdom(string gps)
		{
			float[] array = new float[2];
			string text = gps.Split(new string[1]
			{
				","
			}, StringSplitOptions.None)[0].ToString();
			int length = text.Length - 7;
			text = text.Substring(0, length);
			string text2 = gps.Split(new string[1]
			{
				","
			}, StringSplitOptions.None)[1].ToString();
			int length2 = text2.Length - 7;
			text2 = text2.Substring(0, length2);
			float num = Convert.ToSingle(text);
			float num2 = Convert.ToSingle(text2);
			float num3 = Convert.ToSingle(r.Next(-100, 101)) / 10000f;
			array[0] = num + num3;
			float num4 = Convert.ToSingle(r.Next(-100, 101)) / 10000f;
			array[1] = num2 + num4;
			return array;
		}

		public string uncode(string str)
		{
			string text = "";
			Regex regex = new Regex("(?i)//u([0-9a-f]{4})");
			return regex.Replace(str, (Match m1) => ((char)(ushort)Convert.ToInt32(m1.Groups[1].Value, 16)).ToString());
		}

		public string myRegex(string inputstr, string str)
		{
			string result = "";
			Regex regex = new Regex(str, RegexOptions.IgnoreCase);
			Match match = regex.Match(inputstr);
			if (match.Success)
			{
				result = match.Result("$1");
			}
			return result;
		}

		public string[] myRegexList(string inputstr, string str)
		{
			Regex regex = new Regex(str);
			MatchCollection matchCollection = regex.Matches(inputstr);
			string[] array = new string[matchCollection.Count];
			for (int i = 0; i < matchCollection.Count; i++)
			{
				array[i] = matchCollection[i].Result("$1");
			}
			return array;
		}

		public bool toInt(string str)
		{
			bool result = false;
			int result2 = 0;
			if (int.TryParse(str, out result2))
			{
				result = true;
			}
			return result;
		}
	}
}
