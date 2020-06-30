using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "RemindSyncRequest")]
	[Serializable]
	public class RemindSyncRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _Selector;

		private SKBuiltinBuffer_t _KeyBuff;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BaseRequest", DataFormat = DataFormat.Default)]
		public BaseRequest BaseRequest
		{
			get
			{
				return this._BaseRequest;
			}
			set
			{
				this._BaseRequest = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "Selector", DataFormat = DataFormat.TwosComplement)]
		public uint Selector
		{
			get
			{
				return this._Selector;
			}
			set
			{
				this._Selector = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "KeyBuff", DataFormat = DataFormat.Default)]
		public SKBuiltinBuffer_t KeyBuff
		{
			get
			{
				return this._KeyBuff;
			}
			set
			{
				this._KeyBuff = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
