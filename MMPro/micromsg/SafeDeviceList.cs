using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "SafeDeviceList")]
	[Serializable]
	public class SafeDeviceList : IExtensible
	{
		private uint _Count;

		private readonly List<SafeDevice> _List = new List<SafeDevice>();

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Count", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, Name = "List", DataFormat = DataFormat.Default)]
		public List<SafeDevice> List
		{
			get
			{
				return this._List;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
