﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pae.web.Helpers
{
   public interface IImageHelper
    {
        Task<string> UploadImageAsync(IFormFile imageFile,string ruta,string urlImage,int idStudent);
    }
}
