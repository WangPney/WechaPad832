using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Wechat.Protocol.Andriod
{
	public class SocketTransfer
	{
		public byte[] SendPacket(string ip, int port, byte[] sendPacket)
		{
			byte[] array = null;
			while (true)
			{
				try
				{
					IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(ip), port);
					Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
					socket.Connect(remoteEP);
					int num = socket.Send(sendPacket);
					byte[] array2 = new byte[4];
					num = socket.Receive(array2, 0, 4, SocketFlags.None);
					int num2 = array2[2] * 256 + array2[3];
					array = new byte[num2];
					for (int i = 4; i < num2; i += num)
					{
						num = socket.Receive(array, i, num2 - i, SocketFlags.None);
					}
					array = array.Take(num2).ToArray();
				}
				catch (Exception)
				{
				}
				if (array != null && array.Length != 0)
				{
					break;
				}
				Thread.Sleep(5000);
			}
			return array;
		}

		public byte[] SendLBSPacket(string ip, int port, byte[] sendPacket)
		{
			IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(ip), port);
			Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			socket.Connect(remoteEP);
			int num = socket.Send(sendPacket);
			byte[] array = new byte[40000];
			Thread.Sleep(300);
			num = socket.Receive(array);
			return array.Take(num).ToArray();
		}
	}
}
