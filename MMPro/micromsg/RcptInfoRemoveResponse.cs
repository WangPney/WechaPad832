using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "RcptInfoRemoveResponse")]
	[Serializable]
	public class RcptInfoRemoveResponse : IExtensible
	{
		private uint _id;

		private RcptInfoList _rcptinfolist;

		private BaseResponse _BaseResponse;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id;
			}
			set
			{
				this._id = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "rcptinfolist", DataFormat = DataFormat.Default)]
		public RcptInfoList rcptinfolist
		{
			get
			{
				return this._rcptinfolist;
			}
			set
			{
				this._rcptinfolist = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "BaseResponse", DataFormat = DataFormat.Default)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
