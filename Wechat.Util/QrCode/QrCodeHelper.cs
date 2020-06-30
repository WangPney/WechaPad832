using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace Wechat.Util.QrCode
{
    public class QrCodeHelper
    {
        public static Bitmap CreateQRCode(string asset, int width = 120, int height = 120)
        {
            EncodingOptions options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = width,
                Height = height
            };
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;
            return writer.Write(asset);
        }

        /// <summary>
        /// 解码二维码
        /// </summary>
        /// <param name="barcodeBitmap">待解码的二维码图片</param>
        /// <returns>扫码结果</returns>
        public static string DecodeQrCode(Stream sm)
        {
            Bitmap barcodeBitmap = new Bitmap(sm);
            BarcodeReader reader = new BarcodeReader();
            reader.Options.CharacterSet = "UTF-8";
            var result = reader.Decode(barcodeBitmap);
            return (result == null) ? null : result.Text;
        }


    
    }
}
