using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pae.web.Data.Entities
{
    public class ActaSequence
    {
        public int Id { get; set; }

        [MaxLength(10, ErrorMessage = "El campo {0} no puede superar los 10 caracteres")]
        public string Prefix { get; set; }

        public int Sequence { get; set; }

    }
}
