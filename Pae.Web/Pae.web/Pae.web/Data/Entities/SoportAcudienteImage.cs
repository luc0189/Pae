using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pae.web.Data.Entities
{
    public class SoportAcudienteImage
    {
        public int Id { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl)
                ? null :
                $"https://intranetweblcs.azurewebsites.net{ImageUrl.Substring(1)}";
        public Delivery Delivery { get; set; }
    }
}
