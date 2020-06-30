using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "AskForRewardRequest")]
	[Serializable]
	public class AskForRewardRequest : IExtensible
	{
		private string _ProductID;

		private EmotionPrice _Price;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "ProductID", DataFormat = DataFormat.Default)]
		public string ProductID
		{
			get
			{
				return this._ProductID;
			}
			set
			{
				this._ProductID = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "Price", DataFormat = DataFormat.Default)]
		public EmotionPrice Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				this._Price = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
