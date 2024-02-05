using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
         public ApplicationDBContext(DbContextOptions dbContextOptions)
       :base(dbContextOptions)
       {

       }

       public DbSet<Empleados> empleado { get; set;}

       public DbSet<Maquinaria> Maquinaria { get; set;}
    }
}