using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pae.web.Data.Entities
{
    public class Estudents
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Codigo")]
        public string NOrden { get; set; }

        [Required(ErrorMessage ="El campo {0} es requerido")]
        [Display(Name ="Documento")]
        [MaxLength(100,ErrorMessage ="El campo {0} no puede superar los 100 caracteres")]
        public string Document { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre Completo")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede superar los 100 caracteres")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre Acudiente")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede superar los 100 caracteres")]
        public string AcudienteName { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Documento Acudiente")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede superar los 100 caracteres")]
        public string DocumentAcu { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Mesa")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede superar los {1} caracteres")]
        public string Mesas { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Jornada")]
        [MaxLength(300, ErrorMessage = "El campo {0} no puede superar los {1} caracteres")]
        public string Jornada { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Entregas Autorizadas")]
        [MaxLength(300, ErrorMessage = "El campo {0} no puede superar los {1} caracteres")]
        public string AutDelivery { get; set; }

        public DateTime FechaActualización { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public Sedes Sedes { get; set; }
        public ICollection<DeliveryActa> DeliveryActas { get; set; }



    }
}
