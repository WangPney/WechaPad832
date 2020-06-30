using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "SnsObjectDetailRequest")]
	[Serializable]
	public class SnsObjectDetailRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private ulong _Id;

		private uint _GroupDetail = 0u;

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

		[ProtoMember(2, IsRequired = true, Name = "Id", DataFormat = DataFormat.TwosComplement)]
		public ulong Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				this._Id = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "GroupDetail", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint GroupDetail
		{
			get
			{
				return this._GroupDetail;
			}
			set
			{
				this._GroupDetail = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
