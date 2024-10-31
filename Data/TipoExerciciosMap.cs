using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class TipoExerciciosMap : IEntityTypeConfiguration<TipoExerciciosModel>
    {
        public void Configure(EntityTypeBuilder<TipoExerciciosModel> builder)
        {
            builder.HasKey(x => x.TipoExerciciosId);
            builder.Property(x => x.NomeTipoExercicios).IsRequired().HasMaxLength(255);
        }
    }
}
