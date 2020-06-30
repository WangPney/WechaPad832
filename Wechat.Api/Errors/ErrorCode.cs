using System.Collections.Generic;

namespace WeChat.Api.Errors
{
    public enum ErrorCode
    {
        OK=0,
        ErrBadRequest = 400,
        ErrNotFound = 404,
        ErrInterServcerErr = 500,
    }

    public static class ErrorExtension
    {
        private static readonly Dictionary<ErrorCode, string> _codeMsgs = new
            Dictionary<ErrorCode, string>
        {
            { ErrorCode.OK, "OK" },
            { ErrorCode.ErrBadRequest, "Bad Request" },
            { ErrorCode.ErrNotFound, "Not Found" },
            { ErrorCode.ErrInterServcerErr, "Internal Error" },
        };
        public static string CodeString(this ErrorCode code)
        {
            if (_codeMsgs.TryGetValue(code, out string msg))
            {
                return msg;
            }
            return "Unknown Error";
        }
    }
}
