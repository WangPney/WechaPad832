using System;

namespace WeChat.Api.Errors
{
    public class ObjError:Error<object>
    {
        public ObjError() : base() { }
        public ObjError(int code, object data = null) : base(code,  data)
        {
        }
        public ObjError(string msg, object data = null) : base(msg, data)
        {
        }
        public ObjError(int code, string msg, object data = null) : base(code, msg, data)
        {
        }
        public new ObjError WithRequestId(string id)
        {
            this.RequestId = id;
            return this;
        }
        public new ObjError WithCode(int code)
        {
            this.Code = code;
            if (this.Message.IsEmpty())
            {
                this.Message = ((ErrorCode)code).CodeString();
            }
            return this;
        }
        public new ObjError WithCode(ErrorCode code)
        {
            return this.WithCode((int)code);
        }
        public new ObjError WithMessage(string msg)
        {
            this.Message = $"{((ErrorCode)Code).CodeString()} {(msg.IsEmpty() ? "" : $": { msg}")}";
            return this;
        }
        public new ObjError WithData(object data)
        {
            if (data is bool ok)
            {
                if (ok)
                {
                    this.Code = 0;
                    this.Message = ErrorCode.OK.CodeString();
                }
            }
            else
            {
                this.Data = data;
            }
            return this;
        }
        public WhException Wrap()
        {
            return new WhException(this);
        }
        public new static ObjError New()
        {
            return new ObjError();
        }
    }
}
