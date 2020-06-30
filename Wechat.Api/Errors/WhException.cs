using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WeChat.Api.Errors
{
    public class WhException:Exception
    {
        private ObjError error;
        public WhException()
        {
        }

        public WhException(string message) : base(message)
        {
            this.error = new ObjError(-1, message);
        }

        public WhException(string message, Exception innerException) : base(message, innerException)
        {
            this.error = new ObjError(-1, message);
        }
        public WhException(ObjError err):base(err?.Message??"unknown error")
        {
            this.error = err;
        }
        public ObjError Unwrap()
        {
            return this.error;
        }
        public static WhException Wrap(ObjError err)
        {
            return new WhException(err);
        }

        public static WhException New()
        {
            return new WhException();
        }
    }
}
