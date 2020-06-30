using Google.ProtocolBuffers;
using mm.command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;

namespace Wechat.Protocol.Andriod
{
	public class GoogleProto
	{
		private static DateTime dateTime_0 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		private static long GetCurTime()
		{
			return (long)(DateTime.UtcNow - dateTime_0).TotalMilliseconds;
		}

		public static BindopMobileForRegRequest CreateMobileRegPacket(BaseRequest baseRequest, int opCode, string mobile, string verifyCode, byte[] randomEncryKey, string devicetype, string clientid, string regSession)
		{
			BindopMobileForRegRequest.Builder builder = new BindopMobileForRegRequest.Builder();
			builder.SetBase(baseRequest);
			builder.SetOpcode(opCode).SetMobile(mobile).SetVerifycode(verifyCode)
				.SetDialFlag(0)
				.SetDialLang("");
			builder.SetSafeDeviceName("Android设备");
			builder.SetSafeDeviceType(devicetype);
			SKBuiltinBuffer_t.Builder builder2 = new SKBuiltinBuffer_t.Builder();
			builder2.SetILen(randomEncryKey.Length);
			builder2.SetBuffer(ByteString.CopyFrom(randomEncryKey));
			builder.SetRandomEncryKey(builder2);
			builder.SetForceReg(0);
			builder.SetInputMobileRetrys(0);
			builder.SetAdjustRet(0);
			if (opCode == 15)
			{
				builder.SetMobileCheckType(0u);
			}
			else
			{
				builder.SetMobileCheckType(0u);
			}
			builder.SetClientSeqId(clientid);
			if (opCode != 12)
			{
				builder.SetRegSessionID(regSession);
			}
			return builder.Build();
		}

		internal static UploadMContact UploadMContact(string sessionKey, uint uin, string deviceID, string OSType, string mobile, List<string> contacts, string userName)
		{
			BaseRequest @base = CreateBaseRequestEntity(deviceID, sessionKey, uin, OSType);
			UploadMContact.Builder builder = new UploadMContact.Builder();
			builder.SetBase(@base);
			builder.SetMobile(mobile);
			builder.SetUserName(userName);
			builder.SetOpcode(1);
			builder.SetMobileListSize(contacts.Count);
			foreach (string contact in contacts)
			{
				SKBuiltinString_t.Builder builder2 = new SKBuiltinString_t.Builder();
				builder2.SetString(contact);
				builder.AddMobiles(builder2);
			}
			builder.SetEmailListSize(0);
			return builder.Build();
		}

		public static GetMFriendRequest GetMFriend(string sessionKey, uint uin, string deviceID, string OSType)
		{
			BaseRequest @base = CreateBaseRequestEntity(deviceID, sessionKey, uin, OSType);
			GetMFriendRequest.Builder builder = new GetMFriendRequest.Builder();
			builder.SetBase(@base);
			builder.SetOpType(0);
			builder.SetMD5("");
			return builder.Build();
		}

		public static ThrowBottleRequest CreateThrowBottleRequestEntity(string sessionKey, uint uin, string deviceID, string OSType, string text)
		{
			BaseRequest @base = CreateBaseRequestEntity(deviceID, sessionKey, uin, OSType);
			ThrowBottleRequest.Builder builder = new ThrowBottleRequest.Builder();
			builder.SetBase(@base);
			builder.SetMsgType(1);
			builder.SetBottleType(0);
			SKBuiltinBuffer_t.Builder builder2 = new SKBuiltinBuffer_t.Builder();
			byte[] bytes = Encoding.GetEncoding("utf-8").GetBytes(text);
			builder2.SetILen(bytes.Length);
			builder2.SetBuffer(ByteString.CopyFrom(bytes));
			builder.SetContent(builder2.Build());
			builder.SetStartPos(0);
			builder.SetTotalLen(bytes.Length);
			builder.SetClientID(string.Format("127c322ff65c763{0}", new Random().Next(10000, 99999)));
			builder.SetVoiceLength(0);
			return builder.Build();
		}

		public static BindOpMobileRequest CreateBindMobileRequestEntity(string sessionKey, uint uin, string deviceID, string OSType, string mobile, string deviceName, string deviceType)
		{
			BaseRequest @base = CreateBaseRequestEntity(deviceID, sessionKey, uin, OSType);
			BindOpMobileRequest.Builder builder = new BindOpMobileRequest.Builder();
			builder.SetBase(@base);
			builder.SetMobile(mobile);
			builder.SetOpcode(3);
			builder.SetVerifycode("");
			builder.SetDialFlag(0);
			builder.SetDialLang("");
			builder.SetForceReg(0);
			builder.SetSafeDeviceName(deviceName);
			builder.SetSafeDeviceType(deviceType);
			return builder.Build();
		}

		public static BindQQRequest CreateBindMobileRequestEntity(string sessionKey, uint uin, string deviceID, string OSType, string qq, string pass, string deviceName, string deviceType)
		{
			BaseRequest @base = CreateBaseRequestEntity(deviceID, sessionKey, uin, OSType);
			BindQQRequest.Builder builder = new BindQQRequest.Builder();
			builder.SetBase(@base);
			builder.SetQQ((uint)long.Parse(qq));
			string text = FormsAuthentication.HashPasswordForStoringInConfigFile(pass, "MD5").ToLower();
			builder.SetPwd(text);
			builder.SetPwd2(text);
			builder.SetImgSid("");
			builder.SetImgCode("");
			builder.SetOPCode(1);
			builder.SetImgEncryptKey(new SKBuiltinString_t.Builder().SetString(""));
			SKBuiltinBuffer_t.Builder builder2 = new SKBuiltinBuffer_t.Builder();
			builder2.SetILen(0);
			builder2.SetBuffer(ByteString.CopyFrom(new byte[0]));
			builder.SetKSid(builder2);
			builder.SetSafeDeviceName(deviceName);
			builder.SetSafeDeviceType(deviceType);
			return builder.Build();
		}

		public static BindEmailRequest BindEmailEntity(string sessionKey, uint uin, string deviceID, string OSType, string email)
		{
			BaseRequest @base = CreateBaseRequestEntity(deviceID, sessionKey, uin, OSType);
			BindEmailRequest.Builder builder = new BindEmailRequest.Builder();
			builder.SetBase(@base);
			builder.SetOpCode(1);
			builder.SetEmail(email);
			return builder.Build();
		}

		public static BaseRequest CreateBaseRequestEntity(string deviceID, string osType)
		{
			return CreateBaseRequestEntity(deviceID, osType, 1);
		}

		public static BaseRequest CreateBaseRequestEntity(string deviceID, string osType, int scene)
		{
			BaseRequest.Builder builder = new BaseRequest.Builder();
			byte[] bytes = new byte[0];
			builder.SetSessionKey(ByteString.CopyFrom(bytes));
			builder.SetUin(0u);
			byte[] array = new byte[16];
			array = Encoding.Default.GetBytes(deviceID + "\0");
			builder.SetDeviceID(ByteString.CopyFrom(array));
			builder.SetClientVersion(637929271);
			builder.SetDeviceType(ByteString.CopyFrom(osType, Encoding.Default));
			builder.SetScene(scene);
			return builder.Build();
		}

		public static BaseRequest CreateBaseRequestEntity(string deviceID, string sessionKey, uint uIn, string osType)
		{
			return CreateBaseRequestEntity(deviceID, sessionKey, uIn, osType, 0);
		}

		public static BaseRequest CreateBaseRequestEntity(string deviceID, string sessionKey, uint uIn, string osType, int scene)
		{
			BaseRequest.Builder builder = new BaseRequest.Builder();
			builder.SetSessionKey(ByteString.CopyFrom(sessionKey, Encoding.Default));
			builder.SetUin(uIn);
			byte[] array = new byte[16];
			array = Encoding.Default.GetBytes(deviceID + "\0");
			builder.SetDeviceID(ByteString.CopyFrom(array));
			builder.SetClientVersion(637929271);
			builder.SetDeviceType(ByteString.CopyFrom(osType, Encoding.Default));
			builder.SetScene(scene);
			return builder.Build();
		}

		public static AuthRequest CreateAuthRequestEntity(BaseRequest br, string wxAccount, string wxPwd, string imei, string MANUFACTURER, string MODEL, string RELEASE, string INCREMENTAL, string DISPLAY, string OSType, byte[] randomEncryKey)
		{
			AuthRequest.Builder builder = new AuthRequest.Builder();
			builder.SetBase(br);
			builder.SetUserName(new SKBuiltinString_t.Builder().SetString(wxAccount).Build());
			string text = FormsAuthentication.HashPasswordForStoringInConfigFile(wxPwd, "MD5");
			builder.SetPwd(new SKBuiltinString_t.Builder().SetString(text).Build());
			builder.SetImgSid(new SKBuiltinString_t.Builder().SetString("").Build());
			builder.SetImgCode(new SKBuiltinString_t.Builder().SetString("").Build());
			builder.SetPwd2(text);
			builder.SetBuiltinIPSeq(0);
			builder.SetExtPwd(text);
			builder.SetExtPwd2(text);
			builder.SetTimeZone("8.00");
			builder.SetLanguage("en_US");
			builder.SetIMEI(imei);
			builder.SetChannel(0);
			builder.SetImgEncryptKey(new SKBuiltinString_t.Builder().SetString("").Build());
			builder.SetKSid(new SKBuiltinBuffer_t.Builder().SetILen(0).SetBuffer(ByteString.CopyFrom("", Encoding.Default)));
			builder.SetDeviceBrand(MANUFACTURER);
			builder.SetDeviceModel(MODEL);
			builder.SetOSType(OSType);
			builder.SetDeviceType("<deviceinfo><MANUFACTURER name=\"" + MANUFACTURER + "\"><MODEL name=\"" + MODEL + "\"><VERSION_RELEASE name=\"" + RELEASE + "\"><VERSION_INCREMENTAL name=\"" + INCREMENTAL + "\"><DISPLAY name=\"" + DISPLAY + "\"></DISPLAY></VERSION_INCREMENTAL></VERSION_RELEASE></MODEL></MANUFACTURER></deviceinfo>");
			builder.SetAuthTicket("");
			builder.SetSignature("18c867f0717aa67b2ab7347505ba07ed");
			SKBuiltinBuffer_t.Builder builder2 = new SKBuiltinBuffer_t.Builder();
			builder2.SetILen(16);
			builder2.SetBuffer(ByteString.CopyFrom(randomEncryKey));
			SKBuiltinBuffer_t randomEncryKey2 = builder2.Build();
			builder.SetRandomEncryKey(randomEncryKey2);
			return builder.Build();
		}

		public static InitKey CreateInitKeyEntity(byte[] randomEncryKey, ECDHKey cliPubECDHKey, string string_0, string wxPwd)
		{
			InitKey.Builder builder = new InitKey.Builder();
			SKBuiltinBuffer_t.Builder builder2 = new SKBuiltinBuffer_t.Builder();
			builder2.SetILen(16);
			builder2.SetBuffer(ByteString.CopyFrom(randomEncryKey));
			builder.SetRandomEncryKey(builder2);
			builder.SetCliPubECDHKey(cliPubECDHKey);
			builder.SetAccount(string_0);
			string text = FormsAuthentication.HashPasswordForStoringInConfigFile(wxPwd, "MD5");
			builder.SetPwd(text);
			builder.SetPwd2(text);
			return builder.Build();
		}

		public static AutoAuthRsaReqData CreateAutoAuthKeyEntity(byte[] randomEncryKey, ECDHKey cliPubECDHKey)
		{
			AutoAuthRsaReqData.Builder builder = new AutoAuthRsaReqData.Builder();
			SKBuiltinBuffer_t.Builder builder2 = new SKBuiltinBuffer_t.Builder();
			builder2.SetILen(16);
			builder2.SetBuffer(ByteString.CopyFrom(randomEncryKey));
			builder.SetAesEncryptKey(builder2);
			builder.SetCliPubECDHKey(cliPubECDHKey);
			return builder.Build();
		}

		public static ManualAuthRequest CreateManualAuthRequestEntity(BaseRequest br, string imei, string MANUFACTURER, string MODEL, string OSType, string fingerprint, string clientID, string abi, string deviceType)
		{
			ManualAuthRequest.Builder builder = new ManualAuthRequest.Builder();
			builder.SetBase(br);
			builder.SetIMEI(imei);
			builder.SetSoftType(fingerprint);
			builder.SetBuiltinIpseq(0u);
			builder.SetClientSeqId(clientID);
			builder.SetSignature("18c867f0717aa67b2ab7347505ba07ed");
			builder.SetDeviceName(MANUFACTURER + "-" + MODEL);
			builder.SetDeviceType(deviceType);
			builder.SetLanguage("zh_CN");
			builder.SetTimeZone("8.00");
			builder.SetChannel(0);
			builder.SetTimeStamp(0u);
			builder.SetDeviceBrand(MANUFACTURER);
			builder.SetDeviceModel(MODEL + abi);
			builder.SetOSType(OSType);
			builder.SetCountryCode("cn");
			builder.SetInputType(1);
			return builder.Build();
		}

		public static AutoAuthRequest CreateAutoAuthRequestEntity(BaseRequest br, string imei, string MANUFACTURER, string MODEL, string RELEASE, string INCREMENTAL, string DISPLAY, string OSType, SKBuiltinBuffer_t autoauthkey)
		{
			AutoAuthRequest.Builder builder = new AutoAuthRequest.Builder();
			builder.SetBase(br);
			builder.SetAutoAuthKey(autoauthkey);
			builder.SetIMEI(imei);
			builder.SetSoftType("");
			builder.SetBuiltinIpseq(0u);
			builder.SetClientSeqId("");
			builder.SetSignature("18c867f0717aa67b2ab7347505ba07ed");
			builder.SetDeviceName("Xiaomi-MI 2S");
			builder.SetDeviceType("<deviceinfo><MANUFACTURER name=\"" + MANUFACTURER + "\"><MODEL name=\"" + MODEL + "\"><VERSION_RELEASE name=\"" + RELEASE + "\"><VERSION_INCREMENTAL name=\"" + INCREMENTAL + "\"><DISPLAY name=\"" + DISPLAY + "\"></DISPLAY></VERSION_INCREMENTAL></VERSION_RELEASE></MODEL></MANUFACTURER></deviceinfo>");
			builder.SetLanguage("zh_CN");
			builder.SetTimeZone("8.00");
			return builder.Build();
		}

		internal static NewVerifyPasswdRequest NewVerifyPasswd(string sessionKey, uint uin, string deviceID, string OSType, string pass)
		{
			BaseRequest @base = CreateBaseRequestEntity(deviceID, sessionKey, uin, OSType);
			NewVerifyPasswdRequest.Builder builder = new NewVerifyPasswdRequest.Builder();
			builder.SetBase(@base);
			string text = Fun.CumputeMD5(pass);
			builder.SetOpCode(1);
			builder.SetPwd1(text);
			builder.SetPwd2(text);
			return builder.Build();
		}

		public static NewSetPasswdRequest CreateNewSetPassRequestEntity(string sessionKey, uint uin, string deviceID, string OSType, string newPass, string ticket, string authkey)
		{
			BaseRequest @base = CreateBaseRequestEntity(deviceID, sessionKey, uin, OSType);
			NewSetPasswdRequest.Builder builder = new NewSetPasswdRequest.Builder();
			builder.SetBase(@base);
			builder.SetPassword(newPass);
			builder.SetTicket(ticket);
			SKBuiltinBuffer_t.Builder builder2 = new SKBuiltinBuffer_t.Builder();
			byte[] array = Convert.FromBase64String(authkey);
			builder2.SetILen(array.Length);
			builder2.SetBuffer(ByteString.CopyFrom(array));
			builder.SetAutoAuthKey(builder2.Build());
			return builder.Build();
		}

		public static AuthRequest CreateAuthRequestEntity(BaseRequest br, string wxAccount, string wxPwd, string imei, string deviceBrand, string deviceModel, byte[] randomEncryKey, string imgSID, string code, string imgKey)
		{
			AuthRequest.Builder builder = new AuthRequest.Builder();
			builder.SetBase(br);
			builder.SetUserName(new SKBuiltinString_t.Builder().SetString(wxAccount).Build());
			string text = FormsAuthentication.HashPasswordForStoringInConfigFile(wxPwd, "MD5");
			builder.SetPwd(new SKBuiltinString_t.Builder().SetString(text).Build());
			builder.SetImgSid(new SKBuiltinString_t.Builder().SetString(imgSID).Build());
			builder.SetImgCode(new SKBuiltinString_t.Builder().SetString(code).Build());
			builder.SetPwd2(text);
			builder.SetBuiltinIPSeq(0);
			builder.SetExtPwd(text);
			builder.SetExtPwd2(text);
			builder.SetTimeZone("8.00");
			builder.SetLanguage("zh_CN");
			builder.SetIMEI(imei);
			builder.SetChannel(0);
			builder.SetImgEncryptKey(new SKBuiltinString_t.Builder().SetString(imgKey).Build());
			builder.SetKSid(new SKBuiltinBuffer_t.Builder().SetILen(0).SetBuffer(ByteString.CopyFrom("", Encoding.Default)));
			builder.SetDeviceBrand(deviceBrand);
			builder.SetDeviceModel(deviceModel);
			builder.SetOSType("android-10");
			builder.SetDeviceType("<deviceinfo><MANUFACTURER name=\"unknown\"><MODEL name=\"sdk\"><VERSION_RELEASE name=\"2.3.3\"><VERSION_INCREMENTAL name=\"101070\"><DISPLAY name=\"sdk-eng 2.3.3 GRI34 101070 test-keys\"></DISPLAY></VERSION_INCREMENTAL></VERSION_RELEASE></MODEL></MANUFACTURER></deviceinfo>");
			builder.SetAuthTicket("");
			builder.SetSignature("e89b158e4bcf988ebd09eb83f5378e87");
			SKBuiltinBuffer_t.Builder builder2 = new SKBuiltinBuffer_t.Builder();
			builder2.SetILen(16);
			builder2.SetBuffer(ByteString.CopyFrom(randomEncryKey));
			SKBuiltinBuffer_t randomEncryKey2 = builder2.Build();
			builder.SetRandomEncryKey(randomEncryKey2);
			return builder.Build();
		}

		public static NewRegRequest CreateNewRegRequestEntity(BaseRequest br, string wxAccount, string wxPwd, string nickName, string ticket, byte[] randomEncryKey, ECDHKey cliPubECDHKey, string clientid, string androidid, string fingerprint, string mac, string regID)
		{
			NewRegRequest.Builder builder = new NewRegRequest.Builder();
			builder.SetBase(br);
			builder.SetUserName("");
			string pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(wxPwd, "MD5");
			builder.SetPwd(pwd);
			builder.SetNickName(nickName);
			builder.SetBindUin(0u);
			builder.SetBindEmail("");
			builder.SetBindMobile(wxAccount);
			builder.SetTicket(ticket);
			builder.SetBuiltinIPSeq(0);
			builder.SetDLSrc(0);
			builder.SetRegMode(1);
			builder.SetTimeZone("8.00");
			builder.SetLanguage("zh_CN");
			builder.SetForceReg(1);
			builder.SetRealCountry("cn");
			SKBuiltinBuffer_t.Builder builder2 = new SKBuiltinBuffer_t.Builder();
			builder2.SetILen(16);
			builder2.SetBuffer(ByteString.CopyFrom(randomEncryKey));
			SKBuiltinBuffer_t randomEncryKey2 = builder2.Build();
			builder.SetRandomEncryKey(randomEncryKey2);
			builder.SetAlias("");
			builder.SetVerifyContent("");
			builder.SetVerifySignature("");
			builder.SetHasHeadImg(0u);
			builder.SetSuggestRet(0u);
			builder.SetClientSeqId(clientid);
			builder.SetCliPubEcdhkey(cliPubECDHKey);
			builder.SetGoogleAid("");
			builder.SetMobileCheckType(0u);
			builder.SetBioSigCheckType(0u);
			builder.SetRegSessionId(regID);
			builder.SetAndroidInstallRef("");
			builder.SetAndroidId(androidid);
			builder.SetClientFingerprint(fingerprint);
			builder.SetMacAddr(mac);
			return builder.Build();
		}

		public static NewInitRequest CreateNewInitRequestEntity(uint uin, string sessionKey, string userName, string deviceID, string OSType, byte[] init, byte[] max)
		{
			BaseRequest @base = CreateBaseRequestEntity(deviceID, sessionKey, uin, OSType, 3);
			NewInitRequest.Builder builder = new NewInitRequest.Builder();
			builder.SetBase(@base);
			builder.SetUserName(userName);
			builder.SetLanguage("zh_CN");
			SKBuiltinBuffer_t.Builder builder2 = new SKBuiltinBuffer_t.Builder();
			if (init == null)
			{
				builder2.SetILen(0);
				builder2.SetBuffer(ByteString.CopyFrom(new byte[0]));
			}
			else
			{
				builder2.SetILen(init.Length);
				builder2.SetBuffer(ByteString.CopyFrom(init));
			}
			SKBuiltinBuffer_t currentSynckey = builder2.Build();
			builder.SetCurrentSynckey(currentSynckey);
			SKBuiltinBuffer_t.Builder builder3 = new SKBuiltinBuffer_t.Builder();
			if (max == null)
			{
				builder3.SetILen(0);
				builder3.SetBuffer(ByteString.CopyFrom(new byte[0]));
			}
			else
			{
				builder3.SetILen(max.Length);
				builder3.SetBuffer(ByteString.CopyFrom(max));
			}
			SKBuiltinBuffer_t maxSynckey = builder3.Build();
			builder.SetMaxSynckey(maxSynckey);
			return builder.Build();
		}

		public static NewSyncRequest CreateNewSyncRequestEntity(byte[] keyBuffer)
		{
			NewSyncRequest.Builder builder = new NewSyncRequest.Builder();
			CmdList.Builder builder2 = new CmdList.Builder();
			builder2.SetCount(0);
			builder.SetOplog(builder2.Build());
			builder.SetSelector(3);
			builder.SetScene(7);
			SKBuiltinBuffer_t.Builder builder3 = new SKBuiltinBuffer_t.Builder();
			builder3.SetBuffer(ByteString.CopyFrom(keyBuffer));
			builder3.SetILen(keyBuffer.Length);
			builder.SetKeyBuf(builder3.Build());
			builder.SetDeviceType("Android设备");
			builder.SetSyncMsgDigest(1u);
			return builder.Build();
		}

		public static NewSyncRequest ModifyProfile(int sex, string province, string city, string signature, byte[] keyBuffer)
		{
			UserProfile.Builder builder = new UserProfile.Builder();
			builder.SetBitFlag(128u);
			builder.SetUserName(new SKBuiltinString_t.Builder().SetString(""));
			builder.SetNickName(new SKBuiltinString_t.Builder().SetString("nick"));
			builder.SetBindUin(0u);
			builder.SetBindEmail(new SKBuiltinString_t.Builder().SetString(""));
			builder.SetBindMobile(new SKBuiltinString_t.Builder().SetString(""));
			builder.SetStatus(0);
			builder.SetImgLen(0);
			builder.SetImgBuf(ByteString.CopyFrom("", Encoding.Default));
			builder.SetSex(sex);
			builder.SetProvince(province);
			builder.SetCity(city);
			builder.SetSignature(signature);
			builder.SetPersonalCard(1);
			builder.SetPluginFlag(0);
			builder.SetPluginSwitch(0);
			builder.SetAlias("");
			builder.SetWeiboNickname("");
			builder.SetWeiboFlag(0);
			builder.SetCountry("CN");
			UserProfile userProfile = builder.Build();
			byte[] array = userProfile.ToByteArray();
			SKBuiltinBuffer_t.Builder builder2 = new SKBuiltinBuffer_t.Builder();
			builder2.SetBuffer(ByteString.CopyFrom(array));
			builder2.SetILen(array.Length);
			SKBuiltinBuffer_t cmdBuf = builder2.Build();
			CmdItem.Builder builder3 = new CmdItem.Builder();
			builder3.SetCmdBuf(cmdBuf);
			builder3.SetCmdId(1);
			CmdItem value = builder3.Build();
			CmdList.Builder builder4 = new CmdList.Builder();
			builder4.SetCount(1);
			builder4.AddList(value);
			CmdList oplog = builder4.Build();
			NewSyncRequest.Builder builder5 = new NewSyncRequest.Builder();
			builder5.SetOplog(oplog);
			builder5.SetSelector(7);
			builder5.SetScene(7);
			SKBuiltinBuffer_t.Builder builder6 = new SKBuiltinBuffer_t.Builder();
			builder6.SetBuffer(ByteString.CopyFrom(keyBuffer));
			builder6.SetILen(keyBuffer.Length);
			builder5.SetKeyBuf(builder6.Build());
			return builder5.Build();
		}

		public static NewSyncRequest ModifyProfile(string nickName, byte[] keyBuffer)
		{
			UserProfile.Builder builder = new UserProfile.Builder();
			builder.SetBitFlag(2u);
			builder.SetUserName(new SKBuiltinString_t.Builder().SetString(""));
			builder.SetNickName(new SKBuiltinString_t.Builder().SetString(nickName));
			builder.SetBindUin(0u);
			builder.SetBindEmail(new SKBuiltinString_t.Builder().SetString(""));
			builder.SetBindMobile(new SKBuiltinString_t.Builder().SetString(""));
			builder.SetStatus(0);
			builder.SetImgLen(0);
			builder.SetImgBuf(ByteString.CopyFrom("", Encoding.Default));
			builder.SetSex(0);
			builder.SetProvince("");
			builder.SetCity("");
			builder.SetSignature("");
			builder.SetPersonalCard(1);
			builder.SetPluginFlag(0);
			builder.SetPluginSwitch(0);
			builder.SetAlias("");
			builder.SetWeiboNickname("");
			builder.SetWeiboFlag(0);
			builder.SetCountry("CN");
			UserProfile userProfile = builder.Build();
			byte[] array = userProfile.ToByteArray();
			SKBuiltinBuffer_t.Builder builder2 = new SKBuiltinBuffer_t.Builder();
			builder2.SetBuffer(ByteString.CopyFrom(array));
			builder2.SetILen(array.Length);
			SKBuiltinBuffer_t cmdBuf = builder2.Build();
			CmdItem.Builder builder3 = new CmdItem.Builder();
			builder3.SetCmdBuf(cmdBuf);
			builder3.SetCmdId(1);
			CmdItem value = builder3.Build();
			CmdList.Builder builder4 = new CmdList.Builder();
			builder4.SetCount(1);
			builder4.AddList(value);
			CmdList oplog = builder4.Build();
			NewSyncRequest.Builder builder5 = new NewSyncRequest.Builder();
			builder5.SetOplog(oplog);
			builder5.SetSelector(7);
			builder5.SetScene(7);
			SKBuiltinBuffer_t.Builder builder6 = new SKBuiltinBuffer_t.Builder();
			builder6.SetBuffer(ByteString.CopyFrom(keyBuffer));
			builder6.SetILen(keyBuffer.Length);
			builder5.SetKeyBuf(builder6.Build());
			return builder5.Build();
		}

		public static LBSFindRequest CreateLBSFindRequestEntity(string sessionKey, uint uin, float weidu, float jingdu, string deviceID, string OSType, int sex)
		{
			BaseRequest @base = CreateBaseRequestEntity(deviceID, sessionKey, uin, OSType);
			LBSFindRequest.Builder builder = new LBSFindRequest.Builder();
			builder.SetBase(@base);
			builder.SetCellId("");
			builder.SetMacAddr("");
			builder.SetOpCode(sex);
			builder.SetGPSSource(0);
			builder.SetPrecision(5);
			builder.SetLatitude(weidu);
			builder.SetLongitude(jingdu);
			return builder.Build();
		}

		public static ShakereportRequest CreateShakeReportRequestEntity(string sessionKey, uint uin, string deviceID, string OSType, float weidu, float jingdu)
		{
			BaseRequest @base = CreateBaseRequestEntity(deviceID, sessionKey, uin, OSType);
			ShakereportRequest.Builder builder = new ShakereportRequest.Builder();
			builder.SetBase(@base);
			builder.SetOpCode(0);
			builder.SetLatitude(weidu);
			builder.SetLongitude(jingdu);
			builder.SetPrecision(5);
			builder.SetCellId("");
			builder.SetMacAddr("");
			builder.SetImgId(0);
			builder.SetTimes(4);
			builder.SetGPSSource(1);
			return builder.Build();
		}

		public static ShakegetRequest CreateShakeGetRequestEntity(string sessionKey, uint uin, string deviceID, string OSType, SKBuiltinBuffer_t buffer)
		{
			BaseRequest @base = CreateBaseRequestEntity(deviceID, sessionKey, uin, OSType);
			ShakegetRequest.Builder builder = new ShakegetRequest.Builder();
			builder.SetBase(@base);
			builder.SetBuffer(buffer);
			builder.SetIsNewVerson(1);
			return builder.Build();
		}

		public static UploadhdheadimgRequest CreateUploadhdheadimgRequestEntity(string sessionKey, uint uin, int totalLen, int startPos, byte[] imgBuffer, string deviceID, string OSType)
		{
			BaseRequest @base = CreateBaseRequestEntity(deviceID, sessionKey, uin, OSType);
			UploadhdheadimgRequest.Builder builder = new UploadhdheadimgRequest.Builder();
			builder.SetBase(@base);
			builder.SetTotalLen(totalLen);
			builder.SetStartPos(startPos);
			builder.SetHeadImgType(1);
			SKBuiltinBuffer_t.Builder builder2 = new SKBuiltinBuffer_t.Builder();
			builder2.SetILen(imgBuffer.Length);
			builder2.SetBuffer(ByteString.CopyFrom(imgBuffer));
			builder.SetData(builder2.Build());
			return builder.Build();
		}

		public static UploadMsgImgRequest CreateUploadMsgImgRequestEntity(string sessionKey, uint uin, int totalLen, int startPos, byte[] imgBuffer, string deviceID, string OSType, string clientID, string fromUser, string toUser)
		{
			BaseRequest @base = CreateBaseRequestEntity(deviceID, sessionKey, uin, OSType);
			UploadMsgImgRequest.Builder builder = new UploadMsgImgRequest.Builder();
			builder.SetBase(@base);
			builder.SetClientImgId(new SKBuiltinString_t.Builder().SetString(clientID));
			builder.SetFromUserName(new SKBuiltinString_t.Builder().SetString(fromUser));
			builder.SetToUserName(new SKBuiltinString_t.Builder().SetString(toUser));
			builder.SetTotalLen(totalLen);
			builder.SetStartPos(startPos);
			builder.SetDataLen(imgBuffer.Length);
			SKBuiltinBuffer_t.Builder builder2 = new SKBuiltinBuffer_t.Builder();
			builder2.SetILen(imgBuffer.Length);
			builder2.SetBuffer(ByteString.CopyFrom(imgBuffer));
			builder.SetData(builder2.Build());
			builder.SetMsgType(3);
			builder.SetCompressType(1);
			return builder.Build();
		}

		public static MmsnsuploadRequest CreateUploadTwitterImgRequestEntity(string sessionKey, uint uin, int totalLen, int startPos, byte[] imgBuffer, string deviceID, string OSType, string clientId, string Description)
		{
			BaseRequest @base = CreateBaseRequestEntity(deviceID, sessionKey, uin, OSType);
			MmsnsuploadRequest.Builder builder = new MmsnsuploadRequest.Builder();
			builder.SetBase(@base);
			builder.SetType(2);
			builder.SetStartPos(startPos);
			builder.SetTotalLen(totalLen);
			SKBuiltinBuffer_t.Builder builder2 = new SKBuiltinBuffer_t.Builder();
			builder2.SetILen(imgBuffer.Length);
			builder2.SetBuffer(ByteString.CopyFrom(imgBuffer));
			builder.SetBuffer(builder2.Build());
			builder.ClientId = clientId;
			builder.FilterStype = 0;
			builder.SyncFlag = 0;
			builder.Description = Description;
			TwitterInfoObj.Builder builder3 = new TwitterInfoObj.Builder();
			builder3.OauthToken = "";
			builder3.OauthTokenSecret = "";
			builder.SetTwitterInfo(builder3.Build());
			return builder.Build();
		}

		public static MMSnsPostRequest CreateSendTwitterRequestEntity(string sessionKey, uint uin, string deviceID, string OSType, string clientId, string DescriptionHtml)
		{
			BaseRequest @base = CreateBaseRequestEntity(deviceID, sessionKey, uin, OSType);
			MMSnsPostRequest.Builder builder = new MMSnsPostRequest.Builder();
			builder.SetBase(@base);
			SKBuiltinBuffer_t.Builder builder2 = new SKBuiltinBuffer_t.Builder();
			builder2.Buffer = ByteString.CopyFromUtf8(DescriptionHtml);
			builder2.ILen = builder2.Buffer.Length;
			builder.SetObjectDesc(builder2);
			builder.Privacy = 0;
			builder.SyncFlag = 0;
			builder.ClientId = clientId;
			builder.PostBGImgType = 0;
			builder.ObjectSource = 0;
			return builder.Build();
		}

		public static NewSendMsgRequest CreateSendMsgRequestEntity(string Content, uint CreateTime, uint ClientMsgId, string ToUserName, uint msgType)
		{
			NewSendMsgRequest.Builder builder = new NewSendMsgRequest.Builder();
			builder.SetCount(1);
			NewMsgRequestBody.Builder builder2 = new NewMsgRequestBody.Builder();
			builder2.SetToUserName(new SKBuiltinString_t.Builder().SetString(ToUserName));
			builder2.SetType(msgType);
			builder2.SetContent(Content);
			builder2.SetCreateTime(CreateTime);
			builder2.SetClientMsgId(ClientMsgId);
			builder.AddList(builder2);
			return builder.Build();
		}

		public static LogoutRequest CreateLogoutRequestEntity(string sessionKey, uint uin, string deviceID, string OSType)
		{
			BaseRequest @base = CreateBaseRequestEntity(deviceID, sessionKey, uin, OSType);
			LogoutRequest.Builder builder = new LogoutRequest.Builder();
			builder.SetBase(@base);
			builder.SetScene(2);
			return builder.Build();
		}

		public static VerifyUserRequest CreateVerifyUserRequestEntity(string sessionKey, uint uin, string deviceID, string OSType, string strangerUserName, string ticket, int opCode, string scene, string content)
		{
			VerifyUserObj.Builder builder = new VerifyUserObj.Builder();
			builder.SetValue(strangerUserName);
			if (opCode == 3)
			{
				builder.SetVerifyUserTicket(ticket);
			}
			else
			{
				builder.SetVerifyUserTicket("");
				builder.SetAntiSpamTicket(ticket);
			}
			builder.SetFriendFlag(0u);
			builder.SetChatRoomUserName("");
			builder.SetSourceNickName("");
			builder.SetSourceUserName("");
			BaseRequest @base = CreateBaseRequestEntity(deviceID, sessionKey, uin, OSType);
			VerifyUserRequest.Builder builder2 = new VerifyUserRequest.Builder();
			builder2.SetBase(@base);
			builder2.SetOpcode(opCode);
			builder2.SetVerifyUserListSize(1);
			builder2.AddVerifyUserList(builder);
			builder2.SetVerifyContent(content);
			builder2.SetSceneListNumb(1);
			builder2.AddSceneList(scene);
			return builder2.Build();
		}

		internal static SearchContactRequest CreateSearchContactEntity(string sessionKey, uint uin, string deviceID, string OSType, string peer)
		{
			BaseRequest @base = CreateBaseRequestEntity(deviceID, sessionKey, uin, OSType);
			SearchContactRequest.Builder builder = new SearchContactRequest.Builder();
			builder.SetBase(@base);
			builder.SetOpCode(0);
			SKBuiltinString_t.Builder builder2 = new SKBuiltinString_t.Builder();
			builder2.SetString(peer);
			builder.SetUserName(builder2);
			return builder.Build();
		}

		internal static GeneralSetRequest CreateSetIDEntity(string sessionKey, uint uin, string deviceID, string OSType, string wxID)
		{
			BaseRequest @base = CreateBaseRequestEntity(deviceID, sessionKey, uin, OSType);
			GeneralSetRequest.Builder builder = new GeneralSetRequest.Builder();
			builder.SetBase(@base);
			builder.SetSetType(1);
			builder.SetSetValue(wxID);
			return builder.Build();
		}

		internal static OplogRequest CreateOpSetCheckRequestEntity(int cmdid, int key, int value)
		{
			KeyValPair.Builder builder = new KeyValPair.Builder();
			builder.SetKey(key);
			builder.SetVal(value);
			byte[] array = builder.Build().ToByteArray();
			SKBuiltinBuffer_t.Builder builder2 = new SKBuiltinBuffer_t.Builder();
			builder2.SetBuffer(ByteString.CopyFrom(array));
			builder2.SetILen(array.Length);
			SKBuiltinBuffer_t cmdBuf = builder2.Build();
			CmdItem.Builder builder3 = new CmdItem.Builder();
			builder3.SetCmdBuf(cmdBuf);
			builder3.SetCmdId(cmdid);
			CmdItem value2 = builder3.Build();
			CmdList.Builder builder4 = new CmdList.Builder();
			builder4.SetCount(1);
			builder4.AddList(value2);
			CmdList oplog = builder4.Build();
			OplogRequest.Builder builder5 = new OplogRequest.Builder();
			builder5.SetOplog(oplog);
			return builder5.Build();
		}

		internal static OplogRequest CreateOpLogRequestEntity(int cmdid, string removeObj)
		{
			RemoveFriendObject.Builder builder = new RemoveFriendObject.Builder();
			builder.SetUserName(new SKBuiltinString_t.Builder().SetString(removeObj));
			byte[] array = builder.Build().ToByteArray();
			SKBuiltinBuffer_t.Builder builder2 = new SKBuiltinBuffer_t.Builder();
			builder2.SetBuffer(ByteString.CopyFrom(array));
			builder2.SetILen(array.Length);
			SKBuiltinBuffer_t cmdBuf = builder2.Build();
			CmdItem.Builder builder3 = new CmdItem.Builder();
			builder3.SetCmdBuf(cmdBuf);
			builder3.SetCmdId(cmdid);
			CmdItem value = builder3.Build();
			CmdList.Builder builder4 = new CmdList.Builder();
			builder4.SetCount(1);
			builder4.AddList(value);
			CmdList oplog = builder4.Build();
			OplogRequest.Builder builder5 = new OplogRequest.Builder();
			builder5.SetOplog(oplog);
			return builder5.Build();
		}

		internal static OplogRequest CreateExitChatroomRequestEntity(int cmdid, string chatroom, string self)
		{
			ExitChatroomObject.Builder builder = new ExitChatroomObject.Builder();
			builder.SetChatroom(new SKBuiltinString_t.Builder().SetString(chatroom));
			builder.SetUserName(new SKBuiltinString_t.Builder().SetString(self));
			byte[] array = builder.Build().ToByteArray();
			SKBuiltinBuffer_t.Builder builder2 = new SKBuiltinBuffer_t.Builder();
			builder2.SetBuffer(ByteString.CopyFrom(array));
			builder2.SetILen(array.Length);
			SKBuiltinBuffer_t cmdBuf = builder2.Build();
			CmdItem.Builder builder3 = new CmdItem.Builder();
			builder3.SetCmdBuf(cmdBuf);
			builder3.SetCmdId(cmdid);
			CmdItem value = builder3.Build();
			CmdList.Builder builder4 = new CmdList.Builder();
			builder4.SetCount(1);
			builder4.AddList(value);
			CmdList oplog = builder4.Build();
			OplogRequest.Builder builder5 = new OplogRequest.Builder();
			builder5.SetOplog(oplog);
			return builder5.Build();
		}

		internal static CreateChatRoomRequest CreateChatroomRequestEntity(string sessionKey, uint uin, string deviceID, string OSType, List<string> memList)
		{
			BaseRequest @base = CreateBaseRequestEntity(deviceID, sessionKey, uin, OSType);
			CreateChatRoomRequest.Builder builder = new CreateChatRoomRequest.Builder();
			builder.SetBase(@base);
			builder.SetTopic(new SKBuiltinString_t.Builder().SetString(""));
			builder.SetMemberCount(memList.Count);
			foreach (string mem in memList)
			{
				ChatRoomItem.Builder builder2 = new ChatRoomItem.Builder();
				builder2.SetMemberName(new SKBuiltinString_t.Builder().SetString(mem));
				builder.AddMembers(builder2);
			}
			return builder.Build();
		}

		internal static AddChatRoomMemberRequest CreateChatroomMemRequestEntity(string sessionKey, uint uin, string deviceID, string OSType, string chatroomName, List<string> memList)
		{
			BaseRequest @base = CreateBaseRequestEntity(deviceID, sessionKey, uin, OSType);
			AddChatRoomMemberRequest.Builder builder = new AddChatRoomMemberRequest.Builder();
			builder.SetBase(@base);
			builder.SetMemberCount(memList.Count);
			foreach (string mem in memList)
			{
				ChatRoomItem.Builder builder2 = new ChatRoomItem.Builder();
				builder2.SetMemberName(new SKBuiltinString_t.Builder().SetString(mem));
				builder.AddMembers(builder2);
			}
			builder.SetChatRoomName(new SKBuiltinString_t.Builder().SetString(chatroomName));
			return builder.Build();
		}

		internal static GetChatRoomMemberDetailRequest CreateGetChatroomMemberListRequestEntity(string sessionKey, uint uin, string deviceID, string OSType, string chatroomName)
		{
			BaseRequest @base = CreateBaseRequestEntity(deviceID, sessionKey, uin, OSType);
			GetChatRoomMemberDetailRequest.Builder builder = new GetChatRoomMemberDetailRequest.Builder();
			builder.SetBase(@base);
			builder.SetChatroomUserName(chatroomName);
			builder.SetClientVersion(0u);
			return builder.Build();
		}

		internal static Geta8keyRequest CreateGetOAuthRequestEntity(string sessionKey, uint uin, string deviceID, string OSType, string url)
		{
			BaseRequest @base = CreateBaseRequestEntity(deviceID, sessionKey, uin, OSType);
			Geta8keyRequest.Builder builder = new Geta8keyRequest.Builder();
			builder.SetBase(@base);
			builder.SetOpCode(2);
			builder.SetReqUrl(new SKBuiltinString_t.Builder().SetString(url));
			builder.SetScene(4);
			return builder.Build();
		}

		internal static UploadvoiceRequest CreateVoiceMsgRequestEntity(string sessionKey, uint uin, string deviceID, string OSType, string toUserName, string userName, byte[] voiceData, string msgID)
		{
			BaseRequest @base = CreateBaseRequestEntity(deviceID, sessionKey, uin, OSType);
			UploadvoiceRequest.Builder builder = new UploadvoiceRequest.Builder();
			builder.SetBase(@base);
			builder.SetFromUserName(userName);
			builder.SetToUserName(toUserName);
			builder.SetOffset(0);
			builder.SetLength(voiceData.Length);
			builder.SetClientMsgId(msgID);
			builder.SetMsgId(new Random().Next() % 100);
			builder.SetVoiceLength(1011);
			SKBuiltinBuffer_t.Builder builder2 = new SKBuiltinBuffer_t.Builder();
			builder2.SetILen(voiceData.Length);
			builder2.SetBuffer(ByteString.CopyFrom(voiceData));
			builder.SetData(builder2);
			builder.SetEndFlag(1);
			builder.SetCancelFlag(0);
			builder.SetMsgSource("<msgsource></msgsource>");
			builder.SetVoiceFormat(1);
			builder.SetUICreateTime(0);
			builder.SetForwardFlag(0);
			return builder.Build();
		}

		internal static GetContactRequest CreateGetContactEntity(string sessionKey, uint uin, string deviceID, string OSType, string peer)
		{
			BaseRequest @base = CreateBaseRequestEntity(deviceID, sessionKey, uin, OSType);
			GetContactRequest.Builder builder = new GetContactRequest.Builder();
			builder.SetBase(@base);
			builder.SetUserCount(1);
			SKBuiltinString_t.Builder builder2 = new SKBuiltinString_t.Builder();
			builder2.SetString(peer);
			builder.AddUserNameList(builder2);
			builder.SetFromChatRoomNumb(1u);
			builder.AddFromChatRoom(new SKBuiltinString_t.Builder());
			return builder.Build();
		}

		internal static ExtDeviceLoginConfirmGetRequest CreateGetExtDevConfirmEntity(string reqUrl)
		{
			ExtDeviceLoginConfirmGetRequest.Builder builder = new ExtDeviceLoginConfirmGetRequest.Builder();
			builder.SetLoginUrl(reqUrl);
			builder.SetDeviceName("Android设备");
			return builder.Build();
		}

		internal static ExtDeviceLoginConfirmOKRequest CreateGetExtDevConfirmOKEntity(string reqUrl)
		{
			ExtDeviceLoginConfirmOKRequest.Builder builder = new ExtDeviceLoginConfirmOKRequest.Builder();
			builder.SetLoginUrl(reqUrl);
			builder.SetSessionList("");
			builder.SetSyncMsg(0u);
			return builder.Build();
		}

		internal static LogOutWebWxRequest CreateLogoutWebEntity(string sessionKey, uint uin, string deviceID, string OSType)
		{
			BaseRequest @base = CreateBaseRequestEntity(deviceID, sessionKey, uin, OSType);
			LogOutWebWxRequest.Builder builder = new LogOutWebWxRequest.Builder();
			builder.SetBase(@base);
			builder.SetOpCode(1u);
			return builder.Build();
		}

		//internal static GetSafetyInfoRequest GetSafetyInfo(string sessionKey, uint uin, string deviceID, string OSType)
		//{
		//	BaseRequest @base = CreateBaseRequestEntity(deviceID, sessionKey, uin, OSType);
		//	GetSafetyInfoRequest.Builder builder = new GetSafetyInfoRequest.Builder();
		//	builder.SetBase(@base);
		//	return builder.Build();
		//}

		//internal static MmsnsuserpageRequest CreateUserPage(string sessionKey, uint uin, string deviceID, string OSType, string userName, ulong maxid)
		//{
		//	BaseRequest @base = CreateBaseRequestEntity(deviceID, sessionKey, uin, OSType);
		//	MmsnsuserpageRequest.Builder builder = new MmsnsuserpageRequest.Builder();
		//	builder.SetBase(@base);
		//	builder.SetUsername(userName);
		//	builder.SetMaxId(maxid);
		//	builder.SetSource(0);
		//	return builder.Build();
		//}
	}


}
