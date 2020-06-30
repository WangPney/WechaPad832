using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "ImportFriendsResponse")]
	[Serializable]
	public class ImportFriendsResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _ImportedCount;

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

		[ProtoMember(2, IsRequired = true, Name = "ImportedCount", DataFormat = DataFormat.TwosComplement)]
		public uint ImportedCount
		{
			get
			{
				return this._ImportedCount;
			}
			set
			{
				this._ImportedCount = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
