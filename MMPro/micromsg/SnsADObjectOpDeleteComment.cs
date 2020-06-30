using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "SnsADObjectOpDeleteComment")]
	[Serializable]
	public class SnsADObjectOpDeleteComment : IExtensible
	{
		private ulong _CommentId;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "CommentId", DataFormat = DataFormat.TwosComplement)]
		public ulong CommentId
		{
			get
			{
				return this._CommentId;
			}
			set
			{
				this._CommentId = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
