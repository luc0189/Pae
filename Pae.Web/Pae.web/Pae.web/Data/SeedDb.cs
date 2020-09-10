using Microsoft.EntityFrameworkCore;
using Pae.web.Data.Entities;
using Pae.web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pae.web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext dataContext,
            IUserHelper userHelper)
        {
            _dataContext = dataContext;
            _userHelper = userHelper;
        }
        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRoles();
            await ChekIntitucionAsyn();
            await ChekSiteAsyn();
            //await ChekStudentAsyn();
         
  
            var manager = await CheckUserAsync(1117498993, "Luis Carlos", "Sanchez Cabrera", "luc0189@gmail.com",
                                                "Calle Luna Calle Sol", "3107957939", "Manager", true);

            await CheckManagerAsync(manager);



        }
      

        private async Task ChekIntitucionAsyn()
        {
            if (!_dataContext.Institucions.Any())
            {
                _dataContext.Institucions.Add(new Institucion
                {

                    NameIntitucion = "IE AGROECOLOGICO AMAZONICO BUINAIMA"
                });
                _dataContext.Institucions.Add(new Institucion
                {

                    NameIntitucion = "IE AGROINDUSTRIAL DE LA AMAZONIA"
                });
                _dataContext.Institucions.Add(new Institucion
                {

                    NameIntitucion = "IE ANTONIO RICAURTE "
                });
                _dataContext.Institucions.Add(new Institucion
                {

                    NameIntitucion = "IE BARRIOS UNIDOS DEL SUR"
                });
                _dataContext.Institucions.Add(new Institucion
                {

                    NameIntitucion = "IE BELLO HORIZONTE"
                }); _dataContext.Institucions.Add(new Institucion
                {

                    NameIntitucion = "IE CIUDADELA SIGLO XXI "
                }); _dataContext.Institucions.Add(new Institucion
                {

                    NameIntitucion = "IE DIVINO NIÑO"
                }); _dataContext.Institucions.Add(new Institucion
                {

                    NameIntitucion = "IE JORGE ELIECER GAITAN"
                }); _dataContext.Institucions.Add(new Institucion
                {

                    NameIntitucion = "IE JUAN BAUTISTA LA SALLE"
                }); _dataContext.Institucions.Add(new Institucion
                {

                    NameIntitucion = "IE JUAN BAUTISTA MIGANI"
                }); _dataContext.Institucions.Add(new Institucion
                {

                    NameIntitucion = "IE LA ESPERANZA"
                }); _dataContext.Institucions.Add(new Institucion
                {

                    NameIntitucion = "IE LA SALLE"
                }); _dataContext.Institucions.Add(new Institucion
                {

                    NameIntitucion = "IE LOS ANDES "
                }); _dataContext.Institucions.Add(new Institucion
                {

                    NameIntitucion = "IE LOS PINOS"
                }); _dataContext.Institucions.Add(new Institucion
                {

                    NameIntitucion = "IE NORMAL SUPERIOR"
                }); _dataContext.Institucions.Add(new Institucion
                {

                    NameIntitucion = "IE SAGRADOS CORAZONES"
                }); _dataContext.Institucions.Add(new Institucion
                {

                    NameIntitucion = "IE SAN FRANCISCO DE ASIS"
                }); _dataContext.Institucions.Add(new Institucion
                {

                    NameIntitucion = "IE TECNICO INDUSTRIAL"
                }); _dataContext.Institucions.Add(new Institucion
                {

                    NameIntitucion = "IE LOS PINOS"
                });
                await _dataContext.SaveChangesAsync();
            }
        }
        private async Task ChekSiteAsyn()
        {
            if (!_dataContext.Sites.Any())
            {
                _dataContext.Sites.Add(new Site
                {

                    NameSite = "SEDE BELLAVISTA",
                    Institucion = await _dataContext.Institucions.FirstAsync(o => o.NameIntitucion == "IE AGROINDUSTRIAL DE LA AMAZONIA")


                });


                await _dataContext.SaveChangesAsync();
            }
        }
        private async Task ChekStudentAsyn()
        {
            if (!_dataContext.Estudents.Any())
            {

                _dataContext.Estudents.Add(new Estudents
                {

                    Document = 1117523911,
                    FullName = "SNEIDER  VEGA PALOMARES",
                    //Mesa = "Mesa 1",
                    Site = await _dataContext.Sites.FirstAsync(o => o.NameSite == "SEDE BELLAVISTA")


                });
                _dataContext.Estudents.Add(new Estudents
                {

                    Document = 1117935724,
                    FullName = "DIYER ESNEIDER LOPEZ VARGAS",
                    //Mesa = "Mesa 2",
                    Site = await _dataContext.Sites.FirstAsync(o => o.NameSite == "SEDE BELLAVISTA")


                });

                await _dataContext.SaveChangesAsync();
            }
        }


        private async Task CheckManagerAsync(Users user)
        {
            if (!_dataContext.Managers.Any())
            {
                _dataContext.Managers.Add(new Manager
                {

                    Users = user
                });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task<Users> CheckUserAsync(
            int document,
            string firstName,
            string lastName,
            string email,
            string address,
            string movil,
            string role,
             bool activo

            )
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new Users
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = movil,
                    Movil = movil,
                    Address = address,
                    Document = document,
                    DateRegistro = DateTime.Today,
                    Activo = activo,


                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, role);
                var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);
            }

            return user;
        }


        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Manager");
            await _userHelper.CheckRoleAsync("Recursoshumanos");
            await _userHelper.CheckRoleAsync("purchasing");
            await _userHelper.CheckRoleAsync("StoreLeader");
            await _userHelper.CheckRoleAsync("UserApp");

        }


    }
}
