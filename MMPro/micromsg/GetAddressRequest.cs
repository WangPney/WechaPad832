using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GetAddressRequest")]
	[Serializable]
	public class GetAddressRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private double _Longitude;

		private double _Latitude;

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

		[ProtoMember(2, IsRequired = true, Name = "Longitude", DataFormat = DataFormat.TwosComplement)]
		public double Longitude
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
		public double Latitude
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
