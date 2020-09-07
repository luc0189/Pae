using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pae.web.Data.Entities
{
    public class Delivery
    {
        public int Id { get; set; }

        public string MonthDelivery { get; set; }

        public ICollection<DetailsDelivery> DetailsDeliveries { get; set; }


    }
}
