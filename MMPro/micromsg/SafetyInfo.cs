using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "SafetyInfo")]
	[Serializable]
	public class SafetyInfo : IExtensible
	{
		private readonly List<LoginDevice> _devicelist = new List<LoginDevice>();

		private IExtension extensionObject;

		[ProtoMember(1, Name = "devicelist", DataFormat = DataFormat.Default)]
		public List<LoginDevice> devicelist
		{
			get
			{
				return this._devicelist;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
