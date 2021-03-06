﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pae.web.Data.Entities
{
    public class DeliveryActa
    {
        public int Id { get; set; }
     
      //public int IdActa { get; set; }
        public DateTime FechaCrea { get; set; }

        public string Prefix { get; set; }

        // ActaSecuence.Sequence
        public int PrefixSequence { get; set; }

        public bool Entrega3 { get; set; }
        public bool Entrega4 { get; set; }
        public bool Entrega5 { get; set; }
        public bool Entrega6 { get; set; }
        public bool Entrega7 { get; set; }
        public string Usucrea { get; set; }
        public DateTime FechaActualización { get; set; }
        public Estudents Estudents { get; set; }
       
        public ICollection<DetailsDelivery> DetailsDeliveries { get; set; }
    }
}
