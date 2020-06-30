using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "GetTVTopicCommentResponse")]
	[Serializable]
	public class GetTVTopicCommentResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _Count;

		private readonly List<TVTopicCommentItem> _List = new List<TVTopicCommentItem>();

		private uint _LastCommentId;

		private uint _TotalCommentCount;

		private uint _LeftCommentCount;

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
		public List<TVTopicCommentItem> List
		{
			get
			{
				return this._List;
			}
		}

		[ProtoMember(4, IsRequired = true, Name = "LastCommentId", DataFormat = DataFormat.TwosComplement)]
		public uint LastCommentId
		{
			get
			{
				return this._LastCommentId;
			}
			set
			{
				this._LastCommentId = value;
			}
		}

		[ProtoMember(5, IsRequired = true, Name = "TotalCommentCount", DataFormat = DataFormat.TwosComplement)]
		public uint TotalCommentCount
		{
			get
			{
				return this._TotalCommentCount;
			}
			set
			{
				this._TotalCommentCount = value;
			}
		}

		[ProtoMember(6, IsRequired = true, Name = "LeftCommentCount", DataFormat = DataFormat.TwosComplement)]
		public uint LeftCommentCount
		{
			get
			{
				return this._LeftCommentCount;
			}
			set
			{
				this._LeftCommentCount = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
