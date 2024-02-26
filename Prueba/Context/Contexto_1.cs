using Microsoft.EntityFrameworkCore;
using Prueba.Models;
using System.Data;

namespace Prueba.Context
{
    public class Contexto_1:DbContext
    {
        public Contexto_1(DbContextOptions<Contexto_1> contextOptions):base(contextOptions)
        {

        }

        public DbSet<Coche> Coche { get; set; }
        public DbSet<Dueno> Dueno { get; set; }
    }
}
