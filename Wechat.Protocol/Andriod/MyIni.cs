using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Wechat.Protocol.Andriod
{
	public class MyIni
	{
		private string FilePath;

		public string IniFilePath
		{
			get
			{
				return FilePath;
			}
			set
			{
				FilePath = value;
			}
		}

		[DllImport("kernel32")]
		private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

		[DllImport("kernel32")]
		private static extern int GetPrivateProfileInt(string lpApplicationName, string lpKeyName, int nDefault, string lpFileName);

		public MyIni()
		{
		}

		public MyIni(string _FilePath)
		{
			FilePath = _FilePath;
		}

		public int WriteIniString(string Section, string key, string val)
		{
			if (IniFilePath.Length <= 0)
			{
				throw new Exception("没有指定ini文件路径。");
			}
			try
			{
				if (WritePrivateProfileString(Section, key, val, FilePath) == 0L)
				{
					return 0;
				}
				return 1;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public string GetIniString(string Section, string key, string def, int size)
		{
			StringBuilder stringBuilder = new StringBuilder(size);
			if (IniFilePath.Length <= 0)
			{
				throw new Exception("没有指定ini文件路径。");
			}
			try
			{
				GetPrivateProfileString(Section, key, def, stringBuilder, size, FilePath);
				return stringBuilder.ToString();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public int GetIniInt(string Section, string key, long nDefault)
		{
			if (IniFilePath.Length <= 0)
			{
				throw new Exception("没有指定ini文件路径。");
			}
			try
			{
				int privateProfileInt = GetPrivateProfileInt(Section, key, 0, FilePath);
				if (privateProfileInt == 0)
				{
					privateProfileInt = GetPrivateProfileInt(Section, key, 1, FilePath);
					if (privateProfileInt == 1)
					{
						return (int)nDefault;
					}
				}
				return privateProfileInt;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
