using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pae.web.Data.Entities
{
    public class Sedes
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {} es requerido")]
        [MaxLength(100)]
        public string NameSedes { get; set; }

        public Institucion Institucion { get; set; }

        public ICollection<Estudents> Estudents { get; set; }
    }
}
