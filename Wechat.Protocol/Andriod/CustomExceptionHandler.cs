//using System;
//using System.IO;
//using System.Text;
//using System.Threading;
//using System.Windows.Forms;

//namespace Wechat.Protocol.Andriod
//{
//	internal class CustomExceptionHandler
//	{
//		public void OnThreadException(object sender, ThreadExceptionEventArgs e)
//		{
//			DialogResult dialogResult = DialogResult.Cancel;
//			try
//			{
//				dialogResult = ShowThreadExceptionDialog(e.Exception);
//			}
//			catch
//			{
//				try
//				{
//					MessageBox.Show("致命错误", "致命错误", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Hand);
//				}
//				finally
//				{
//					Application.Exit();
//				}
//			}
//			Log(e.Exception.Message);
//			if (dialogResult == DialogResult.Abort)
//			{
//				Application.Exit();
//			}
//		}

//		private DialogResult ShowThreadExceptionDialog(Exception e)
//		{
//			string str = "发生错误，请与我们联系以下信息给管理员:\r\n";
//			str = str + e.Message + "堆栈跟踪:\r\n" + e.StackTrace;
//			return MessageBox.Show(str, "应用程序错误", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Hand);
//		}

//		public void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
//		{
//			string text = "";
//			Exception ex = e.ExceptionObject as Exception;
//			string str = "发生错误，请与我们联系。将以下信息给管理员：\r\n";
//			text = ((ex == null) ? string.Format("{0}", e) : string.Format(str + "{0};\r\n堆栈信息:\r\n{1}", ex.Message, ex.StackTrace));
//			Log(text);
//			MessageBox.Show(text, "程序错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
//		}

//		public void Log(string log)
//		{
//			StreamWriter streamWriter = null;
//			try
//			{
//				if (!(log == ""))
//				{
//					streamWriter = new StreamWriter(Application.StartupPath + "\\log_" + DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss") + ".txt", true, Encoding.Default);
//					streamWriter.Write(log, false);
//				}
//			}
//			catch
//			{
//			}
//			finally
//			{
//				if (streamWriter != null)
//				{
//					streamWriter.Close();
//					streamWriter.Dispose();
//				}
//			}
//		}
//	}
//}
