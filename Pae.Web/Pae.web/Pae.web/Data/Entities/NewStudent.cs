using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pae.web.Data.Entities
{
    public class NewStudent : Estudents
    {
        public string AutorizadoPor { get; set; }
        public string Cordinador { get; set; }

    }
}
