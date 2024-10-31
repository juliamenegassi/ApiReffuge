using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class TipoConteudoMap : IEntityTypeConfiguration<TipoConteudoModel>
    {
        public void Configure(EntityTypeBuilder<TipoConteudoModel> builder)
        {
            builder.HasKey(x => x.TipoConteudoId);
            builder.Property(x => x.NomeTipoConteudo).IsRequired().HasMaxLength(255);
        }
    }
}
