using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "SnsObjectOpDeleteComment")]
	[Serializable]
	public class SnsObjectOpDeleteComment : IExtensible
	{
		private int _CommentId;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "CommentId", DataFormat = DataFormat.TwosComplement)]
		public int CommentId
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
