using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "ImgPair")]
	[Serializable]
	public class ImgPair : IExtensible
	{
		private SKBuiltinBuffer_t _ImgBuf;

		private SKBuiltinString_t _Username;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "ImgBuf", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t ImgBuf
		{
			get
			{
				return this._ImgBuf;
			}
			set
			{
				this._ImgBuf = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "Username", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				this._Username = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
