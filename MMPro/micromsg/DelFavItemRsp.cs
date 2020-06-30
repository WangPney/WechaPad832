using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "DelFavItemRsp")]
	[Serializable]
	public class DelFavItemRsp : IExtensible
	{
		private int _Ret;

		private uint _FavId;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Ret", DataFormat = DataFormat.TwosComplement)]
		public int Ret
		{
			get
			{
				return this._Ret;
			}
			set
			{
				this._Ret = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "FavId", DataFormat = DataFormat.TwosComplement)]
		public uint FavId
		{
			get
			{
				return this._FavId;
			}
			set
			{
				this._FavId = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
