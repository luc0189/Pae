using System;
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

       
       
        [Display(Name = "Doc Side 1")]
        public string Imagedocl { get; set; }
        public string ImageDoc1FullPath => string.IsNullOrEmpty(Imagedocl)
                ? null :
                $"https://intranetweblcs.azurewebsites.net{Imagedocl.Substring(1)}";

      
        [Display(Name = "Doc Side 2")]
        public string Imagedoc2 { get; set; }
        public string ImageDoc2FullPath => string.IsNullOrEmpty(Imagedoc2)
                ? null :
                $"https://intranetweblcs.azurewebsites.net{Imagedoc2.Substring(1)}";

        [Display(Name = "Image Entrega")]
        public string ImageDeliveryUrl { get; set; }
        public string ImageDeliveryFullPath => string.IsNullOrEmpty(ImageDeliveryUrl)
                ? null :
                $"https://intranetweblcs.azurewebsites.net{ImageDeliveryUrl.Substring(1)}";

       public DeliveryActa DeliveryActa { get; set; }

    }
}
