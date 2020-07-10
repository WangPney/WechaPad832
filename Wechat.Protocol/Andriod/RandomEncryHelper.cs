using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wechat.Protocol.Andriod
{
    public class RandomEncryHelper
    {

        public static byte[] GenRandomEncryKey()
        {
            return new byte[16]
            {
                142,
                97,
                147,
                137,
                232,
                153,
                66,
                29,
                7,
                116,
                240,
                9,
                54,
                94,
                75,
                31
            };
        }
    }
}
