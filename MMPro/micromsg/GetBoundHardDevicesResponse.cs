using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "GetBoundHardDevicesResponse")]
	[Serializable]
	public class GetBoundHardDevicesResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _Count;

		private readonly List<ModHardDevice> _DeviceList = new List<ModHardDevice>();

		private uint _Version;

		private uint _ContinueFlag;

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

		[ProtoMember(2, IsRequired = true, Name = "Count", DataFormat = DataFormat.TwosComplement)]
		public uint Count
		{
			get
			{
				return this._Count;
			}
			set
			{
				this._Count = value;
			}
		}

		[ProtoMember(5, Name = "DeviceList", DataFormat = DataFormat.Default)]
		public List<ModHardDevice> DeviceList
		{
			get
			{
				return this._DeviceList;
			}
		}

		[ProtoMember(6, IsRequired = true, Name = "Version", DataFormat = DataFormat.TwosComplement)]
		public uint Version
		{
			get
			{
				return this._Version;
			}
			set
			{
				this._Version = value;
			}
		}

		[ProtoMember(7, IsRequired = true, Name = "ContinueFlag", DataFormat = DataFormat.TwosComplement)]
		public uint ContinueFlag
		{
			get
			{
				return this._ContinueFlag;
			}
			set
			{
				this._ContinueFlag = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
