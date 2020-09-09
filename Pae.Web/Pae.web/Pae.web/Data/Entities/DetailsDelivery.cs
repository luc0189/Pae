﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pae.web.Data.Entities
{
    public class DetailsDelivery
    {
        public int Id { get; set; }

        [Display(Name ="Sitio de Entrega")]
        [Required(ErrorMessage ="El campo {0} es Requerido")]
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
        public long  TelMovil { get; set; }

       
        [Required (ErrorMessage ="El campo {0} es Requerido")]
        [Display(Name = "Image Acudiente")]
        public string ImageAcudienteUrl { get; set; }
        public string ImageAcudienteFullPath => string.IsNullOrEmpty(ImageAcudienteUrl)
                ? null :
                $"https://intranetweblcs.azurewebsites.net{ImageAcudienteUrl.Substring(1)}";

        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [Display(Name = "Image Entrega")]
        public string ImageDeliveryUrl { get; set; }
        public string ImageDeliveryFullPath => string.IsNullOrEmpty(ImageDeliveryUrl)
                ? null :
                $"https://intranetweblcs.azurewebsites.net{ImageDeliveryUrl.Substring(1)}";

        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [Display(Name = "Image Acta")]
        public string ImageActaUrl { get; set; }
        public string ImageActaFullPath => string.IsNullOrEmpty(ImageActaUrl)
                ? null :
                $"https://intranetweblcs.azurewebsites.net{ImageActaUrl.Substring(1)}";


        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [Display(Name = "Image Estudiante")]
        public string ImageStudentUrl { get; set; }
        public string ImageStudentFullPath => string.IsNullOrEmpty(ImageStudentUrl)
                ? null :
                $"https://intranetweblcs.azurewebsites.net{ImageStudentUrl.Substring(1)}";

        public DeliveryActa DeliveryActa { get; set; }

    }
}
