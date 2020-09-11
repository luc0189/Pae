using Pae.web.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Pae.web.Models
{
    public class EstudentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {} es requerido")]
        [Display(Name = "Codigo")]
        public int NOrden { get; set; }

        [Required(ErrorMessage = "El campo {} es requerido")]
        [Display(Name = "Documento")]
        public int Document { get; set; }

        [Required(ErrorMessage = "El campo {} es requerido")]
        [Display(Name = "Nombre Completo")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "El campo {} es requerido")]
        [Display(Name = "Mesa")]
        public string Mesa { get; set; }

        [Required(ErrorMessage = "El campo {} es requerido")]
        public Sedes Sedes { get; set; }

    }
}
