using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "GameResourceReq")]
	[Serializable]
	public class GameResourceReq : IExtensible
	{
		private BaseRequest _BaseRequest;

		private int _PropsCount;

		private readonly List<uint> _PropsIdList = new List<uint>();

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

		[ProtoMember(2, IsRequired = true, Name = "PropsCount", DataFormat = DataFormat.TwosComplement)]
		public int PropsCount
		{
			get
			{
				return this._PropsCount;
			}
			set
			{
				this._PropsCount = value;
			}
		}

		[ProtoMember(3, Name = "PropsIdList", DataFormat = DataFormat.TwosComplement, Options = MemberSerializationOptions.Packed)]
		public List<uint> PropsIdList
		{
			get
			{
				return this._PropsIdList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
