using System;
using livraria.Contexto.Maps;
using livraria.Models;
using Microsoft.EntityFrameworkCore;

namespace livraria.Repositorio
{
    public class LivrariaContexto : DbContext
    {
        public LivrariaContexto(DbContextOptions<LivrariaContexto> options) : base (options) { }
            
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Aluguel> Alugueis { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LivroMap());
            modelBuilder.ApplyConfiguration(new AluguelMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());

            base.OnModelCreating(modelBuilder);
        }

        internal object Find(Guid codigo)
        {
            throw new NotImplementedException();
        }
    }
}
