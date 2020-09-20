using Microsoft.AspNetCore.Mvc.Rendering;
using Pae.web.Data.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pae.web.Models
{
    public class EstudentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Codigo")]
        public string NOrden { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Documento")]
        public string Document { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre Completo")]
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
        [Display(Name = "Jornada")]
        [MaxLength(300, ErrorMessage = "El campo {0} no puede superar los {1} caracteres")]
        public string Jornada { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Mesa")]
        public string Mesa { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Entregas")]
        public string AutoDelivery { get; set; }

        [Required(ErrorMessage = "The Field {0} is mandatory.")]
        [Display(Name = "Sede")]

        public int SedeId { get; set; }

        public IEnumerable<SelectListItem> Sedes { get; set; }
    }
}
