using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class DiarioMap : IEntityTypeConfiguration<DiarioModel>
    {
        public void Configure(EntityTypeBuilder<DiarioModel> builder)
        {
            builder.HasKey(x => x.DiarioId);
            builder.Property(x => x.DataHorario).IsRequired();
            builder.Property(x => x.ConteudoDiario).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ClienteId).IsRequired();
        }
    }
}
