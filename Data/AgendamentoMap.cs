using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class AgendamentoMap : IEntityTypeConfiguration<AgendamentoModel>
    {
        public void Configure(EntityTypeBuilder<AgendamentoModel> builder)
        {
            builder.HasKey(x => x.AgendamentoId);
            builder.Property(x => x.ClienteId).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DataHora).IsRequired();
            builder.Property(x => x.ProfissionalId).IsRequired();
        }
    }
}
