using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "OpenQQMicroBlog")]
	[Serializable]
	public class OpenQQMicroBlog : IExtensible
	{
		private SKBuiltinString_t _MicroBlogUserName;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "MicroBlogUserName", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t MicroBlogUserName
		{
			get
			{
				return this._MicroBlogUserName;
			}
			set
			{
				this._MicroBlogUserName = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
