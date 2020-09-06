using Pae.web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pae.web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;

        public SeedDb(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRoles();
            await ChekPositionAsyn();
            await ChekSiteAsyn();
            await ChekAreaAsyn();
            await ChekExamTypeAsyn();
            await ChekEndowmentTypeAsyn();
            await ChekEpsAsyn();
            await ChekPensionAsyn();
            await ChekCajaCompAsyn();
            var manager = await CheckUserAsync(1117498993, "Luis Carlos", "Sanchez Cabrera", "luc0189@gmail.com",
                                                "Calle Luna Calle Sol", "3107957939", "Manager", true);

            await CheckManagerAsync(manager);



        }
        private async Task ChekEndowmentTypeAsyn()
        {
            if (!_dataContext.EndowmentsTypes.Any())
            {

                _dataContext.EndowmentsTypes.Add(new EndowmentType
                {

                    NameType = "Pantalones",
                    DateRegistro = DateTime.Now,
                    UserRegistra = "System",
                    EspirationDate = 6


                });

                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task ChekExamTypeAsyn()
        {
            if (!_dataContext.ExamsTypes.Any())
            {

                _dataContext.ExamsTypes.Add(new ExamsType
                {

                    Name = "Manipulacion De Alimentos",

                });

                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task ChekPositionAsyn()
        {
            if (!_dataContext.PositionEmployees.Any())
            {
                _dataContext.PositionEmployees.Add(new PositionEmployee
                {

                    Position = "Administrador"
                });
                _dataContext.PositionEmployees.Add(new PositionEmployee
                {

                    Position = "Jefe Sistemas"
                });
                _dataContext.PositionEmployees.Add(new PositionEmployee
                {

                    Position = "Gerente"
                });
                _dataContext.PositionEmployees.Add(new PositionEmployee
                {

                    Position = "Lider de Tienda"
                });

                await _dataContext.SaveChangesAsync();
            }
        }
        private async Task ChekSiteAsyn()
        {
            if (!_dataContext.SiteHeadquarters.Any())
            {
                _dataContext.SiteHeadquarters.Add(new SiteHeadquarters
                {

                    Nombre = "Administracion"
                });


                await _dataContext.SaveChangesAsync();
            }
        }
        private async Task ChekAreaAsyn()
        {
            if (!_dataContext.Areas.Any())
            {

                _dataContext.Areas.Add(new Area
                {

                    Nombre = "Sistemas",
                    SiteHeadquarters = await _context.SiteHeadquarters.FirstAsync(o => o.Nombre == "Administracion")
                });


                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task ChekEpsAsyn()
        {
            if (!_dataContext.Eps.Any())
            {
                _dataContext.Eps.Add(new Eps
                {

                    Nombre = "Coomeva"
                });


                await _dataContext.SaveChangesAsync();
            }
        }
        private async Task ChekPensionAsyn()
        {
            if (!_dataContext.Pensions.Any())
            {
                _dataContext.Pensions.Add(new Pension
                {

                    Nombre = "Porvenir"
                });


                await _dataContext.SaveChangesAsync();
            }
        }
        private async Task ChekCajaCompAsyn()
        {
            if (!_dataContext.CajaCompensacions.Any())
            {
                _dataContext.CajaCompensacions.Add(new CajaCompensacion
                {

                    Nombre = "Comfaca"
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

                    User = user
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
