using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wechat.Util.ConfigManagers
{

    public class WechatProtocolMqSection : ConfigurationSection
    {
        private static WechatProtocolMqSection _Instance = null;

        public static WechatProtocolMqSection Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = ConfigurationManager.GetSection("wechatprotocols") as WechatProtocolMqSection;
                }
                return _Instance;
            }
        }

        [ConfigurationProperty("protocols")]
        public WechatProtocolMqCollection Protocols
        {
            get { return this["protocols"] as WechatProtocolMqCollection; }
        }

    }


    public class WechatProtocolMqCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ProtocolElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ProtocolElement)element).Name;
        }

        public ProtocolElement this[int index]
        {
            get
            {
                return this.BaseGet(index) as ProtocolElement;
            }
        }
        new public ProtocolElement this[string Name]
        {
            get
            {
                return (ProtocolElement)BaseGet(Name);
            }
        }
        new public int Count
        {
            get { return base.Count; }
        }
    }


    public class ProtocolElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return this["name"].ToString(); }
        }

        [ConfigurationProperty("groupname", IsRequired = true)]
        public string GroupName
        {
            get { return this["groupname"].ToString(); }
        }

        [ConfigurationProperty("topic", IsRequired = true)]
        public string Topic
        {
            get { return this["topic"].ToString(); }
        }



        [ConfigurationProperty("subexpression", IsRequired = false, DefaultValue = "*")]
        public string SubExpression
        {
            get { return this["subexpression"].ToString(); }
        }


        [ConfigurationProperty("type", IsRequired = true)]
        public string Type
        {
            get { return this["type"].ToString(); }
        }
       
    }
}
