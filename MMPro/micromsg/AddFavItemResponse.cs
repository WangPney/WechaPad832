using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "AddFavItemResponse")]
	[Serializable]
	public class AddFavItemResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _FavId;

		private uint _UpdateSeq;

		private ulong _UsedSize = 0uL;

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

		[ProtoMember(3, IsRequired = true, Name = "UpdateSeq", DataFormat = DataFormat.TwosComplement)]
		public uint UpdateSeq
		{
			get
			{
				return this._UpdateSeq;
			}
			set
			{
				this._UpdateSeq = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "UsedSize", DataFormat = DataFormat.TwosComplement), DefaultValue(0f)]
		public ulong UsedSize
		{
			get
			{
				return this._UsedSize;
			}
			set
			{
				this._UsedSize = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
