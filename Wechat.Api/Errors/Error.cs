using Newtonsoft.Json;
using System;

namespace WeChat.Api.Errors
{
    public interface IResponse
    {
        public void SetRequestId(string id);
    }
    [Serializable]
    public class Error <T >:IResponse
    {
        [JsonIgnore]
        private const int defaultCode = 0;
        [JsonIgnore]
        private const string defaultMsg = "";
        [JsonProperty("requestId")]
        public string RequestId { get; set; }
        [JsonProperty("code")]
        public int Code { get; set; } = -1;
        [JsonProperty("message")]
        public string Message { get; set; } = "Generic Error";
        [JsonProperty("data")]
        public T Data { get; set; }

        public Error()
        {
        }
        public Error(int code, T data = default):this(code,"",data)
        {
        }
        public Error(string msg, T data = default) : this(0, msg, data)
        {
        }
        public Error(int code, string msg, T data = default):this()
        {
            this.Code = code;
            this.Message = $"{((ErrorCode)Code).CodeString()} {(msg.IsEmpty() ? "" : $": { msg}")}";
            this.Data = data;
        }

        public bool Ok()
        {
            return this.Ok(code => code == 0);
        }
        public bool Ok(Func<int, bool> func)
        {
            return func?.Invoke(this.Code) ?? false;
        }
        public void SetRequestId(string id)
        {
            this.RequestId = id;
        }
        public virtual Error<T> WithRequestId(string id)
        {
            this.RequestId = id; 
            return this;
        }
        public virtual Error<T> WithCode(int code)
        {
            this.Code = code;
            if (this.Message.IsEmpty())
            {
                this.Message = ((ErrorCode)code).CodeString();
            }
            return this;
        }
        public virtual Error<T> WithCode(ErrorCode code)
        {
            return this.WithCode((int)code);
        }
        public virtual Error<T> WithMessage(string msg)
        {
            this.Message = $"{((ErrorCode)Code).CodeString()} {(msg.IsEmpty()?"":$": { msg}")}";
            return this;
        }
        public virtual Error<T> WithData(T data)
        {
            this.Data = data ;
            return this;
        }

        public static Error<T> New()
        {
            return New(defaultCode, defaultMsg);
        }
        public static Error<T> New(int code)
        {
            return New(code, defaultMsg);
        }
        public static Error<T> New(string msg)
        {
            return New(defaultCode, msg);
        }
        public static Error<T> New(int code, string msg, T data = default)
        {
            return new Error<T>(code, msg, data);
        }
    }
}
