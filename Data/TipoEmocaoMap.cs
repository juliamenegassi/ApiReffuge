using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class TipoEmocaoMap : IEntityTypeConfiguration<TipoEmocaoModel>
    {
        public void Configure(EntityTypeBuilder<TipoEmocaoModel> builder)
        {
            builder.HasKey(x => x.TipoEmocaoId);
            builder.Property(x => x.NomeTipoEmocao).IsRequired().HasMaxLength(255);
        }
    }
}
