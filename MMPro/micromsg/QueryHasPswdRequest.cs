using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "QueryHasPswdRequest")]
	[Serializable]
	public class QueryHasPswdRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private int _Scene;

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

		[ProtoMember(2, IsRequired = true, Name = "Scene", DataFormat = DataFormat.TwosComplement)]
		public int Scene
		{
			get
			{
				return this._Scene;
			}
			set
			{
				this._Scene = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
