using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GameCheckResp")]
	[Serializable]
	public class GameCheckResp : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _CheckLeftTime;

		private uint _LifeNum;

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

		[ProtoMember(2, IsRequired = true, Name = "CheckLeftTime", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = true, Name = "LifeNum", DataFormat = DataFormat.TwosComplement)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
