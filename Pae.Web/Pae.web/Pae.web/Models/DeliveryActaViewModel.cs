using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pae.web.Models
{
    public class DeliveryActaViewModel
    {
        public int EstudentId { get; set; }
        public int Id { get; set; }
        
        public string Usucrea { get; set; }

        [Required(ErrorMessage = "The Field {0} is mandatory.")]
        [Display(Name = "Periodos")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un Periodo.")]
        public int PeriodoId { get; set; }


        public IEnumerable<SelectListItem> Periodos { get; set; }
    }
}
