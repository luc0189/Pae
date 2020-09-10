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
            string fileName = $"{hostingEnvironment.WebRootPath}\\files\\{file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            var students = await this.GetStudentList(file.FileName);
            return Index();
        }


        private async Task<Estudents> GetStudentList(string fName)
        {
            try
            {
                Estudents students = new Estudents();
                var fileName = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fName;
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        Site site = await _dataContext.Sites.FirstAsync(o => o.NameSite == "SEDE BELLAVISTA");
                        while (reader.Read())
                        {                            
                            _dataContext.Estudents.Add(new Estudents()
                            {
                                FullName = reader.GetValue(0).ToString(),
                                Document = Convert.ToInt64(reader.GetValue(1).ToString()),
                                Site = site
                                //Site =  _dataContext.Sites.FirstAsync(s => s.Id ==  (Convert.ToInt32(reader.GetValue(2).ToString())))
                            });
                        }
                        
                       await _dataContext.SaveChangesAsync();
                                            
                    }
                }
                return students;
            }
            catch (Exception e)
            {

                throw e;
            }
          
            
        }
    }
}
