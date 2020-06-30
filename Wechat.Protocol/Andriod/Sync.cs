using System.Collections.Generic;

namespace Wechat.Protocol.Andriod
{
	public struct Sync
	{
		public byte[] iniSyncKey;

		public List<SysncInfo> strangerInfo;
	}
}
