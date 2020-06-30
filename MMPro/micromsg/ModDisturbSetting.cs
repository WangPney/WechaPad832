using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "ModDisturbSetting")]
	[Serializable]
	public class ModDisturbSetting : IExtensible
	{
		private DisturbSetting _DisturbSetting;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "DisturbSetting", DataFormat = DataFormat.Default)]
		public DisturbSetting DisturbSetting
		{
			get
			{
				return this._DisturbSetting;
			}
			set
			{
				this._DisturbSetting = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
