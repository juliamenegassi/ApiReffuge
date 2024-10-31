using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<UsersModel> User { get; set; }
        public DbSet<AgendamentoModel> Agendamento { get; set; }
        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<ConteudoModel> Conteudo { get; set; }
        public DbSet<DiarioModel> Diario { get; set; }
        public DbSet<DuracaoSonoModel> DuracaoSono { get; set; }
        public DbSet<ExerciciosModel> Exercicios { get; set; }
        public DbSet<PlanosModel> Planos { get; set; }
        public DbSet<ProfissionalModel> Profissional { get; set; }
        public DbSet<TermometroEmocionalModel> TermometroEmocional { get; set; }
        public DbSet<TermometroNoturnoModel> TermometroNoturno { get; set; }
        public DbSet<TipoConteudoModel> TipoConteudo { get; set; }
        public DbSet<TipoEmocaoModel> TipoEmocao { get; set; }
        public DbSet<TipoEspecializacaoModel> TipoEspecializacao { get; set; }
        public DbSet<TipoExerciciosModel> TipoExercicios { get; set; }
        public DbSet<TipoSentimentoSonoModel> TipoSentimentoSono { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TipoSentimentoSonoMap());
            modelBuilder.ApplyConfiguration(new TipoExerciciosMap());
            modelBuilder.ApplyConfiguration(new TipoEspecializacaoMap());
            modelBuilder.ApplyConfiguration(new TipoEmocaoMap());
            modelBuilder.ApplyConfiguration(new TipoConteudoMap());
            modelBuilder.ApplyConfiguration(new TermometroNoturnoMap());
            modelBuilder.ApplyConfiguration(new TermometroEmocionalMap());
            modelBuilder.ApplyConfiguration(new ProfissionalMap());
            modelBuilder.ApplyConfiguration(new PlanosMap());
            modelBuilder.ApplyConfiguration(new ExerciciosMap());
            modelBuilder.ApplyConfiguration(new DuracaoSonoMap());
            modelBuilder.ApplyConfiguration(new DiarioMap());
            modelBuilder.ApplyConfiguration(new ConteudoMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new AgendamentoMap());
            modelBuilder.ApplyConfiguration(new UsersMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
