using Microsoft.AspNetCore.Mvc;
using Wechat.Api.Beans.Login;
using Wechat.Protocol;
using WeChat.Api.Errors;
using System;
using static MMPro.MM;

namespace Wechat.Api.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly WechatHelper _wechat;
        public LoginController(WechatHelper wechat)
        {
            this._wechat =wechat;
        }
        /// <summary>
        /// 获取登录二维码
        /// </summary>
        [HttpPost("qr_code")]
        public Error<GetLoginQrCodeResp> GetQrCode([FromBody]GetLoginQrCodeReq req)
        {
           var result = _wechat.GetLoginQRcode(0,req.Proxy?.Ip ?? "", req.Proxy?.Username ?? "", req.DeviceId, req.DeviceName);
            if (result != null && result.baseResponse.ret == MMPro.MM.RetConst.MM_OK)
            {
                return Error<GetLoginQrCodeResp>.New().WithCode(ErrorCode.OK).WithData(new GetLoginQrCodeResp()
                {
                    QrCodeId = result.uuid,
                    QrCodeBase64 = $"data:img/jpg;base64,{result.qRCode.src.ToBase64String()}",
                    ExpiredTime = result.expiredTime,
                });
            }
            return Error<GetLoginQrCodeResp>.New().WithCode(ErrorCode.ErrInterServcerErr).WithMessage((result?.baseResponse?.errMsg.@string)??"获取二维码失败");
        }
        /// <summary>
        /// 检查登录状态
        /// </summary>
        /// <param name="qrCodeId">二维码ID</param>
        [HttpGet("state/{qrCodeId}")]
        public Error<CheckLoginResp> CheckLogin([FromRoute]string qrCodeId)
        {
            var result = _wechat.CheckLoginQRCode(qrCodeId);
            if (result != null)
            {
                CheckLoginResp checkLoginResponse = new CheckLoginResp();
                checkLoginResponse.State = result.State;
                checkLoginResponse.Uuid = result.Uuid;
                checkLoginResponse.WxId = result.WxId;
                checkLoginResponse.NickName = result.NickName;
                checkLoginResponse.Device = result.Device;
                checkLoginResponse.HeadUrl = result.HeadUrl;
                checkLoginResponse.Mobile = result.BindMobile;
                checkLoginResponse.Email = result.BindEmail;
                checkLoginResponse.Alias = result.Alias;
                return Error<CheckLoginResp>.New().WithCode(ErrorCode.OK).WithData(checkLoginResponse);
            }

            return Error<CheckLoginResp>.New().WithCode(ErrorCode.ErrInterServcerErr).WithMessage( "登录失败");
        }
        /// <summary>
        /// 心跳
        /// </summary>
        /// <param name="wxid">已登录的wxid</param>
        /// <returns></returns>
        [HttpGet("heartbeat/{wxid}")]
        public Error<HearbeatResp> HeartBeat([FromRoute]string wxid)
        {
            var result = _wechat.HeartBeat(wxid);
            if (result!=null && result.BaseResponse?.Ret == (int)RetConst.MM_OK)
            {
                return Error<HearbeatResp>.New()
                    .WithCode(ErrorCode.ErrInterServcerErr)
                    .WithData(new HearbeatResp() {NextTime=result.NextTime });
            }
            return Error<HearbeatResp>.New().WithCode(ErrorCode.ErrInterServcerErr).WithMessage("发送心跳失败");
        }
        ///// <summary>
        ///// 获取62数据
        ///// </summary>
        ///// <param name="wxid"></param>
        //[HttpGet("get_62_data/{wxid}")]
        //public Error<Data62Resp> Get62data([FromRoute]string wxid)
        //{
        //    var result = _wechat.Get62Data(wxid);
        //    if (result.IsEmpty())
        //    {
        //        return Error<Data62Resp>.New()
        //            .WithCode(ErrorCode.ErrInterServcerErr)
        //            .WithMessage("获取62数据失败");
        //    }
        //    return Error<Data62Resp>.New()
        //        .WithCode(ErrorCode.OK)
        //        .WithData(new Data62Resp() { Data62 = result });
        //}

        ///// <summary>
        ///// 62数据登录
        ///// </summary>
        ///// <param name="req"></param>
        //[HttpPost("with_62_data")]
        //public void Data62Login([FromBody]LoginWith62Req req)
        //{
        //    var result = _wechat.UserLogin(req.Username, req.Password, req.Data62, req.Proxy?.Ip, req.Proxy?.Username, req.Proxy?.Password);
        //}
        ///// <summary>
        ///// A16数据登录
        ///// </summary>
        ///// <param name="uuid"></param>
        //[HttpPost("with_a16_data")]
        //public void DataA16Login(string uuid)
        //{


        //}
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <param name="wxid"></param>
        [HttpDelete("out/{wxid}")]
        public Error<bool> LoginOut([FromRoute]string wxid)
        {
            var result = _wechat.logOut(wxid);
            if (result != null && result.BaseResponse.Ret== (int)RetConst.MM_OK)
            {
                return Error<bool>.New().WithCode(ErrorCode.OK).WithData(true);
            }
            else
            {
                return Error<bool>.New().WithCode(ErrorCode.ErrInterServcerErr)
                    .WithMessage("退出登录失败")
                    .WithData(false);
            }
        }
    }
}