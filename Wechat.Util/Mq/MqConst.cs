using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wechat.Util.Mq
{
    public class MqConst
    {
        //用户状态
        public const string UserOfflineStatusCusomerGroup = "WECHAT_OFFLINE_STATUS_UPDATE_CG";
        public const string UserOfflineStatusProducerGroup = "WECHAT_OFFLINE_STATUS_UPDATE_PG";
        public const string UserOfflineStatusTopic = "WECHAT_OFFLINE_STATUS_UPDATE_TOPIC";

        //用户同步消息队列
        public const string UserSyncMessageTopic = "WECHAT_USER_MESSAGE_QUEUE_TOPIC";
        public const string UserSyncMessageProducerGroup = "WECHAT_USER_MESSAGE_QUEUE_PG";
        public const string UserSyncMessageCusomerGroup = "WECHAT_USER_MESSAGE_QUEUE_CG";

        //同步消息
        public const string SyncMessageProducerGroup = "WECHAT_SYNC_MESSAGE_PG";
        public const string SyncMessageCusomerGroup = "WECHAT_SYNC_MESSAGE_CG";
        public const string SyncMessageTopic = "WECHAT_SYNC_MESSAGE_TOPIC";

        //上传文件到oss
        public const string UploadOssCusomerGroup = "WECHAT_UPLOAD_FILE_TO_OSS_CG";
        public const string UploadOssProducerGroup = "WECHAT_UPLOAD_FILE_TO_OSS_PG";
        public const string UploadOssTopic = "WECHAT_UPLOAD_FILE_TO_OSS_TOPIC";



        
    }
}
