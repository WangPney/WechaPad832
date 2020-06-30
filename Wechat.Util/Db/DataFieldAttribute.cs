using System;

namespace Wechat.Util.Db
{
    // Token: 0x02000016 RID: 22
    public class DataFieldAttribute : Attribute
    {
        // Token: 0x06000070 RID: 112 RVA: 0x0000375E File Offset: 0x0000195E
        public DataFieldAttribute()
        {
        }

        // Token: 0x06000071 RID: 113 RVA: 0x00003766 File Offset: 0x00001966
        public DataFieldAttribute(string name)
        {
            this.m_name = name;
        }

        // Token: 0x17000011 RID: 17
        // (get) Token: 0x06000072 RID: 114 RVA: 0x00003775 File Offset: 0x00001975
        // (set) Token: 0x06000073 RID: 115 RVA: 0x0000377D File Offset: 0x0000197D
        public string Name
        {
            get
            {
                return this.m_name;
            }
            set
            {
                this.m_name = value;
            }
        }

        // Token: 0x04000034 RID: 52
        private string m_name;
    }
}
