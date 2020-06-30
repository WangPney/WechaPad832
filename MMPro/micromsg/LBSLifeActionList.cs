using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "LBSLifeActionList")]
	[Serializable]
	public class LBSLifeActionList : IExtensible
	{
		private uint _Type;

		private LBSLifeAction _LifeAction;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Type", DataFormat = DataFormat.TwosComplement)]
		public uint Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				this._Type = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "LifeAction", DataFormat = DataFormat.Default)]
		public LBSLifeAction LifeAction
		{
			get
			{
				return this._LifeAction;
			}
			set
			{
				this._LifeAction = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
