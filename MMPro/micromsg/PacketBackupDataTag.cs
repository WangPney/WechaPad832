using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "PacketBackupDataTag")]
	[Serializable]
	public class PacketBackupDataTag : IExtensible
	{
		private string _BakChatName;

		private long _StartTime;

		private long _EndTime;

		private string _MsgDataID;

		private string _NickName;

		private readonly List<string> _MediaIDList = new List<string>();

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BakChatName", DataFormat = DataFormat.Default)]
		public string BakChatName
		{
			get
			{
				return this._BakChatName;
			}
			set
			{
				this._BakChatName = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "StartTime", DataFormat = DataFormat.TwosComplement)]
		public long StartTime
		{
			get
			{
				return this._StartTime;
			}
			set
			{
				this._StartTime = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "EndTime", DataFormat = DataFormat.TwosComplement)]
		public long EndTime
		{
			get
			{
				return this._EndTime;
			}
			set
			{
				this._EndTime = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "MsgDataID", DataFormat = DataFormat.Default)]
		public string MsgDataID
		{
			get
			{
				return this._MsgDataID;
			}
			set
			{
				this._MsgDataID = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "NickName", DataFormat = DataFormat.Default)]
		public string NickName
		{
			get
			{
				return this._NickName;
			}
			set
			{
				this._NickName = value;
			}
		}

		[ProtoMember(6, Name = "MediaIDList", DataFormat = DataFormat.Default)]
		public List<string> MediaIDList
		{
			get
			{
				return this._MediaIDList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
