using CRYPT;
using Google.ProtocolBuffers;
using micromsg;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;
using Wechat.Util.Ip;

namespace Wechat.Protocol
{
    public class Util
    {
        [DllImport("CodeDecrypt.dll", EntryPoint = "Zip")]
        private static extern int Zip(byte[] srcByte, int srcLen, byte[] dstByte, int dstLen);
        [DllImport("Common.dll")]
        public static extern int GenerateECKey(int nid, byte[] pub, byte[] pri);

        [DllImport("Common.dll")]
        public static extern int ComputerECCKeyMD5(byte[] pub, int pubLen, byte[] pri, int priLen, byte[] eccKey);

        public const string shortUrl = "http://szshort.weixin.qq.com";
        //public const string shortUrl = "http://szextshort.weixin.qq.com";

        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        ///<param name="t">
        /// <returns></returns>
        public static string SerializeToString<t>(t T)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize<t>(ms, T);

                ProtoBuf.Serializer.Deserialize<t>(ms);

                return Encoding.ASCII.GetString(ms.ToArray());
            }
        }

        public static T Deserialize<T>(byte[] data)
        {
            T t = default(T);
            try
            {
                using (var sm = new MemoryStream(data))
                {
                    t = ProtoBuf.Serializer.Deserialize<T>(sm);
                }
            }
            catch (Exception ex)
            {
                Wechat.Util.Log.Logger.GetLog("Wechat.Protocol.Util").Error(ex);

            }
            return t;

        }

        public static byte[] Serialize<T>(T data)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(memoryStream, data);
                return memoryStream.ToArray();
            }
        }

        public static byte[] nocompress_rsa(byte[] data)
        {
            RSA rsa = RSA.Create();
            rsa.ImportParameters(new RSAParameters() { Exponent = "010001".ToByteArray(16, 2), Modulus = "D153E8A2B314D2110250A0A550DDACDCD77F5801F3D1CC21CB1B477E4F2DE8697D40F10265D066BE8200876BB7135EDC74CDBC7C4428064E0CDCBE1B6B92D93CEAD69EC27126DEBDE564AAE1519ACA836AA70487346C85931273E3AA9D24A721D0B854A7FCB9DED49EE03A44C189124FBEB8B17BB1DBE47A534637777D33EEC88802CD56D0C7683A796027474FEBF237FA5BF85C044ADC63885A70388CD3696D1F2E466EB6666EC8EFE1F91BC9353F8F0EAC67CC7B3281F819A17501E15D03291A2A189F6A35592130DE2FE5ED8E3ED59F65C488391E2D9557748D4065D00CBEA74EB8CA19867C65B3E57237BAA8BF0C0F79EBFC72E78AC29621C8AD61A2B79B".ToByteArray(16, 2) });

            return rsa.Encrypt(data, RSAEncryptionPadding.Pkcs1);
        }

        public static string Get62Key(string Data)
        {
            int FinIndex = Data.IndexOf("6E756C6C5F1020", StringComparison.CurrentCultureIgnoreCase);

            if (FinIndex == -1)
            {
                return "3267b9918eb51294259866a6360432c0";
            }

            int head = FinIndex + "6E756C6C5F1020".Length;
            return Encoding.Default.GetString(Data.Substring(head, 64).ToByteArray(16, 2));
        }

 




        public static string stringWithFormEncodedComponentsAscending(Dictionary<string, object> queryPairs, bool ascending, bool skipempty, string sep)
        {
            List<string> list;
            if (ascending)
            {
                list = (from m in queryPairs
                        select m.Key into b
                        orderby b
                        select b).ToList<string>();
            }
            else
            {
                list = (from m in queryPairs
                        select m.Key into b
                        orderby b descending
                        select b).ToList<string>();
            }
            string str = null;
            foreach (string str2 in list)
            {
                string str3;
                if (queryPairs[str2] == null)
                {
                    str3 = string.Empty;
                }
                else if (queryPairs[str2] is Enum)
                {
                    str3 = ((int)queryPairs[str2]).ToString();
                }
                else
                {
                    str3 = System.Web.HttpUtility.UrlEncode(queryPairs[str2].ToString());
                }
                if (!skipempty || !string.IsNullOrEmpty(str3))
                {
                    if (str == null)
                    {
                        str = str2 + "=" + str3;
                    }
                    else
                    {
                        str = str + sep + str2 + "=" + str3;
                    }
                }
            }
            return str;
        }



        public static SKBuiltinBuffer_t packQueryQuest(Dictionary<string, object> queryDic, bool needLog = false)
        {
            string str = stringWithFormEncodedComponentsAscending(queryDic, true, true, "&");

            if (string.IsNullOrEmpty(str))
            {
                str = "WCPaySign=";
            }
            else
            {
                //string str2 = "";//TenpayUtil.Get3DesSignData(str);
                string str2 = WCPaySignDES3Encode(str, "6BA3DAAA443A2BBB6311D7932B25F626");
                //str = str + "&WCPaySign=" + str2;
            }
            return Util.toSKBuffer(str);
        }
        public static SKBuiltinBuffer_t toSKBuffer(string inStr)
        {
            SKBuiltinBuffer_t sKBuiltinBuffer_T = new SKBuiltinBuffer_t();
            if (string.IsNullOrEmpty(inStr))
            {
                sKBuiltinBuffer_T.iLen = 0;
            }
            else
            {
                sKBuiltinBuffer_T.Buffer = ByteString.CopyFromUtf8(inStr).ToByteArray();
                sKBuiltinBuffer_T.iLen = (uint)sKBuiltinBuffer_T.Buffer.Length;
            }
            return sKBuiltinBuffer_T;
        }



        public static string WCPaySignDES3Encode(string data, string key)
        {
            TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
            //DES.KeySize = 16;
            DES.Mode = CipherMode.CBC;
            DES.Padding = PaddingMode.Zeros;
            Type t = Type.GetType("System.Security.Cryptography.CryptoAPITransformMode");
            object obj = t.GetField("Encrypt", BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly).GetValue(t);
            MethodInfo mi = DES.GetType().GetMethod("_NewEncryptor", BindingFlags.Instance | BindingFlags.NonPublic);
            byte[] keys = str2Bcd(key);
            ICryptoTransform desCrypt = (ICryptoTransform)mi.Invoke(DES, new object[] { keys, CipherMode.CBC, null, 0, obj });
            byte[] Buffer = Encoding.UTF8.GetBytes(data);
            byte[] result = desCrypt.TransformFinalBlock(Buffer, 0, Buffer.Length);

            return bcd2Str(result);
        }
        public static string bcd2Str(byte[] bytes)
        {
            StringBuilder temp = new StringBuilder(bytes.Length * 2);

            for (int i = 0; i < bytes.Length; i++)
            {
                temp.Append((byte)((bytes[i] & 0xf0) >> 4));
                temp.Append((byte)(bytes[i] & 0x0f));
            }
            return temp.ToString().Substring(0, 1).Equals("0") ? temp.ToString().Substring(1) : temp.ToString();
        }
        public static byte[] str2Bcd(string asc)
        {
            int len = asc.Length;
            int mod = len % 2;

            if (mod != 0)
            {
                asc = "0" + asc;
                len = asc.Length;
            }

            byte[] abt = new byte[len];
            if (len >= 2)
            {
                len = len / 2;
            }

            byte[] bbt = new byte[len];
            abt = System.Text.Encoding.UTF8.GetBytes(asc);
            int j, k;

            for (int p = 0; p < asc.Length / 2; p++)
            {
                if ((abt[2 * p] >= '0') && (abt[2 * p] <= '9'))
                {
                    j = abt[2 * p] - '0';
                }
                else if ((abt[2 * p] >= 'a') && (abt[2 * p] <= 'z'))
                {
                    j = abt[2 * p] - 'a' + 0x0a;
                }
                else
                {
                    j = abt[2 * p] - 'A' + 0x0a;
                }

                if ((abt[2 * p + 1] >= '0') && (abt[2 * p + 1] <= '9'))
                {
                    k = abt[2 * p + 1] - '0';
                }
                else if ((abt[2 * p + 1] >= 'a') && (abt[2 * p + 1] <= 'z'))
                {
                    k = abt[2 * p + 1] - 'a' + 0x0a;
                }
                else
                {
                    k = abt[2 * p + 1] - 'A' + 0x0a;
                }

                int a = (j << 4) + k;
                byte b = (byte)a;
                bbt[p] = b;
            }
            return bbt;
        }
        public static byte[] HttpPost(string url, byte[] data, string Url_GCI, ProxyIpCacheResp proxy)
        {
            //if (!IpHelper.IsProxy)
            //{
            //    proxy = null;
            //}
            if (string.IsNullOrEmpty(url))
            {
                url = shortUrl;
            }
            //Console.WriteLine(shortUrl + Url_GCI);
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = url + Url_GCI,
                Method = "post",
                PostdataByte = data,
                PostDataType = PostDataType.Byte,
                UserAgent = "MicroMessenger Client",
                Accept = "*/*",
                ContentType = "application/octet-stream",
                //se = "SEC_SF_edcd630591726845634a339fa1e14168; Domain =.weixin110.qq.com; Path =/; Secure; HttpOnly",
                ResultType = ResultType.Byte,
                ProxyIp = proxy?.ProxyIp,
                ProxyUserName = proxy?.Username,
                ProxyPwd = proxy?.Password,
                KeepAlive = true

            };


            //if (proxy!=null && !string.IsNullOrWhiteSpace(proxy.ClientProxyId))
            //{
            //    ICommand.HttpItem commItem = new ICommand.HttpItem()
            //    {
            //        URL = item.URL,
            //        Method = item.Method,
            //        PostdataByte = item.PostdataByte,
            //        PostDataType = ICommand.PostDataType.Byte,
            //        UserAgent = item.UserAgent,
            //        Accept = item.Accept,
            //        ContentType = item.ContentType,
            //        ResultType = ICommand.ResultType.Byte,
            //        ProxyIp = item.ProxyIp,
            //        ProxyUserName = item.ProxyUserName,
            //        ProxyPwd = item.ProxyPwd,
            //        KeepAlive = item.KeepAlive,
            //    };
            //    ClientProxy.Proxy clientProxy = new ClientProxy.Proxy();
            //    byte[] byteResult = clientProxy.ClientHttpPost(proxy.ClientProxyId, commItem);
            //    return byteResult;
            //}

            HttpResult ret = http.GetHtml(item);
            // Console.WriteLine(ret.ResultByte.ToString(16, 2));
            return ret.ResultByte == null ? new byte[2] { 1, 2 } : ret.ResultByte;
        }


        public static byte[] HttpPostTestProxy(string url, ProxyIpCacheResp proxy)
        {
            //Console.WriteLine(shortUrl + Url_GCI);
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = url,
                Method = "get",
                PostDataType = PostDataType.Byte,
                UserAgent = "Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10_6_8; en-us) AppleWebKit/534.50 (KHTML, like Gecko) Version/5.1 Safari/534.50",
                Accept = "*/*",
                //se = "SEC_SF_edcd630591726845634a339fa1e14168; Domain =.weixin110.qq.com; Path =/; Secure; HttpOnly",
                ResultType = ResultType.Byte,
                ProxyIp = proxy?.ProxyIp,
               // ProxyIp= "115.216.56.244:32329",
                ProxyUserName = proxy?.Username,
                ProxyPwd = proxy?.Password,
                KeepAlive = true,
                Timeout = 30000

            };

            HttpResult ret = http.GetHtml(item);
            // Console.WriteLine(ret.ResultByte.ToString(16, 2));
            return ret.ResultByte == null ? new byte[2] { 1, 2 } : ret.ResultByte;
        }

        /// <summary>
        /// AES解密 先解密后解压
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static byte[] uncompress_aes(byte[] data, byte[] key)
        {
            data = AES.AESDecrypt(data, key);
            data = ZipUtils.deCompressBytes(data);
            return data;
        }
        /// <summary>
        /// 生成62数据
        /// </summary>
        /// <param name="imei"></param>
        /// <returns></returns>
        public static string SixTwoData(string imei)
        {

            /// string randStr = Time_Stamp().ToString();//随机字符串 
            string hexStr = HexToStr(System.Text.Encoding.Default.GetBytes(imei)).Replace(" ", "");
            string str = "62706c6973743030d4010203040506090a582476657273696f6e58246f626a65637473592461726368697665725424746f7012000186a0a2070855246e756c6c5f1020" + hexStr + "5f100f4e534b657965644172636869766572d10b0c54726f6f74800108111a232d32373a406375787d0000000000000101000000000000000d0000000000000000000000000000007f";
            return str;
        }


        public static string SixTwoData(byte[] imei)
        {

            /// string randStr = Time_Stamp().ToString();//随机字符串 
            string hexStr = HexToStr(imei).Replace(" ", "");
            string str = "62706c6973743030d4010203040506090a582476657273696f6e58246f626a65637473592461726368697665725424746f7012000186a0a2070855246e756c6c5f1020" + hexStr + "5f100f4e534b657965644172636869766572d10b0c54726f6f74800108111a232d32373a406375787d0000000000000101000000000000000d0000000000000000000000000000007f";
            return str;
        }
  
        /// <summary>
        /// //AES解密 只解密
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static byte[] nouncompress_aes(byte[] data, byte[] key)
        {
            data = AES.AESDecrypt(data, key);
            //data = ZipUtils.deCompressBytes(data);
            return data;
        }
        public static byte[] compress_rsa(byte[] data)
        {

            using (RSA rsa = RSA.Create())
            {
                byte[] strOut = new byte[] { };
                rsa.ImportParameters(new RSAParameters() { Exponent = "010001".ToByteArray(16, 2), Modulus = "D153E8A2B314D2110250A0A550DDACDCD77F5801F3D1CC21CB1B477E4F2DE8697D40F10265D066BE8200876BB7135EDC74CDBC7C4428064E0CDCBE1B6B92D93CEAD69EC27126DEBDE564AAE1519ACA836AA70487346C85931273E3AA9D24A721D0B854A7FCB9DED49EE03A44C189124FBEB8B17BB1DBE47A534637777D33EEC88802CD56D0C7683A796027474FEBF237FA5BF85C044ADC63885A70388CD3696D1F2E466EB6666EC8EFE1F91BC9353F8F0EAC67CC7B3281F819A17501E15D03291A2A189F6A35592130DE2FE5ED8E3ED59F65C488391E2D9557748D4065D00CBEA74EB8CA19867C65B3E57237BAA8BF0C0F79EBFC72E78AC29621C8AD61A2B79B".ToByteArray(16, 2) });
                var rsa_len = rsa.KeySize;
                rsa_len = rsa_len / 8;
                // data = ZipUtils.compressBytes(data);
                if (data.Length > rsa_len - 12)
                {
                    int blockCnt = (data.Length / (rsa_len - 12)) + (((data.Length % (rsa_len - 12)) == 0) ? 0 : 1);
                    //strOut.resize(blockCnt * rsa_len);

                    for (int i = 0; i < blockCnt; ++i)
                    {
                        int blockSize = rsa_len - 12;
                        if (i == blockCnt - 1) blockSize = data.Length - i * blockSize;
                        var temp = data.Copy(i * (rsa_len - 12), blockSize);
                        strOut = strOut.Concat(rsa.Encrypt(temp, RSAEncryptionPadding.Pkcs1)).ToArray();
                    }
                    return strOut;
                }
                else
                {
                    //strOut.resize(rsa_len);
                    return rsa.Encrypt(data, RSAEncryptionPadding.Pkcs1);
                }
            }

        }

        public static byte[] compress_rsa_LOGIN(byte[] data)
        {

            using (RSA rsa = RSA.Create())
            {
                byte[] strOut = new byte[] { };
                rsa.ImportParameters(new RSAParameters() { Exponent = "010001".ToByteArray(16, 2), Modulus = "D153E8A2B314D2110250A0A550DDACDCD77F5801F3D1CC21CB1B477E4F2DE8697D40F10265D066BE8200876BB7135EDC74CDBC7C4428064E0CDCBE1B6B92D93CEAD69EC27126DEBDE564AAE1519ACA836AA70487346C85931273E3AA9D24A721D0B854A7FCB9DED49EE03A44C189124FBEB8B17BB1DBE47A534637777D33EEC88802CD56D0C7683A796027474FEBF237FA5BF85C044ADC63885A70388CD3696D1F2E466EB6666EC8EFE1F91BC9353F8F0EAC67CC7B3281F819A17501E15D03291A2A189F6A35592130DE2FE5ED8E3ED59F65C488391E2D9557748D4065D00CBEA74EB8CA19867C65B3E57237BAA8BF0C0F79EBFC72E78AC29621C8AD61A2B79B".ToByteArray(16, 2) });
                var rsa_len = rsa.KeySize;
                rsa_len = rsa_len / 8;
                data = ZipUtils.compressBytes(data);
                if (data.Length > rsa_len - 12)
                {
                    int blockCnt = (data.Length / (rsa_len - 12)) + (((data.Length % (rsa_len - 12)) == 0) ? 0 : 1);
                    //strOut.resize(blockCnt * rsa_len);

                    for (int i = 0; i < blockCnt; ++i)
                    {
                        int blockSize = rsa_len - 12;
                        if (i == blockCnt - 1) blockSize = data.Length - i * blockSize;
                        var temp = data.Copy(i * (rsa_len - 12), blockSize);
                        strOut = strOut.Concat(rsa.Encrypt(temp, RSAEncryptionPadding.Pkcs1)).ToArray();
                    }
                    return strOut;
                }
                else
                {
                    //strOut.resize(rsa_len);
                    return rsa.Encrypt(data, RSAEncryptionPadding.Pkcs1);
                }
            }

        }


        public static byte[] compress_aes(byte[] data, byte[] key)
        {
            data = ZipUtils.compressBytes(data);

            return AES.AESEncrypt(data, key);
        }
        public static byte[] nocompress_aes(byte[] data, byte[] key)
        {
            return AES.AESEncrypt(data, key);
        }

        public static byte[] MD5(byte[] src)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider MD5CSP = new System.Security.Cryptography.MD5CryptoServiceProvider();

            return MD5CSP.ComputeHash(src);
        }
        public static byte[] AESEncryptorData(byte[] data, byte[] key)
        {
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.Key = key.Take(16).ToArray();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.IV = key.Take(16).ToArray();
            ICryptoTransform ict = aes.CreateEncryptor();
            byte[] decByte = null;
            decByte = ict.TransformFinalBlock(data, 0, data.Length);
            aes.Clear();

            return decByte;
        }
        public static byte[] DeflateZip(byte[] srcByte)
        {
            //压缩的时候数据长度 要处理
            byte[] dstByte = new byte[srcByte.Length + 100];
            int len = Zip(srcByte, srcByte.Length, dstByte, dstByte.Length);
            dstByte = dstByte.Take(len).ToArray();

            return dstByte;
        }

        /// <summary>
        /// 反序列JSON
        /// </summary>
        /// <param name="jsonStr">JSON字符串</param>
        /// <returns></returns>
        public static dynamic JsonToObject(string jsonStr)
        {

            JavaScriptSerializer jsonSerialize = new JavaScriptSerializer();
            dynamic modelDy = "";
            modelDy = jsonSerialize.Deserialize<dynamic>(jsonStr); //反序列化
            return modelDy;

        }

        public static string HexToStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("x2");
                }
            }
            return returnStr;
        }


        public static string MD5Encrypt(string strText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(Encoding.Default.GetBytes(strText));
            return HexToStr(result);
        }

        private static string getip()
        {
            HttpHelper http = new HttpHelper();
            HttpItem Item = new HttpItem()
            {
                URL = "http://www.ifunc.ink/getIp.php",
            };

            HttpResult HttpRet = http.GetHtml(Item);

            return HttpRet.Html;

        }


        public static string EncryptWithMD5(string source)
        {
            byte[] sor = Encoding.UTF8.GetBytes(source);
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] result = md5.ComputeHash(sor);
            StringBuilder strbul = new StringBuilder(40);
            for (int i = 0; i < result.Length; i++)
            {
                strbul.Append(result[i].ToString("x2"));//加密结果"x2"结果为32位,"x3"结果为48位,"x4"结果为64位

            }
            return strbul.ToString();
        }


    }



}



