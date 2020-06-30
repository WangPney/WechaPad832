using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Wechat.Api.Beans.Message;
using Wechat.Api.Extensions;
using Wechat.Protocol;
using WeChat.Api.Errors;

namespace Wechat.Api.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly WechatHelper _wechat;

        public MessageController(WechatHelper wechat)
        {
            this._wechat = wechat;
        }
        /// <summary>
        /// 发送文本信息
        /// </summary>
        /// <param name="wxid">已登录的wxid</param>
        /// <param name="msg"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("send_txt_message/{wxid}")]
        public Error<IList<MMPro.MM.NewSendMsgRespone.NewMsgResponeNew>> SendTxtMessage([FromRoute, Required]string wxid, [FromBody,Required]TxtMessage msg)
        {
            IList<MMPro.MM.NewSendMsgRespone.NewMsgResponeNew> list = new List<MMPro.MM.NewSendMsgRespone.NewMsgResponeNew>();
            foreach (var item in msg.ToWxIds)
            {
                var result = _wechat.SendNewMsg(wxid, item, msg.Content);
                list.Add(result?.List?.FirstOrDefault());
            }
            return Error<IList<MMPro.MM.NewSendMsgRespone.NewMsgResponeNew>>.New()
                .WithCode(ErrorCode.OK)
                .WithData(list);
        }
        /// <summary>
        /// 发送语音信息
        /// </summary>
        /// <param name="wxid">已登录的wxid</param>
        /// <param name="msg"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("send_voice_message/{wxid}")]
        public Error<IList<MMPro.MM.UploadVoiceResponse>> SendVoiceMessage([FromRoute, Required]string wxid, [FromBody, Required]VoiceMessage msg)
        {
            IList<MMPro.MM.UploadVoiceResponse> list = new List<MMPro.MM.UploadVoiceResponse>();
            var buffer = Convert.FromBase64String(msg.Base64.Replace("data:audio/amr;base64,", ""));
            foreach (var item in msg.ToWxIds)
            {
                var result = _wechat.SendVoiceMessage(wxid, item, buffer, msg.FileName.GetVoiceType(), msg.VoiceSecond * 100);
                list.Add(result);
            }
            return Error<IList<MMPro.MM.UploadVoiceResponse>>.New()
                .WithCode(ErrorCode.OK)
                .WithData(list);
        }
        /// <summary>
        /// 发送图片信息
        /// </summary>
        /// <param name="wxid">已登录的wxid</param>
        /// <param name="msg"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("send_image_message/{wxid}")]
        public Error<IList<MMPro.MM.UploadMsgImgResponse>> SendImageMessage([FromRoute, Required]string wxid, [FromBody, Required]ImageMessage msg)
        {
            IList<MMPro.MM.UploadMsgImgResponse> list = new List<MMPro.MM.UploadMsgImgResponse>();
            byte[] buffer = null;
            var arr = msg.Base64.Split(',');
            if (arr.Count() == 2)
            {
                buffer = Convert.FromBase64String(arr[1]);
            }
            else
            {
                buffer = Convert.FromBase64String(msg.Base64);
            }
            foreach (var item in msg.ToWxIds)
            {
                var result = _wechat.SendImageMessage(wxid, item, buffer);
                list.Add(result);
            }
            return Error<IList<MMPro.MM.UploadMsgImgResponse>>.New()
                .WithCode(ErrorCode.OK)
                .WithData(list);
        }

        /// <summary>
        /// 发送视频信息
        /// </summary>
        /// <param name="wxid">已登录的wxid</param>
        /// <param name="msg"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("send_video_message/{wxid}")]
        public Error<IList<MMPro.MM.UploadVideoResponse>> SendVideoMessage([FromRoute, Required]string wxid, [FromBody, Required]VideoMessage msg)
        {
            IList<MMPro.MM.UploadVideoResponse> list = new List<MMPro.MM.UploadVideoResponse>();
            byte[] buffer = null;
            var arr = msg.Base64.Split(',');
            if (arr.Count() == 2)
            {
                buffer = Convert.FromBase64String(arr[1]);

            }
            else
            {
                buffer = Convert.FromBase64String(msg.Base64);
            }
            byte[] imageBuffer = null;
            var arrimageBuffer = msg.ImageBase64.Split(',');
            if (arrimageBuffer.Count() == 2)
            {
                imageBuffer = Convert.FromBase64String(arrimageBuffer[1]);

            }
            else
            {
                imageBuffer = Convert.FromBase64String(msg.ImageBase64);
            }
            foreach (var item in msg.ToWxIds)
            {
                var result = _wechat.SendVideoMessage(wxid, item, msg.PlayLength, buffer, imageBuffer);
                list.Add(result);
            }
            return Error<IList<MMPro.MM.UploadVideoResponse>>.New()
                .WithCode(ErrorCode.OK)
                .WithData(list);
        }
    }
}