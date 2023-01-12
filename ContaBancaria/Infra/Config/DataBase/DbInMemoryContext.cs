using Microsoft.EntityFrameworkCore;
using ContaBancaria.Infra.Entities;

namespace ContaBancaria.Infra.Config.Database
{
    public class DbInMemoryContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ContaBancariaDb");
        }

        public DbSet<Conta> Contas { get; set; }
        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Pessoa> Titulares { get; set; }
        public DbSet<Juridica> Juridicas { get; set; }
        public DbSet<Fisica> Fisicas { get; set; }
    }
}