using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "VoipCompleteStatusList")]
	[Serializable]
	public class VoipCompleteStatusList : IExtensible
	{
		private int _Count;

		private readonly List<VoipCompleteStatus> _CompleteStatus = new List<VoipCompleteStatus>();

		private uint _Seq;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Count", DataFormat = DataFormat.TwosComplement)]
		public int Count
		{
			get
			{
				return this._Count;
			}
			set
			{
				this._Count = value;
			}
		}

		[ProtoMember(2, Name = "CompleteStatus", DataFormat = DataFormat.Default)]
		public List<VoipCompleteStatus> CompleteStatus
		{
			get
			{
				return this._CompleteStatus;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "Seq", DataFormat = DataFormat.TwosComplement)]
		public uint Seq
		{
			get
			{
				return this._Seq;
			}
			set
			{
				this._Seq = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
