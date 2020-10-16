using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Pae.web.Helpers
{
    public class ImageHelper : IImageHelper
    {
        public async Task<string> UploadImageAsync(IFormFile imageFile,string ruta,string urlImage,int idStudent)
        {
            var guid = Guid.NewGuid().ToString();
            var file = $"{guid}-{idStudent}.jpg";
            var path = Path.Combine(
                Directory.GetCurrentDirectory(),
                ruta,
                file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            return $"{urlImage}{file}";
        }
    }
}
