using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "HWParamBuffer")]
	[Serializable]
	public class HWParamBuffer : IExtensible
	{
		private uint _HeaderLen;

		private byte[] _SPSBuf;

		private byte[] _PPSBuf;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "HeaderLen", DataFormat = DataFormat.TwosComplement)]
		public uint HeaderLen
		{
			get
			{
				return this._HeaderLen;
			}
			set
			{
				this._HeaderLen = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "SPSBuf", DataFormat = DataFormat.Default)]
		public byte[] SPSBuf
		{
			get
			{
				return this._SPSBuf;
			}
			set
			{
				this._SPSBuf = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "PPSBuf", DataFormat = DataFormat.Default)]
		public byte[] PPSBuf
		{
			get
			{
				return this._PPSBuf;
			}
			set
			{
				this._PPSBuf = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
