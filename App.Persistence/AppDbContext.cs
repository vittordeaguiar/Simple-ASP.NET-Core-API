using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence
{
    /*
     * DbContext está relacionado ao banco de dados
     * É uma combinação de valores que permite acessar um banco de dados
     * Um DbSet representa as tabelas do banco de dados, que são passados/acessados através do LINQ
     */
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
        /*
         * Entidades que devem ser tabelas do banco de dados
         */
        public DbSet<Cidade> Cidade { get; set; } // Pegar valor e setar valor
        public DbSet<Pessoa> Pessoa { get; set; }
    }
}