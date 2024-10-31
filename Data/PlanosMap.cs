using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class PlanosMap : IEntityTypeConfiguration<PlanosModel>
    {
        public void Configure(EntityTypeBuilder<PlanosModel> builder)
        {
            builder.HasKey(x => x.PlanosId);
            builder.Property(x => x.NomePlanos).IsRequired().HasMaxLength(255);
            builder.Property(x => x.PrecoPlanos).IsRequired();
            builder.Property(x => x.DescricaoPlanos).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DuracaoPlanos).IsRequired().HasMaxLength(255);
        }
    }
}
