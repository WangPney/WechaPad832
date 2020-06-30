using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "ModMicroBlogInfo")]
	[Serializable]
	public class ModMicroBlogInfo : IExtensible
	{
		private SKBuiltinString_t _UserName;

		private uint _MicroBlogType;

		private uint _NotifyStatus;

		private uint _DeleteFlag;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "UserName", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				this._UserName = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "MicroBlogType", DataFormat = DataFormat.TwosComplement)]
		public uint MicroBlogType
		{
			get
			{
				return this._MicroBlogType;
			}
			set
			{
				this._MicroBlogType = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "NotifyStatus", DataFormat = DataFormat.TwosComplement)]
		public uint NotifyStatus
		{
			get
			{
				return this._NotifyStatus;
			}
			set
			{
				this._NotifyStatus = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "DeleteFlag", DataFormat = DataFormat.TwosComplement)]
		public uint DeleteFlag
		{
			get
			{
				return this._DeleteFlag;
			}
			set
			{
				this._DeleteFlag = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
