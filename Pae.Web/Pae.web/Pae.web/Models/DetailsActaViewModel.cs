using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pae.web.Models
{
    public class DetailsActaViewModel
    {
        public int StudentId { get; set; }
        public int ActaId { get; set; }
        public int Id { get; set; }

        [Display(Name = "Sitio de Entrega")]
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [MaxLength(120)]
        public string SiteDelivery { get; set; }

        [Display(Name = "Documento Acudiente")]
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        public int DocAcudiente { get; set; }

        [Display(Name = "Nombre Acudiente")]
        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [MaxLength(120)]
        public string FullNameAcudiente { get; set; }

        [Display(Name = "Telefono Movil")]
        public int TelMovil { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
       

        [Display(Name = "Image Acudiente")]
        public string ImageAcudienteUrl { get; set; }
     

        [Display(Name = "Image Entrega")]
        public string ImageDeliveryUrl { get; set; }
       


        [Display(Name = "Image Acta")]
        public string ImageActaUrl { get; set; }
        public string ImageActaFullPath => string.IsNullOrEmpty(ImageActaUrl)
                ? null :
                $"https://intranetweblcs.azurewebsites.net{ImageActaUrl.Substring(1)}";


        [Display(Name = "Image Estudiante")]
        public string ImageStudentUrl { get; set; }
        public string ImageStudentFullPath => string.IsNullOrEmpty(ImageStudentUrl)
                ? null :
                $"https://intranetweblcs.azurewebsites.net{ImageStudentUrl.Substring(1)}";


        
    }
}
