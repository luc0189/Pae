using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pae.web.Data.Entities
{
    public class Institucion
    {
        public int Id { get; set; }
        public string NameIntitucion { get; set; }
        public ICollection<Site> Sites { get; set; }
    }
}
