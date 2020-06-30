using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "DownLoadPackageResponse")]
	[Serializable]
	public class DownLoadPackageResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private SKBuiltinBuffer_t _PackageBuf;

		private uint _Type = 0u;

		private uint _TotalSize = 0u;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BaseResponse", DataFormat = DataFormat.Default)]
		public BaseResponse BaseResponse
		{
			get
			{
				return this._BaseResponse;
			}
			set
			{
				this._BaseResponse = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "PackageBuf", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t PackageBuf
		{
			get
			{
				return this._PackageBuf;
			}
			set
			{
				this._PackageBuf = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "Type", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		[ProtoMember(4, IsRequired = false, Name = "TotalSize", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint TotalSize
		{
			get
			{
				return this._TotalSize;
			}
			set
			{
				this._TotalSize = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
