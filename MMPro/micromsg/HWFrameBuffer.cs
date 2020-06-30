using ProtoBuf;
using System;
using System.Collections.Generic;

namespace micromsg
{
	[ProtoContract(Name = "HWFrameBuffer")]
	[Serializable]
	public class HWFrameBuffer : IExtensible
	{
		private byte[] _RawBuf;

		private int _SamplesCount;

		private readonly List<HWTimeInfo> _TimeInfo = new List<HWTimeInfo>();

		private readonly List<int> _SampleSize = new List<int>();

		private IExtension extensionObject;

		[ProtoMember(1, IsRequired = true, Name = "RawBuf", DataFormat = DataFormat.Default)]
		public byte[] RawBuf
		{
			get
			{
				return this._RawBuf;
			}
			set
			{
				this._RawBuf = value;
			}
		}

		[ProtoMember(2, IsRequired = true, Name = "SamplesCount", DataFormat = DataFormat.TwosComplement)]
		public int SamplesCount
		{
			get
			{
				return this._SamplesCount;
			}
			set
			{
				this._SamplesCount = value;
			}
		}

		[ProtoMember(3, Name = "TimeInfo", DataFormat = DataFormat.Default)]
		public List<HWTimeInfo> TimeInfo
		{
			get
			{
				return this._TimeInfo;
			}
		}

		[ProtoMember(4, Name = "SampleSize", DataFormat = DataFormat.TwosComplement)]
		public List<int> SampleSize
		{
			get
			{
				return this._SampleSize;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}
	}
}
