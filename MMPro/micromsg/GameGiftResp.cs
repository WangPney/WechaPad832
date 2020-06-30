using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GameGiftResp")]
	[Serializable]
	public class GameGiftResp : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _LifeNum;

		private uint _CheckLeftTime;

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

		[ProtoMember(2, IsRequired = true, Name = "LifeNum", DataFormat = DataFormat.TwosComplement)]
		public uint LifeNum
		{
			get
			{
				return this._LifeNum;
			}
			set
			{
				this._LifeNum = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "CheckLeftTime", DataFormat = DataFormat.TwosComplement)]
		public uint CheckLeftTime
		{
			get
			{
				return this._CheckLeftTime;
			}
			set
			{
				this._CheckLeftTime = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
