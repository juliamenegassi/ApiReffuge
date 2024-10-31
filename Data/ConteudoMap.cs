using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class ConteudoMap : IEntityTypeConfiguration<ConteudoModel>
    {
        public void Configure(EntityTypeBuilder<ConteudoModel> builder)
        {
            builder.HasKey(x => x.ConteudoId);
            builder.Property(x => x.NomeConteudo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.TipoConteudoId).IsRequired();
        }
    }
}
