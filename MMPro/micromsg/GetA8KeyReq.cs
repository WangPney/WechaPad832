using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "GetA8KeyReq")]
	[Serializable]
	public class GetA8KeyReq : IExtensible
	{
		private BaseRequest _BaseRequest;

		private uint _OpCode;

		private SKBuiltinBuffer_t _A2Key = null;

		private SKBuiltinString_t _AppID = null;

		private SKBuiltinString_t _Scope = null;

		private SKBuiltinString_t _State = null;

		private SKBuiltinString_t _ReqUrl = null;

		private string _FriendUserName = "";

		private uint _FriendQQ = 0u;

		private uint _Scene = 0u;

		private string _UserName = "";

		private string _BundleID = "";

		private SKBuiltinBuffer_t _A2KeyNew = null;

		private uint _Reason = 0u;

		private uint _FontScale = 0u;

		private uint _Flag = 0u;

		private string _NetType = "";

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

		[ProtoMember(2, IsRequired = true, Name = "OpCode", DataFormat = DataFormat.TwosComplement)]
		public uint OpCode
		{
			get
			{
				return this._OpCode;
			}
			set
			{
				this._OpCode = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "A2Key", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t A2Key
		{
			get
			{
				return this._A2Key;
			}
			set
			{
				this._A2Key = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "AppID", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinString_t AppID
		{
			get
			{
				return this._AppID;
			}
			set
			{
				this._AppID = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "Scope", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinString_t Scope
		{
			get
			{
				return this._Scope;
			}
			set
			{
				this._Scope = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "State", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinString_t State
		{
			get
			{
				return this._State;
			}
			set
			{
				this._State = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "ReqUrl", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinString_t ReqUrl
		{
			get
			{
				return this._ReqUrl;
			}
			set
			{
				this._ReqUrl = value;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "FriendUserName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string FriendUserName
		{
			get
			{
				return this._FriendUserName;
			}
			set
			{
				this._FriendUserName = value;
			}
		}

		[ProtoMember(9, IsRequired = false, Name = "FriendQQ", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint FriendQQ
		{
			get
			{
				return this._FriendQQ;
			}
			set
			{
				this._FriendQQ = value;
			}
		}

		[ProtoMember(10, IsRequired = false, Name = "Scene", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Scene
		{
			get
			{
				return this._Scene;
			}
			set
			{
				this._Scene = value;
			}
		}

		[ProtoMember(11, IsRequired = false, Name = "UserName", DataFormat = DataFormat.Default), DefaultValue("")]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				this._UserName = value;
			}
		}

		[ProtoMember(12, IsRequired = false, Name = "BundleID", DataFormat = DataFormat.Default), DefaultValue("")]
		public string BundleID
		{
			get
			{
				return this._BundleID;
			}
			set
			{
				this._BundleID = value;
			}
		}

		[ProtoMember(13, IsRequired = false, Name = "A2KeyNew", DataFormat = DataFormat.Default), DefaultValue(null)]
		public SKBuiltinBuffer_t A2KeyNew
		{
			get
			{
				return this._A2KeyNew;
			}
			set
			{
				this._A2KeyNew = value;
			}
		}

		[ProtoMember(14, IsRequired = false, Name = "Reason", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Reason
		{
			get
			{
				return this._Reason;
			}
			set
			{
				this._Reason = value;
			}
		}

		[ProtoMember(15, IsRequired = false, Name = "FontScale", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint FontScale
		{
			get
			{
				return this._FontScale;
			}
			set
			{
				this._FontScale = value;
			}
		}

		[ProtoMember(16, IsRequired = false, Name = "Flag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint Flag
		{
			get
			{
				return this._Flag;
			}
			set
			{
				this._Flag = value;
			}
		}

		[ProtoMember(17, IsRequired = false, Name = "NetType", DataFormat = DataFormat.Default), DefaultValue("")]
		public string NetType
		{
			get
			{
				return this._NetType;
			}
			set
			{
				this._NetType = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
