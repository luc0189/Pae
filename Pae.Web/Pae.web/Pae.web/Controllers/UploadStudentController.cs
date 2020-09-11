using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pae.web.Data;
using Pae.web.Data.Entities;
using Pae.web.Models;

namespace Pae.web.Controllers
{
    public class UploadStudentController : Controller

    {
        private readonly DataContext _dataContext;

        public UploadStudentController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public IActionResult Index(List<Estudents> students=null)
        {
            students = students == null ? new List<Estudents>() : students;

            return View(students);
        }
        [HttpPost]
        public async  Task<IActionResult> Index (IFormFile file,[FromServices] IHostingEnvironment hostingEnvironment)
        {
            if (file == null)
            {
                ViewBag.Message = $"Seleccione un Documento de Excel";
            }
            try
            {
                string fileName = $"{hostingEnvironment.WebRootPath}\\files\\{file.FileName}";

                using (FileStream fileStream = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }
                var students = await this.GetStudentList(file.FileName);
                return Index();
            }
            catch (Exception e)
            {

                ViewBag.Message = $"Excepcion no Controlada: {e.Message}";
                return View();
            }
            
        }


        private async Task<Estudents> GetStudentList(string fName)
        {
            Estudents students = new Estudents();
            try
            {
                
                var fileName = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fName;
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        
                        while (reader.Read())
                        {                            
                            _dataContext.Estudents.Add(new Estudents()
                            {
                                FullName = reader.GetValue(1).ToString(),
                                NOrden = Convert.ToInt32(reader.GetValue(0).ToString()),
                                Document = reader.GetValue(2).ToString(),
                                Site = await _dataContext.Sites.FirstAsync(o => o.NameSite == reader.GetValue(3).ToString()),
                                 Mesa=reader.GetValue(4).ToString() 
                            //Site =  _dataContext.Sites.FirstAsync(s => s.Id ==  (Convert.ToInt32(reader.GetValue(2).ToString())))
                        });
                        }
                        
                       await _dataContext.SaveChangesAsync();
                        ViewBag.Success = $"Se guardaron {reader.RowCount} Registros";
                    }
                }
               
                return students;
            }
            catch (Exception e)
            {
                ViewBag.Message = $"Excepcion no Controlada: {e.Message} mas detalles:{e.InnerException}";

            }

            return students;

        }
    }
}
