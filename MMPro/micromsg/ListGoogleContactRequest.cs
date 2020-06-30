using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "ListGoogleContactRequest")]
	[Serializable]
	public class ListGoogleContactRequest : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _Count;

		private readonly List<GoogleContactUploadItem> _List = new List<GoogleContactUploadItem>();

		private uint _ContinueFlag;

		private uint _ClickSource;

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

		[ProtoMember(2, IsRequired = true, Name = "Count", DataFormat = DataFormat.TwosComplement)]
		public uint Count
		{
			get
			{
				return this._Count;
			}
			set
			{
				this._Count = value;
			}
		}

		[ProtoMember(3, Name = "List", DataFormat = DataFormat.Default)]
		public List<GoogleContactUploadItem> List
		{
			get
			{
				return this._List;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "ContinueFlag", DataFormat = DataFormat.TwosComplement)]
		public uint ContinueFlag
		{
			get
			{
				return this._ContinueFlag;
			}
			set
			{
				this._ContinueFlag = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "ClickSource", DataFormat = DataFormat.TwosComplement)]
		public uint ClickSource
		{
			get
			{
				return this._ClickSource;
			}
			set
			{
				this._ClickSource = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
