using livraria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace livraria.Contexto.Maps
{
    public class AluguelMap : IEntityTypeConfiguration<Aluguel>
    {
        public void Configure(EntityTypeBuilder<Aluguel> builder)
        {
            builder.ToTable("aluguel", "livraria");

            builder.HasKey(x => x.Codigo);

            builder.Property(x => x.Codigo).HasColumnName("co_aluguel");
            builder.Property(x => x.Status).HasColumnName("st_aluguel");
            builder.Property(x => x.DataDeEntrega).HasColumnName("de_aluguel");
            builder.Property(x => x.DataDeRetirada).HasColumnName("dr_aluguel");

            builder.Property(y => y.LivroId).HasColumnName("co_livro");
            builder.HasOne(z => z.Livro).WithMany().HasForeignKey(z => z.LivroId).IsRequired();

            builder.Property(y => y.ClienteId).HasColumnName("co_cliente");
            builder.HasOne(z => z.Cliente).WithMany().HasForeignKey(z => z.ClienteId).IsRequired();


        }
    }
}
