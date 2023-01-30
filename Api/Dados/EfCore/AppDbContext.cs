using Api.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Api.Dados.EfCore
{
    public class AppDbContext : DbContext
    {
        public DbSet<Feriado> Feriados { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> opcoes) : base(opcoes)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Feriado>()
                .HasIndex(f => f.Titulo)
                .IsUnique();
        }


    }
}
