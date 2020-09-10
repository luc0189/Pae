using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pae.web.Models;

namespace Pae.web.Controllers
{
    public class UploadStudentController : Controller
    {
        [HttpGet]
        public IActionResult Index(List<UploadStudentViewModel> students=null)
        {
            students = students == null ? new List<UploadStudentViewModel>() : students;

            return View(students);
        }
        [HttpPost]
        public  IActionResult Index (IFormFile file,[FromServices] IHostingEnvironment hostingEnvironment)
        {
            string fileName = $"{hostingEnvironment.WebRootPath}\\files\\{file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            var students = this.GetStudentList(file.FileName);
            return Index(students);
        }


        private List<UploadStudentViewModel> GetStudentList(string fName)
        {
            try
            {
                List<UploadStudentViewModel> students = new List<UploadStudentViewModel>();
                var fileName = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fName;
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        while (reader.Read())
                        {
                            students.Add(new UploadStudentViewModel()
                            {
                                FullName = reader.GetValue(0).ToString(),
                                Document = Convert.ToInt64(reader.GetValue(1).ToString()),
                                Site = Convert.ToInt32(reader.GetValue(2).ToString())
                            });
                        }
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
