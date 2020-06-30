using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "InitResponse")]
	[Serializable]
	public class InitResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _NewSyncKey;

		private int _ContinueFlag;

		private uint _CmdCount;

		private readonly List<CmdItem> _CmdList = new List<CmdItem>();

		private SKBuiltinString_t _Buffer;

		private uint _Ratio;

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

		[ProtoMember(2, IsRequired = true, Name = "NewSyncKey", DataFormat = DataFormat.TwosComplement)]
		public uint NewSyncKey
		{
			get
			{
				return this._NewSyncKey;
			}
			set
			{
				this._NewSyncKey = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "ContinueFlag", DataFormat = DataFormat.TwosComplement)]
		public int ContinueFlag
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

		[ProtoMember(4, IsRequired = true, Name = "CmdCount", DataFormat = DataFormat.TwosComplement)]
		public uint CmdCount
		{
			get
			{
				return this._CmdCount;
			}
			set
			{
				this._CmdCount = value;
			}
		}

		[ProtoMember(5, Name = "CmdList", DataFormat = DataFormat.Default)]
		public List<CmdItem> CmdList
		{
			get
			{
				return this._CmdList;
			}
		}

		[ProtoMember(6, IsRequired = true, Name = "Buffer", DataFormat = DataFormat.Default)]
		public SKBuiltinString_t Buffer
		{
			get
			{
				return this._Buffer;
			}
			set
			{
				this._Buffer = value;
			}
		}

		[ProtoMember(7, IsRequired = true, Name = "Ratio", DataFormat = DataFormat.TwosComplement)]
		public uint Ratio
		{
			get
			{
				return this._Ratio;
			}
			set
			{
				this._Ratio = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
