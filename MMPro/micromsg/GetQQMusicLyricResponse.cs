using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GetQQMusicLyricResponse")]
	[Serializable]
	public class GetQQMusicLyricResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private SKBuiltinBuffer_t _SongLyric;

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

		[ProtoMember(2, IsRequired = true, Name = "SongLyric", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t SongLyric
		{
			get
			{
				return this._SongLyric;
			}
			set
			{
				this._SongLyric = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
