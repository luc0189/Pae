using Pae.web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pae.web.Models
{
    public class AddSiteViewModel
    {
        public int Id { get; set; }
        public int InstitucionId { get; set; }

        [Required(ErrorMessage = "El campo {} es requerido")]
        [MaxLength(100)]
        public string NameSites { get; set; }
    }
}
