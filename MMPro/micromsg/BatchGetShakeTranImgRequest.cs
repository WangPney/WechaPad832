using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "BatchGetShakeTranImgRequest")]
	[Serializable]
	public class BatchGetShakeTranImgRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _Count;

		private readonly List<SKBuiltinString_t> _WebUrlList = new List<SKBuiltinString_t>();

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

		[ProtoMember(2, IsRequired = true, Name = "Count", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, Name = "WebUrlList", DataFormat = DataFormat.Default)]
		public List<SKBuiltinString_t> WebUrlList
		{
			get
			{
				return this._WebUrlList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
