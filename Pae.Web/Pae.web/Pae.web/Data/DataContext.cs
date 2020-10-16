using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pae.web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pae.web.Data
{
    public class DataContext :IdentityDbContext<Users>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
      
        public DbSet<Periodos> Periodos { get; set; }
        public DbSet<DetailsDelivery> DetailsDeliveries { get; set; }
        public DbSet<DeliveryActa> DeliveryActas { get; set; }
        public DbSet<Estudents> Estudents { get; set; }
        public DbSet<Institucion> Institucions { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Sedes> Sedes { get; set; }
        public DbSet<Sincro> Sincros { get; set; }
       
    }
}
