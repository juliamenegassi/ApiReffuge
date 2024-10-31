using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class TermometroEmocionalMap : IEntityTypeConfiguration<TermometroEmocionalModel>
    {
        public void Configure(EntityTypeBuilder<TermometroEmocionalModel> builder)
        {
            builder.HasKey(x => x.TermometroEmocionalId);
            builder.Property(x => x.TipoEmocaoId).IsRequired();
            builder.Property(x => x.ClienteId).IsRequired();
            builder.Property(x => x.Data).IsRequired();
        }
    }
}
