using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "PacketSvrIDResponse")]
	[Serializable]
	public class PacketSvrIDResponse : IExtensible
	{
		private readonly List<ulong> _SvrID = new List<ulong>();

		private readonly List<string> _MediaID = new List<string>();

		private readonly List<string> _MD5 = new List<string>();

		private string _BakChatName;

		private IExtension extensionObject;

		[ProtoMember(1, Name = "SvrID", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> SvrID
		{
			get
			{
				return this._SvrID;
			}
		}

		[ProtoMember(2, Name = "MediaID", DataFormat = DataFormat.Default)]
		public List<string> MediaID
		{
			get
			{
				return this._MediaID;
			}
		}

		[ProtoMember(3, Name = "MD5", DataFormat = DataFormat.Default)]
		public List<string> MD5
		{
			get
			{
				return this._MD5;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "BakChatName", DataFormat = DataFormat.Default)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
