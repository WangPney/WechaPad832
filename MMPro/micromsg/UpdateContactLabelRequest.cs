using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "UpdateContactLabelRequest")]
	[Serializable]
	public class UpdateContactLabelRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private LabelPair _LabelPair;

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

		[ProtoMember(2, IsRequired = true, Name = "LabelPair", DataFormat = DataFormat.Default)]
		public LabelPair LabelPair
		{
			get
			{
				return this._LabelPair;
			}
			set
			{
				this._LabelPair = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
