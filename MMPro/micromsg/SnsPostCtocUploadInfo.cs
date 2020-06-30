using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "SnsPostCtocUploadInfo")]
	[Serializable]
	public class SnsPostCtocUploadInfo : IExtensible
	{
		private uint _Flag;

		private uint _PhotoCount;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Flag", DataFormat = DataFormat.TwosComplement)]
		public uint Flag
		{
			get
			{
				return this._Flag;
			}
			set
			{
				this._Flag = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "PhotoCount", DataFormat = DataFormat.TwosComplement)]
		public uint PhotoCount
		{
			get
			{
				return this._PhotoCount;
			}
			set
			{
				this._PhotoCount = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
