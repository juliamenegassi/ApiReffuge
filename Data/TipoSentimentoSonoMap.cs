using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class TipoSentimentoSonoMap : IEntityTypeConfiguration<TipoSentimentoSonoModel>
    {
        public void Configure(EntityTypeBuilder<TipoSentimentoSonoModel> builder)
        {
            builder.HasKey(x => x.TipoSentimentoSonoId);
            builder.Property(x => x.NomeTipoSentimentoSono).IsRequired().HasMaxLength(255);
        }
    }
}
