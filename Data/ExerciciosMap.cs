using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class ExerciciosMap : IEntityTypeConfiguration<ExerciciosModel>
    {
        public void Configure(EntityTypeBuilder<ExerciciosModel> builder)
        {
            builder.HasKey(x => x.ExerciciosId);
            builder.Property(x => x.NomeExercicios).IsRequired().HasMaxLength(255);
            builder.Property(x => x.TipoExerciciosId).IsRequired();
        }
    }
}
