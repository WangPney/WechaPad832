namespace Wechat.Protocol.Andriod
{
    public struct userInfo
    {
        public string nick { get; set; }

        public string user { get; set; }

        public string pwd { get; set; }

        public byte[] sessionKey { get; set; }

        public uint uin { get; set; }

        public string userName { get; set; }

        public string imei { get; set; }

        public string deviceID { get; set; }

        public string manufacturer { get; set; }

        public string Model { get; set; }

        public string release { get; set; }

        public string incremental { get; set; }

        public string display { get; set; }

        public string abi { get; set; }

        public string fingerprint { get; set; }

        public string clientid { get; set; }

        public string androidid { get; set; }

        public string mac { get; set; }

        public string devicetype { get; set; }

        public string ostype { get; set; }

        public string site { get; set; }

        public string group { get; set; }

        public byte[] initSyncKey { get; set; }

        public int QianMing { get; set; }

        public int headImg { get; set; }

        public int friendCou { get; set; }

        public string task { get; set; }
    }
}
