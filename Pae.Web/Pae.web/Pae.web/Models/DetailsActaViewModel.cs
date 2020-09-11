using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pae.web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pae.web.Models
{
    public class DetailsActaViewModel : DetailsDelivery
    {
        public int StudentId { get; set; }

        public int ActaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [Display(Name = "Doc Side 1")]
        public IFormFile ImageDocfrente { get; set; }

        [Required(ErrorMessage = "El campo {0} es Requerido")]
        [Display(Name = "Doc Side 2")]
        public IFormFile ImageDocReverso { get; set; }

        
        public IFormFile ImageDelivery { get; set; }



    }
}
