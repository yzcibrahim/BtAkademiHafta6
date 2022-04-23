using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KisiTakipMvc
{
    public interface IDeneme
    {
        int DenemeInstanceId { get; set; }
        string Name { get;}
    }
}
