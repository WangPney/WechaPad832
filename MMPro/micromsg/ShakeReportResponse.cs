using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "ShakeReportResponse")]
	[Serializable]
	public class ShakeReportResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private SKBuiltinBuffer_t _Buffer;

		private int _Ret;

		private uint _ImgId;

		private uint _ImgTotoalLen = 0u;

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

		[ProtoMember(2, IsRequired = true, Name = "Buffer", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t Buffer
		{
			get
			{
				return this._Buffer;
			}
			set
			{
				this._Buffer = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "Ret", DataFormat = DataFormat.TwosComplement)]
		public int Ret
		{
			get
			{
				return this._Ret;
			}
			set
			{
				this._Ret = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "ImgId", DataFormat = DataFormat.TwosComplement)]
		public uint ImgId
		{
			get
			{
				return this._ImgId;
			}
			set
			{
				this._ImgId = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "ImgTotoalLen", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint ImgTotoalLen
		{
			get
			{
				return this._ImgTotoalLen;
			}
			set
			{
				this._ImgTotoalLen = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
