using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "SendInviteEmailRequest")]
	[Serializable]
	public class SendInviteEmailRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _UinCount;

		private readonly List<uint> _UinList = new List<uint>();

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

		[ProtoMember(2, IsRequired = true, Name = "UinCount", DataFormat = DataFormat.TwosComplement)]
		public uint UinCount
		{
			get
			{
				return this._UinCount;
			}
			set
			{
				this._UinCount = value;
			}
		}

		[ProtoMember(3, Name = "UinList", DataFormat = DataFormat.TwosComplement, Options = MemberSerializationOptions.Packed)]
		public List<uint> UinList
		{
			get
			{
				return this._UinList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
