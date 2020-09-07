using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pae.web.Data.Entities
{
    public class DeliveryActa
    {
        public int Id { get; set; }
        public DateTime FechaCrea { get; set; }
        public string Usucrea { get; set; }
        public Estudents Estudents { get; set; }
        public Periodos Periodos { get; set; }
        public ICollection<DetailsDelivery> DetailsDeliveries { get; set; }
    }
}
