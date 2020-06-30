using Newtonsoft.Json;
using org.apache.rocketmq.client.producer;
using org.apache.rocketmq.common.message;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace Wechat.Util.Extensions
{
    public static class Extension
    {
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static object ToObj(this string str)
        {
            return JsonConvert.DeserializeObject(str);
        }

        public static T ToObj<T>(this string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }

        public static Stream ToStream(this byte[] buffer)
        {
            MemoryStream sm = new MemoryStream(buffer);
            return sm;
        }


        public static string ToStr(this byte[] buffer)
        {
            return Encoding.Default.GetString(buffer);

        }
        public static string ToStr(this byte[] buffer, Encoding encoding)
        {
            return encoding.GetString(buffer);

        }

        public static byte[] ToBuffer(this Stream sm)
        {
            sm.Seek(0, SeekOrigin.Begin);
            byte[] buffer = new byte[sm.Length];
            sm.Read(buffer, 0, buffer.Length);
            sm.Seek(0, SeekOrigin.Begin);
            return buffer;
        }

        public static async Task<byte[]> ToBufferAsync(this Stream sm)
        {
            sm.Seek(0, SeekOrigin.Begin);
            byte[] buffer = new byte[sm.Length];
            await sm.ReadAsync(buffer, 0, buffer.Length);
            sm.Seek(0, SeekOrigin.Begin);
            return buffer;
        }

        public static bool IsImage(this string fileName)
        {
            bool isImage = false;
            string[] exts = { ".bmp", ".dib", ".jpg", ".jpeg", ".jpe", ".jfif", ".png", ".gif", ".tif", ".tiff" };
            if (exts.Contains(fileName.ToLower()))
            {
                isImage = true;
            }
            return isImage;
        }

        public static bool IsVideo(this string fileName)
        {
            bool isVideo = false;
            string[] exts = { "wmv", ".asf", ".asx", ".rm", ".rmvb", ".mp4 ", ".3gp", ".mov", ".m4v", ".avi", ".dat", ".mkv", ".flv", ".vob" };
            if (exts.Contains(fileName.ToLower()))
            {
                isVideo = true;
            }
            return isVideo;
        }

        public static bool IsVoice(this string fileName)
        {
            bool isVoice = false;
            string[] exts = { ".wav", ".aif", ".aiff", ".au", ".mp3", ".ra", ".rm", ".ram", ".wma", ".mmf", ".amr", ".aac", ".flac", ".snd" };
            if (exts.Contains(fileName.ToLower()))
            {
                isVoice = true;
            }
            return isVoice;
        }


        public static Bitmap CreateQRCode(this string asset)
        {
            EncodingOptions options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 280,
                Height = 280
            };
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;
            var bitmap = writer.Write(asset);
            return bitmap;
        }

        /// <summary>
        ///  4、图片转换成字节流 
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static byte[] ImageToByteArray(this Image img)
        {
            ImageConverter imgconv = new ImageConverter();
            byte[] b = (byte[])imgconv.ConvertTo(img, typeof(byte[]));
            return b;
        }


        public static Image ToCustomeImage(this Image image, Dictionary<string, string> dic = null)
        {
            Bitmap printPicture = new Bitmap(image);
            int height = image.Height + 5;
            Font font = new Font("宋体", 10f);
            Graphics g = Graphics.FromImage(printPicture);
            Brush brush = new SolidBrush(Color.Black);

            g.SmoothingMode = SmoothingMode.HighQuality;

            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;//如果不填加反锯齿代码效果如图1

            int interval = 15;
            int pointX = 5;
            Rectangle destRect = new Rectangle(pointX, pointX, image.Width, image.Height + dic?.Count * 20 ?? 0);
            g.DrawImage(image, destRect, 0, 0, image.Width / 2, image.Height / 2, GraphicsUnit.Pixel);
            if (dic != null)
            {
                foreach (var item in dic)
                {

                    RectangleF layoutRectangle = new RectangleF(pointX, height, 260f, 85f);
                    g.DrawString($"{item.Key}:" + item.Value, font, brush, layoutRectangle);
                    height += interval;
                }

            }



            return printPicture;
        }

        public static SendResult SendMessage(this DefaultMQProducer defaultMQProducer, Message message)
        {
            var sendResult = defaultMQProducer.send(message);

            if (sendResult.getSendStatus() != SendStatus.SEND_OK)
            {
                Wechat.Util.Log.Logger.GetLog<DefaultMQProducer>().Error($"推送作业消息失败，推送内容【{Encoding.UTF8.GetString(message.getBody())}】");
            }
            return sendResult;
        }


        public static SendResult SendMessage(this DefaultMQProducer defaultMQProducer, Message message, int delayLevel)
        {
            message.setDelayTimeLevel(delayLevel);
            var sendResult = defaultMQProducer.send(message);

            if (sendResult.getSendStatus() != SendStatus.SEND_OK)
            {
                Wechat.Util.Log.Logger.GetLog<DefaultMQProducer>().Error($"推送作业消息失败，推送内容【{Encoding.UTF8.GetString(message.getBody())}】");
            }
            return sendResult;
        }
    }
}
