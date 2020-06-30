using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "GeneralShareRequest")]
	[Serializable]
	public class GeneralShareRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private GeneralShareBaseInfo _BaseInfo;

		private GeneralShareContent _Content;

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

		[ProtoMember(2, IsRequired = true, Name = "BaseInfo", DataFormat = DataFormat.Default)]
		public GeneralShareBaseInfo BaseInfo
		{
			get
			{
				return this._BaseInfo;
			}
			set
			{
				this._BaseInfo = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "Content", DataFormat = DataFormat.Default)]
		public GeneralShareContent Content
		{
			get
			{
				return this._Content;
			}
			set
			{
				this._Content = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
