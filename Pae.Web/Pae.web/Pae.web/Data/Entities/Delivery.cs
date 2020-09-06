using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pae.web.Data.Entities
{
    public class Delivery
    {
        public int Id { get; set; }

        public string MonthDelivery { get; set; }

        public string SiteDelivery { get; set; }

        public Estudents Estudents { get; set; }

        public Acudiente Acudiente { get; set; }

        public ICollection<SoportAcudienteImage> SoportAcudienteImages { get; set; }

        [Required(ErrorMessage = "El campo {} es requerido")]
        public ICollection<SoportDeliveryImage> SoportDeliveryImages { get; set; }

        [Required(ErrorMessage = "El campo {} es requerido")]
        public ICollection<SoportDocSignatureImage> SoportDocSignatureImages { get; set; }

        [Required(ErrorMessage = "El campo {} es requerido")]
        public ICollection<SoportStudentImage> SoportStudentImages { get; set; }


    }
}
