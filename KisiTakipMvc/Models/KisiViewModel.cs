using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace KisiTakipMvc.Models
{
    public class KisiViewModel
    {
        
        public int Id { get; set; }
        
        [DisplayName("Ad")]
        public string Name { get; set; }

        [DisplayName("Soyad")]
        public string Surname { get; set; }
        [DisplayName("Yaş")]
        public int Age { get; set; }

    }


}
