using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "QueryResCtx")]
	[Serializable]
	public class QueryResCtx : IExtensible
	{
		private uint _Interval;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Interval", DataFormat = DataFormat.TwosComplement)]
		public uint Interval
		{
			get
			{
				return this._Interval;
			}
			set
			{
				this._Interval = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
