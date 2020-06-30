using Google.ProtocolBuffers;
using mm.command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Web.Security;
using Wechat.Util.Cache;

namespace Wechat.Protocol.Andriod
{
    public class WechatAndriodHelper
    {
        private List<string> ipList = new List<string>();


        private static string shortUrl = "short.weixin.qq.com";
        private static string longUrl = "long.weixin.qq.com";
        private readonly RedisCache _redisCache;
        public WechatAndriodHelper(RedisCache redisCache)
        {
            this._redisCache = redisCache;
        }

        private static Dictionary<string, TcpClient> clients = new Dictionary<string, TcpClient>();


        [DllImport("Common.dll")]
        private static extern int GenerateECKey(int nid, byte[] pub, byte[] pri);

        [DllImport("Common.dll")]
        private static extern int ComputerECCKeyMD5(byte[] pub, int pubLen, byte[] pri, int priLen, byte[] eccKey);

        [DllImport("Common.dll")]
        private static extern uint Adler32(uint adler, byte[] buf, int len);

        private static long GetCurTime()
        {
            var dateTime_0 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)(DateTime.UtcNow - dateTime_0).TotalMilliseconds;
        }
        private object obj = new object();


        private TcpClient getClient(string username)
        {
            TcpClient client = clients[username];
            if (!client.Connected)
            {
                client.Connect(longUrl, 8080);
            }
            return client;
        }


        private TcpClient createClient(string username)
        {
            TcpClient client = null;

            lock (obj)
            {
                if (clients.ContainsKey(username))
                {
                    clients.Remove(username);
                }
                client = new TcpClient();
                clients.Add(username, client);
            }
            if (!client.Connected)
            {
                client.Connect(longUrl, 8080);
            }
            return client;
        }




        public NewAuthResponse A16Login(string username, string password, string a16)
        {
            string text = HardInfoHelper.GetRandomHandInfo();
            string[] array = text.Split('|');
            string text2 = array[28];
            string text3 = array[25];
            string text4 = array[7];
            string text5 = array[2];
            string text6 = array[27];
            string text7 = array[26];
            string text8 = array[29];
            string text9 = Fun.GenIEMI(array[3]);
            string text10 = Fun.GenMac(array[13]);
            string text11 = Fun.GenMac(array[16]);
            string text12 = Fun.GenMac(array[12]);
            string text13 = Fun.GenSerial(WiFiHelper.GetRanWifiName(), 6);
            string text14 = FormsAuthentication.HashPasswordForStoringInConfigFile(GetCurTime().ToString(), "md5").ToLower().Substring(0, 16);
            string text15 = FormsAuthentication.HashPasswordForStoringInConfigFile("+86" + username, "md5").ToLower();
            string text16 = string.Format("<softtype><lctmoc>0</lctmoc><level>1</level><k26>0</k26><k1>{0}</k1><k2>{1}</k2><k3>{2}</k3><k4>{3}</k4><k5>{4}</k5><k6>{5}</k6><k7>{6}</k7><k8>{7}</k8><k9>{8}</k9><k10>{9}</k10><k11>{10}</k11><k12>{11}</k12><k13>{12}</k13><k14>{13}</k14><k15>{14}</k15><k16>{15}</k16><k18>{16}</k18><k21>\"{17}\"</k21><k22>{18}</k22><k24>{19}</k24><k30>\"{20}\"</k30><k33>com.tencent.mm</k33><k34>{21}</k34><k35>{22}</k35><k36>{23}</k36><k37>{24}</k37><k38>{25}</k38><k39>{26}</k39><k40>{27}</k40><k41>0</k41><k42>{28}</k42><k43>null</k43><k44>0</k44><k45>{29}</k45><k46></k46><k47>wifi</k47><k48>{3}</k48><k49>/data/data/com.tencent.mm/</k49><k52>0</k52><k53>0</k53><k57>980</k57><k58></k58><k59>2</k59></softtype>", array[0], array[1], array[2], text9, Fun.GenSerial(array[4], 15 - array[4].Length), Fun.GenSerial(array[5], 20 - array[5].Length), text14, Fun.GenSerial("", array[6].Length), array[7], array[8], array[9], array[10], array[11], text12, text10.ToUpper(), array[14], "18c867f0717aa67b2ab7347505ba07ed", text13, array[15], text11, text13, array[17], array[18], array[19], array[20], array[21], array[22], array[23], array[24], text15);
            string deviceType = string.Format("<deviceinfo><MANUFACTURER name=\"{0}\"><MODEL name=\"{1}\"><VERSION_RELEASE name=\"{2}\"><VERSION_INCREMENTAL name=\"{3}\"><DISPLAY name=\"{4}\"></DISPLAY></VERSION_INCREMENTAL></VERSION_RELEASE></MODEL></MANUFACTURER></deviceinfo>", text3, text4, text5, text7, text6);
            userInfo user = new userInfo();
            user.imei = text9;
            user.deviceID = Fun.GenDeviceID();
            user.ostype = text2;
            user.manufacturer = text3;
            user.Model = text4;
            user.release = text5;
            user.display = text6;
            user.incremental = text7;
            user.fingerprint = text16;
            user.abi = text8;
            user.devicetype = deviceType;
            user.user = username;
            user.userName = username;
            user.pwd = password;
            //if (!string.IsNullOrEmpty(a16) && a16.Length == 16)
            //{
            //    a16 = a16.Remove(a16.Length - 1);
            //}
            user.deviceID = a16;

            int num = 0;
            int num2 = 0;
            BaseRequest br = GoogleProto.CreateBaseRequestEntity(user.deviceID, user.ostype);
            string clientID = user.deviceID + "0_" + GetCurTime().ToString();
            ManualAuthRequest manualAuthRequest = GoogleProto.CreateManualAuthRequestEntity(br, user.imei, user.manufacturer, user.Model, user.ostype, user.fingerprint, clientID, user.abi, user.devicetype);
            ECDHKey.Builder builder = new ECDHKey.Builder();
            builder.SetNID(713);
            SKBuiltinBuffer_t.Builder builder2 = new SKBuiltinBuffer_t.Builder();
            byte[] array1 = new byte[57];
            byte[] pri = new byte[328];
            GenerateECKey(713, array1, pri);
            builder2.SetILen(array1.Length);
            builder2.SetBuffer(ByteString.CopyFrom(array1));
            builder.SetKey(builder2);
            ECDHKey cliPubECDHKey = builder.Build();
            var randomEncryKey = RandomEncryHelper.GenRandomEncryKey();
            InitKey initKey = GoogleProto.CreateInitKeyEntity(randomEncryKey, cliPubECDHKey, username, password);
            byte[] array2 = manualAuthRequest.ToByteArray();
            num = array2.Length;
            byte[] array3 = DeflateCompression.DeflateZip(manualAuthRequest.ToByteArray());
            num2 = array3.Length;
            byte[] array4 = initKey.ToByteArray();
            byte[] data = DeflateCompression.DeflateZip(array4);
            byte[] array5 = RSAEncryptData.RSAEncryptCoreData(data);
            byte[] array6 = DecryptPacket.AESEncryptorData(array3, randomEncryKey);
            byte[] array7 = new byte[12 + array6.Length + array5.Length];
            array7[2] = (byte)(array4.Length / 256);
            array7[3] = (byte)(array4.Length % 256);
            array7[6] = (byte)(num / 256);
            array7[7] = (byte)(num % 256);
            array7[10] = (byte)(array5.Length / 256);
            array7[11] = (byte)(array5.Length % 256);
            Array.Copy(array5, 0, array7, 12, array5.Length);
            Array.Copy(array6, 0, array7, 12 + array5.Length, array6.Length);
            byte[] data2 = ConstructPacket.AuthRequestPacket(num, num2, array7, user.deviceID, 701);
            NewAuthResponse newAuthResponse = null;
            int count = 0;
            while (true)
            {
                if (count > 5)
                {
                    break;
                }
                count++;
                string address = "http://" + shortUrl + "/cgi-bin/micromsg-bin/manualauth";
                WebClient webClient = new WebClient();
                byte[] array8 = null;
                try
                {
                    array8 = webClient.UploadData(address, "POST", data2);
                }
                catch (Exception)
                {
                }
                byte b = array8[0];
                b = (byte)(b >> 2);
                bool flag = (array8[0] & 3) == 1;
                byte b2 = (byte)((int)array8[1] % 16);
                byte[] cookie = new byte[b2];
                Array.Copy(array8, 10, cookie, 0, b2);
                array8 = array8.Take(array8.Length).Skip(b).ToArray();
                byte[] array9 = DecryptPacket.DecryptReceivedPacket(array8, randomEncryKey);
                if (array9 != null && array9.Count() != 0)
                {
                    byte[] data3 = array9;
                    if (flag)
                    {
                        data3 = DeflateCompression.DeflateUnZip(array9);
                    }
                    newAuthResponse = NewAuthResponse.ParseFrom(data3);
                    CustomerInfoCache customerInfoCache = new CustomerInfoCache();
                    customerInfoCache.Cookie = Encoding.Default.GetString(cookie);
                    customerInfoCache.WxId = username;
                    customerInfoCache.WxNewPass = password;
                    customerInfoCache.Remark = a16;
                    customerInfoCache.DeviceId = Encoding.Default.GetBytes(user.deviceID);
                    customerInfoCache.BaseRequest = new CustomerInfoCache.BaseRequestCache();
                    customerInfoCache.BaseRequest.osType = user.ostype;
                    customerInfoCache.BaseRequest.devicelId = Encoding.Default.GetBytes(user.deviceID);

                    customerInfoCache.DeviceBrand = user.fingerprint;
                    customerInfoCache.DeviceModel = user.Model;
                    customerInfoCache.release = user.release;
                    customerInfoCache.display = user.display;
                    customerInfoCache.incremental = user.incremental;
                    customerInfoCache.randomEncryKey = randomEncryKey;
                    customerInfoCache.AesKey = new byte[16];
                    if (newAuthResponse.Base.Ret == 0 || newAuthResponse.Base.Ret == -17)
                    {

                        ComputerECCKeyMD5(newAuthResponse.Auth.SvrPubECDHKey.Key.Buffer.Take(57).ToArray(), 57, pri, 328, customerInfoCache.AesKey);
                        customerInfoCache.BaseRequest.sessionKey = DecryptPacket.DecryptReceivedPacket(newAuthResponse.Auth.SessionKey.Buffer.Take(32).ToArray(), customerInfoCache.AesKey);
                        customerInfoCache.BaseRequest.uin = (int)newAuthResponse.Auth.Uin;
                        customerInfoCache.HeadUrl = newAuthResponse.Auth.PicData.Data;

                        customerInfoCache.Status = newAuthResponse.User.Status;
                        customerInfoCache.NickName = newAuthResponse.User.NickName;
                        customerInfoCache.UserName = username;
                        customerInfoCache.AutoAuthTicket = newAuthResponse.Auth.AutoAuthKey.Buffer.ToByteArray();
                        customerInfoCache.Alias = newAuthResponse.User.Alias;
                        customerInfoCache.BindEmail = newAuthResponse.User.BindEmail;
                        customerInfoCache.BindMobile = newAuthResponse.User.BindMobile;
                        customerInfoCache.Ticket = newAuthResponse.Auth.Str16;
                        customerInfoCache.ImgSid = newAuthResponse.Auth.Str14;
                        customerInfoCache.ImgEncryptKey = newAuthResponse.Auth.Str14;

                        this._redisCache.HashSet(ConstCacheKey.GetWxIdKey(), customerInfoCache.WxId, customerInfoCache);
                        break;
                    }
                    if (newAuthResponse.Base.Ret == -6)
                    {
                        customerInfoCache.ImgSid = newAuthResponse.Auth.Str14;
                        customerInfoCache.ImgEncryptKey = newAuthResponse.Auth.Str14;
                        break;
                    }
                    if (newAuthResponse.Base.Ret == -30)
                    {
                        customerInfoCache.Ticket = newAuthResponse.Auth.Str16;
                        break;
                    }
                    if (newAuthResponse.Base.Ret != -301)
                    {
                        break;
                    }
                    shortUrl = newAuthResponse.Server.NewHostList.ListList[1].Substitute;
                    longUrl = newAuthResponse.Server.NewHostList.ListList[0].Substitute;
                    this._redisCache.HashSet(ConstCacheKey.GetWxIdKey(), customerInfoCache.UserName, customerInfoCache);
                }
            }
            return newAuthResponse;
        }


        public NewAuthResponse A16LoginLong(string username, string password, string a16)
        {
            string randomHandinfo = HardInfoHelper.GetRandomHandInfo();
            string[] array = randomHandinfo.Split('|');
            string ostype = array[28];
            string text2 = array[25];
            string text3 = array[7];
            string text4 = array[2];
            string text5 = array[27];
            string text6 = array[26];
            string abi = array[29];
            string text7 = Fun.GenIEMI(array[3]);
            string text8 = Fun.GenMac(array[13]);
            string text9 = Fun.GenMac(array[16]);
            string text10 = Fun.GenMac(array[12]);
            string text11 = Fun.GenSerial(WiFiHelper.GetRanWifiName(), 6);
            string text12 = FormsAuthentication.HashPasswordForStoringInConfigFile(GetCurTime().ToString(), "md5").ToLower().Substring(0, 16);
            string text13 = FormsAuthentication.HashPasswordForStoringInConfigFile("+86" + username, "md5").ToLower();
            string fingerprint = string.Format("<softtype><lctmoc>0</lctmoc><level>1</level><k26>0</k26><k1>{0}</k1><k2>{1}</k2><k3>{2}</k3><k4>{3}</k4><k5>{4}</k5><k6>{5}</k6><k7>{6}</k7><k8>{7}</k8><k9>{8}</k9><k10>{9}</k10><k11>{10}</k11><k12>{11}</k12><k13>{12}</k13><k14>{13}</k14><k15>{14}</k15><k16>{15}</k16><k18>{16}</k18><k21>\"{17}\"</k21><k22>{18}</k22><k24>{19}</k24><k30>\"{20}\"</k30><k33>com.tencent.mm</k33><k34>{21}</k34><k35>{22}</k35><k36>{23}</k36><k37>{24}</k37><k38>{25}</k38><k39>{26}</k39><k40>{27}</k40><k41>0</k41><k42>{28}</k42><k43>null</k43><k44>0</k44><k45>{29}</k45><k46></k46><k47>wifi</k47><k48>{3}</k48><k49>/data/data/com.tencent.mm/</k49><k52>0</k52><k53>0</k53><k57>980</k57><k58></k58><k59>2</k59></softtype>", array[0], array[1], array[2], text7, Fun.GenSerial(array[4], 15 - array[4].Length), Fun.GenSerial(array[5], 20 - array[5].Length), text12, Fun.GenSerial("", array[6].Length), array[7], array[8], array[9], array[10], array[11], text10, text8.ToUpper(), array[14], "18c867f0717aa67b2ab7347505ba07ed", text11, array[15], text9, text11, array[17], array[18], array[19], array[20], array[21], array[22], array[23], array[24], text13);
            string text14 = string.Format("<deviceinfo><MANUFACTURER name=\"{0}\"><MODEL name=\"{1}\"><VERSION_RELEASE name=\"{2}\"><VERSION_INCREMENTAL name=\"{3}\"><DISPLAY name=\"{4}\"></DISPLAY></VERSION_INCREMENTAL></VERSION_RELEASE></MODEL></MANUFACTURER></deviceinfo>", text2, text3, text4, text6, text5);

            userInfo user = new userInfo();
            user.imei = text7;
            user.ostype = ostype;
            user.manufacturer = text2;
            user.Model = text3;
            user.release = text4;
            user.display = text5;
            user.incremental = text6;
            user.fingerprint = fingerprint;
            user.abi = abi;
            user.devicetype = text14;
            user.user = username;
            user.pwd = password;
            if (!string.IsNullOrEmpty(a16) && a16.Length == 16)
            {
                a16 = a16.Remove(a16.Length - 1);
            }
            user.deviceID = a16;
            int num = 0;
            int num2 = 0;
            BaseRequest br = GoogleProto.CreateBaseRequestEntity(user.deviceID, user.ostype);
            string clientID = user.deviceID + "0_" + GetCurTime().ToString();
            ManualAuthRequest manualAuthRequest = GoogleProto.CreateManualAuthRequestEntity(br, user.imei, user.manufacturer, user.Model, user.ostype, fingerprint, clientID, abi, text14);
            Debug.Print(manualAuthRequest.ToString());
            ECDHKey.Builder builder = new ECDHKey.Builder();
            builder.SetNID(713);
            SKBuiltinBuffer_t.Builder builder2 = new SKBuiltinBuffer_t.Builder();
            byte[] array1 = new byte[57];
            byte[] pri = new byte[328];
            GenerateECKey(713, array1, pri);
            builder2.SetILen(array1.Length);
            builder2.SetBuffer(ByteString.CopyFrom(array1));
            builder.SetKey(builder2);
            ECDHKey cliPubECDHKey = builder.Build();
            var randomEncryKey = RandomEncryHelper.GenRandomEncryKey();
            InitKey initKey = GoogleProto.CreateInitKeyEntity(randomEncryKey, cliPubECDHKey, username, password);
            byte[] array2 = manualAuthRequest.ToByteArray();
            num = array2.Length;
            byte[] array3 = DeflateCompression.DeflateZip(manualAuthRequest.ToByteArray());
            num2 = array3.Length;
            byte[] array4 = initKey.ToByteArray();
            byte[] data = DeflateCompression.DeflateZip(array4);
            byte[] array5 = RSAEncryptData.RSAEncryptCoreData(data);
            byte[] array6 = DecryptPacket.AESEncryptorData(array3, randomEncryKey);
            byte[] array7 = new byte[12 + array6.Length + array5.Length];
            array7[2] = (byte)(array4.Length / 256);
            array7[3] = (byte)(array4.Length % 256);
            array7[6] = (byte)(num / 256);
            array7[7] = (byte)(num % 256);
            array7[10] = (byte)(array5.Length / 256);
            array7[11] = (byte)(array5.Length % 256);
            Array.Copy(array5, 0, array7, 12, array5.Length);
            Array.Copy(array6, 0, array7, 12 + array5.Length, array6.Length);
            byte[] array8 = ConstructPacket.AuthRequestPacket(num, num2, array7, user.deviceID, 701);
            byte[] array9 = new byte[array8.Length + 16];
            array9[0] = 0;
            array9[1] = 0;
            array9[2] = (byte)(array9.Length / 256);
            array9[3] = (byte)(array9.Length % 256);
            array9[4] = 0;
            array9[5] = 16;
            array9[6] = 0;
            array9[7] = 1;
            array9[8] = 0;
            array9[9] = 0;
            array9[10] = 0;
            array9[11] = 253;
            array9[12] = 0;
            array9[13] = 0;
            var seq = new Random().Next(100);
            array9[14] = (byte)(seq / 256);
            array9[15] = (byte)(seq % 256);
            Array.Copy(array8, 0, array9, 16, array8.Length);
            //IPHostEntry hostByName = Dns.GetHostByName(longUrl);
            //hostByName.AddressList[0].ToString();
            NewAuthResponse newAuthResponse = null;
            int count = 0;
            while (true)
            {
                if (count > 5)
                {
                    break;
                }
                count++;
                byte[] array10 = new byte[16];
                var client = createClient(username);
                NetworkStream stream = client.GetStream();
                stream.Write(array9, 0, array9.Length);
                stream.Read(array10, 0, array10.Length);
                int num3 = array10[2] * 256 + array10[3] - 16;
                array10 = new byte[num3];
                num3 = stream.Read(array10, 0, array10.Length);
                byte b = array10[0];
                b = (byte)(b >> 2);
                bool flag = (array10[0] & 3) == 1;
                byte b2 = (byte)((int)array10[1] % 16);
                var cookieToken = new byte[b2];
                Array.Copy(array10, 10, cookieToken, 0, b2);
                array10 = array10.Take(array10.Length).Skip(b).ToArray();
                byte[] array11 = DecryptPacket.DecryptReceivedPacket(array10, randomEncryKey);
                if (array11 != null && array11.Count() != 0)
                {
                    byte[] data2 = array11;
                    if (flag)
                    {
                        data2 = DeflateCompression.DeflateUnZip(array11);
                    }
                    newAuthResponse = NewAuthResponse.ParseFrom(data2);


                    CustomerInfoCache customerInfoCache = new CustomerInfoCache();
                    customerInfoCache.Cookie = Encoding.Default.GetString(cookieToken);
                    customerInfoCache.CookieBuffer = cookieToken;

                    customerInfoCache.WxNewPass = password;
                    customerInfoCache.Remark = a16;
                    customerInfoCache.DeviceId = Encoding.Default.GetBytes(user.deviceID);
                    customerInfoCache.BaseRequest = new CustomerInfoCache.BaseRequestCache();
                    customerInfoCache.BaseRequest.osType = user.ostype;
                    customerInfoCache.BaseRequest.devicelId = Encoding.Default.GetBytes(user.deviceID);

                    customerInfoCache.DeviceBrand = user.fingerprint;
                    customerInfoCache.DeviceModel = user.Model;
                    customerInfoCache.release = user.release;
                    customerInfoCache.display = user.display;
                    customerInfoCache.incremental = user.incremental;
                    customerInfoCache.randomEncryKey = randomEncryKey;
                    customerInfoCache.AesKey = new byte[16];
                    if (newAuthResponse.Base.Ret == 0 || newAuthResponse.Base.Ret == -17)
                    {
                        ComputerECCKeyMD5(newAuthResponse.Auth.SvrPubECDHKey.Key.Buffer.Take(57).ToArray(), 57, pri, 328, customerInfoCache.AesKey);
                        customerInfoCache.BaseRequest.sessionKey = DecryptPacket.DecryptReceivedPacket(newAuthResponse.Auth.SessionKey.Buffer.Take(32).ToArray(), customerInfoCache.AesKey);
                        customerInfoCache.BaseRequest.uin = (int)newAuthResponse.Auth.Uin;
                        customerInfoCache.HeadUrl = newAuthResponse.Auth.PicData.Data;
                        customerInfoCache.WxId = newAuthResponse.User.UserName;
                        customerInfoCache.Status = newAuthResponse.User.Status;
                        customerInfoCache.UserName = username;
                        customerInfoCache.NickName = newAuthResponse.User.NickName;
                        customerInfoCache.AutoAuthTicket = newAuthResponse.Auth.AutoAuthKey.Buffer.ToByteArray();
                        customerInfoCache.Alias = newAuthResponse.User.Alias;
                        customerInfoCache.BindEmail = newAuthResponse.User.BindEmail;
                        customerInfoCache.BindMobile = newAuthResponse.User.BindMobile;
                        customerInfoCache.Ticket = newAuthResponse.Auth.Str16;
                        customerInfoCache.ImgSid = newAuthResponse.Auth.Str14;
                        customerInfoCache.ImgEncryptKey = newAuthResponse.Auth.Str14;

                        this._redisCache.HashSet(ConstCacheKey.GetWxIdKey(), customerInfoCache.UserName, customerInfoCache);
                        break;
                    }
                    if (newAuthResponse.Base.Ret == -6)
                    {
                        customerInfoCache.ImgSid = newAuthResponse.Auth.Str14;
                        customerInfoCache.ImgEncryptKey = newAuthResponse.Auth.Str14;
                        break;
                    }
                    if (newAuthResponse.Base.Ret == -30)
                    {
                        customerInfoCache.Ticket = newAuthResponse.Auth.Str16;
                        break;
                    }
                    if (newAuthResponse.Base.Ret != -301)
                    {
                        break;
                    }
                    shortUrl = newAuthResponse.Server.NewHostList.ListList[1].Substitute;
                    longUrl = newAuthResponse.Server.NewHostList.ListList[0].Substitute;



                }
            }


            return newAuthResponse;
        }



        public NewVerifyPasswdResponse NewVerifyPass(string userName, string pass)
        {
            var wxUserCache = GetWxUser(userName);
            byte b = 182;
            int num = 0;
            int num2 = 0;
            NewVerifyPasswdRequest newVerifyPasswdRequest = GoogleProto.NewVerifyPasswd(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.BaseRequest.devicelId), wxUserCache.BaseRequest.osType, pass);
            byte[] array = newVerifyPasswdRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
                (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(newVerifyPasswdRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] array4 = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.BaseRequest.devicelId), 182, 384, wxUserCache.CookieBuffer, adler);
            byte[] array5 = new byte[array4.Length + 16];
            var seq = new Random().Next(100);
            seq++;
            array5[0] = 0;
            array5[1] = 0;
            array5[2] = (byte)(array5.Length / 256);
            array5[3] = (byte)(array5.Length % 256);
            array5[4] = 0;
            array5[5] = 16;
            array5[6] = 0;
            array5[7] = 1;
            array5[8] = 0;
            array5[9] = 0;
            array5[10] = 0;
            array5[11] = 182;
            array5[12] = 0;
            array5[13] = 0;
            array5[14] = (byte)(seq / 256);
            array5[15] = (byte)(seq % 256);
            Array.Copy(array4, 0, array5, 16, array4.Length);
            var client = getClient(userName);
            NetworkStream stream = client.GetStream();
            stream.Write(array5, 0, array5.Length);
            byte b2;
            byte[] array6;
            do
            {
                array6 = new byte[16];
                int num3 = stream.Read(array6, 0, array6.Length);
                Debug.Print(string.Format("readed:{0}", num3));
                b2 = array6[11];
                int num4 = array6[2] * 256 + array6[3] - 16;
                array6 = new byte[num4];
                int num5;
                for (num3 = 0; num3 < num4; num3 += num5)
                {
                    num5 = stream.Read(array6, num3, array6.Length - num3);
                }
                Debug.Print(string.Format("toRead{0}, readed:{1}", num4, num3));
            }
            while (b2 != b);
            byte b3 = array6[1];
            b3 = (byte)(b3 >> 2);
            bool flag = (array6[1] & 3) == 1;
            array6 = array6.Take(array6.Length).Skip(b3).ToArray();
            byte[] array7 = DecryptPacket.DecryptReceivedPacket(array6, wxUserCache.BaseRequest.sessionKey);
            byte[] data = array7;
            if (flag)
            {
                data = DeflateCompression.DeflateUnZip(array7);
            }
            return NewVerifyPasswdResponse.ParseFrom(data);
        }

        public NewSetPasswdResponse NewSetPass(string userName, string newpass, string ticket)
        {
            var wxUserCache = GetWxUser(userName);
            byte b = 180;
            int num = 0;
            int num2 = 0;
            NewSetPasswdRequest newSetPasswdRequest = GoogleProto.CreateNewSetPassRequestEntity(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType, Fun.CumputeMD5(newpass), ticket, wxUserCache.AuthKey);
            byte[] array = newSetPasswdRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
                (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(newSetPasswdRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] array4 = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.BaseRequest.devicelId), 180, 383, wxUserCache.CookieBuffer, adler);
            byte[] array5 = new byte[array4.Length + 16];
            int seq = new Random().Next(100);
            seq++;
            array5[0] = 0;
            array5[1] = 0;
            array5[2] = (byte)(array5.Length / 256);
            array5[3] = (byte)(array5.Length % 256);
            array5[4] = 0;
            array5[5] = 16;
            array5[6] = 0;
            array5[7] = 1;
            array5[8] = 0;
            array5[9] = 0;
            array5[10] = 0;
            array5[11] = 180;
            array5[12] = 0;
            array5[13] = 0;
            array5[14] = (byte)(seq / 256);
            array5[15] = (byte)(seq % 256);
            Array.Copy(array4, 0, array5, 16, array4.Length);
            var client = getClient(userName);
            NetworkStream stream = client.GetStream();
            stream.Write(array5, 0, array5.Length);
            byte b2;
            byte[] array6;
            do
            {
                array6 = new byte[16];
                int num3 = stream.Read(array6, 0, array6.Length);
                Debug.Print(string.Format("readed:{0}", num3));
                b2 = array6[11];
                int num4 = array6[2] * 256 + array6[3] - 16;
                array6 = new byte[num4];
                int num5;
                for (num3 = 0; num3 < num4; num3 += num5)
                {
                    num5 = stream.Read(array6, num3, array6.Length - num3);
                }
                Debug.Print(string.Format("toRead{0}, readed:{1}", num4, num3));
            }
            while (b2 != b);
            byte[] array7 = array6;
            array6 = array7;
            byte b3 = array6[1];
            b3 = (byte)(b3 >> 2);
            bool flag = (array6[1] & 3) == 1;
            array6 = array6.Take(array6.Length).Skip(b3).ToArray();
            byte[] array8 = DecryptPacket.DecryptReceivedPacket(array6, wxUserCache.BaseRequest.sessionKey);
            byte[] array9 = array8;
            if (flag)
            {
                array9 = DeflateCompression.DeflateUnZip(array8);
            }
            if (array9.Length < 1)
            {
                return null;
            }
            return NewSetPasswdResponse.ParseFrom(array9);
        }

        public NewAuthResponse AutoAuth(string userName, SKBuiltinBuffer_t autokey)
        {
            var wxUserCache = GetWxUser(userName);
            int num = 0;
            int num2 = 0;
            BaseRequest br = GoogleProto.CreateBaseRequestEntity(Encoding.Default.GetString(wxUserCache.BaseRequest.devicelId), wxUserCache.BaseRequest.osType);
            AutoAuthRequest autoAuthRequest = GoogleProto.CreateAutoAuthRequestEntity(br, Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.DeviceBrand, wxUserCache.DeviceModel, wxUserCache.release, wxUserCache.incremental, wxUserCache.display, wxUserCache.BaseRequest.osType, autokey);
            ECDHKey.Builder builder = new ECDHKey.Builder();
            builder.SetNID(713);
            SKBuiltinBuffer_t.Builder builder2 = new SKBuiltinBuffer_t.Builder();
            byte[] array = new byte[57];
            byte[] pri = new byte[328];
            GenerateECKey(713, array, pri);
            builder2.SetILen(array.Length);
            builder2.SetBuffer(ByteString.CopyFrom(array));
            builder.SetKey(builder2);
            ECDHKey cliPubECDHKey = builder.Build();

            AutoAuthRsaReqData autoAuthRsaReqData = GoogleProto.CreateAutoAuthKeyEntity(wxUserCache.randomEncryKey, cliPubECDHKey);
            byte[] array2 = autoAuthRequest.ToByteArray();
            num = array2.Length;
            byte[] array3 = DeflateCompression.DeflateZip(autoAuthRequest.ToByteArray());
            num2 = array3.Length;
            byte[] array4 = autoAuthRsaReqData.ToByteArray();
            DeflateCompression.DeflateZip(array4);
            byte[] array5 = RSAEncryptData.RSAEncryptCoreData(array4);
            byte[] array6 = DecryptPacket.AESEncryptorData(array3, wxUserCache.randomEncryKey);
            byte[] array7 = new byte[12 + array6.Length + array5.Length];
            array7[2] = (byte)(array4.Length / 256);
            array7[3] = (byte)(array4.Length % 256);
            array7[6] = (byte)(num / 256);
            array7[7] = (byte)(num % 256);
            array7[10] = (byte)(array5.Length / 256);
            array7[11] = (byte)(array5.Length % 256);
            Array.Copy(array5, 0, array7, 12, array5.Length);
            Array.Copy(array6, 0, array7, 12 + array5.Length, array6.Length);
            byte[] data = ConstructPacket.AuthRequestPacket(num, num2, array7, Encoding.Default.GetString(wxUserCache.DeviceId), 702);
            NewAuthResponse newAuthResponse;
            while (true)
            {
                string address = "http://" + shortUrl + "/cgi-bin/micromsg-bin/autoauth";
                WebClient webClient = new WebClient();
                webClient.Headers.Add("User-Agent", "MicroMessenger Client");
                webClient.Headers.Add("Content-Type", "application/octet-stream");
                byte[] array8 = null;
                try
                {
                    array8 = webClient.UploadData(address, "POST", data);
                }
                catch (Exception)
                {
                    Thread.Sleep(3000);
                    continue;
                }
                byte b = array8[0];
                b = (byte)(b >> 2);
                bool flag = (array8[0] & 3) == 1;
                byte b2 = (byte)((int)array8[1] % 16);
                var cookie = new byte[b2];
                Array.Copy(array8, 10, wxUserCache.CookieBuffer, 0, b2);
                array8 = array8.Take(array8.Length).Skip(b).ToArray();
                byte[] array9 = DecryptPacket.DecryptReceivedPacket(array8, wxUserCache.randomEncryKey);
                if (array9 != null && array9.Count() != 0)
                {
                    byte[] data2 = array9;
                    if (flag)
                    {
                        data2 = DeflateCompression.DeflateUnZip(array9);
                    }
                    newAuthResponse = NewAuthResponse.ParseFrom(data2);
                    if (newAuthResponse.Base.Ret == 0 || newAuthResponse.Base.Ret == -17)
                    {
                        userName = newAuthResponse.User.UserName;
                        //wxUserCache.AccountInfo = newAuthResponse.User;
                        ComputerECCKeyMD5(newAuthResponse.Auth.SvrPubECDHKey.Key.Buffer.Take(57).ToArray(), 57, pri, 328, wxUserCache.AesKey);
                        wxUserCache.BaseRequest.sessionKey = DecryptPacket.DecryptReceivedPacket(newAuthResponse.Auth.SessionKey.Buffer.Take(32).ToArray(), wxUserCache.AesKey);

                        break;
                    }
                    if (newAuthResponse.Base.Ret == -6)
                    {
                        wxUserCache.ImgSid = newAuthResponse.Auth.Str14;
                        wxUserCache.ImgEncryptKey = newAuthResponse.Auth.Str14;
                        break;
                    }
                    if (newAuthResponse.Base.Ret == -30)
                    {
                        wxUserCache.Ticket = newAuthResponse.Auth.Str16;
                        break;
                    }
                    if (newAuthResponse.Base.Ret != -301)
                    {
                        break;
                    }
                }
            }
            Debug.Print(newAuthResponse.ToString());
            CacheHelper.CreateInstance().Add(userName, wxUserCache);
            return newAuthResponse;
        }

        public AuthResponse SendVerifyCode(string userName, string code)
        {
            var wxUserCache = GetWxUser(userName);
            int num = 0;
            int num2 = 0;
            BaseRequest br = GoogleProto.CreateBaseRequestEntity(Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType);
            AuthRequest authRequest = GoogleProto.CreateAuthRequestEntity(br, userName, wxUserCache.WxNewPass, Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.DeviceBrand, wxUserCache.DeviceModel, wxUserCache.randomEncryKey, wxUserCache.ImgSid, code, wxUserCache.ImgEncryptKey);
            byte[] array = authRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = DeflateCompression.DeflateZip(authRequest.ToByteArray());
            num2 = array2.Length;
            byte[] rsaDataPacket = RSAEncryptData.RSAEncryptCoreData(array2);
            byte[] data = ConstructPacket.AuthRequestPacket(num, num2, rsaDataPacket, Encoding.Default.GetString(wxUserCache.DeviceId), 380);
            string address = "http://" + shortUrl + "/cgi-bin/micromsg-bin/newauth";
            AuthResponse authResponse;
            while (true)
            {
                WebClient webClient = new WebClient();
                webClient.Headers.Add("User-Agent", "MicroMessenger Client");
                webClient.Headers.Add("Content-Type", "application/octet-stream");
                byte[] array3 = null;
                try
                {
                    array3 = webClient.UploadData(address, "POST", data);
                }
                catch (Exception)
                {
                    Thread.Sleep(3000);
                    continue;
                }
                byte b = array3[0];
                b = (byte)(b >> 2);
                bool flag = (array3[0] & 3) == 1;
                byte b2 = (byte)((int)array3[1] % 16);
                byte[] cookie = new byte[b2];
                Array.Copy(array3, 10, wxUserCache.CookieBuffer, 0, b2);
                array3 = array3.Take(array3.Length).Skip(b).ToArray();
                byte[] array4 = DecryptPacket.DecryptReceivedPacket(array3, wxUserCache.randomEncryKey);
                byte[] data2 = array4;
                if (flag)
                {
                    data2 = DeflateCompression.DeflateUnZip(array4);
                }
                authResponse = AuthResponse.ParseFrom(data2);
                if (authResponse.Base.Ret != 0)
                {
                    if (authResponse.Base.Ret != -30)
                    {
                        if (authResponse.Base.Ret != -301)
                        {
                            break;
                        }
                        IList<IPEnd> longConnectIPListList = authResponse.BuiltinIPList.LongConnectIPListList;
                        for (int i = 0; i < longConnectIPListList.Count; i++)
                        {
                            IPEnd iPEnd = longConnectIPListList[i];
                            string item = iPEnd.IP.ToStringUtf8().Replace("\0", "");
                            ipList.Add(item);
                        }
                        shortUrl = authResponse.NewHostList.ListList[1].Substitute;

                        continue;
                    }
                    wxUserCache.Ticket = authResponse.Ticket;
                    break;
                }
                wxUserCache.BaseRequest.uin = (int)authResponse.Uin;
                userName = authResponse.UserName.String;

                wxUserCache.BaseRequest.sessionKey = authResponse.SessionKey.ToByteArray().Take(16).ToArray();

                break;
            }
            return authResponse;
        }



        public NewInitResponse NewInit(string userName)
        {
            var wxUserCache = GetWxUser(userName);
            byte b = 27;
            int num = 0;
            int num2 = 0;
            NewInitRequest newInitRequest = GoogleProto.CreateNewInitRequestEntity((uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), wxUserCache.WxId, Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType, wxUserCache.InitSyncKey, wxUserCache.MaxSyncKey);
            byte[] array = newInitRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
                (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(newInitRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] array4 = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 27, 139, wxUserCache.CookieBuffer, adler);
            byte[] array5 = new byte[array4.Length + 16];
            int seq = new Random().Next(100);
            seq++;
            array5[0] = 0;
            array5[1] = 0;
            array5[2] = (byte)(array5.Length / 256);
            array5[3] = (byte)(array5.Length % 256);
            array5[4] = 0;
            array5[5] = 16;
            array5[6] = 0;
            array5[7] = 1;
            array5[8] = 0;
            array5[9] = 0;
            array5[10] = 0;
            array5[11] = 27;
            array5[12] = 0;
            array5[13] = 0;
            array5[14] = (byte)(seq / 256);
            array5[15] = (byte)(seq % 256);
            Array.Copy(array4, 0, array5, 16, array4.Length);
            var client = getClient(userName);
            NetworkStream stream = client.GetStream();
            stream.Write(array5, 0, array5.Length);
            byte b2;
            byte[] array6;
            do
            {
                array6 = new byte[16];
                int num3 = stream.Read(array6, 0, array6.Length);
                Debug.Print(string.Format("readed:{0}", num3));
                b2 = array6[11];
                int num4 = array6[2] * 256 + array6[3] - 16;
                array6 = new byte[num4];
                int num5;
                for (num3 = 0; num3 < num4; num3 += num5)
                {
                    num5 = stream.Read(array6, num3, array6.Length - num3);
                }
                Debug.Print(string.Format("toRead{0}, readed:{1}", num4, num3));
            }
            while (b2 != b);
            byte b3 = array6[1];
            b3 = (byte)(b3 >> 2);
            bool flag = (array6[1] & 3) == 1;
            array6 = array6.Take(array6.Length).Skip(b3).ToArray();
            byte[] array7 = DecryptPacket.DecryptReceivedPacket(array6, wxUserCache.BaseRequest.sessionKey);
            if (array7 == null || array7.Count() == 0)
            {
                return null;
            }
            byte[] data = array7;
            if (flag)
            {
                data = DeflateCompression.DeflateUnZip(array7);
            }
            NewInitResponse newInitResponse = NewInitResponse.ParseFrom(data);
            if (newInitResponse.Base.Ret == 0)
            {
                wxUserCache.InitSyncKey = newInitResponse.CurrentSynckey.Buffer.ToByteArray();
                wxUserCache.MaxSyncKey = newInitResponse.MaxSynckey.Buffer.ToByteArray();
                this._redisCache.HashSet(ConstCacheKey.GetWxIdKey(), userName, wxUserCache);
            }

            return newInitResponse;
        }

        public NewSyncResponse NewSync(string userName)
        {
            var wxUserCache = GetWxUser(userName);
            int num = 0;
            int num2 = 0;
            byte b = 121;
            NewSyncRequest newSyncRequest = GoogleProto.CreateNewSyncRequestEntity(wxUserCache.InitSyncKey);
            byte[] array = newSyncRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
                (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(newSyncRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] array4 = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 121, 138, wxUserCache.CookieBuffer, adler);
            byte[] array5 = new byte[array4.Length + 16];
            int seq = new Random().Next(100);
            seq++;
            array5[0] = 0;
            array5[1] = 0;
            array5[2] = (byte)(array5.Length / 256);
            array5[3] = (byte)(array5.Length % 256);
            array5[4] = 0;
            array5[5] = 16;
            array5[6] = 0;
            array5[7] = 1;
            array5[8] = 0;
            array5[9] = 0;
            array5[10] = 0;
            array5[11] = 121;
            array5[12] = 0;
            array5[13] = 0;
            array5[14] = (byte)(seq / 256);
            array5[15] = (byte)(seq % 256);
            Array.Copy(array4, 0, array5, 16, array4.Length);
            var client = getClient(userName);
            NetworkStream stream = client.GetStream();
            stream.Write(array5, 0, array5.Length);
            byte b2;
            byte[] array6;
            do
            {
                array6 = new byte[16];
                int num3 = stream.Read(array6, 0, array6.Length);
                Debug.Print(string.Format("readed:{0}", num3));
                b2 = array6[11];
                int num4 = array6[2] * 256 + array6[3] - 16;
                array6 = new byte[num4];
                int num5;
                for (num3 = 0; num3 < num4; num3 += num5)
                {
                    num5 = stream.Read(array6, num3, array6.Length - num3);
                }
                Debug.Print(string.Format("toRead{0}, readed:{1}", num4, num3));
            }
            while (b2 != b);
            byte b3 = array6[1];
            b3 = (byte)(b3 >> 2);
            bool flag = (array6[1] & 3) == 1;
            array6 = array6.Take(array6.Length).Skip(b3).ToArray();
            byte[] array7 = DecryptPacket.DecryptReceivedPacket(array6, wxUserCache.BaseRequest.sessionKey);
            if (array7 == null || array7.Count() == 0)
            {
                return null;
            }
            byte[] data = array7;
            if (flag)
            {
                data = DeflateCompression.DeflateUnZip(array7);
            }
            NewSyncResponse newSyncResponse = NewSyncResponse.ParseFrom(data);
            if (newSyncResponse.Ret == 0)
            {
                wxUserCache.InitSyncKey = newSyncResponse.KeyBuf.Buffer.ToByteArray();
                this._redisCache.HashSet(ConstCacheKey.GetWxIdKey(), userName, wxUserCache);
            }
            return newSyncResponse;
        }

        public NewSyncResponse ModifyProfile(string userName, int sex, string province, string city, string signature)
        {
            var wxUserCache = GetWxUser(userName);
            byte b = 121;
            int num = 0;
            int num2 = 0;
            NewSyncRequest newSyncRequest = GoogleProto.ModifyProfile(sex, province, city, signature, wxUserCache.InitSyncKey);
            byte[] array = newSyncRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
                (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(newSyncRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] array4 = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 121, 138, wxUserCache.CookieBuffer, adler);
            byte[] array5 = new byte[array4.Length + 16];
            int seq = new Random().Next(100);
            seq++;
            array5[0] = 0;
            array5[1] = 0;
            array5[2] = (byte)(array5.Length / 256);
            array5[3] = (byte)(array5.Length % 256);
            array5[4] = 0;
            array5[5] = 16;
            array5[6] = 0;
            array5[7] = 1;
            array5[8] = 0;
            array5[9] = 0;
            array5[10] = 0;
            array5[11] = 121;
            array5[12] = 0;
            array5[13] = 0;
            array5[14] = (byte)(seq / 256);
            array5[15] = (byte)(seq % 256);
            Array.Copy(array4, 0, array5, 16, array4.Length);
            var client = getClient(userName);
            NetworkStream stream = client.GetStream();
            stream.Write(array5, 0, array5.Length);
            byte b2;
            byte[] array6;
            do
            {
                array6 = new byte[16];
                int num3 = stream.Read(array6, 0, array6.Length);
                Debug.Print(string.Format("readed:{0}", num3));
                b2 = array6[11];
                int num4 = array6[2] * 256 + array6[3] - 16;
                array6 = new byte[num4];
                int num5;
                for (num3 = 0; num3 < num4; num3 += num5)
                {
                    num5 = stream.Read(array6, num3, array6.Length - num3);
                }
                Debug.Print(string.Format("toRead{0}, readed:{1}", num4, num3));
            }
            while (b2 != b);
            byte b3 = array6[1];
            b3 = (byte)(b3 >> 2);
            bool flag = (array6[1] & 3) == 1;
            array6 = array6.Take(array6.Length).Skip(b3).ToArray();
            byte[] array7 = DecryptPacket.DecryptReceivedPacket(array6, wxUserCache.BaseRequest.sessionKey);
            byte[] data = array7;
            if (flag)
            {
                data = DeflateCompression.DeflateUnZip(array7);
            }
            NewSyncResponse newSyncResponse = NewSyncResponse.ParseFrom(data);
            if (newSyncResponse.Ret == 0)
            {
                wxUserCache.InitSyncKey = newSyncResponse.KeyBuf.Buffer.ToByteArray();
                this._redisCache.HashSet(ConstCacheKey.GetWxIdKey(), userName, wxUserCache);
            }
            return newSyncResponse;
        }

        public NewSyncResponse ModifyNickName(string userName, string nickName)
        {
            var wxUserCache = GetWxUser(userName);

            byte b = 121;
            int num = 0;
            int num2 = 0;
            NewSyncRequest newSyncRequest = GoogleProto.ModifyProfile(nickName, wxUserCache.InitSyncKey);
            byte[] array = newSyncRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
                (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(newSyncRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] array4 = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 121, 138, wxUserCache.CookieBuffer, adler);
            byte[] array5 = new byte[array4.Length + 16];
            int seq = new Random().Next(100);
            seq++;
            array5[0] = 0;
            array5[1] = 0;
            array5[2] = (byte)(array5.Length / 256);
            array5[3] = (byte)(array5.Length % 256);
            array5[4] = 0;
            array5[5] = 16;
            array5[6] = 0;
            array5[7] = 1;
            array5[8] = 0;
            array5[9] = 0;
            array5[10] = 0;
            array5[11] = 121;
            array5[12] = 0;
            array5[13] = 0;
            array5[14] = (byte)(seq / 256);
            array5[15] = (byte)(seq % 256);
            Array.Copy(array4, 0, array5, 16, array4.Length);
            var client = getClient(userName);
            NetworkStream stream = client.GetStream();
            stream.Write(array5, 0, array5.Length);
            byte b2;
            byte[] array6;
            do
            {
                array6 = new byte[16];
                int num3 = stream.Read(array6, 0, array6.Length);
                Debug.Print(string.Format("readed:{0}", num3));
                b2 = array6[11];
                int num4 = array6[2] * 256 + array6[3] - 16;
                array6 = new byte[num4];
                int num5;
                for (num3 = 0; num3 < num4; num3 += num5)
                {
                    num5 = stream.Read(array6, num3, array6.Length - num3);
                }
                Debug.Print(string.Format("toRead{0}, readed:{1}", num4, num3));
            }
            while (b2 != b);
            byte b3 = array6[1];
            b3 = (byte)(b3 >> 2);
            bool flag = (array6[1] & 3) == 1;
            array6 = array6.Take(array6.Length).Skip(b3).ToArray();
            byte[] array7 = DecryptPacket.DecryptReceivedPacket(array6, wxUserCache.BaseRequest.sessionKey);
            byte[] data = array7;
            if (flag)
            {
                data = DeflateCompression.DeflateUnZip(array7);
            }
            NewSyncResponse newSyncResponse = NewSyncResponse.ParseFrom(data);
            if (newSyncResponse.Ret == 0)
            {
                wxUserCache.InitSyncKey = newSyncResponse.KeyBuf.Buffer.ToByteArray();
                this._redisCache.HashSet(ConstCacheKey.GetWxIdKey(), userName, wxUserCache);
            }
            return newSyncResponse;
        }




        //public LBSFindResponse LBSFind2(string userName, float weidu, float jingdu, int sex)
        //{
        //    var wxUserCache = GetWxUser(userName);
        //    int num = 0;
        //    int num2 = 0;
        //    string address = "http://" + shortUrl + "/cgi-bin/micromsg-bin/lbsfind";
        //    uint uin = (uint)wxUserCache.BaseRequest.uin;
        //    LBSFindRequest lBSFindRequest = GoogleProto.CreateLBSFindRequestEntity(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), uin, weidu, jingdu, Encoding.Default.GetString(wxUserCache.BaseRequest.devicelId), wxUserCache.BaseRequest.osType, sex);
        //    Debug.Print(lBSFindRequest.ToString());
        //    byte[] array = lBSFindRequest.ToByteArray();
        //    num = array.Length;


        //    byte[] array2 = new byte[4]
        //    {
        //        (byte)(((uint)((int)uin & -16777216) >> 24) & 0xFF),
        //        (byte)(((uin & 0xFF0000) >> 16) & 0xFF),
        //        (byte)(((uin & 0xFF00) >> 8) & 0xFF),
        //        (byte)(uin & 0xFF & 0xFF)
        //    };
        //    byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
        //    array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
        //    array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
        //    array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
        //    array2[3] = (byte)(num & 0xFF & 0xFF);
        //    second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
        //    uint adler = Adler32(1u, second, second.Length);
        //    adler = Adler32(adler, array, num);
        //    byte[] array3 = DeflateCompression.DeflateZip(lBSFindRequest.ToByteArray());
        //    num2 = array3.Length;
        //    byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
        //    byte[] data = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, uin, Encoding.Default.GetString(wxUserCache.BaseRequest.devicelId), 121, 148, wxUserCache.CookieBuffer, adler);
        //    byte[] array4;
        //    while (true)
        //    {
        //        WebClient webClient = new WebClient();
        //        array4 = null;
        //        try
        //        {
        //            array4 = webClient.UploadData(address, "POST", data);
        //        }
        //        catch (Exception)
        //        {
        //            Thread.Sleep(3000);
        //            continue;
        //        }
        //        break;
        //    }
        //    byte b = array4[1];
        //    b = (byte)(b >> 2);
        //    bool flag = (array4[1] & 3) == 1;
        //    array4 = array4.Take(array4.Length).Skip(b).ToArray();
        //    byte[] array5 = DecryptPacket.DecryptReceivedPacket(array4, wxUserCache.BaseRequest.sessionKey);
        //    if (array5 == null || array5.Count() == 0)
        //    {
        //        return null;
        //    }
        //    byte[] data2 = array5;
        //    if (flag)
        //    {
        //        data2 = DeflateCompression.DeflateLBSUnzip(array5);
        //    }
        //    return LBSFindResponse.ParseFrom(data2);
        //}


        public LBSFindResponse LBSFind(string userName, float weidu, float jingdu, int sex)
        {
            var wxUserCache = GetWxUser(userName);
            int num = 0;
            int num2 = 0;
            string address = "http://" + shortUrl + "/cgi-bin/micromsg-bin/lbsfind";
            uint uin = (uint)wxUserCache.BaseRequest.uin;
            LBSFindRequest lBSFindRequest = GoogleProto.CreateLBSFindRequestEntity(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), uin, weidu, jingdu, Encoding.Default.GetString(wxUserCache.BaseRequest.devicelId), wxUserCache.BaseRequest.osType, sex);
            Debug.Print(lBSFindRequest.ToString());
            byte[] array = lBSFindRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)uin & -16777216) >> 24) & 0xFF),
                (byte)(((uin & 0xFF0000) >> 16) & 0xFF),
                (byte)(((uin & 0xFF00) >> 8) & 0xFF),
                (byte)(uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(lBSFindRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] data = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, uin, Encoding.Default.GetString(wxUserCache.BaseRequest.devicelId), 121, 148, wxUserCache.CookieBuffer, adler);
            byte[] array4;
            while (true)
            {
                WebClient webClient = new WebClient();
                array4 = null;
                try
                {
                    array4 = webClient.UploadData(address, "POST", data);
                }
                catch (Exception)
                {
                    Thread.Sleep(3000);
                    continue;
                }
                break;
            }
            byte b = array4[1];
            b = (byte)(b >> 2);
            bool flag = (array4[1] & 3) == 1;
            array4 = array4.Take(array4.Length).Skip(b).ToArray();
            byte[] array5 = DecryptPacket.DecryptReceivedPacket(array4, wxUserCache.BaseRequest.sessionKey);
            if (array5 == null || array5.Count() == 0)
            {
                return null;
            }
            byte[] data2 = array5;
            if (flag)
            {
                data2 = DeflateCompression.DeflateLBSUnzip(array5);
            }
            return LBSFindResponse.ParseFrom(data2);
        }

        public UploadhdheadimgResponse UploadHeadImg(string userName, byte[] buffer)
        {

            UploadhdheadimgResponse result = null;
            int num = 8192;
            byte[] array = buffer;
            int totalLen = array.Length;
            int num2 = 0;
            List<byte[]> list = SplitBuffer(array, 8192);
            for (int i = 0; i < list.Count; i++)
            {
                result = UploadHeadImgBlock(userName, totalLen, num2, list[i]);
                num2 += num;
            }
            return result;
        }

        private UploadhdheadimgResponse UploadHeadImgBlock(string userName, int totalLen, int startPos, byte[] blockImgBuffer)
        {
            var wxUserCache = GetWxUser(userName);
            byte b = 46;
            int num = 0;
            int num2 = 0;
            UploadhdheadimgRequest uploadhdheadimgRequest = GoogleProto.CreateUploadhdheadimgRequestEntity(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), (uint)wxUserCache.BaseRequest.uin, totalLen, startPos, blockImgBuffer, Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType);
            byte[] array = uploadhdheadimgRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
                (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(uploadhdheadimgRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] array4 = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 46, 157, wxUserCache.CookieBuffer, adler);
            byte[] array5 = new byte[array4.Length + 16];
            int seq = new Random().Next(100);
            seq++;
            array5[0] = 0;
            array5[1] = 0;
            array5[2] = (byte)(array5.Length / 256);
            array5[3] = (byte)(array5.Length % 256);
            array5[4] = 0;
            array5[5] = 16;
            array5[6] = 0;
            array5[7] = 1;
            array5[8] = 0;
            array5[9] = 0;
            array5[10] = 0;
            array5[11] = 46;
            array5[12] = 0;
            array5[13] = 0;
            array5[14] = (byte)(seq / 256);
            array5[15] = (byte)(seq % 256);
            Array.Copy(array4, 0, array5, 16, array4.Length);
            var client = getClient(userName);
            NetworkStream stream = client.GetStream();
            stream.Write(array5, 0, array5.Length);
            byte b2;
            byte[] array6;
            do
            {
                array6 = new byte[16];
                int num3 = stream.Read(array6, 0, array6.Length);
                Debug.Print(string.Format("readed:{0}", num3));
                b2 = array6[11];
                int num4 = array6[2] * 256 + array6[3] - 16;
                array6 = new byte[num4];
                int num5;
                for (num3 = 0; num3 < num4; num3 += num5)
                {
                    num5 = stream.Read(array6, num3, array6.Length - num3);
                }
                Debug.Print(string.Format("toRead{0}, readed:{1}", num4, num3));
            }
            while (b2 != b);
            byte b3 = array6[1];
            b3 = (byte)(b3 >> 2);
            bool flag = (array6[1] & 3) == 1;
            array6 = array6.Take(array6.Length).Skip(b3).ToArray();
            byte[] array7 = DecryptPacket.DecryptReceivedPacket(array6, wxUserCache.BaseRequest.sessionKey);
            byte[] data = array7;
            if (flag)
            {
                data = DeflateCompression.DeflateUnZip(array7);
            }
            return UploadhdheadimgResponse.ParseFrom(data);
        }

        public MmsnsuploadResponse MMSUploadImg(string userName, byte[] buffer, string ranMd5, string Description, ref int totalLen)
        {
            MmsnsuploadResponse result = null;
            int num = 8192;
            byte[] array = buffer;
            totalLen = array.Length;
            int num2 = 0;
            List<byte[]> list = SplitBuffer(array, 8192);
            for (int i = 0; i < list.Count; i++)
            {
                result = UploadTwitterImgBlock(userName, totalLen, num2, list[i], ranMd5, Description);
                num2 += num;
            }
            return result;
        }

        private MmsnsuploadResponse UploadTwitterImgBlock(string userName, int totalLen, int startPos, byte[] blockImgBuffer, string md5r, string mes)
        {
            var wxUserCache = GetWxUser(userName);
            byte b = 95;
            int num = 0;
            int num2 = 0;
            MmsnsuploadRequest mmsnsuploadRequest = GoogleProto.CreateUploadTwitterImgRequestEntity(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), (uint)wxUserCache.BaseRequest.uin, totalLen, startPos, blockImgBuffer, Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType, md5r, mes);
            Debug.Print(mmsnsuploadRequest.ToString());
            byte[] array = mmsnsuploadRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
                (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(mmsnsuploadRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] array4 = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 95, 207, wxUserCache.CookieBuffer, adler);
            byte[] array5 = new byte[array4.Length + 16];
            int seq = new Random().Next(100);
            seq++;
            array5[0] = 0;
            array5[1] = 0;
            array5[2] = (byte)(array5.Length / 256);
            array5[3] = (byte)(array5.Length % 256);
            array5[4] = 0;
            array5[5] = 16;
            array5[6] = 0;
            array5[7] = 1;
            array5[8] = 0;
            array5[9] = 0;
            array5[10] = 0;
            array5[11] = 95;
            array5[12] = 0;
            array5[13] = 0;
            array5[14] = (byte)(seq / 256);
            array5[15] = (byte)(seq % 256);
            Array.Copy(array4, 0, array5, 16, array4.Length);
            var client = getClient(userName);
            NetworkStream stream = client.GetStream();
            stream.Write(array5, 0, array5.Length);
            byte b2;
            byte[] array6;
            do
            {
                array6 = new byte[16];
                int num3 = stream.Read(array6, 0, array6.Length);
                Debug.Print(string.Format("readed:{0}", num3));
                b2 = array6[11];
                int num4 = array6[2] * 256 + array6[3] - 16;
                array6 = new byte[num4];
                int num5;
                for (num3 = 0; num3 < num4; num3 += num5)
                {
                    num5 = stream.Read(array6, num3, array6.Length - num3);
                }
                Debug.Print(string.Format("toRead{0}, readed:{1}", num4, num3));
            }
            while (b2 != b);
            byte b3 = array6[1];
            b3 = (byte)(b3 >> 2);
            array6 = array6.Take(array6.Length).Skip(b3).ToArray();
            byte[] array7 = DecryptPacket.DecryptReceivedPacket(array6, wxUserCache.BaseRequest.sessionKey);
            if (array7 == null || array7.Length == 0)
            {
                return null;
            }
            byte[] data = array7;
            if (array7[0] == 120 && array7[1] == 156)
            {
                data = DeflateCompression.DeflateUnZip(array7);
            }
            return MmsnsuploadResponse.ParseFrom(data);
        }

        public MMSnsPostResponse MMSPost(string userName, string clientId, string Desc, string imgUrl0, string imgUrl150, int totalLen, int imgH, int imgW)
        {
            var wxUserCache = GetWxUser(userName);
            byte b = 97;
            int num = 0;
            int num2 = 0;
            GoogleProto.CreateBaseRequestEntity(Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType);
            string descriptionHtml = "<TimelineObject><id><![CDATA[0]]></id><username><![CDATA[" + userName + "]]></username><createTime><![CDATA[0]]></createTime><private><![CDATA[0]]></private><contentDesc><![CDATA[" + Desc + "]]></contentDesc><sourceUserName></sourceUserName><sourceNickName></sourceNickName><location longitude =  \"0.0\"  city =  \"\"  latitude =  \"0.0\" ></location><ContentObject><contentStyle><![CDATA[1]]></contentStyle><title></title><description></description><contentUrl></contentUrl><mediaList><media><id><![CDATA[0]]></id><type><![CDATA[2]]></type><title></title><description></description><private><![CDATA[0]]></private><url type =  \"1\" ><![CDATA[" + imgUrl0 + "]]></url><thumb type =  \"1\" ><![CDATA[" + imgUrl150 + "]]></thumb><size totalSize =  \"" + totalLen + ".0\"  height =  \"" + imgH + ".0\"  width =  \"" + imgW + ".0\" ></size></media></mediaList></ContentObject></TimelineObject>";
            MMSnsPostRequest mMSnsPostRequest = GoogleProto.CreateSendTwitterRequestEntity(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType, clientId, descriptionHtml);
            Debug.Print(mMSnsPostRequest.ToString());
            byte[] array = mMSnsPostRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin  & 0xFF0000) >> 16) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin  & 0xFF00) >> 8) & 0xFF),
                (byte)((uint)wxUserCache.BaseRequest.uin  & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(mMSnsPostRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] array4 = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 97, 209, wxUserCache.CookieBuffer, adler);
            byte[] array5 = new byte[array4.Length + 16];
            int seq = new Random().Next(100);
            seq++;
            array5[0] = 0;
            array5[1] = 0;
            array5[2] = (byte)(array5.Length / 256);
            array5[3] = (byte)(array5.Length % 256);
            array5[4] = 0;
            array5[5] = 16;
            array5[6] = 0;
            array5[7] = 1;
            array5[8] = 0;
            array5[9] = 0;
            array5[10] = 0;
            array5[11] = 97;
            array5[12] = 0;
            array5[13] = 0;
            array5[14] = (byte)(seq / 256);
            array5[15] = (byte)(seq % 256);
            Array.Copy(array4, 0, array5, 16, array4.Length);
            var client = getClient(userName);
            NetworkStream stream = client.GetStream();
            stream.Write(array5, 0, array5.Length);
            byte b2;
            byte[] array6;
            do
            {
                array6 = new byte[16];
                int num3 = stream.Read(array6, 0, array6.Length);
                Debug.Print(string.Format("readed:{0}", num3));
                b2 = array6[11];
                int num4 = array6[2] * 256 + array6[3] - 16;
                array6 = new byte[num4];
                int num5;
                for (num3 = 0; num3 < num4; num3 += num5)
                {
                    num5 = stream.Read(array6, num3, array6.Length - num3);
                }
                Debug.Print(string.Format("toRead{0}, readed:{1}", num4, num3));
            }
            while (b2 != b);
            byte b3 = array6[1];
            b3 = (byte)(b3 >> 2);
            bool flag = (array6[1] & 3) == 1;
            array6 = array6.Take(array6.Length).Skip(b3).ToArray();
            byte[] array7 = DecryptPacket.DecryptReceivedPacket(array6, wxUserCache.BaseRequest.sessionKey);
            byte[] data = array7;
            if (flag)
            {
                data = DeflateCompression.DeflateUnZip(array7);
            }
            MMSnsPostResponse mMSnsPostResponse = MMSnsPostResponse.ParseFrom(data);
            Debug.Print(mMSnsPostResponse.ToString());
            return mMSnsPostResponse;
        }

        public NewSendMsgResponse SendFriendMsg(string userName, uint ClientMsgId, string Content, uint CreateTime, string ToUserName, uint msgType)
        {
            var wxUserCache = GetWxUser(userName);
            byte b = 237;
            int num = 0;
            int num2 = 0;
            NewSendMsgRequest newSendMsgRequest = GoogleProto.CreateSendMsgRequestEntity(Content, CreateTime, ClientMsgId, ToUserName, msgType);
            Debug.Print(newSendMsgRequest.ToString());
            byte[] array = newSendMsgRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
                (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(newSendMsgRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] array4 = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 237, 522, wxUserCache.CookieBuffer, adler);
            byte[] array5 = new byte[array4.Length + 16];

            int seq = new Random().Next(100);
            seq++;
            array5[0] = 0;
            array5[1] = 0;
            array5[2] = (byte)(array5.Length / 256);
            array5[3] = (byte)(array5.Length % 256);
            array5[4] = 0;
            array5[5] = 16;
            array5[6] = 0;
            array5[7] = 1;
            array5[8] = 0;
            array5[9] = 0;
            array5[10] = 0;
            array5[11] = 237;
            array5[12] = 0;
            array5[13] = 0;
            array5[14] = (byte)(seq / 256);
            array5[15] = (byte)(seq % 256);
            Array.Copy(array4, 0, array5, 16, array4.Length);
            var client = getClient(userName);
            NetworkStream stream = client.GetStream();
            stream.Write(array5, 0, array5.Length);
            byte b2;
            byte[] array6;
            do
            {
                array6 = new byte[16];
                int num3 = stream.Read(array6, 0, array6.Length);
                Debug.Print(string.Format("readed:{0}", num3));
                b2 = array6[11];
                int num4 = array6[2] * 256 + array6[3] - 16;
                array6 = new byte[num4];
                int num5;
                for (num3 = 0; num3 < num4; num3 += num5)
                {
                    num5 = stream.Read(array6, num3, array6.Length - num3);
                }
                Debug.Print(string.Format("toRead{0}, readed:{1}", num4, num3));
            }
            while (b2 != b);
            byte b3 = array6[1];
            b3 = (byte)(b3 >> 2);
            bool flag = (array6[1] & 3) == 1;
            array6 = array6.Take(array6.Length).Skip(b3).ToArray();
            byte[] array7 = DecryptPacket.DecryptReceivedPacket(array6, wxUserCache.BaseRequest.sessionKey);
            byte[] data = array7;
            if (flag)
            {
                data = DeflateCompression.DeflateUnZip(array7);
            }
            NewSendMsgResponse newSendMsgResponse = NewSendMsgResponse.ParseFrom(data);
            Debug.Print(newSendMsgResponse.ToString());
            return newSendMsgResponse;
        }

        public LogoutResponse Logout(string userName)
        {
            var wxUserCache = GetWxUser(userName);
            int num = 0;
            int num2 = 0;
            LogoutRequest logoutRequest = GoogleProto.CreateLogoutRequestEntity(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType);
            byte[] array = logoutRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
                (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(logoutRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] data = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 0, 255, wxUserCache.CookieBuffer, adler);
            string address = "http://" + shortUrl + "/cgi-bin/micromsg-bin/queryhaspasswd";
            byte[] array4;
            while (true)
            {
                WebClient webClient = new WebClient();
                webClient.Headers.Add("User-Agent", "MicroMessenger Client");
                webClient.Headers.Add("Content-Type", "application/octet-stream");
                array4 = null;
                try
                {
                    array4 = webClient.UploadData(address, "POST", data);
                }
                catch (Exception)
                {
                    Thread.Sleep(3000);
                    continue;
                }
                break;
            }
            byte b = array4[1];
            b = (byte)(b >> 2);
            bool flag = (array4[1] & 3) == 1;
            array4 = array4.Take(array4.Length).Skip(b).ToArray();
            byte[] array5 = DecryptPacket.DecryptReceivedPacket(array4, wxUserCache.BaseRequest.sessionKey);
            byte[] data2 = array5;
            if (flag)
            {
                data2 = DeflateCompression.DeflateUnZip(array5);
            }
            return LogoutResponse.ParseFrom(data2);
        }

        private List<byte[]> SplitBuffer(byte[] buffer, int blockLength)
        {
            List<byte[]> list = new List<byte[]>();
            for (int i = 0; buffer.Length - i > 0; i += blockLength)
            {
                byte[] item = buffer.Take(i + blockLength).Skip(i).ToArray();
                list.Add(item);
            }
            return list;
        }

        private int variantSkip(byte[] a)
        {
            int num = 0;
            foreach (byte b in a)
            {
                num++;
                if (b < 128)
                {
                    break;
                }
            }
            return num;
        }

        public VerifyUserResponse VerifyUser1(string userName, string strangerUserName, string ticket, int opCode, string scene, string content)
        {
            var wxUserCache = GetWxUser(userName);
            byte b = 44;
            int num = 0;
            int num2 = 0;
            uint uin = (uint)wxUserCache.BaseRequest.uin;
            VerifyUserRequest verifyUserRequest = GoogleProto.CreateVerifyUserRequestEntity(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), uin, Encoding.Default.GetString(wxUserCache.BaseRequest.devicelId), wxUserCache.BaseRequest.osType, strangerUserName, ticket, opCode, scene, content);
            Debug.Print(verifyUserRequest.ToString());
            byte[] array = verifyUserRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)uin & -16777216) >> 24) & 0xFF),
                (byte)(((uin & 0xFF0000) >> 16) & 0xFF),
                (byte)(((uin & 0xFF00) >> 8) & 0xFF),
                (byte)(uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(verifyUserRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] array4 = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, uin, Encoding.Default.GetString(wxUserCache.BaseRequest.devicelId), 34, 137, wxUserCache.CookieBuffer, adler);
            byte[] array5 = new byte[array4.Length + 16];
            int seq = new Random().Next(100);
            seq++;
            array5[0] = 0;
            array5[1] = 0;
            array5[2] = (byte)(array5.Length / 256);
            array5[3] = (byte)(array5.Length % 256);
            array5[4] = 0;
            array5[5] = 16;
            array5[6] = 0;
            array5[7] = 1;
            array5[8] = 0;
            array5[9] = 0;
            array5[10] = 0;
            array5[11] = 44;
            array5[12] = 0;
            array5[13] = 0;
            array5[14] = (byte)(seq / 256);
            array5[15] = (byte)(seq % 256);
            Array.Copy(array4, 0, array5, 16, array4.Length);
            var client = getClient(userName);
            NetworkStream stream = client.GetStream();
            stream.Write(array5, 0, array5.Length);
            byte b2;
            byte[] array6;
            do
            {
                array6 = new byte[16];
                int num3 = stream.Read(array6, 0, array6.Length);
                Debug.Print(string.Format("readed:{0}", num3));
                b2 = array6[11];
                int num4 = array6[2] * 256 + array6[3] - 16;
                array6 = new byte[num4];
                int num5;
                for (num3 = 0; num3 < num4; num3 += num5)
                {
                    num5 = stream.Read(array6, num3, array6.Length - num3);
                }
                Debug.Print(string.Format("toRead{0}, readed:{1}", num4, num3));
            }
            while (b2 != b);
            byte b3 = array6[1];
            b3 = (byte)(b3 >> 2);
            bool flag = (array6[1] & 3) == 1;
            array6 = array6.Take(array6.Length).Skip(b3).ToArray();
            byte[] array7 = DecryptPacket.DecryptReceivedPacket(array6, wxUserCache.BaseRequest.sessionKey);
            if (array7 == null || array7.Count() == 0)
            {
                return null;
            }
            byte[] data = array7;
            if (flag)
            {
                data = DeflateCompression.DeflateUnZip(array7);
            }
            return VerifyUserResponse.ParseFrom(data);
        }

        public VerifyUserResponse VerifyUser(string userName, string strangerUserName, string ticket, int opCode, string scene, string content)
        {
            var wxUserCache = GetWxUser(userName);

            byte b = 44;
            int num = 0;
            int num2 = 0;
            VerifyUserRequest verifyUserRequest = GoogleProto.CreateVerifyUserRequestEntity(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType, strangerUserName, ticket, opCode, scene, content);
            Debug.Print(verifyUserRequest.ToString());
            byte[] array = verifyUserRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
                (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(verifyUserRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] array4 = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 34, 137, wxUserCache.CookieBuffer, adler);
            byte[] array5 = new byte[array4.Length + 16];
            int seq = new Random().Next(100);
            seq++;
            array5[0] = 0;
            array5[1] = 0;
            array5[2] = (byte)(array5.Length / 256);
            array5[3] = (byte)(array5.Length % 256);
            array5[4] = 0;
            array5[5] = 16;
            array5[6] = 0;
            array5[7] = 1;
            array5[8] = 0;
            array5[9] = 0;
            array5[10] = 0;
            array5[11] = 44;
            array5[12] = 0;
            array5[13] = 0;
            array5[14] = (byte)(seq / 256);
            array5[15] = (byte)(seq % 256);
            Array.Copy(array4, 0, array5, 16, array4.Length);
            var client = getClient(userName);
            NetworkStream stream = client.GetStream();
            stream.Write(array5, 0, array5.Length);
            byte b2;
            byte[] array6;
            do
            {
                array6 = new byte[16];
                int num3 = stream.Read(array6, 0, array6.Length);
                Debug.Print(string.Format("readed:{0}", num3));
                b2 = array6[11];
                int num4 = array6[2] * 256 + array6[3] - 16;
                array6 = new byte[num4];
                int num5;
                for (num3 = 0; num3 < num4; num3 += num5)
                {
                    num5 = stream.Read(array6, num3, array6.Length - num3);
                }
                Debug.Print(string.Format("toRead{0}, readed:{1}", num4, num3));
            }
            while (b2 != b);
            byte b3 = array6[1];
            b3 = (byte)(b3 >> 2);
            bool flag = (array6[1] & 3) == 1;
            array6 = array6.Take(array6.Length).Skip(b3).ToArray();
            byte[] array7 = DecryptPacket.DecryptReceivedPacket(array6, wxUserCache.BaseRequest.sessionKey);
            if (array7 == null || array7.Count() == 0)
            {
                return null;
            }
            byte[] data = array7;
            if (flag)
            {
                data = DeflateCompression.DeflateUnZip(array7);
            }
            return VerifyUserResponse.ParseFrom(data);
        }

        private UploadMsgImgResponse UploadMsgImgBlock(string userName, string clientID, string toUser, int totalLen, int startPos, byte[] blockImgBuffer)
        {
            var wxUserCache = GetWxUser(userName);
            byte b = 9;
            int num = 0;
            int num2 = 0;
            UploadMsgImgRequest uploadMsgImgRequest = GoogleProto.CreateUploadMsgImgRequestEntity(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), (uint)wxUserCache.BaseRequest.uin, totalLen, startPos, blockImgBuffer, Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType, clientID, userName, toUser);
            byte[] array = uploadMsgImgRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
                (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(uploadMsgImgRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] array4 = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 9, 110, wxUserCache.CookieBuffer, adler);
            byte[] array5 = new byte[array4.Length + 16];
            int seq = new Random().Next(100);
            seq++;
            array5[0] = 0;
            array5[1] = 0;
            array5[2] = (byte)(array5.Length / 256);
            array5[3] = (byte)(array5.Length % 256);
            array5[4] = 0;
            array5[5] = 16;
            array5[6] = 0;
            array5[7] = 1;
            array5[8] = 0;
            array5[9] = 0;
            array5[10] = 0;
            array5[11] = 9;
            array5[12] = 0;
            array5[13] = 0;
            array5[14] = (byte)(seq / 256);
            array5[15] = (byte)(seq % 256);
            Array.Copy(array4, 0, array5, 16, array4.Length);
            var client = getClient(userName);
            NetworkStream stream = client.GetStream();
            stream.Write(array5, 0, array5.Length);
            byte b2;
            byte[] array6;
            do
            {
                array6 = new byte[16];
                int num3 = stream.Read(array6, 0, array6.Length);
                Debug.Print(string.Format("readed:{0}", num3));
                b2 = array6[11];
                int num4 = array6[2] * 256 + array6[3] - 16;
                array6 = new byte[num4];
                int num5;
                for (num3 = 0; num3 < num4; num3 += num5)
                {
                    num5 = stream.Read(array6, num3, array6.Length - num3);
                }
                Debug.Print(string.Format("toRead{0}, readed:{1}", num4, num3));
            }
            while (b2 != b);
            byte b3 = array6[1];
            b3 = (byte)(b3 >> 2);
            bool flag = (array6[1] & 3) == 1;
            array6 = array6.Take(array6.Length).Skip(b3).ToArray();
            byte[] array7 = DecryptPacket.DecryptReceivedPacket(array6, wxUserCache.BaseRequest.sessionKey);
            byte[] data = array7;
            if (flag)
            {
                data = DeflateCompression.DeflateUnZip(array7);
            }
            return UploadMsgImgResponse.ParseFrom(data);
        }

        public SearchContactResponse SearchOne(string userName, string peer)
        {
            var wxUserCache = GetWxUser(userName);
            byte b = 34;
            int num = 0;
            int num2 = 0;
            SearchContactRequest searchContactRequest = GoogleProto.CreateSearchContactEntity(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType, peer);
            byte[] array = searchContactRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
                (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(searchContactRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] array4 = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 34, 106, wxUserCache.CookieBuffer, adler);
            byte[] array5 = new byte[array4.Length + 16];
            int seq = new Random().Next(100);
            seq++;
            array5[0] = 0;
            array5[1] = 0;
            array5[2] = (byte)(array5.Length / 256);
            array5[3] = (byte)(array5.Length % 256);
            array5[4] = 0;
            array5[5] = 16;
            array5[6] = 0;
            array5[7] = 1;
            array5[8] = 0;
            array5[9] = 0;
            array5[10] = 0;
            array5[11] = 34;
            array5[12] = 0;
            array5[13] = 0;
            array5[14] = (byte)(seq / 256);
            array5[15] = (byte)(seq % 256);
            Array.Copy(array4, 0, array5, 16, array4.Length);
            var client = getClient(userName);
            NetworkStream stream = client.GetStream();
            stream.Write(array5, 0, array5.Length);
            byte b2;
            byte[] array6;
            do
            {
                array6 = new byte[16];
                int num3 = stream.Read(array6, 0, array6.Length);
                Debug.Print(string.Format("readed:{0}", num3));
                b2 = array6[11];
                int num4 = array6[2] * 256 + array6[3] - 16;
                array6 = new byte[num4];
                int num5;
                for (num3 = 0; num3 < num4; num3 += num5)
                {
                    num5 = stream.Read(array6, num3, array6.Length - num3);
                }
                Debug.Print(string.Format("toRead{0}, readed:{1}", num4, num3));
            }
            while (b2 != b);
            byte b3 = array6[1];
            b3 = (byte)(b3 >> 2);
            bool flag = (array6[1] & 3) == 1;
            array6 = array6.Take(array6.Length).Skip(b3).ToArray();
            byte[] array7 = DecryptPacket.DecryptReceivedPacket(array6, wxUserCache.BaseRequest.sessionKey);
            if (array7 == null || array7.Count() == 0)
            {
                return null;
            }
            byte[] data = array7;
            if (flag)
            {
                data = DeflateCompression.DeflateUnZip(array7);
            }
            return SearchContactResponse.ParseFrom(data);
        }

        public BindQQResponse BindQQ(string p1, string p2)
        {
            throw new NotImplementedException();
        }

        public GeneralSetResponse SetWXID(string userName, string wxID)
        {
            var wxUserCache = GetWxUser(userName);
            int num = 0;
            int num2 = 0;
            GeneralSetRequest generalSetRequest = GoogleProto.CreateSetIDEntity(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType, wxID);
            byte[] array = generalSetRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
                (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(generalSetRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] data = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 0, 177, wxUserCache.CookieBuffer, adler);
            string address = "http://" + shortUrl + "/cgi-bin/micromsg-bin/generalset";
            byte[] array4;
            while (true)
            {
                WebClient webClient = new WebClient();
                array4 = null;
                try
                {
                    array4 = webClient.UploadData(address, "POST", data);
                }
                catch (Exception)
                {
                    Thread.Sleep(3000);
                    continue;
                }
                break;
            }
            byte b = array4[1];
            b = (byte)(b >> 2);
            bool flag = (array4[1] & 3) == 1;
            array4 = array4.Take(array4.Length).Skip(b).ToArray();
            byte[] array5 = DecryptPacket.DecryptReceivedPacket(array4, wxUserCache.BaseRequest.sessionKey);
            if (array5 == null || array5.Count() == 0)
            {
                return null;
            }
            byte[] data2 = array5;
            if (flag)
            {
                data2 = DeflateCompression.DeflateUnZip(array5);
            }
            return GeneralSetResponse.ParseFrom(data2);
        }

        public BindEmailResponse BingEmail(string userName, string Email)
        {
            var wxUserCache = GetWxUser(userName);
            int num = 0;
            int num2 = 0;
            BindEmailRequest bindEmailRequest = GoogleProto.BindEmailEntity(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType, Email);
            byte[] array = bindEmailRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
                (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(bindEmailRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] data = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 34, 256, wxUserCache.CookieBuffer, adler);
            string address = "http://" + shortUrl + "/cgi-bin/micromsg-bin/bindemail";
            WebClient webClient = new WebClient();
            byte[] array4;
            while (true)
            {
                array4 = null;
                try
                {
                    array4 = webClient.UploadData(address, "POST", data);
                }
                catch (Exception)
                {
                    Thread.Sleep(3000);
                    continue;
                }
                break;
            }
            byte b = array4[1];
            b = (byte)(b >> 2);
            array4 = array4.Take(array4.Length).Skip(b).ToArray();
            byte[] array5 = DecryptPacket.DecryptReceivedPacket(array4, wxUserCache.BaseRequest.sessionKey);
            if (array5 == null || array5.Count() == 0)
            {
                return null;
            }
            BindEmailResponse bindEmailResponse = BindEmailResponse.ParseFrom(array5);
            Debug.Print(bindEmailResponse.ToString());
            return bindEmailResponse;
        }

        public BindOpMobileResponse BindMobile(string userName, string mobile, string deviceName, string deviceType)
        {
            var wxUserCache = GetWxUser(userName);
            int num = 0;
            int num2 = 0;
            BindOpMobileRequest bindOpMobileRequest = GoogleProto.CreateBindMobileRequestEntity(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType, mobile, deviceName, deviceType);
            byte[] array = bindOpMobileRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
                (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(bindOpMobileRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] data = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 132, 132, wxUserCache.CookieBuffer, adler);
            string address = "http://" + shortUrl + "/cgi-bin/micromsg-bin/bindopmobile";
            byte[] array4;
            while (true)
            {
                WebClient webClient = new WebClient();
                array4 = null;
                try
                {
                    array4 = webClient.UploadData(address, "POST", data);
                }
                catch (Exception)
                {
                    Thread.Sleep(3000);
                    continue;
                }
                break;
            }
            byte b = array4[1];
            b = (byte)(b >> 2);
            array4 = array4.Take(array4.Length).Skip(b).ToArray();
            byte[] array5 = DecryptPacket.DecryptReceivedPacket(array4, wxUserCache.BaseRequest.sessionKey);
            byte[] data2 = array5;
            if (array5[0] == 120 && array5[1] == 156)
            {
                data2 = DeflateCompression.DeflateUnZip(array5);
            }
            BindOpMobileResponse bindOpMobileResponse = BindOpMobileResponse.ParseFrom(data2);
            Debug.Print(bindOpMobileResponse.ToString());
            return bindOpMobileResponse;
        }

        public BindQQResponse BindQQ(string userName, string qq, string pass, string deviceName, string deviceType)
        {
            var wxUserCache = GetWxUser(userName);
            int num = 0;
            int num2 = 0;
            BindQQRequest bindQQRequest = GoogleProto.CreateBindMobileRequestEntity(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType, qq, pass, deviceName, deviceType);
            Debug.Print(bindQQRequest.ToString());
            byte[] array = bindQQRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
                (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(bindQQRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] data = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 144, 144, wxUserCache.CookieBuffer, adler);
            string address = "http://" + shortUrl + "/cgi-bin/micromsg-bin/bindqq";
            byte[] array4;
            while (true)
            {
                WebClient webClient = new WebClient();
                array4 = null;
                try
                {
                    array4 = webClient.UploadData(address, "POST", data);
                }
                catch (Exception)
                {
                    Thread.Sleep(3000);
                    continue;
                }
                break;
            }
            byte b = array4[1];
            b = (byte)(b >> 2);
            bool flag = (array4[1] & 3) == 1;
            array4 = array4.Take(array4.Length).Skip(b).ToArray();
            byte[] array5 = DecryptPacket.DecryptReceivedPacket(array4, wxUserCache.BaseRequest.sessionKey);
            byte[] data2 = array5;
            if (flag)
            {
                data2 = DeflateCompression.DeflateUnZip(array5);
            }
            BindQQResponse bindQQResponse = BindQQResponse.ParseFrom(data2);
            Debug.Print(bindQQResponse.ToString());
            return bindQQResponse;
        }

        public UploadMContactResponse UploadMContact(string userName, string mobile, List<string> contacts)
        {
            var wxUserCache = GetWxUser(userName);
            int num = 0;
            int num2 = 0;
            for (long num3 = 13803111230L; num3 < 13803111250L; num3++)
            {
                contacts.Add(string.Format("{0}", num3));
            }
            UploadMContact uploadMContact = GoogleProto.UploadMContact(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType, mobile, contacts, userName);
            byte[] array = uploadMContact.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
                (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(uploadMContact.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] data = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 133, 133, wxUserCache.CookieBuffer, adler);
            string address = "http://" + shortUrl + "/cgi-bin/micromsg-bin/uploadmcontact";
            byte[] array4;
            while (true)
            {
                WebClient webClient = new WebClient();
                array4 = null;
                try
                {
                    array4 = webClient.UploadData(address, "POST", data);
                }
                catch (Exception)
                {
                    Thread.Sleep(3000);
                    continue;
                }
                break;
            }
            byte b = array4[1];
            b = (byte)(b >> 2);
            bool flag = (array4[1] & 3) == 1;
            array4 = array4.Take(array4.Length).Skip(b).ToArray();
            byte[] array5 = DecryptPacket.DecryptReceivedPacket(array4, wxUserCache.BaseRequest.sessionKey);
            byte[] data2 = array5;
            if (flag)
            {
                data2 = DeflateCompression.DeflateUnZip(array5);
            }
            return UploadMContactResponse.ParseFrom(data2);
        }

        //public BindopMobileForRegResponse MobileReg(string userName, int opCode, string mobile, string verifyCode)
        //{
        //    var wxUserCache = GetWxUser(userName);
        //    int num = 0;
        //    int num2 = 0;
        //    BaseRequest baseRequest = GoogleProto.CreateBaseRequestEntity(Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType, 0);
        //    BindopMobileForRegRequest bindopMobileForRegRequest = GoogleProto.CreateMobileRegPacket(baseRequest, opCode, mobile, verifyCode, wxUserCache.randomEncryKey, wxUserCache.devicetype, wxUserCache.clientid, regSession);
        //    Debug.Print(bindopMobileForRegRequest.ToString());
        //    byte[] array = bindopMobileForRegRequest.ToByteArray();
        //    num = array.Length;
        //    byte[] array2 = DeflateCompression.DeflateZip(bindopMobileForRegRequest.ToByteArray());
        //    num2 = array2.Length;
        //    byte[] rsaDataPacket = RSAEncryptData.RSAEncryptNewReg(array2);
        //    byte[] array3 = ConstructPacket.RegRequestPacket(num, num2, rsaDataPacket, Encoding.Default.GetString(wxUserCache.DeviceId), 145);
        //    string requestUriString = "http://" + shortUrl + "/cgi-bin/micromsg-bin/bindopmobileforreg";
        //    bool flag;
        //    byte[] array5;
        //    do
        //    {
        //        byte[] array4 = null;
        //        try
        //        {
        //            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
        //            httpWebRequest.ContentType = "application/octet-stream";
        //            httpWebRequest.UserAgent = "MicroMessenger Client";
        //            httpWebRequest.Method = "POST";
        //            httpWebRequest.Timeout = 20000;
        //            httpWebRequest.ContentLength = array3.Length;
        //            httpWebRequest.GetRequestStream().Write(array3, 0, array3.Length);
        //            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        //            string s = httpWebResponse.Headers["Content-Length"];
        //            int num3 = int.Parse(s);
        //            Stream responseStream = httpWebResponse.GetResponseStream();
        //            array4 = new byte[num3];
        //            responseStream.Read(array4, 0, num3);
        //            responseStream.Close();
        //            httpWebRequest.Abort();
        //            httpWebResponse.Close();
        //        }
        //        catch (Exception)
        //        {
        //        }
        //        byte b = array4[1];
        //        b = (byte)(b >> 2);
        //        flag = ((array4[1] & 3) == 1);
        //        array4 = array4.Take(array4.Length).Skip(b).ToArray();
        //        array5 = DecryptPacket.DecryptReceivedPacket(array4, wxUserCache.randomEncryKey);
        //    }
        //    while (array5 == null);
        //    byte[] data = array5;
        //    if (flag)
        //    {
        //        data = DeflateCompression.DeflateUnZip(array5);
        //    }
        //    BindopMobileForRegResponse bindopMobileForRegResponse = BindopMobileForRegResponse.ParseFrom(data);
        //    if (bindopMobileForRegResponse.Base.Ret == -301)
        //    {
        //        shortUrl = bindopMobileForRegResponse.NewHostList.ListList[1].Substitute;
        //    }
        //    return bindopMobileForRegResponse;
        //}

        public ThrowBottleResponse ThrowBottle(string userName, string text)
        {
            var wxUserCache = GetWxUser(userName);
            int num = 0;
            int num2 = 0;
            ThrowBottleRequest throwBottleRequest = GoogleProto.CreateThrowBottleRequestEntity(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType, text);
            Debug.Print(throwBottleRequest.ToString());
            byte[] array = throwBottleRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                 (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                  (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
              (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(throwBottleRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] data = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 0, 154, wxUserCache.CookieBuffer, adler);
            string address = "http://" + shortUrl + "/cgi-bin/micromsg-bin/throwbottle";
            byte[] array4;
            while (true)
            {
                WebClient webClient = new WebClient();
                array4 = null;
                try
                {
                    array4 = webClient.UploadData(address, "POST", data);
                }
                catch (Exception)
                {
                    Thread.Sleep(3000);
                    continue;
                }
                break;
            }
            byte b = array4[1];
            b = (byte)(b >> 2);
            bool flag = (array4[1] & 3) == 1;
            array4 = array4.Take(array4.Length).Skip(b).ToArray();
            byte[] array5 = DecryptPacket.DecryptReceivedPacket(array4, wxUserCache.BaseRequest.sessionKey);
            byte[] data2 = array5;
            if (flag)
            {
                data2 = DeflateCompression.DeflateUnZip(array5);
            }
            ThrowBottleResponse throwBottleResponse = ThrowBottleResponse.ParseFrom(data2);
            Debug.Print(throwBottleResponse.ToString());
            return throwBottleResponse;
        }

        public ShakereportResponse ShakeReprot(string userName, float latitude, float longitude)
        {
            var wxUserCache = GetWxUser(userName);
            int num = 0;
            int num2 = 0;
            ShakereportRequest shakereportRequest = GoogleProto.CreateShakeReportRequestEntity(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType, latitude, longitude);
            Debug.Print(shakereportRequest.ToString());
            byte[] array = shakereportRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                  (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
              (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(shakereportRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] data = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 0, 161, wxUserCache.CookieBuffer, adler);
            string address = "http://" + shortUrl + "/cgi-bin/micromsg-bin/shakereport";
            byte[] array4;
            while (true)
            {
                WebClient webClient = new WebClient();
                array4 = null;
                try
                {
                    array4 = webClient.UploadData(address, "POST", data);
                }
                catch (Exception)
                {
                    Thread.Sleep(3000);
                    continue;
                }
                break;
            }
            byte b = array4[1];
            b = (byte)(b >> 2);
            bool flag = (array4[1] & 3) == 1;
            array4 = array4.Take(array4.Length).Skip(b).ToArray();
            byte[] array5 = DecryptPacket.DecryptReceivedPacket(array4, wxUserCache.BaseRequest.sessionKey);
            byte[] data2 = array5;
            if (flag)
            {
                data2 = DeflateCompression.DeflateUnZip(array5);
            }
            ShakereportResponse shakereportResponse = ShakereportResponse.ParseFrom(data2);
            Debug.Print(shakereportResponse.ToString());

            return shakereportResponse;
        }

        public ShakegetResponse ShakeGet(string userName, SKBuiltinBuffer_t shakeBuff)
        {
            var wxUserCache = GetWxUser(userName);
            int num = 0;
            int num2 = 0;
         

            ShakegetRequest shakegetRequest = GoogleProto.CreateShakeGetRequestEntity(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType, shakeBuff);
            Debug.Print(shakegetRequest.ToString());
            byte[] array = shakegetRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                 (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
              (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(shakegetRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] data = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 0, 162, wxUserCache.CookieBuffer, adler);
            string address = "http://" + shortUrl + "/cgi-bin/micromsg-bin/shakeget";
            byte[] array4;
            while (true)
            {
                WebClient webClient = new WebClient();
                array4 = null;
                try
                {
                    array4 = webClient.UploadData(address, "POST", data);
                }
                catch (Exception)
                {
                    Thread.Sleep(3000);
                    continue;
                }
                break;
            }
            byte b = array4[1];
            b = (byte)(b >> 2);
            bool flag = (array4[1] & 3) == 1;
            array4 = array4.Take(array4.Length).Skip(b).ToArray();
            byte[] array5 = DecryptPacket.DecryptReceivedPacket(array4, wxUserCache.BaseRequest.sessionKey);
            byte[] data2 = array5;
            if (flag)
            {
                data2 = DeflateCompression.DeflateUnZip(array5);
            }
            ShakegetResponse shakegetResponse = ShakegetResponse.ParseFrom(data2);
            Debug.Print(shakegetResponse.ToString());
            return shakegetResponse;
        }

        public GetLoginQRCodeResponse GetQRCode()
        {
            string text = HardInfoHelper.GetRandomHandInfo();
            var randomEncryKey = RandomEncryHelper.GenRandomEncryKey();
            string[] array1 = text.Split('|');
            string ostype = array1[28];
            string deviceid = array1[4];
            int num = 0;
            int num2 = 0;
            BaseRequest @base = GoogleProto.CreateBaseRequestEntity(deviceid, ostype, 0);
            GetLoginQRCodeRequest.Builder builder = new GetLoginQRCodeRequest.Builder();
            builder.SetBase(@base);
            SKBuiltinBuffer_t.Builder builder2 = new SKBuiltinBuffer_t.Builder();
            builder2.SetILen(16);
            builder2.SetBuffer(ByteString.CopyFrom(randomEncryKey));
            builder.SetRandomEncryKey(builder2);
            builder.SetOpcode(0u);
            byte[] array = builder.Build().ToByteArray();
            num = array.Length;
            byte[] array2 = DeflateCompression.DeflateZip(array);
            num2 = array2.Length;
            byte[] rsaDataPacket = RSAEncryptData.RSAEncryptCoreData(array2);
            byte[] data = ConstructPacket.QRCodeRequestPacket(num, num2, rsaDataPacket, deviceid, 502);
            string address = "http://" + shortUrl + "/cgi-bin/micromsg-bin/getloginqrcode";
            byte[] array4;
            do
            {
                IL_0164:
                WebClient webClient = new WebClient();
                webClient.Headers.Add("User-Agent", "MicroMessenger Client");
                webClient.Headers.Add("Content-Type", "application/octet-stream");
                byte[] array3 = null;
                try
                {
                    array3 = webClient.UploadData(address, "POST", data);
                }
                catch (Exception)
                {
                    Thread.Sleep(3000);
                    goto IL_0164;
                }
                byte b = array3[0];
                b = (byte)(b >> 2);
                byte b2 = (byte)((int)array3[1] % 16);
                byte[] cookie = new byte[b2];
                Array.Copy(array3, 10, cookie, 0, b2);
                array3 = array3.Take(array3.Length).Skip(b).ToArray();
                array4 = DecryptPacket.DecryptReceivedPacket(array3, randomEncryKey);
            }
            while (array4 == null || array4.Count() == 0);
            byte[] data2 = DeflateCompression.DeflateUnZip(array4);
            GetLoginQRCodeResponse getLoginQRCodeResponse = GetLoginQRCodeResponse.ParseFrom(data2);
            if (getLoginQRCodeResponse.Base.Ret == 0)
            {
                CustomerInfoCache customerInfoCache = new CustomerInfoCache();
                customerInfoCache.BaseRequest = new CustomerInfoCache.BaseRequestCache()
                {
                    devicelId = Encoding.Default.GetBytes(deviceid),
                    osType = ostype
                };
                customerInfoCache.Uuid = getLoginQRCodeResponse.UUID;
                customerInfoCache.notifykey = getLoginQRCodeResponse.NotifyKey.Buffer.ToByteArray();
                this._redisCache.Add(ConstCacheKey.GetUuidKey(customerInfoCache.Uuid), customerInfoCache, DateTime.Now.AddMinutes(3));
            }
            Debug.Print(getLoginQRCodeResponse.ToString());
            return getLoginQRCodeResponse;
        }

        public CheckLoginQRCodeResponse CheckQRCode(string uuid)
        {
            var wxUserCache = this._redisCache.Get<CustomerInfoCache>(ConstCacheKey.GetUuidKey(uuid));
            //var wxUserCache = GetWxUser(userName);
            int num = 0;
            int num2 = 0;
            BaseRequest @base = GoogleProto.CreateBaseRequestEntity(Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType, 0);
            CheckLoginQRCodeRequest.Builder builder = new CheckLoginQRCodeRequest.Builder();
            builder.SetBase(@base);
            SKBuiltinBuffer_t.Builder builder2 = new SKBuiltinBuffer_t.Builder();
            builder2.SetILen(16);
            builder2.SetBuffer(ByteString.CopyFrom(wxUserCache.randomEncryKey));
            builder.SetRandomEncryKey(builder2);
            builder.SetUuid(uuid);
            DateTime d = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0));
            uint timeStamp = (uint)(DateTime.Now - d).TotalSeconds;
            builder.SetTimeStamp(timeStamp);
            builder.SetOpcode(0u);
            byte[] array = builder.Build().ToByteArray();
            num = array.Length;
            byte[] array2 = DeflateCompression.DeflateZip(array);
            num2 = array2.Length;
            byte[] rsaDataPacket = RSAEncryptData.RSAEncryptCoreData(array2);
            byte[] data = ConstructPacket.QRCodeRequestPacket(num, num2, rsaDataPacket, Encoding.Default.GetString(wxUserCache.DeviceId), 503);
            string address = "http://" + shortUrl + "/cgi-bin/micromsg-bin/checkloginqrcode";
            bool flag;
            byte[] array4;
            do
            {
                IL_01b9:
                WebClient webClient = new WebClient();
                webClient.Headers.Add("User-Agent", "MicroMessenger Client");
                webClient.Headers.Add("Content-Type", "application/octet-stream");
                byte[] array3 = null;
                try
                {
                    array3 = webClient.UploadData(address, "POST", data);
                }
                catch (Exception)
                {
                    Thread.Sleep(3000);
                    goto IL_01b9;
                }
                byte b = array3[0];
                b = (byte)(b >> 2);
                flag = ((array3[1] & 3) == 1);
                byte b2 = (byte)((int)array3[1] % 16);
                byte[] cookie = new byte[b2];
                Array.Copy(array3, 10, wxUserCache.CookieBuffer, 0, b2);
                array3 = array3.Take(array3.Length).Skip(b).ToArray();
                array4 = DecryptPacket.DecryptReceivedPacket(array3, wxUserCache.randomEncryKey);
            }
            while (array4 == null || array4.Count() == 0);
            byte[] data2 = array4;
            if (flag)
            {
                data2 = DeflateCompression.DeflateUnZip(array4);
            }
            CheckLoginQRCodeResponse checkLoginQRCodeResponse = CheckLoginQRCodeResponse.ParseFrom(data2);
            if (checkLoginQRCodeResponse.Base.Ret == 0)
            {
                var buffer = DecryptPacket.DecryptReceivedPacket(checkLoginQRCodeResponse.NotifyPkg.NotifyData.Buffer.ToByteArray(), wxUserCache.notifykey);
                var r = Util.Deserialize<MMPro.MM.LoginQRCodeNotify>(buffer);
                wxUserCache.HeadUrl = r.headImgUrl;
                //wxUserCache.MUid = mUid;
                //wxUserCache.Cookie = cookie;
                wxUserCache.WxId = r.wxid;
                wxUserCache.WxNewPass = r.wxnewpass;
                wxUserCache.State = r.state;
                wxUserCache.Uuid = r.uuid;
                wxUserCache.NickName = r.nickName;
                wxUserCache.Device = r.device;
                wxUserCache.State = r.state;
                this._redisCache.HashSet(ConstCacheKey.GetWxIdKey(), wxUserCache.WxId, wxUserCache);
            }
            Debug.Print(checkLoginQRCodeResponse.ToString());
            return checkLoginQRCodeResponse;
        }





        public UploadMsgImgResponse UploadMsgImg(string userName, byte[] buffer, string toUser)
        {
            UploadMsgImgResponse result = null;
            int num = 8192;
            string clientID = Fun.CumputeMD5(DateTime.Now.ToLongTimeString());
            byte[] array = buffer;
            int totalLen = array.Length;
            int num2 = 0;
            List<byte[]> list = SplitBuffer(array, 8192);
            for (int i = 0; i < list.Count; i++)
            {
                result = UploadMsgImgBlock(userName, clientID, toUser, totalLen, num2, list[i]);
                num2 += num;
            }
            return result;
        }

        public OplogResponse OpLog(string userName, int cmdid, string removeObj)
        {
            var wxUserCache = GetWxUser(userName);
            int num = 0;
            int num2 = 0;
            OplogRequest oplogRequest = GoogleProto.CreateOpLogRequestEntity(cmdid, removeObj);
            Debug.Print(oplogRequest.ToString());
            byte[] array = oplogRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                 (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                  (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
                (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(oplogRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] data = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 0, 681, wxUserCache.CookieBuffer, adler);
            string address = "http://" + shortUrl + "/cgi-bin/micromsg-bin/oplog";
            bool flag;
            byte[] array5;
            do
            {
                IL_020b:
                WebClient webClient = new WebClient();
                webClient.Headers.Add("User-Agent", "MicroMessenger Client");
                webClient.Headers.Add("Content-Type", "application/octet-stream");
                byte[] array4 = null;
                try
                {
                    array4 = webClient.UploadData(address, "POST", data);
                }
                catch (Exception)
                {
                    Thread.Sleep(3000);
                    goto IL_020b;
                }
                byte b = array4[1];
                b = (byte)(b >> 2);
                flag = ((array4[1] & 3) == 1);
                array4 = array4.Take(array4.Length).Skip(b).ToArray();
                array5 = DecryptPacket.DecryptReceivedPacket(array4, wxUserCache.BaseRequest.sessionKey);
            }
            while (array5 == null || array5.Count() == 0);
            byte[] data2 = array5;
            if (flag)
            {
                data2 = DeflateCompression.DeflateUnZip(array5);
            }
            OplogResponse oplogResponse = OplogResponse.ParseFrom(data2);
            Debug.Print(oplogResponse.ToString());
            return oplogResponse;
        }

        public OplogResponse OpExitChatroom(string userName, int cmdid, string chatroom, string self)
        {
            var wxUserCache = GetWxUser(userName);
            int num = 0;
            int num2 = 0;
            OplogRequest oplogRequest = GoogleProto.CreateExitChatroomRequestEntity(cmdid, chatroom, self);
            Debug.Print(oplogRequest.ToString());
            byte[] array = oplogRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                 (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                  (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
              (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(oplogRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] data = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 0, 681, wxUserCache.CookieBuffer, adler);
            string address = "http://" + shortUrl + "/cgi-bin/micromsg-bin/oplog";
            bool flag;
            byte[] array5;
            do
            {
                IL_020c:
                WebClient webClient = new WebClient();
                webClient.Headers.Add("User-Agent", "MicroMessenger Client");
                webClient.Headers.Add("Content-Type", "application/octet-stream");
                byte[] array4 = null;
                try
                {
                    array4 = webClient.UploadData(address, "POST", data);
                }
                catch (Exception)
                {
                    Thread.Sleep(3000);
                    goto IL_020c;
                }
                byte b = array4[1];
                b = (byte)(b >> 2);
                flag = ((array4[1] & 3) == 1);
                array4 = array4.Take(array4.Length).Skip(b).ToArray();
                array5 = DecryptPacket.DecryptReceivedPacket(array4, wxUserCache.BaseRequest.sessionKey);
            }
            while (array5 == null || array5.Count() == 0);
            byte[] data2 = array5;
            if (flag)
            {
                data2 = DeflateCompression.DeflateUnZip(array5);
            }
            OplogResponse oplogResponse = OplogResponse.ParseFrom(data2);
            Debug.Print(oplogResponse.ToString());
            return oplogResponse;
        }

        public OplogResponse OpSetCheck(string userName, int cmdid, int key, int value)
        {
            var wxUserCache = GetWxUser(userName);
            int num = 0;
            int num2 = 0;
            OplogRequest oplogRequest = GoogleProto.CreateOpSetCheckRequestEntity(cmdid, key, value);
            Debug.Print(oplogRequest.ToString());
            byte[] array = oplogRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                 (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                  (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
              (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(oplogRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] data = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 0, 681, wxUserCache.CookieBuffer, adler);
            string address = "http://" + shortUrl + "/cgi-bin/micromsg-bin/oplog";
            bool flag;
            byte[] array5;
            do
            {
                IL_020c:
                WebClient webClient = new WebClient();
                webClient.Headers.Add("User-Agent", "MicroMessenger Client");
                webClient.Headers.Add("Content-Type", "application/octet-stream");
                byte[] array4 = null;
                try
                {
                    array4 = webClient.UploadData(address, "POST", data);
                }
                catch (Exception)
                {
                    Thread.Sleep(3000);
                    goto IL_020c;
                }
                byte b = array4[1];
                b = (byte)(b >> 2);
                flag = ((array4[1] & 3) == 1);
                array4 = array4.Take(array4.Length).Skip(b).ToArray();
                array5 = DecryptPacket.DecryptReceivedPacket(array4, wxUserCache.BaseRequest.sessionKey);
            }
            while (array5 == null || array5.Count() == 0);
            byte[] data2 = array5;
            if (flag)
            {
                data2 = DeflateCompression.DeflateUnZip(array5);
            }
            OplogResponse oplogResponse = OplogResponse.ParseFrom(data2);
            Debug.Print(oplogResponse.ToString());
            return oplogResponse;
        }

        public CreateChatRoomResponse CreateChatroom(string userName, List<string> memList)
        {
            var wxUserCache = GetWxUser(userName);
            byte b = 37;
            int num = 0;
            int num2 = 0;
            CreateChatRoomRequest createChatRoomRequest = GoogleProto.CreateChatroomRequestEntity(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType, memList);
            Debug.Print(createChatRoomRequest.ToString());
            byte[] array = createChatRoomRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                 (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                  (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
              (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(createChatRoomRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] array4 = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 185, 119, wxUserCache.CookieBuffer, adler);
            byte[] array5 = new byte[array4.Length + 16];
            int seq = new Random().Next(100);
            seq++;
            array5[0] = 0;
            array5[1] = 0;
            array5[2] = (byte)(array5.Length / 256);
            array5[3] = (byte)(array5.Length % 256);
            array5[4] = 0;
            array5[5] = 16;
            array5[6] = 0;
            array5[7] = 1;
            array5[8] = 0;
            array5[9] = 0;
            array5[10] = 0;
            array5[11] = 37;
            array5[12] = 0;
            array5[13] = 0;
            array5[14] = (byte)(seq / 256);
            array5[15] = (byte)(seq % 256);
            Array.Copy(array4, 0, array5, 16, array4.Length);
            var client = getClient(userName);
            NetworkStream stream = client.GetStream();
            stream.Write(array5, 0, array5.Length);
            byte b2;
            byte[] array6;
            do
            {
                array6 = new byte[16];
                int num3 = stream.Read(array6, 0, array6.Length);
                Debug.Print(string.Format("readed:{0}", num3));
                b2 = array6[11];
                int num4 = array6[2] * 256 + array6[3] - 16;
                array6 = new byte[num4];
                int num5;
                for (num3 = 0; num3 < num4; num3 += num5)
                {
                    num5 = stream.Read(array6, num3, array6.Length - num3);
                }
                Debug.Print(string.Format("toRead{0}, readed:{1}", num4, num3));
            }
            while (b2 != b);
            byte b3 = array6[1];
            b3 = (byte)(b3 >> 2);
            bool flag = (array6[1] & 3) == 1;
            array6 = array6.Take(array6.Length).Skip(b3).ToArray();
            byte[] array7 = DecryptPacket.DecryptReceivedPacket(array6, wxUserCache.BaseRequest.sessionKey);
            byte[] data = array7;
            if (flag)
            {
                data = DeflateCompression.DeflateUnZip(array7);
            }
            CreateChatRoomResponse createChatRoomResponse = CreateChatRoomResponse.ParseFrom(data);
            Debug.Print(createChatRoomResponse.ToString());
            return createChatRoomResponse;
        }

        public AddChatRoomMemberResponse AddChatroomMember(string userName, string chatroomName, List<string> memList)
        {
            var wxUserCache = GetWxUser(userName);
            byte b = 36;
            int num = 0;
            int num2 = 0;
            AddChatRoomMemberRequest addChatRoomMemberRequest = GoogleProto.CreateChatroomMemRequestEntity(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType, chatroomName, memList);
            Debug.Print(addChatRoomMemberRequest.ToString());
            byte[] array = addChatRoomMemberRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                 (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                  (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
              (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(addChatRoomMemberRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] array4 = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 185, 120, wxUserCache.CookieBuffer, adler);
            byte[] array5 = new byte[array4.Length + 16];
            int seq = new Random().Next(100);
            seq++;
            array5[0] = 0;
            array5[1] = 0;
            array5[2] = (byte)(array5.Length / 256);
            array5[3] = (byte)(array5.Length % 256);
            array5[4] = 0;
            array5[5] = 16;
            array5[6] = 0;
            array5[7] = 1;
            array5[8] = 0;
            array5[9] = 0;
            array5[10] = 0;
            array5[11] = 36;
            array5[12] = 0;
            array5[13] = 0;
            array5[14] = (byte)(seq / 256);
            array5[15] = (byte)(seq % 256);
            Array.Copy(array4, 0, array5, 16, array4.Length);
            var client = getClient(userName);
            NetworkStream stream = client.GetStream();
            stream.Write(array5, 0, array5.Length);
            byte b2;
            byte[] array6;
            do
            {
                array6 = new byte[16];
                int num3 = stream.Read(array6, 0, array6.Length);
                Debug.Print(string.Format("readed:{0}", num3));
                b2 = array6[11];
                int num4 = array6[2] * 256 + array6[3] - 16;
                array6 = new byte[num4];
                int num5;
                for (num3 = 0; num3 < num4; num3 += num5)
                {
                    num5 = stream.Read(array6, num3, array6.Length - num3);
                }
                Debug.Print(string.Format("toRead{0}, readed:{1}", num4, num3));
            }
            while (b2 != b);
            byte b3 = array6[1];
            b3 = (byte)(b3 >> 2);
            bool flag = (array6[1] & 3) == 1;
            array6 = array6.Take(array6.Length).Skip(b3).ToArray();
            byte[] array7 = DecryptPacket.DecryptReceivedPacket(array6, wxUserCache.BaseRequest.sessionKey);
            byte[] data = array7;
            if (flag)
            {
                data = DeflateCompression.DeflateUnZip(array7);
            }
            AddChatRoomMemberResponse addChatRoomMemberResponse = AddChatRoomMemberResponse.ParseFrom(data);
            Debug.Print(addChatRoomMemberResponse.ToString());
            return addChatRoomMemberResponse;
        }

        public GetChatRoomMemberDetailResponse GetChatroomMemberList(string userName, string chatroomName)
        {
            var wxUserCache = GetWxUser(userName);
            int num = 0;
            int num2 = 0;
            GetChatRoomMemberDetailRequest getChatRoomMemberDetailRequest = GoogleProto.CreateGetChatroomMemberListRequestEntity(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType, chatroomName);
            Debug.Print(getChatRoomMemberDetailRequest.ToString());
            byte[] array = getChatRoomMemberDetailRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                 (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                  (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
              (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(getChatRoomMemberDetailRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] data = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 0, 551, wxUserCache.CookieBuffer, adler);
            string address = "http://" + shortUrl + "/cgi-bin/micromsg-bin/getchatroommemberdetail";
            bool flag;
            byte[] array5;
            do
            {
                IL_022c:
                WebClient webClient = new WebClient();
                webClient.Headers.Add("User-Agent", "MicroMessenger Client");
                webClient.Headers.Add("Content-Type", "application/octet-stream");
                byte[] array4 = null;
                try
                {
                    array4 = webClient.UploadData(address, "POST", data);
                }
                catch (Exception)
                {
                    Thread.Sleep(3000);
                    goto IL_022c;
                }
                byte b = array4[1];
                b = (byte)(b >> 2);
                flag = ((array4[1] & 3) == 1);
                array4 = array4.Take(array4.Length).Skip(b).ToArray();
                array5 = DecryptPacket.DecryptReceivedPacket(array4, wxUserCache.BaseRequest.sessionKey);
            }
            while (array5 == null || array5.Count() == 0);
            byte[] data2 = array5;
            if (flag)
            {
                data2 = DeflateCompression.DeflateUnZip(array5);
            }
            GetChatRoomMemberDetailResponse getChatRoomMemberDetailResponse = GetChatRoomMemberDetailResponse.ParseFrom(data2);
            Debug.Print(getChatRoomMemberDetailResponse.ToString());
            return getChatRoomMemberDetailResponse;
        }

        public Geta8keyResponse GetOAuth(string userName, string reqUrl)
        {
            var wxUserCache = GetWxUser(userName);
            int num = 0;
            int num2 = 0;
            Geta8keyRequest geta8keyRequest = GoogleProto.CreateGetOAuthRequestEntity(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType, reqUrl);
            Debug.Print(geta8keyRequest.ToString());
            byte[] array = geta8keyRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                 (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                  (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
              (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(geta8keyRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] data = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 0, 233, wxUserCache.CookieBuffer, adler);
            string address = "http://" + shortUrl + "/cgi-bin/micromsg-bin/geta8key";
            bool flag;
            byte[] array5;
            do
            {
                IL_022c:
                WebClient webClient = new WebClient();
                webClient.Headers.Add("User-Agent", "MicroMessenger Client");
                webClient.Headers.Add("Content-Type", "application/octet-stream");
                byte[] array4 = null;
                try
                {
                    array4 = webClient.UploadData(address, "POST", data);
                }
                catch (Exception)
                {
                    Thread.Sleep(3000);
                    goto IL_022c;
                }
                byte b = array4[1];
                b = (byte)(b >> 2);
                flag = ((array4[1] & 3) == 1);
                array4 = array4.Take(array4.Length).Skip(b).ToArray();
                array5 = DecryptPacket.DecryptReceivedPacket(array4, wxUserCache.BaseRequest.sessionKey);
            }
            while (array5 == null || array5.Count() == 0);
            byte[] data2 = array5;
            if (flag)
            {
                data2 = DeflateCompression.DeflateUnZip(array5);
            }
            Geta8keyResponse geta8keyResponse = Geta8keyResponse.ParseFrom(data2);
            Debug.Print(geta8keyResponse.ToString());
            return geta8keyResponse;
        }

        public void HeartBeat(string userName)
        {
            byte b = 6;
            byte[] array = new byte[16];
            int seq = new Random().Next(100);
            seq++;
            array[0] = 0;
            array[1] = 0;
            array[2] = (byte)(array.Length / 256);
            array[3] = (byte)(array.Length % 256);
            array[4] = 0;
            array[5] = 16;
            array[6] = 0;
            array[7] = 1;
            array[8] = 0;
            array[9] = 0;
            array[10] = 0;
            array[11] = 6;
            array[12] = 0;
            array[13] = 0;
            array[14] = (byte)(seq / 256);
            array[15] = (byte)(seq % 256);
            var client = getClient(userName);
            NetworkStream stream = client.GetStream();
            stream.Write(array, 0, array.Length);
            byte b2;
            do
            {
                byte[] array2 = new byte[16];
                int num = stream.Read(array2, 0, array2.Length);
                Debug.Print(string.Format("readed:{0}", num));
                b2 = array2[11];
                int num2 = array2[2] * 256 + array2[3] - 16;
                array2 = new byte[num2];
                int num3;
                for (num = 0; num < num2; num += num3)
                {
                    num3 = stream.Read(array2, num, array2.Length - num);
                }
                Debug.Print(string.Format("toRead{0}, readed:{1}", num2, num));
            }
            while (b2 != b);
        }

        public UploadvoiceResponse SendVoiceMsg(string userName, string toUserName, string voicePath)
        {
            var wxUserCache = GetWxUser(userName);
            byte b = 19;
            int num = 0;
            int num2 = 0;
            byte[] voiceData = File.ReadAllBytes(voicePath);
            string msgID = string.Format("{0}{1}_{2}", toUserName, GetCurTime() % 100L, GetCurTime() / 1000L);
            UploadvoiceRequest uploadvoiceRequest = GoogleProto.CreateVoiceMsgRequestEntity(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType, toUserName, userName, voiceData, msgID);
            Debug.Print(uploadvoiceRequest.ToString());
            byte[] array = uploadvoiceRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                 (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                  (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
              (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(uploadvoiceRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] array4 = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 19, 127, wxUserCache.CookieBuffer, adler);
            byte[] array5 = new byte[array4.Length + 16];
            int seq = new Random().Next(100);
            seq++;
            array5[0] = 0;
            array5[1] = 0;
            array5[2] = (byte)(array5.Length / 256);
            array5[3] = (byte)(array5.Length % 256);
            array5[4] = 0;
            array5[5] = 16;
            array5[6] = 0;
            array5[7] = 1;
            array5[8] = 0;
            array5[9] = 0;
            array5[10] = 0;
            array5[11] = 19;
            array5[12] = 0;
            array5[13] = 0;
            array5[14] = (byte)(seq / 256);
            array5[15] = (byte)(seq % 256);
            Array.Copy(array4, 0, array5, 16, array4.Length);
            var client = getClient(userName);
            NetworkStream stream = client.GetStream();
            stream.Write(array5, 0, array5.Length);
            byte b2;
            byte[] array6;
            do
            {
                array6 = new byte[16];
                int num3 = stream.Read(array6, 0, array6.Length);
                Debug.Print(string.Format("readed:{0}", num3));
                b2 = array6[11];
                int num4 = array6[2] * 256 + array6[3] - 16;
                array6 = new byte[num4];
                int num5;
                for (num3 = 0; num3 < num4; num3 += num5)
                {
                    num5 = stream.Read(array6, num3, array6.Length - num3);
                }
                Debug.Print(string.Format("toRead{0}, readed:{1}", num4, num3));
            }
            while (b2 != b);
            byte b3 = array6[1];
            b3 = (byte)(b3 >> 2);
            bool flag = (array6[1] & 3) == 1;
            array6 = array6.Take(array6.Length).Skip(b3).ToArray();
            byte[] array7 = DecryptPacket.DecryptReceivedPacket(array6, wxUserCache.BaseRequest.sessionKey);
            byte[] data = array7;
            if (flag)
            {
                data = DeflateCompression.DeflateUnZip(array7);
            }
            UploadvoiceResponse uploadvoiceResponse = UploadvoiceResponse.ParseFrom(data);
            Debug.Print(uploadvoiceResponse.ToString());
            return uploadvoiceResponse;
        }

        public GetContactResponse GetContact(string userName, string peer)
        {
            var wxUserCache = GetWxUser(userName);
            int num = 0;
            int num2 = 0;
            GetContactRequest getContactRequest = GoogleProto.CreateGetContactEntity(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType, peer);
            Debug.Print(getContactRequest.ToString());
            byte[] array = getContactRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                 (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                  (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
              (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(getContactRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] data = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 0, 182, wxUserCache.CookieBuffer, adler);
            string address = "http://" + shortUrl + "/cgi-bin/micromsg-bin/getcontact";
            bool flag;
            byte[] array5;
            do
            {
                IL_022c:
                WebClient webClient = new WebClient();
                webClient.Headers.Add("User-Agent", "MicroMessenger Client");
                webClient.Headers.Add("Content-Type", "application/octet-stream");
                byte[] array4 = null;
                try
                {
                    array4 = webClient.UploadData(address, "POST", data);
                }
                catch (Exception)
                {
                    Thread.Sleep(3000);
                    goto IL_022c;
                }
                byte b = array4[1];
                b = (byte)(b >> 2);
                flag = ((array4[1] & 3) == 1);
                array4 = array4.Take(array4.Length).Skip(b).ToArray();
                array5 = DecryptPacket.DecryptReceivedPacket(array4, wxUserCache.BaseRequest.sessionKey);
            }
            while (array5 == null || array5.Count() == 0);
            byte[] data2 = array5;
            if (flag)
            {
                data2 = DeflateCompression.DeflateUnZip(array5);
            }
            GetContactResponse getContactResponse = GetContactResponse.ParseFrom(data2);
            Debug.Print(getContactResponse.ToString());
            return getContactResponse;
        }

        public ExtDeviceLoginConfirmGetResponse ExtDevLogin(string userName, string reqUrl)
        {
            var wxUserCache = GetWxUser(userName);
            int num = 0;
            int num2 = 0;
            ExtDeviceLoginConfirmGetRequest extDeviceLoginConfirmGetRequest = GoogleProto.CreateGetExtDevConfirmEntity(reqUrl);
            Debug.Print(extDeviceLoginConfirmGetRequest.ToString());
            byte[] array = extDeviceLoginConfirmGetRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                 (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                  (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
              (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(extDeviceLoginConfirmGetRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] data = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 0, 971, wxUserCache.CookieBuffer, adler);
            string address = "http://" + shortUrl + "/cgi-bin/micromsg-bin/extdeviceloginconfirmget";
            bool flag;
            byte[] array5;
            do
            {
                IL_020a:
                WebClient webClient = new WebClient();
                webClient.Headers.Add("User-Agent", "MicroMessenger Client");
                webClient.Headers.Add("Content-Type", "application/octet-stream");
                byte[] array4 = null;
                try
                {
                    array4 = webClient.UploadData(address, "POST", data);
                }
                catch (Exception)
                {
                    Thread.Sleep(3000);
                    goto IL_020a;
                }
                byte b = array4[1];
                b = (byte)(b >> 2);
                flag = ((array4[1] & 3) == 1);
                array4 = array4.Take(array4.Length).Skip(b).ToArray();
                array5 = DecryptPacket.DecryptReceivedPacket(array4, wxUserCache.BaseRequest.sessionKey);
            }
            while (array5 == null || array5.Count() == 0);
            byte[] data2 = array5;
            if (flag)
            {
                data2 = DeflateCompression.DeflateUnZip(array5);
            }
            ExtDeviceLoginConfirmGetResponse extDeviceLoginConfirmGetResponse = ExtDeviceLoginConfirmGetResponse.ParseFrom(data2);
            Debug.Print(extDeviceLoginConfirmGetResponse.ToString());
            return extDeviceLoginConfirmGetResponse;
        }

        public ExtDeviceLoginConfirmOKResponse ExtDevLoginOK(string userName, string reqUrl)
        {
            var wxUserCache = GetWxUser(userName);
            int num = 0;
            int num2 = 0;
            ExtDeviceLoginConfirmOKRequest extDeviceLoginConfirmOKRequest = GoogleProto.CreateGetExtDevConfirmOKEntity(reqUrl);
            Debug.Print(extDeviceLoginConfirmOKRequest.ToString());
            byte[] array = extDeviceLoginConfirmOKRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                 (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                  (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
              (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(extDeviceLoginConfirmOKRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] data = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 0, 972, wxUserCache.CookieBuffer, adler);
            string address = "http://" + shortUrl + "/cgi-bin/micromsg-bin/extdeviceloginconfirmok";
            bool flag;
            byte[] array5;
            do
            {
                IL_020a:
                WebClient webClient = new WebClient();
                webClient.Headers.Add("User-Agent", "MicroMessenger Client");
                webClient.Headers.Add("Content-Type", "application/octet-stream");
                byte[] array4 = null;
                try
                {
                    array4 = webClient.UploadData(address, "POST", data);
                }
                catch (Exception)
                {
                    Thread.Sleep(3000);
                    goto IL_020a;
                }
                byte b = array4[1];
                b = (byte)(b >> 2);
                flag = ((array4[1] & 3) == 1);
                array4 = array4.Take(array4.Length).Skip(b).ToArray();
                array5 = DecryptPacket.DecryptReceivedPacket(array4, wxUserCache.BaseRequest.sessionKey);
            }
            while (array5 == null || array5.Count() == 0);
            byte[] data2 = array5;
            if (flag)
            {
                data2 = DeflateCompression.DeflateUnZip(array5);
            }
            ExtDeviceLoginConfirmOKResponse extDeviceLoginConfirmOKResponse = ExtDeviceLoginConfirmOKResponse.ParseFrom(data2);
            Debug.Print(extDeviceLoginConfirmOKResponse.ToString());
            return extDeviceLoginConfirmOKResponse;
        }

        public LogOutWebWxResponse LogoutWeb(string userName)
        {
            var wxUserCache = GetWxUser(userName);
            int num = 0;
            int num2 = 0;
            LogOutWebWxRequest logOutWebWxRequest = GoogleProto.CreateLogoutWebEntity(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType);
            Debug.Print(logOutWebWxRequest.ToString());
            byte[] array = logOutWebWxRequest.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                 (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                  (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
              (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(logOutWebWxRequest.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] data = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 0, 281, wxUserCache.CookieBuffer, adler);
            string address = "http://" + shortUrl + "/cgi-bin/micromsg-bin/logoutwebwx";
            bool flag;
            byte[] array5;
            do
            {
                IL_022b:
                WebClient webClient = new WebClient();
                webClient.Headers.Add("User-Agent", "MicroMessenger Client");
                webClient.Headers.Add("Content-Type", "application/octet-stream");
                byte[] array4 = null;
                try
                {
                    array4 = webClient.UploadData(address, "POST", data);
                }
                catch (Exception)
                {
                    Thread.Sleep(3000);
                    goto IL_022b;
                }
                byte b = array4[1];
                b = (byte)(b >> 2);
                flag = ((array4[1] & 3) == 1);
                array4 = array4.Take(array4.Length).Skip(b).ToArray();
                array5 = DecryptPacket.DecryptReceivedPacket(array4, wxUserCache.BaseRequest.sessionKey);
            }
            while (array5 == null || array5.Count() == 0);
            byte[] data2 = array5;
            if (flag)
            {
                data2 = DeflateCompression.DeflateUnZip(array5);
            }
            LogOutWebWxResponse logOutWebWxResponse = LogOutWebWxResponse.ParseFrom(data2);
            Debug.Print(logOutWebWxResponse.ToString());
            return logOutWebWxResponse;
        }

        public UploadMContactResponse UploadMContact(string userName, List<string> contacts)
        {
            var wxUserCache = GetWxUser(userName);
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            UploadMContact uploadMContact = GoogleProto.UploadMContact(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType, userName, contacts, userName);
            Debug.Print(uploadMContact.ToString());
            byte[] array = uploadMContact.ToByteArray();
            num2 = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                 (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                  (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
              (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num2 & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num2 & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num2 & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num2 & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num2);
            byte[] array3 = DeflateCompression.DeflateZip(uploadMContact.ToByteArray());
            num3 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] data = ConstructPacket.CommonRequestPacket(num2, num3, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 133, 133, wxUserCache.CookieBuffer, adler);
            string address = "http://" + shortUrl + "/cgi-bin/micromsg-bin/uploadmcontact";
            bool flag;
            byte[] array5;
            do
            {
                IL_0259:
                WebClient webClient = new WebClient();
                webClient.Headers.Add("User-Agent", "MicroMessenger Client");
                webClient.Headers.Add("Content-Type", "application/octet-stream");
                byte[] array4 = null;
                try
                {
                    array4 = webClient.UploadData(address, "POST", data);
                }
                catch (Exception)
                {
                    Thread.Sleep(3000);
                    if (++num >= 3)
                    {
                        return null;
                    }
                    goto IL_0259;
                }
                byte b = array4[1];
                b = (byte)(b >> 2);
                flag = ((array4[1] & 3) == 1);
                array4 = array4.Take(array4.Length).Skip(b).ToArray();
                array5 = DecryptPacket.DecryptReceivedPacket(array4, wxUserCache.BaseRequest.sessionKey);
            }
            while (array5 == null || array5.Count() == 0);
            byte[] data2 = array5;
            if (flag)
            {
                data2 = DeflateCompression.DeflateUnZip(array5);
            }
            UploadMContactResponse uploadMContactResponse = UploadMContactResponse.ParseFrom(data2);
            Debug.Print(uploadMContactResponse.ToString());
            return uploadMContactResponse;
        }

        public GetMFriendResponse GetMFriend(string userName)
        {
            var wxUserCache = GetWxUser(userName);
            int num = 0;
            int num2 = 0;
            GetMFriendRequest mFriend = GoogleProto.GetMFriend(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType);
            Debug.Print(mFriend.ToString());
            byte[] array = mFriend.ToByteArray();
            num = array.Length;
            byte[] array2 = new byte[4]
            {
                (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
                 (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
                  (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
              (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
            };
            byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
            array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
            array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
            array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
            array2[3] = (byte)(num & 0xFF & 0xFF);
            second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
            uint adler = Adler32(1u, second, second.Length);
            adler = Adler32(adler, array, num);
            byte[] array3 = DeflateCompression.DeflateZip(mFriend.ToByteArray());
            num2 = array3.Length;
            byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
            byte[] data = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 32, 142, wxUserCache.CookieBuffer, adler);
            string address = "http://" + shortUrl + "/cgi-bin/micromsg-bin/getmfriend";
            bool flag;
            byte[] array5;
            do
            {
                IL_022c:
                WebClient webClient = new WebClient();
                webClient.Headers.Add("User-Agent", "MicroMessenger Client");
                webClient.Headers.Add("Content-Type", "application/octet-stream");
                byte[] array4 = null;
                try
                {
                    array4 = webClient.UploadData(address, "POST", data);
                }
                catch (Exception)
                {
                    Thread.Sleep(3000);
                    goto IL_022c;
                }
                byte b = array4[1];
                b = (byte)(b >> 2);
                flag = ((array4[1] & 3) == 1);
                array4 = array4.Take(array4.Length).Skip(b).ToArray();
                array5 = DecryptPacket.DecryptReceivedPacket(array4, wxUserCache.BaseRequest.sessionKey);
            }
            while (array5 == null || array5.Count() == 0);
            byte[] data2 = array5;
            if (flag)
            {
                data2 = DeflateCompression.DeflateUnZip(array5);
            }
            GetMFriendResponse getMFriendResponse = GetMFriendResponse.ParseFrom(data2);
            Debug.Print(getMFriendResponse.ToString());
            return getMFriendResponse;
        }

        //public GetSafetyInfoRespsonse LoginDevice(string userName)
        //{
        //    var wxUserCache = GetWxUser(userName);
        //    int num = 0;
        //    int num2 = 0;
        //    GetSafetyInfoRequest safetyInfo = GoogleProto.GetSafetyInfo(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType);
        //    Debug.Print(safetyInfo.ToString());
        //    byte[] array = safetyInfo.ToByteArray();
        //    num = array.Length;
        //    byte[] array2 = new byte[4]
        //    {
        //        (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
        //         (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
        //          (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
        //      (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
        //    };
        //    byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
        //    array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
        //    array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
        //    array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
        //    array2[3] = (byte)(num & 0xFF & 0xFF);
        //    second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
        //    uint adler = Adler32(1u, second, second.Length);
        //    adler = Adler32(adler, array, num);
        //    byte[] array3 = DeflateCompression.DeflateZip(safetyInfo.ToByteArray());
        //    num2 = array3.Length;
        //    byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
        //    byte[] data = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 32, 850, wxUserCache.CookieBuffer, adler);
        //    string address = "http://" + shortUrl + "/cgi-bin/micromsg-bin/getsafetyinfo";
        //    bool flag;
        //    byte[] array5;
        //    do
        //    {
        //        IL_022c:
        //        WebClient webClient = new WebClient();
        //        webClient.Headers.Add("User-Agent", "MicroMessenger Client");
        //        webClient.Headers.Add("Content-Type", "application/octet-stream");
        //        byte[] array4 = null;
        //        try
        //        {
        //            array4 = webClient.UploadData(address, "POST", data);
        //        }
        //        catch (Exception)
        //        {
        //            Thread.Sleep(3000);
        //            goto IL_022c;
        //        }
        //        byte b = array4[1];
        //        b = (byte)(b >> 2);
        //        flag = ((array4[1] & 3) == 1);
        //        array4 = array4.Take(array4.Length).Skip(b).ToArray();
        //        array5 = DecryptPacket.DecryptReceivedPacket(array4, wxUserCache.BaseRequest.sessionKey);
        //    }
        //    while (array5 == null || array5.Count() == 0);
        //    byte[] data2 = array5;
        //    if (flag)
        //    {
        //        data2 = DeflateCompression.DeflateUnZip(array5);
        //    }
        //    GetSafetyInfoRespsonse getSafetyInfoRespsonse = GetSafetyInfoRespsonse.ParseFrom(data2);
        //    Debug.Print(getSafetyInfoRespsonse.ToString());
        //    return getSafetyInfoRespsonse;
        //}

        //public MmsnsuserpageResponse UserPage(string userName, ulong maxid)
        //{
        //    var wxUserCache = GetWxUser(userName);
        //    int num = 0;
        //    int num2 = 0;
        //    MmsnsuserpageRequest mmsnsuserpageRequest = GoogleProto.CreateUserPage(Encoding.Default.GetString(wxUserCache.BaseRequest.sessionKey), (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), wxUserCache.BaseRequest.osType, userName, maxid);
        //    Debug.Print(mmsnsuserpageRequest.ToString());
        //    byte[] array = mmsnsuserpageRequest.ToByteArray();
        //    num = array.Length;
        //    byte[] array2 = new byte[4]
        //    {
        //        (byte)(((uint)((int)(uint)wxUserCache.BaseRequest.uin & -16777216) >> 24) & 0xFF),
        //         (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF0000) >> 16) & 0xFF),
        //          (byte)((((uint)wxUserCache.BaseRequest.uin & 0xFF00) >> 8) & 0xFF),
        //      (byte)((uint)wxUserCache.BaseRequest.uin & 0xFF & 0xFF)
        //    };
        //    byte[] second = Fun.MD5(array2.Concat(wxUserCache.AesKey).ToArray());
        //    array2[0] = (byte)(((num & 0xFF000000) >> 24) & 0xFF);
        //    array2[1] = (byte)(((num & 0xFF0000) >> 16) & 0xFF);
        //    array2[2] = (byte)(((num & 0xFF00) >> 8) & 0xFF);
        //    array2[3] = (byte)(num & 0xFF & 0xFF);
        //    second = Fun.MD5(array2.Concat(wxUserCache.AesKey).Concat(second).ToArray());
        //    uint adler = Adler32(1u, second, second.Length);
        //    adler = Adler32(adler, array, num);
        //    byte[] array3 = DeflateCompression.DeflateZip(mmsnsuserpageRequest.ToByteArray());
        //    num2 = array3.Length;
        //    byte[] aesDataPacket = DecryptPacket.AESEncryptorData(array3, wxUserCache.BaseRequest.sessionKey);
        //    byte[] data = ConstructPacket.CommonRequestPacket(num, num2, aesDataPacket, (uint)wxUserCache.BaseRequest.uin, Encoding.Default.GetString(wxUserCache.DeviceId), 32, 212, wxUserCache.CookieBuffer, adler);
        //    string address = "http://" + shortUrl + "/cgi-bin/micromsg-bin/mmsnsuserpage";
        //    bool flag;
        //    byte[] array5;
        //    do
        //    {
        //        IL_0233:
        //        WebClient webClient = new WebClient();
        //        webClient.Headers.Add("User-Agent", "MicroMessenger Client");
        //        webClient.Headers.Add("Content-Type", "application/octet-stream");
        //        byte[] array4 = null;
        //        try
        //        {
        //            array4 = webClient.UploadData(address, "POST", data);
        //        }
        //        catch (Exception)
        //        {
        //            Thread.Sleep(3000);
        //            goto IL_0233;
        //        }
        //        byte b = array4[1];
        //        b = (byte)(b >> 2);
        //        flag = ((array4[1] & 3) == 1);
        //        array4 = array4.Take(array4.Length).Skip(b).ToArray();
        //        array5 = DecryptPacket.DecryptReceivedPacket(array4, wxUserCache.BaseRequest.sessionKey);
        //    }
        //    while (array5 == null || array5.Count() == 0);
        //    byte[] data2 = array5;
        //    if (flag)
        //    {
        //        data2 = DeflateCompression.DeflateUnZip(array5);
        //    }
        //    MmsnsuserpageResponse mmsnsuserpageResponse = MmsnsuserpageResponse.ParseFrom(data2);
        //    Debug.Print(mmsnsuserpageResponse.ToString());
        //    return mmsnsuserpageResponse;
        //}

        private CustomerInfoCache GetWxUser(string userName)
        {

            var userCache = this._redisCache.HashGet<CustomerInfoCache>(ConstCacheKey.GetWxIdKey(), userName);
            if (userCache == null)
            {
                throw new Exception($"{userName}缓存不存在");
            }
            return userCache;

        }
    }
}
