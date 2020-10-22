using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

            try
            {

                var fileName = cn.StudentsServer(fullUpdate);
                if (fileName.Tables[0].Rows.Count > 0)
                {
                    int contadorSave = 0;
                    int contadorUpdate = 0;

                    var studentIds = _context.Estudents.Select(t => t.Document).ToList();

                    List<Estudents> newEstudents = new List<Estudents>();

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

                        bool exits = studentIds.Any(t => t == doc);

                        if (!exits)
                        {
                            Estudents newEstudent = new Estudents()
                            {
                                NOrden = nOder,
                                FullName = fullName,
                                Document = doc,
                                AcudienteName = acudienteName,
                                DocumentAcu = documentAcu,
                                
                                Sedes = await _context.Sedes.FindAsync(Convert.ToInt32(sedes)),
                                Mesas = mesas,
                                AutDelivery = autDelivery,
                                Jornada = jornada,
                                FechaActualización = Convert.ToDateTime(dateUpdate)

                            };

                            newEstudents.Add(newEstudent);
                            contadorSave++;
                        }
                        else
                        {
                            Estudents updatedEstudent = await _context.Estudents.SingleAsync(t => t.Document == doc);
                            if (Convert.ToDateTime(dateUpdate) > updatedEstudent.FechaActualización)
                            {
                                updatedEstudent.NOrden = $"{updatedEstudent.NOrden}, {nOder}";
                                updatedEstudent.Document = updatedEstudent.Document;
                                updatedEstudent.Sedes = await _context.Sedes.FindAsync(Convert.ToInt32(sedes));
                                updatedEstudent.FullName = updatedEstudent.FullName;
                                updatedEstudent.AcudienteName = updatedEstudent.AcudienteName;
                                updatedEstudent.DocumentAcu = updatedEstudent.DocumentAcu;
                                updatedEstudent.AutDelivery = $"{updatedEstudent.AutDelivery}, {autDelivery}";
                                updatedEstudent.Mesas = $"{updatedEstudent.Mesas}, {mesas}";
                                updatedEstudent.Jornada = updatedEstudent.Jornada;
                                updatedEstudent.FechaActualización = Convert.ToDateTime(dateUpdate);
                                contadorUpdate++;
                                _context.Estudents.Update(updatedEstudent);
                            }
                        }

                    }

                    if (newEstudents.Any())
                    {
                        _context.Estudents.AddRange(newEstudents);
                    }

                    await _context.SaveChangesAsync();

                    ViewBag.Message = $"Se Encontraron {fileName.Tables[0].Rows.Count} Registros de los cuales {contadorSave} son Nuevos y {contadorUpdate} se actualizaron.";


                }
                else
                {
                    ViewBag.Message = $"No hay Registros Nuevos";
                }
                return RedirectToAction($"Index");
            }
            catch (Exception e)
            {
                ViewBag.Message = $"Exeption: {e.Message}";
                return RedirectToAction($"Index");

            }



        }
        public async Task<IActionResult> GetInstitucionList(int? id)
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

            try
            {

                var fileName = cn.InstitucionServer(fullUpdate);
                if (fileName.Tables[0].Rows.Count > 0)
                {
                    int contadorSave = 0;
                    int contadorUpdate = 0;
                    foreach (DataRow dr in fileName.Tables[0].Rows)
                    {

                        string fullName = dr["NameIntitucion"].ToString();
                        string ids = dr["Idins"].ToString();
                        string dateUpdate = dr["FechaActualización"].ToString();

                        var exits = await _context.Institucions
                                   .FirstOrDefaultAsync(s => s.IdIns == ids);

                        if (exits == null)
                        {
                            _context.Institucions.Add(new Institucion()
                            {
                                NameIntitucion = fullName,
                                IdIns=ids,
                                FechaActualización = Convert.ToDateTime(dateUpdate)

                            }); contadorSave++;
                            await _context.SaveChangesAsync();

                        }
                        else
                        {
                            if (Convert.ToDateTime(dateUpdate) > exits.FechaActualización)
                            {

                                exits.NameIntitucion = fullName;
                                exits.FechaActualización = Convert.ToDateTime(dateUpdate);
                                contadorUpdate++;
                                _context.Institucions.Update(exits);
                                await _context.SaveChangesAsync();
                            }


                        }

                    }
                   
                    return ViewBag.Success = $"Se Encontraron {fileName.Tables[0].Rows.Count} Registros de los cuales {contadorSave} son Nuevos y {contadorUpdate} se actualizaron.";


                }
                else
                {
                    ViewBag.Success = $"No hay Registros Nuevos";
                }
                return RedirectToAction($"Index");
            }
            catch (Exception e)
            {

                ViewBag.Message = $"Excepcion no Controlada: {e.Message} mas detalles:{e.InnerException}";
                return RedirectToAction($"Index");
            }



        }
        public async Task<IActionResult> GetSedesList(int? id)
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

            try
            {

                var fileName = cn.SedesServer(fullUpdate);
                if (fileName.Tables[0].Rows.Count > 0)
                {
                    int contadorSave = 0;
                    int contadorUpdate = 0;
                    foreach (DataRow dr in fileName.Tables[0].Rows)
                    {

                        string fullName = dr["NameSedes"].ToString();
                        string idSede = dr["IdSede"].ToString();
                        string dateUpdate = dr["FechaActualización"].ToString();
                        int idInstitucion = Convert.ToInt32(dr["InstitucionId"]);
                        var exits = await _context.Sedes
                                   .FirstOrDefaultAsync(s => s.IdSedes == idSede);

                        if (exits == null)
                        {
                            _context.Sedes.Add(new Sedes()
                            {
                                NameSedes = fullName,
                                IdSedes=idSede,
                                FechaActualización = Convert.ToDateTime(dateUpdate),
                                Institucion = await _context.Institucions.FindAsync(idInstitucion)


                            }); contadorSave++;

                        }
                        else
                        {
                            if (Convert.ToDateTime(dateUpdate) > exits.FechaActualización)
                            {

                                exits.NameSedes = fullName;
                                exits.IdSedes = idSede;
                                exits.FechaActualización = Convert.ToDateTime(dateUpdate);
                                exits.Institucion = await _context.Institucions.FindAsync(Convert.ToInt32(idSede));
                                contadorUpdate++;
                                _context.Sedes.Update(exits);

                            }


                        }

                    }
                    await _context.SaveChangesAsync();
                    return ViewBag.Success = $"Se Encontraron {fileName.Tables[0].Rows.Count} Registros de los cuales {contadorSave} son Nuevos y {contadorUpdate} se actualizaron.";


                }
                else
                {
                    ViewBag.Success = $"No hay Registros Nuevos";
                }
                return RedirectToAction($"Index");
            }
            catch (Exception e)
            {

                ViewBag.Message = $"Excepcion no Controlada: {e.Message} mas detalles:{e.InnerException}";
                return RedirectToAction($"Index");
            }



        }
        public async Task<IActionResult> GetActasList(int? id)
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

            try
            {

                var fileName = cn.ActasServer(fullUpdate);

                if (fileName.Tables[0].Rows.Count > 0)
                {
                    int contadorSave = 0;
                    int contadorUpdate = 0;
                    var localDeliveryActas = _context.DeliveryActas.ToList();

                    List<DeliveryActa> newDeliveryActas = new List<DeliveryActa>();

                    foreach (DataRow dr in fileName.Tables[0].Rows)
                    {
                        string entrega3 = dr["Entrega3"].ToString();
                        string entrega4 = dr["Entrega4"].ToString();
                        string entrega5 = dr["Entrega5"].ToString();
                        string entrega6 = dr["Entrega6"].ToString();
                        string entrega7 = dr["Entrega7"].ToString();
                        string doc = dr["Document"].ToString();
                        int idStudent = Convert.ToInt32(dr["EstudentsId"]);
                        
                        
                        string dateUpdate = dr["FechaActualización"].ToString();
                        string prefix = dr["Prefix"].ToString();
                        int numSequence = Convert.ToInt32(dr["PrefixSequence"]);

                        //var exits = await _context.DeliveryActas 
                        //            .Include(es => es.Estudents)
                        //           .FirstOrDefaultAsync(s => s.Prefix == prefix && s.PrefixSequence == Convert.ToInt32(numSequence));

                        DeliveryActa newOrUpdatedDeliveryActa = null;

                        newOrUpdatedDeliveryActa = localDeliveryActas.SingleOrDefault(t => t.Prefix == prefix && t.PrefixSequence == numSequence);

                        if (newOrUpdatedDeliveryActa == null)
                        {
                            newOrUpdatedDeliveryActa = new DeliveryActa()
                            {
                                Entrega3 = Convert.ToBoolean(entrega3),
                                Entrega4 = Convert.ToBoolean(entrega4),
                                Entrega5 = Convert.ToBoolean(entrega5),
                                Entrega6 = Convert.ToBoolean(entrega6),
                                Entrega7 = Convert.ToBoolean(entrega7),
                                Estudents= await _context.Estudents.FindAsync(doc),
                                Prefix = prefix,
                                PrefixSequence= numSequence,
                                FechaActualización = Convert.ToDateTime(dateUpdate)
                            };

                            _context.DeliveryActas.Add(newOrUpdatedDeliveryActa);
                            await _context.SaveChangesAsync();
                            contadorSave++;
                        }
                        else
                        {

                            if (Convert.ToDateTime(dateUpdate) > newOrUpdatedDeliveryActa.FechaActualización)
                            {
                                newOrUpdatedDeliveryActa.FechaActualización = Convert.ToDateTime(dateUpdate);
                                contadorUpdate++;
                            }
                        }
                    }

                    await _context.SaveChangesAsync();
                    return ViewBag.Success = $"Se Encontraron {fileName.Tables[0].Rows.Count} Registros de los cuales {contadorSave} son Nuevos y {contadorUpdate} se actualizaron.";


                }
                else
                {
                    ViewBag.Success = $"No hay Registros Nuevos";
                }
                return RedirectToAction($"Index");
            }
            catch (Exception e)
            {

                ViewBag.Message = $"Excepcion no Controlada: {e.Message} mas detalles:{e.InnerException}";
                return RedirectToAction($"Index");
            }



        }
        public async Task<IActionResult> PostStudentList(int? id)
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

            DateTime fullUpdate = Convert.ToDateTime(dateup.EndUpdate);

            try
            {

                var fileName = _context.Estudents
                                      .Where(s => s.FechaActualización > fullUpdate)
                                      .ToList();



                if (fileName.Count > 0)
                {
                    int contadorSave = 0;
                    int contadorUpdate = 0;

                  var studentIds = cn.StudentsServer(fullUpdate.ToString());
                    DataRow[] foundRows;
                  
                    List<Estudents> newEstudents = new List<Estudents>();
                  
                       
                        foreach (var drs in fileName)
                        {
                            //Muestras los valores obteniendolos con el Índice o el Nombre de la columna, 
                            //   de la siguiente manera:
                            string rnOder = drs.NOrden;

                            string rdoc = drs.Document;
                            string rfullName = drs.FullName;
                            string racudienteName = drs.AcudienteName;
                            string rdocumentAcu = drs.DocumentAcu;
                            string rmesas = drs.Mesas;
                            string rjornada = drs.Jornada;
                            string rautDelivery = drs.AutDelivery;
                            string rsedes = Convert.ToString(drs.Sedes);
                            DateTime rdateUpdate = drs.FechaActualización;


                        foundRows = studentIds.Tables[0].Select($"Document = '{rdoc}'");
                        if (foundRows==null)
                                {
                            Estudents newEstudent = new Estudents()
                            {
                                NOrden = rnOder,
                                FullName = rfullName,
                                Document = rdoc,
                                AcudienteName = racudienteName,
                                DocumentAcu = rdocumentAcu,
                                Sedes = await _context.Sedes.FindAsync(Convert.ToInt32(rsedes)),
                                Mesas = rmesas,
                                AutDelivery = rautDelivery,
                                Jornada = rjornada,
                                FechaActualización = Convert.ToDateTime(rdateUpdate)

                            };
                            newEstudents.Add(newEstudent);
                            contadorSave++;
                        }

                           
                            else
                            {
                                Estudents updatedEstudent = await _context.Estudents.SingleAsync(t => t.Document == rdoc);
                                if (Convert.ToDateTime(rdateUpdate) > updatedEstudent.FechaActualización)
                                {
                                    updatedEstudent.NOrden = $"{updatedEstudent.NOrden}, {rnOder}";
                                    updatedEstudent.Document = updatedEstudent.Document;
                                    updatedEstudent.Sedes = await _context.Sedes.FindAsync(Convert.ToInt32(rsedes));
                                    updatedEstudent.FullName = updatedEstudent.FullName;
                                    updatedEstudent.AcudienteName = updatedEstudent.AcudienteName;
                                    updatedEstudent.DocumentAcu = updatedEstudent.DocumentAcu;
                                    updatedEstudent.AutDelivery = $"{updatedEstudent.AutDelivery}, {rautDelivery}";
                                    updatedEstudent.Mesas = $"{updatedEstudent.Mesas}, {rmesas}";
                                    updatedEstudent.Jornada = updatedEstudent.Jornada;
                                    updatedEstudent.FechaActualización = Convert.ToDateTime(rdateUpdate);
                                    contadorUpdate++;
                                    _context.Estudents.Update(updatedEstudent);
                                }
                            }

                        }

                 


                    if (newEstudents.Any())
                    {
                        _context.Estudents.AddRange(newEstudents);
                    }

                    await _context.SaveChangesAsync();

                    //ViewBag.Message = $"Se Encontraron {fileName.Tables[0].Rows.Count} Registros de los cuales {contadorSave} son Nuevos y {contadorUpdate} se actualizaron.";


                }
                else
                {
                    ViewBag.Message = $"No hay Registros Nuevos";
                }
                return RedirectToAction($"Index");
            }
            catch (Exception e)
            {
                string mensaje = "<script type='text/javascript'>alert('{0}')</script>";

                mensaje = string.Format(mensaje, $"Hola: {e.Message}");
             

                ViewBag.Message = $"Exeption: {e.Message}";
                return RedirectToAction($"Index");

            }



        }
        public async Task<IActionResult> PostActas(int? id)
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

            DateTime fullUpdate = Convert.ToDateTime(dateup.EndUpdate);

            try
            {

                var fileName = _context.DeliveryActas
                                      .Where(s => s.FechaActualización > fullUpdate)
                                      .ToList();



                if (fileName.Count > 0)
                {
                    int contadorSave = 0;
                    int contadorUpdate = 0;

                    var remoteDeliveryActas = cn.ActasServer(fullUpdate.ToString());
                    DataRow[] foundRows;

                    List<DeliveryActa> newActas = new List<DeliveryActa>();


                    foreach (var drs in fileName)
                    {
                        //Muestras los valores obteniendolos con el Índice o el Nombre de la columna, 
                        //   de la siguiente manera:
                        bool entrega3 = drs.Entrega3;
                        bool entrega4 = drs.Entrega4;
                        bool entrega5 = drs.Entrega5;
                        bool entrega6 = drs.Entrega6;
                        bool entrega7 = drs.Entrega7;
                        int studentId = drs.Estudents.Id;
                        DateTime dataUpdate = drs.FechaActualización;
                        string prefix = drs.Prefix;
                        int prefixSequence = drs.PrefixSequence;


                        foundRows = remoteDeliveryActas.Tables[0].Select($"Prefix = '{prefix}'&& prefixSequence ='{prefixSequence}' ");
                       

                     

                        if (foundRows == null)
                        {
                            DeliveryActa newActa = new DeliveryActa()
                            {
                               
                                FechaActualización = Convert.ToDateTime(dataUpdate)

                            };
                            newActas.Add(newActa);
                            contadorSave++;
                        }


                        else
                        {
                            //Estudents updatedEstudent = await _context.Estudents.SingleAsync(t => t.Document == rdoc);
                            //if (Convert.ToDateTime(dataUpdate) > updatedEstudent.FechaActualización)
                            //{
                            //    updatedEstudent.NOrden = $"{updatedEstudent.NOrden}, {rnOder}";
                            //    updatedEstudent.Document = updatedEstudent.Document;
                            //    updatedEstudent.Sedes = await _context.Sedes.FindAsync(Convert.ToInt32(rsedes));
                            //    updatedEstudent.FullName = updatedEstudent.FullName;
                            //    updatedEstudent.AcudienteName = updatedEstudent.AcudienteName;
                            //    updatedEstudent.DocumentAcu = updatedEstudent.DocumentAcu;
                            //    updatedEstudent.AutDelivery = $"{updatedEstudent.AutDelivery}, {rautDelivery}";
                            //    updatedEstudent.Mesas = $"{updatedEstudent.Mesas}, {rmesas}";
                            //    updatedEstudent.Jornada = updatedEstudent.Jornada;
                            //    updatedEstudent.FechaActualización = Convert.ToDateTime(rdateUpdate);
                            //    contadorUpdate++;
                            //    _context.Estudents.Update(updatedEstudent);
                            //}
                        }

                    }




                    if (newActas.Any())
                    {
                        _context.DeliveryActas.AddRange(newActas);
                    }

                    await _context.SaveChangesAsync();

                    //ViewBag.Message = $"Se Encontraron {fileName.Tables[0].Rows.Count} Registros de los cuales {contadorSave} son Nuevos y {contadorUpdate} se actualizaron.";


                }
                else
                {
                    ViewBag.Message = $"No hay Registros Nuevos";
                }
                return RedirectToAction($"Index");
            }
            catch (Exception e)
            {
                string mensaje = "<script type='text/javascript'>alert('{0}')</script>";

                mensaje = string.Format(mensaje, $"Hola: {e.Message}");


                ViewBag.Message = $"Exeption: {e.Message}";
                return RedirectToAction($"Index");

            }



        }
    }
}
