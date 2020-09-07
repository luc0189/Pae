using Pae.web.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Pae.web.Models
{
    public class EstudentViewModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "El campo {} es requerido")]
        [Display(Name = "Documento")]
        public int Document { get; set; }

        [Required(ErrorMessage = "El campo {} es requerido")]
        [Display(Name = "Nombre Completo")]
        public string FullName { get; set; }



        [Required(ErrorMessage = "El campo {} es requerido")]

        public Site Site { get; set; }

    }
}
