using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KisiTakipMvc
{
    public class DenemeYeni : IDeneme
    {
        // public int DenemeInstanceId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int DenemeInstanceId { get; set; }
        public static int denemeInstanceCount { get; set; } = 0;
       
        // public string Name => throw new NotImplementedException();
        public string Name
        {
            get
            {
                return $"Ben {DenemeInstanceId}. Yeni deneme objesiyim";
            }
        }
        public DenemeYeni()
        {
            DenemeInstanceId = denemeInstanceCount;
            denemeInstanceCount++;
        }
    }
}
