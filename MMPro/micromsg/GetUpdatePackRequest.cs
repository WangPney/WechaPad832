using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetUpdatePackRequest")]
	[Serializable]
	public class GetUpdatePackRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _UpdateType;

		private uint _TotalLen;

		private uint _StartPos;

		private uint _Channel = 0u;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BaseRequest", DataFormat = DataFormat.Default)]
		public BaseRequest BaseRequest
		{
			get
			{
				return this._BaseRequest;
			}
			set
			{
				this._BaseRequest = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "UpdateType", DataFormat = DataFormat.TwosComplement)]
		public uint UpdateType
		{
			get
			{
				return this._UpdateType;
			}
			set
			{
				this._UpdateType = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "TotalLen", DataFormat = DataFormat.TwosComplement)]
		public uint TotalLen
		{
			get
			{
				return this._TotalLen;
			}
			set
			{
				this._TotalLen = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "StartPos", DataFormat = DataFormat.TwosComplement)]
		public uint StartPos
		{
			get
			{
				return this._StartPos;
			}
			set
			{
				this._StartPos = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "Channel", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Channel
		{
			get
			{
				return this._Channel;
			}
			set
			{
				this._Channel = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
