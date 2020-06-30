using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "DownLoadPackageRequest")]
	[Serializable]
	public class DownLoadPackageRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private Package _Package;

		private uint _Offset;

		private uint _Len;

		private uint _Type = 0u;

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

		[ProtoMember(2, IsRequired = true, Name = "Package", DataFormat = DataFormat.Default)]
		public Package Package
		{
			get
			{
				return this._Package;
			}
			set
			{
				this._Package = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "Offset", DataFormat = DataFormat.TwosComplement)]
		public uint Offset
		{
			get
			{
				return this._Offset;
			}
			set
			{
				this._Offset = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "Len", DataFormat = DataFormat.TwosComplement)]
		public uint Len
		{
			get
			{
				return this._Len;
			}
			set
			{
				this._Len = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "Type", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				this._Type = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
