using ProtoBuf;
using System;
using System.ComponentModel;

namespace micromsg
{
	[ProtoContract(Name = "UnifyAuthResponse")]
	[Serializable]
	public class UnifyAuthResponse : IExtensible
	{
		private BaseResponse _BaseResponse;

		private uint _UnifyAuthSectFlag = 0u;

		private AuthSectResp _AuthSectResp = null;

		private AcctSectResp _AcctSectResp = null;

		private NetworkSectResp _NetworkSectResp = null;

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

		[ProtoMember(2, IsRequired = false, Name = "UnifyAuthSectFlag", DataFormat = DataFormat.TwosComplement), DefaultValue(0L)]
		public uint UnifyAuthSectFlag
		{
			get
			{
				return this._UnifyAuthSectFlag;
			}
			set
			{
				this._UnifyAuthSectFlag = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "AuthSectResp", DataFormat = DataFormat.Default), DefaultValue(null)]
		public AuthSectResp AuthSectResp
		{
			get
			{
				return this._AuthSectResp;
			}
			set
			{
				this._AuthSectResp = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "AcctSectResp", DataFormat = DataFormat.Default), DefaultValue(null)]
		public AcctSectResp AcctSectResp
		{
			get
			{
				return this._AcctSectResp;
			}
			set
			{
				this._AcctSectResp = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "NetworkSectResp", DataFormat = DataFormat.Default), DefaultValue(null)]
		public NetworkSectResp NetworkSectResp
		{
			get
			{
				return this._NetworkSectResp;
			}
			set
			{
				this._NetworkSectResp = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
