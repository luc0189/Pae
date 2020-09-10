﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pae.web.Data.Entities
{
    public class Estudents
    {
        public int Id { get; set; }


        [Required(ErrorMessage ="El campo {} es requerido")]
        [Display(Name ="Documento")]
        public long Document { get; set; }

        [Required(ErrorMessage = "El campo {} es requerido")]
        [Display(Name = "Nombre Completo")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "El campo {} es requerido")]
        public Site Site { get; set; }
        public ICollection<DeliveryActa> DeliveryActas { get; set; }



    }
}
