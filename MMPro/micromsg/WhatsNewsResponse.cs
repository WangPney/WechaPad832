using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "WhatsNewsResponse")]
	[Serializable]
	public class WhatsNewsResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _RegistTime = 0u;

		private uint _FstSNSTime = 0u;

		private uint _Count = 0u;

		private readonly List<SKBuiltinString_t> _PicUrlList = new List<SKBuiltinString_t>();

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

		[ProtoMember(2, IsRequired = false, Name = "RegistTime", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint RegistTime
		{
			get
			{
				return this._RegistTime;
			}
			set
			{
				this._RegistTime = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "FstSNSTime", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint FstSNSTime
		{
			get
			{
				return this._FstSNSTime;
			}
			set
			{
				this._FstSNSTime = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "Count", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
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

		[ProtoMember(5, Name = "PicUrlList", DataFormat = DataFormat.Default)]
		public List<SKBuiltinString_t> PicUrlList
		{
			get
			{
				return this._PicUrlList;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
