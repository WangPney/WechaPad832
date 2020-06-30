using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "GetAppSettingResponse")]
	[Serializable]
	public class GetAppSettingResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _AppCount;

		private readonly List<AppSetting> _SettingList = new List<AppSetting>();

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

		[ProtoMember(2, IsRequired = true, Name = "AppCount", DataFormat = DataFormat.TwosComplement)]
		public uint AppCount
		{
			get
			{
				return this._AppCount;
			}
			set
			{
				this._AppCount = value;
			}
		}

		[ProtoMember(3, Name = "SettingList", DataFormat = DataFormat.Default)]
		public List<AppSetting> SettingList
		{
			get
			{
				return this._SettingList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
