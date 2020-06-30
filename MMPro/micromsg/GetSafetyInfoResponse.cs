using ProtoBuf;
using System;

namespace micromsg
{
    [ProtoContract(Name = "GetSafetyInfoResponse")]
    [Serializable]
    public class GetSafetyInfoResponse : IExtensible
    {
        private BaseResponse _BaseResponse;

        private SafetyInfo _info;

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

        [ProtoMember(2, IsRequired = true, Name = "info", DataFormat = DataFormat.Default)]
        public SafetyInfo info
        {
            get
            {
                return this._info;
            }
            set
            {
                this._info = value;
            }
        }

        IExtension IExtensible.GetExtensionObject(bool createIfMissing)
        {
            return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
        }
    }
}
