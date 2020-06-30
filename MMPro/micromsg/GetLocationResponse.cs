using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GetLocationResponse")]
	[Serializable]
	public class GetLocationResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private int _Longitude;

		private int _Latitude;

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

		[ProtoMember(2, IsRequired = true, Name = "Longitude", DataFormat = DataFormat.TwosComplement)]
		public int Longitude
		{
			get
			{
				return this._Longitude;
			}
			set
			{
				this._Longitude = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "Latitude", DataFormat = DataFormat.TwosComplement)]
		public int Latitude
		{
			get
			{
				return this._Latitude;
			}
			set
			{
				this._Latitude = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
