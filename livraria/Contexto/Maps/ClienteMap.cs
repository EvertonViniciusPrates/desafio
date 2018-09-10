using livraria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace livraria.Contexto.Maps
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("cliente", "livraria");
            builder.HasKey(x => x.Codigo);
            builder.Property(x => x.Codigo).HasColumnName("co_cliente");
            builder.Property(x => x.Nome).HasColumnName("nm_cliente");
            builder.Property(x => x.Cpf).HasColumnName("cpf_cliente");
            builder.Property(x => x.DataDeNascimento).HasColumnName("dtn_cliente");
        }
    }
}
