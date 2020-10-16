﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pae.web.Data;
using Pae.web.Data.Entities;

namespace Pae.web.Controllers
{
    public class SincroController : Controller
    {
        private readonly DataContext _context;
        public SincroController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View();
        }
        private async Task<Estudents> GetStudentList(string fName)
        {
            Estudents students = new Estudents();
            //try
            //{

            //    var fileName = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fName;
            //    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //    using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            //    {
            //        using (var reader = ExcelReaderFactory.CreateReader(stream))
            //        {
            //            int contadorSave = 0;
            //            int contadorUpdate = 0;

            //            while (reader.Read())
            //            {
            //                string autorized = reader.GetValue(7).ToString();
            //                string mesa = reader.GetValue(6).ToString();
            //                string nOder = reader.GetValue(0).ToString();
            //                string doc = reader.GetValue(2).ToString();
            //                var exits = await _dataContext.Estudents
            //                                .Include(d => d.Sedes)
            //                                .FirstOrDefaultAsync(s => s.Document == doc);

            //                if (exits == null)
            //                {
            //                    _dataContext.Estudents.Add(new Estudents()
            //                    {
            //                        NOrden = reader.GetValue(0).ToString(),
            //                        FullName = reader.GetValue(1).ToString(),
            //                        Document = reader.GetValue(2).ToString(),
            //                        AcudienteName = reader.GetValue(3).ToString(),
            //                        DocumentAcu = reader.GetValue(4).ToString(),
            //                        Sedes = await _dataContext.Sedes.FirstAsync(o => o.NameSedes == reader.GetValue(5).ToString()),
            //                        Mesas = mesa,
            //                        AutDelivery = autorized,
            //                        Jornada = reader.GetValue(8).ToString()
            //                        //Site =  _dataContext.Sites.FirstAsync(s => s.Id ==  (Convert.ToInt32(reader.GetValue(2).ToString())))
            //                    }); contadorSave++;
            //                }
            //                else
            //                {
            //                    exits.NOrden = $"{exits.NOrden}, {nOder}";
            //                    exits.Document = exits.Document;
            //                    exits.Sedes = await _dataContext.Sedes.FirstAsync(o => o.NameSedes == reader.GetValue(5).ToString());
            //                    exits.FullName = exits.FullName;
            //                    exits.AcudienteName = exits.AcudienteName;
            //                    exits.DocumentAcu = exits.DocumentAcu;

            //                    exits.AutDelivery = $"{exits.AutDelivery}, {autorized}";
            //                    exits.Mesas = $"{exits.Mesas}, {mesa}";
            //                    exits.Jornada = exits.Jornada;
            //                    contadorUpdate++;
            //                    _dataContext.Estudents.Update(exits);


            //                }

            //                await _dataContext.SaveChangesAsync();

            //            }


            //            ViewBag.Success = $"Se Encontraron {reader.RowCount} Registros de los cuales {contadorSave} son Nuevos y {contadorUpdate} se actualizaron.";
            //        }
            //    }

            //    return students;
            //}
            //catch (Exception e)
            //{
            //    ViewBag.Message = $"Excepcion no Controlada: {e.Message} mas detalles:{e.InnerException}";

            //}

            return students;

        }

    }
}
