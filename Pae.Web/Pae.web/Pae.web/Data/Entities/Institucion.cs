using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pae.web.Data.Entities
{
    public class Institucion
    {
        public int Id { get; set; }

        [Display(Name ="Nombre Institucion")]
        [Required(ErrorMessage ="El campo {0} es requerido.")]
        [MaxLength(70,ErrorMessage ="El Campo {0} acepta solo {1} caracteres.")]
        public string NameIntitucion { get; set; }
        public ICollection<Sedes> Sedes { get; set; }
    }
}
