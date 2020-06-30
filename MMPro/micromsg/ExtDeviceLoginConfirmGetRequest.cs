using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "ExtDeviceLoginConfirmGetRequest")]
	[Serializable]
	public class ExtDeviceLoginConfirmGetRequest : IExtensible
	{
		private string _LoginUrl;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "LoginUrl", DataFormat = DataFormat.Default)]
		public string LoginUrl
		{
			get
			{
				return this._LoginUrl;
			}
			set
			{
				this._LoginUrl = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
