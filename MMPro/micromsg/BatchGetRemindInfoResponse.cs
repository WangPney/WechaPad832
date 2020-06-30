using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "BatchGetRemindInfoResponse")]
	[Serializable]
	public class BatchGetRemindInfoResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _RemindInfoCount;

		private readonly List<RemindItem> _RemindInfoList = new List<RemindItem>();

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "BaseResponse", DataFormat = DataFormat.Default)]
		public BaseResponse BaseResponse
		{
			get
			{
				return this._BaseResponse;
			}
			set
			{
				this._BaseResponse = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "RemindInfoCount", DataFormat = DataFormat.TwosComplement)]
		public uint RemindInfoCount
		{
			get
			{
				return this._RemindInfoCount;
			}
			set
			{
				this._RemindInfoCount = value;
			}
		}

		[ProtoMember(3, Name = "RemindInfoList", DataFormat = DataFormat.Default)]
		public List<RemindItem> RemindInfoList
		{
			get
			{
				return this._RemindInfoList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
