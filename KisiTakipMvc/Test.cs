using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KisiTakipMvc
{
    public class Test
    {
        IDeneme _deneme;
        public static int instanceCount { get; set; } = 0;
        public Test(IDeneme d)
        {
            instanceId = instanceCount;
            instanceCount++;
            _deneme = d;
        }

        public int instanceId { get; set; }
    }
}
