using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "Whatsnew61")]
	[Serializable]
	public class Whatsnew61 : IExtensible
	{
		private uint _like = 0u;

		private uint _liked = 0u;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = false, Name = "like", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint like
		{
			get
			{
				return this._like;
			}
			set
			{
				this._like = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "liked", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint liked
		{
			get
			{
				return this._liked;
			}
			set
			{
				this._liked = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
