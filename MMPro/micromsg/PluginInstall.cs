using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "PluginInstall")]
	[Serializable]
	public class PluginInstall : IExtensible
	{
		private uint _PluginFlag;

		private uint _IsUnInstall;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "PluginFlag", DataFormat = DataFormat.TwosComplement)]
		public uint PluginFlag
		{
			get
			{
				return this._PluginFlag;
			}
			set
			{
				this._PluginFlag = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "IsUnInstall", DataFormat = DataFormat.TwosComplement)]
		public uint IsUnInstall
		{
			get
			{
				return this._IsUnInstall;
			}
			set
			{
				this._IsUnInstall = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
