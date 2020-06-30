using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "MediaNoteOpLog")]
	[Serializable]
	public class MediaNoteOpLog : IExtensible
	{
		private uint _WriteCount;

		private int _NoteType;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "WriteCount", DataFormat = DataFormat.TwosComplement)]
		public uint WriteCount
		{
			get
			{
				return this._WriteCount;
			}
			set
			{
				this._WriteCount = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "NoteType", DataFormat = DataFormat.TwosComplement)]
		public int NoteType
		{
			get
			{
				return this._NoteType;
			}
			set
			{
				this._NoteType = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
