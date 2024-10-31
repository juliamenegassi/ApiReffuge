using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class TipoEspecializacaoMap : IEntityTypeConfiguration<TipoEspecializacaoModel>
    {
        public void Configure(EntityTypeBuilder<TipoEspecializacaoModel> builder)
        {
            builder.HasKey(x => x.TipoEspecializacaoId);
            builder.Property(x => x.NomeTipoEspecializacao).IsRequired().HasMaxLength(255);
        }
    }
}
