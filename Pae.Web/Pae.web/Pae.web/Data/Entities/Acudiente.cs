using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pae.web.Data.Entities
{
    public class Acudiente
    {
        public int Id { get; set; }
       
        public string FullName { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
    }
}
