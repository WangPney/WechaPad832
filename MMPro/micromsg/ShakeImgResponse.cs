using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "ShakeImgResponse")]
	[Serializable]
	public class ShakeImgResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _ImgId;

		private uint _TotalLen;

		private uint _StartPos;

		private SKBuiltinBuffer_t _Buffer;

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

		[ProtoMember(2, IsRequired = true, Name = "ImgId", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = true, Name = "TotalLen", DataFormat = DataFormat.TwosComplement)]
		public uint TotalLen
		{
			get
			{
				return this._TotalLen;
			}
			set
			{
				this._TotalLen = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "StartPos", DataFormat = DataFormat.TwosComplement)]
		public uint StartPos
		{
			get
			{
				return this._StartPos;
			}
			set
			{
				this._StartPos = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "Buffer", DataFormat = DataFormat.Default)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
