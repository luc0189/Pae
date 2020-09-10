using Pae.web.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Pae.web.Models
{
    public class UploadStudentViewModel
    {
        [Required(ErrorMessage = "El campo {} es requerido")]
        [Display(Name = "Documento")]
        public long Document { get; set; }

        [Required(ErrorMessage = "El campo {} es requerido")]
        [Display(Name = "Nombre Completo")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "El campo {} es requerido")]
        public int Site { get; set; }
    }
}
