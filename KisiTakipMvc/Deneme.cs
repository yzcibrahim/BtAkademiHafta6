using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KisiTakipMvc
{
    public class Deneme: IDeneme
    {
        public static int denemeInstanceCount { get; set; } = 0;
        public int DenemeInstanceId { get; set; }
        public string Name
        {
            get
            {
                return $"Ben {DenemeInstanceId}. deneme objesiyim";
            }
        }
        public Deneme()
        {
            DenemeInstanceId = denemeInstanceCount;
            denemeInstanceCount++;
        }
    }
}
