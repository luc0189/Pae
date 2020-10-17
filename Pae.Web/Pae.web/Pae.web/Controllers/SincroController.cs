using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pae.web.Data;
using Pae.web.Data.Entities;
using Pae.web.Models;

namespace Pae.web.Controllers
{
    public class SincroController : Controller
    {
        SincroModel cn = new SincroModel();
        private readonly DataContext _context;
       

        public SincroController(DataContext context
            
            )
        {
            _context = context;
           
        }
        public async Task<IActionResult> Index()
        {

            return View(await _context.Sincros.ToListAsync());
        }



        public async Task<IActionResult> GetStudentList(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dateup = await _context.Sincros
                
                .FirstOrDefaultAsync(o => o.Id == id.Value);
            if (dateup == null)
            {
                return NotFound();
            }

            string fullUpdate = dateup.EndUpdate;
            Estudents students = new Estudents();
            try
            {

                var fileName = cn.StudentsServer(fullUpdate);
                if (fileName.Tables[0].Rows.Count > 0)
                {
                    int contadorSave = 0;
                    int contadorUpdate = 0;
                    foreach (DataRow dr in fileName.Tables[0].Rows)
                    {
                        //Muestras los valores obteniendolos con el Índice o el Nombre de la columna, 
                        //   de la siguiente manera:
                        string nOder = dr["NOrden"].ToString();
                        string doc = dr["Document"].ToString();
                        string fullName = dr["FullName"].ToString();
                        string acudienteName = dr["AcudienteName"].ToString();
                        string documentAcu = dr["DocumentAcu"].ToString();
                        string mesas = dr["Mesas"].ToString();
                        string jornada = dr["Jornada"].ToString();
                        string autDelivery = dr["AutDelivery"].ToString();
                        string sedes = dr["SedesId"].ToString();
                        string dateUpdate = dr["DateUpdate"].ToString();

                       
                        var exits = await _context.Estudents
                                        .Include(d => d.Sedes)
                                        .FirstOrDefaultAsync(s => s.Document == doc);

                        if (exits == null)
                        {
                            _context.Estudents.Add(new Estudents()
                            {
                                NOrden = nOder,
                                FullName = fullName,
                                Document = doc,
                                AcudienteName = acudienteName,
                                DocumentAcu = documentAcu,
                                Sedes = await _context.Sedes.FirstAsync(o => o.Id == Convert.ToInt32(sedes)),
                                Mesas = mesas,
                                AutDelivery = autDelivery,
                                Jornada = jornada,
                                FechaActualización=Convert.ToDateTime(dateUpdate)
                                //Site =  _dataContext.Sites.FirstAsync(s => s.Id ==  (Convert.ToInt32(reader.GetValue(2).ToString())))
                            }); contadorSave++;

                        }
                        else
                        {
                            if (Convert.ToDateTime(dateUpdate) > exits.FechaActualización )
                            {
                                exits.NOrden = $"{exits.NOrden}, {nOder}";
                                exits.Document = exits.Document;
                                exits.Sedes = await _context.Sedes.FirstAsync(o => o.Id == Convert.ToInt32(sedes));
                                exits.FullName = exits.FullName;
                                exits.AcudienteName = exits.AcudienteName;
                                exits.DocumentAcu = exits.DocumentAcu;

                                exits.AutDelivery = $"{exits.AutDelivery}, {autDelivery}";
                                exits.Mesas = $"{exits.Mesas}, {mesas}";
                                exits.Jornada = exits.Jornada;
                                exits.FechaActualización = Convert.ToDateTime(dateUpdate);
                                contadorUpdate++;
                                _context.Estudents.Update(exits);

                            }
                           
                            
                        }
                        
                    }
                    await _context.SaveChangesAsync();
                    ViewBag.Success = $"Se Encontraron {fileName.Tables[0].Rows.Count} Registros de los cuales {contadorSave} son Nuevos y {contadorUpdate} se actualizaron.";


                }
                else
                {
                    ViewBag.Success = $"No hay Registros Nuevos";
                }
                               
            }
            catch (Exception e)
            {
                ViewBag.Message = $"Excepcion no Controlada: {e.Message} mas detalles:{e.InnerException}";
                return View();

            }

            return View();

        }

    }
}
