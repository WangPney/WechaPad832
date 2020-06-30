using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "ModifyContactLabelListRequest")]
	[Serializable]
	public class ModifyContactLabelListRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _UserCount;

		private readonly List<UserLabelInfo> _UserLabelInfoList = new List<UserLabelInfo>();

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

		[ProtoMember(2, IsRequired = true, Name = "UserCount", DataFormat = DataFormat.TwosComplement)]
		public uint UserCount
		{
			get
			{
				return this._UserCount;
			}
			set
			{
				this._UserCount = value;
			}
		}

		[ProtoMember(3, Name = "UserLabelInfoList", DataFormat = DataFormat.Default)]
		public List<UserLabelInfo> UserLabelInfoList
		{
			get
			{
				return this._UserLabelInfoList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
