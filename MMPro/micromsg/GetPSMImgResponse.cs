using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GetPSMImgResponse")]
	[Serializable]
	public class GetPSMImgResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private SKBuiltinBuffer_t _Data;

		private uint _TotalLength;

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

		[ProtoMember(2, IsRequired = true, Name = "Data", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t Data
		{
			get
			{
				return this._Data;
			}
			set
			{
				this._Data = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "TotalLength", DataFormat = DataFormat.TwosComplement)]
		public uint TotalLength
		{
			get
			{
				return this._TotalLength;
			}
			set
			{
				this._TotalLength = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
