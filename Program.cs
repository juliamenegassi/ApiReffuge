using Api.Data;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<Contexto>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
    );

builder.Services.AddScoped <IUsersRepositorio, UsersRepositorio>();
builder.Services.AddScoped<IAgendamentoRepositorio, AgendamentoRepositorio>();
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<IConteudoRepositorio, ConteudoRepositorio>();
builder.Services.AddScoped<IDiarioRepositorio, DiarioRepositorio>();
builder.Services.AddScoped<IDuracaoSonoRepositorio, DuracaoSonoRepositorio>();
builder.Services.AddScoped<IExerciciosRepositorio, ExerciciosRepositorio>();
builder.Services.AddScoped<IPlanosRepositorio, PlanosRepositorio>();
builder.Services.AddScoped<IProfissionalRepositorio, ProfissionalRepositorio>();
builder.Services.AddScoped<ITermometroEmocionalRepositorio, TermometroEmocionalRepositorio>();
builder.Services.AddScoped<ITermometroNoturnoRepositorio, TermometroNoturnoRepositorio>();
builder.Services.AddScoped<ITipoConteudoRepositorio, TipoConteudoRepositorio>();
builder.Services.AddScoped<ITipoEmocaoRepositorio, TipoEmocaoRepositorio>();
builder.Services.AddScoped<ITipoEspecializacaoRepositorio, TipoEspecializacaoRepositorio>();
builder.Services.AddScoped<ITipoExerciciosRepositorio, TipoExerciciosRepositorio>();
builder.Services.AddScoped<ITipoSentimentoSonoRepositorio, TipoSentimentoSonoRepositorio>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
