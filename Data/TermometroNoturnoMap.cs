using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class TermometroNoturnoMap : IEntityTypeConfiguration<TermometroNoturnoModel>
    {
        public void Configure(EntityTypeBuilder<TermometroNoturnoModel> builder)
        {
            builder.HasKey(x => x.TermometroNoturnoId);
            builder.Property(x => x.Data).IsRequired();
            builder.Property(x => x.DuracaoSonoId).IsRequired();
            builder.Property(x => x.VezesAcordou).IsRequired();
            builder.Property(x => x.TipoSentimentoSonoId).IsRequired();
            builder.Property(x => x.ClienteId).IsRequired();
        }
    }
}