using Microsoft.AspNetCore.Mvc.Rendering;
using Pae.web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pae.web.Models
{
    public class DeliveryActaViewModel: DeliveryActa
    {
        public int StudentID { get; set; }

    }
}
