using livraria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace livraria.Contexto.Maps
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        { 
            builder.ToTable("livro", "livraria");
            builder.HasKey(x => x.Codigo);
            builder.Property(x => x.Codigo).HasColumnName("co_livro");
            builder.Property(x => x.Descricao).HasColumnName("ds_livro");
            builder.Property(x => x.Nome).HasColumnName("nm_livro");
            builder.Property(x => x.Autor).HasColumnName("au_livro");
        }
    }
}
