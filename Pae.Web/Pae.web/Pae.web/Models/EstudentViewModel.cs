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
        public int NOrden { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Documento")]
        public string Document { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre Completo")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Mesa")]
        public string Mesa { get; set; }

        [Required(ErrorMessage = "The Field {0} is mandatory.")]
        [Display(Name = "Sede")]

        public int SedeId { get; set; }

        public IEnumerable<SelectListItem> Sedes { get; set; }
    }
}
