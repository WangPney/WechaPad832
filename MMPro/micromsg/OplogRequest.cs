using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "OplogRequest")]
	[Serializable]
	public class OplogRequest : IExtensible
	{
		private CmdList _Oplog;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "Oplog", DataFormat = DataFormat.Default)]
		public CmdList Oplog
		{
			get
			{
				return this._Oplog;
			}
			set
			{
				this._Oplog = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
