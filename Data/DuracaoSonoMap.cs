using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class DuracaoSonoMap : IEntityTypeConfiguration<DuracaoSonoModel>
    {
        public void Configure(EntityTypeBuilder<DuracaoSonoModel> builder)
        {
            builder.HasKey(x => x.DuracaoSonoId);
            builder.Property(x => x.NomeDuracaoSono).IsRequired().HasMaxLength(255);
        }
    }
}
