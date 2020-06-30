using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GetQQMusicLyricRequest")]
	[Serializable]
	public class GetQQMusicLyricRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _SongId;

		private SKBuiltinBuffer_t _Url;

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

		[ProtoMember(2, IsRequired = true, Name = "SongId", DataFormat = DataFormat.TwosComplement)]
		public uint SongId
		{
			get
			{
				return this._SongId;
			}
			set
			{
				this._SongId = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "Url", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t Url
		{
			get
			{
				return this._Url;
			}
			set
			{
				this._Url = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
