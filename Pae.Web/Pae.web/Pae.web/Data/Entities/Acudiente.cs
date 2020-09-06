using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pae.web.Data.Entities
{
    public class Acudiente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {} es requerido")]
        [MaxLength(60)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "El campo {} es requerido")]
        public int Tel { get; set; }

        [Display(Name ="Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public  ICollection<Estudents>  Estudents { get; set; }
    }
}
