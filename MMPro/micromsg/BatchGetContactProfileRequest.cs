using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "BatchGetContactProfileRequest")]
	[Serializable]
	public class BatchGetContactProfileRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _Mode;

		private uint _Count;

		private readonly List<SKBuiltinString_t> _UserNameList = new List<SKBuiltinString_t>();

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

		[ProtoMember(2, IsRequired = true, Name = "Mode", DataFormat = DataFormat.TwosComplement)]
		public uint Mode
		{
			get
			{
				return this._Mode;
			}
			set
			{
				this._Mode = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "Count", DataFormat = DataFormat.TwosComplement)]
		public uint Count
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

		[ProtoMember(4, Name = "UserNameList", DataFormat = DataFormat.Default)]
		public List<SKBuiltinString_t> UserNameList
		{
			get
			{
				return this._UserNameList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
