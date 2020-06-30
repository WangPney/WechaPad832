using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "HandleImgMsgResponse")]
	[Serializable]
	public class HandleImgMsgResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _MsgId;

		private SKBuiltinString_t _ClientImgId;

		private SKBuiltinString_t _FromUserName;

		private SKBuiltinString_t _ToUserName;

		private uint _ImgLen;

		private uint _CreateTime;

		private ulong _NewMsgId = 0uL;

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

		[ProtoMember(2, IsRequired = true, Name = "MsgId", DataFormat = DataFormat.TwosComplement)]
		public uint MsgId
		{
			get
			{
				return this._MsgId;
			}
			set
			{
				this._MsgId = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "ClientImgId", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t ClientImgId
		{
			get
			{
				return this._ClientImgId;
			}
			set
			{
				this._ClientImgId = value;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "FromUserName", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t FromUserName
		{
			get
			{
				return this._FromUserName;
			}
			set
			{
				this._FromUserName = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "ToUserName", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t ToUserName
		{
			get
			{
				return this._ToUserName;
			}
			set
			{
				this._ToUserName = value;
			}
		}

		[ProtoMember(6, IsRequired = true, Name = "ImgLen", DataFormat = DataFormat.TwosComplement)]
		public uint ImgLen
		{
			get
			{
				return this._ImgLen;
			}
			set
			{
				this._ImgLen = value;
			}
		}

		[ProtoMember(7, IsRequired = true, Name = "CreateTime", DataFormat = DataFormat.TwosComplement)]
		public uint CreateTime
		{
			get
			{
				return this._CreateTime;
			}
			set
			{
				this._CreateTime = value;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "NewMsgId", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
		public ulong NewMsgId
		{
			get
			{
				return this._NewMsgId;
			}
			set
			{
				this._NewMsgId = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
