using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "ScanStreetViewRequest")]
	[Serializable]
	public class ScanStreetViewRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private PositionInfo _UserPos;

		private uint _Scene = 0u;

		private float _Heading = 0f;

		private float _Pitch = 0f;

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

		[ProtoMember(2, IsRequired = true, Name = "UserPos", DataFormat = DataFormat.Default)]
		public PositionInfo UserPos
		{
			get
			{
				return this._UserPos;
			}
			set
			{
				this._UserPos = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "Scene", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Scene
		{
			get
			{
				return this._Scene;
			}
			set
			{
				this._Scene = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "Heading", DataFormat = DataFormat.FixedSize), DefaultValue(0f)]
		public float Heading
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

		[ProtoMember(5, IsRequired = false, Name = "Pitch", DataFormat = DataFormat.FixedSize), DefaultValue(0f)]
		public float Pitch
		{
			get
			{
				return this._Pitch;
			}
			set
			{
				this._Pitch = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
