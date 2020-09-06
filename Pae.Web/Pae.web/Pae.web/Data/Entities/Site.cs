using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pae.web.Data.Entities
{
    public class Site
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {} es requerido")]
        [MaxLength(100)]
        public string NameSite { get; set; }

        public Institucion Institucion { get; set; }

        public ICollection<Estudents> Estudents { get; set; }
    }
}
