using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "PositionItem")]
	[Serializable]
	public class PositionItem : IExtensible
	{
		private double _Latitude;

		private double _Longitude;

		private double _Heading;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Latitude", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = true, Name = "Heading", DataFormat = DataFormat.TwosComplement)]
		public double Heading
		{
			get
			{
				return this._Heading;
			}
			set
			{
				this._Heading = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
