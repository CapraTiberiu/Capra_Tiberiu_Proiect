using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Capra_Tiberiu_Proiect.Models;

namespace Capra_Tiberiu_Proiect.Data
{
    public class Capra_Tiberiu_ProiectContext : DbContext
    {
        public Capra_Tiberiu_ProiectContext (DbContextOptions<Capra_Tiberiu_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Capra_Tiberiu_Proiect.Models.Telefon> Telefon { get; set; }

        public DbSet<Capra_Tiberiu_Proiect.Models.Producator> Producator { get; set; }

        public DbSet<Capra_Tiberiu_Proiect.Models.Category> Category { get; set; }
    }
}
