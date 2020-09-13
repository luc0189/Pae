using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pae.web.Data.Entities
{
    public class Estudents
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Codigo")]
        public int NOrden { get; set; }

        [Required(ErrorMessage ="El campo {0} es requerido")]
        [Display(Name ="Documento")]
        [MaxLength(100,ErrorMessage ="El campo {0} no puede superar los 100 caracteres")]
        public string Document { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre Completo")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede superar los 100 caracteres")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Mesa")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede superar los {1} caracteres")]
        public string Mesa { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public Sedes Sedes { get; set; }
        public ICollection<DeliveryActa> DeliveryActas { get; set; }



    }
}
