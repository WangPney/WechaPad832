using NLog;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WeChat.Api.Errors;

namespace Wechat.Api.Aop
{
    public class ExceptionHandler : IActionFilter,IOrderedFilter
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public int Order { get; set; } = 10-int.MaxValue;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //if (!context.Canceled)
            //{
            //    return;
            //}
            #region  bind error
            if (!context.ModelState.IsValid)
            {
                //build error
                var msgSb = new StringBuilder();
                foreach (var kv in context.ModelState)
                {
                    var entry = kv.Value;
                    if (entry.ValidationState != ModelValidationState.Invalid)
                    {
                        continue;
                    }
                    msgSb.Append($"\r\n[{kv.Key}]");
                    foreach (var err in entry.Errors)
                    {
                        msgSb.Append($"{err.ErrorMessage};");
                    }
                }
                context.Result = new BadRequestObjectResult(
                    ObjError.New().
                    WithRequestId(context.HttpContext.TraceIdentifier).
                    WithCode(ErrorCode.ErrBadRequest).
                    WithMessage($"{msgSb.ToString()}(requestId:{context.HttpContext.TraceIdentifier})"));
                return;
            }
            #endregion

            #region Exception
            if (context.Exception == null)
            {
                if(context.Result is ObjectResult result)
                {
                    if( result.Value is IResponse resp)
                    {
                        resp.SetRequestId(context.HttpContext.TraceIdentifier);
                    }
                }
                return;
            }
            var exception = context.Exception;
            var msg = exception.Message;
            if (exception is WhException kitExecption)
            {
                context.Result = new ObjectResult(
                    kitExecption.Unwrap()
                    .WithRequestId(context.HttpContext.TraceIdentifier)
                    .WithMessage($"{msg}(requestId:{context.HttpContext.TraceIdentifier})")
                    ) { StatusCode = 200 };
            }
            else
            {
                logger.Warn($"unexcepted exception : {exception.Message}");
                context.Result = new ObjectResult(
                   ObjError.New().
                    WithRequestId(context.HttpContext.TraceIdentifier).
                    WithCode(ErrorCode.ErrInterServcerErr).
                    WithMessage($"{msg}(requestId:{context.HttpContext.TraceIdentifier})"))
                {
                    StatusCode = 500,
                };
            }
            context.ExceptionHandled = true;
            #endregion
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}












//using Castle.DynamicProxy;
//using Microsoft.Extensions.Logging;
//using System;

//namespace khwkit.Aop
//{
//    public class ExceptionHandler : IInterceptor
//    {
//        private readonly ILogger<ExceptionHandler> logger;
//        //public ExceptionHandler()
//        //{
//        //}
//        public ExceptionHandler(ILogger<ExceptionHandler> logger)
//        {
//            this.logger = logger;
//            logger.LogDebug("SSSSSSSSSSSSSSSSSSSSSSSSS");
//        }

//        public virtual void Intercept(IInvocation invocation)
//        {
//            try
//            {
//                logger.LogDebug($"before service call : {invocation.Method.Name}");
//                invocation.Proceed(); //继续执行
//            }
//            catch (Exception e)
//            {
//                logger.LogDebug($"exception service call : {invocation.Method.Name}");
//            }
//            finally
//            {
//                logger.LogDebug($"end service call : {invocation.Method.Name}");
//            }
//        }

//        //public override  async Task Invoke(AspectContext context, AspectDelegate next)
//        //{
//        //    try
//        //    {
//        //        logger.LogDebug($"before service call : {context.ServiceMethod.Name}" );
//        //        await next(context);

//        //    }
//        //    catch (Exception e)
//        //    {
//        //        logger.LogDebug($"exception service call : {context.ServiceMethod.Name}");
//        //    }
//        //    finally
//        //    {
//        //        logger.LogDebug($"end service call : {context.ServiceMethod.Name}");
//        //    }
//        //}
//    }
//}
