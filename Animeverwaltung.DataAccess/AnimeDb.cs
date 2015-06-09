using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animeverwaltung.DataAccess
{
    public class AnimeDb : DbContext
    {
        public DbSet<Anime> Anime { get; set; }
        public DbSet<Kategorie> Kategorie { get; set; }
        public DbSet<Typ> Typ { get; set; }
        public DbSet<Typenzuweisung> Typenzuweisung { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
