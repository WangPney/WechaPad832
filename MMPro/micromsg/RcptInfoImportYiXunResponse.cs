using ProtoBuf;
using System;

namespace micromsg
{
	[ProtoContract(Name = "RcptInfoImportYiXunResponse")]
	[Serializable]
	public class RcptInfoImportYiXunResponse : IExtensible
	{
		private RcptInfoList _rcptinfolist;

		private int _rcptinfoimportstatus;

		private BaseResponse _BaseResponse;

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "rcptinfolist", DataFormat = DataFormat.Default)]
		public RcptInfoList rcptinfolist
		{
			get
			{
				return this._rcptinfolist;
			}
			set
			{
				this._rcptinfolist = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "rcptinfoimportstatus", DataFormat = DataFormat.TwosComplement)]
		public int rcptinfoimportstatus
		{
			get
			{
				return this._rcptinfoimportstatus;
			}
			set
			{
				this._rcptinfoimportstatus = value;
			}
		}

		[ProtoMember(3, IsRequired = true, Name = "BaseResponse", DataFormat = DataFormat.Default)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
