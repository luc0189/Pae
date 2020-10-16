using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pae.web.Data.Entities
{
    public class Sedes
    {
        public int Id { get; set; }

        [Display(Name = "Nombre De la Sede")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(70, ErrorMessage = "El Campo {0} acepta solo {1} caracteres.")]
        public string NameSedes { get; set; }
        public DateTime FechaActualización { get; set; }
        public Institucion Institucion { get; set; }

        public ICollection<Estudents> Estudents { get; set; }
    }
}
