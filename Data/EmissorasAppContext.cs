using EmissorasApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EmissorasApp.Data
{
    public class EmissorasAppContext: DbContext
    {
        public EmissorasAppContext(): base("EmissorasAppContext")
        {

        }

        public DbSet<Emissora> Emissora { get; set; }

        public DbSet<Audiencia> Audiencia { get; set; }

        //Sobrescrita de método para Entity não criar tabelas com nome no plural
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}