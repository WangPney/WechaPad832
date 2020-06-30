using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "VoipAddrSet")]
	[Serializable]
	public class VoipAddrSet : IExtensible
	{
		private int _Cnt;

		private readonly List<VoipAddr> _Addrs = new List<VoipAddr>();

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Cnt", DataFormat = DataFormat.TwosComplement)]
		public int Cnt
		{
			get
			{
				return this._Cnt;
			}
			set
			{
				this._Cnt = value;
			}
		}

		[ProtoMember(2, Name = "Addrs", DataFormat = DataFormat.Default)]
		public List<VoipAddr> Addrs
		{
			get
			{
				return this._Addrs;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
