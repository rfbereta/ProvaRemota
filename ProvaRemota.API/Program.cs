using System.Data;
using System.Data.SqlClient;
using ProvaRemota.Services;
using ProvaRemota.Services.Interfaces;
using ProvaRemota.Services.AutoMapper;
using ProvaRemota.Repository;
using ProvaRemota.Services.BusinessRules;
using ProvaRemota.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddTransient<IDbConnection>((sp) => new SqlConnection(connectionString));

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

builder.Services.AddScoped<ITipoClienteService, TipoClienteService>();
builder.Services.AddScoped<ITipoClienteRepository, TipoClienteRepository>();

builder.Services.AddScoped<ISituacaoClienteService, SituacaoClienteService>();
builder.Services.AddScoped<ISituacaoClienteRepository, SituacaoClienteRepository>();

builder.Services.AddScoped<IClienteValidator, ClienteValidator>();

builder.Services.AddAutoMapper(typeof(MappingProfile));


var app = builder.Build();

app.UseCors(x => x.AllowAnyHeader()
                             .AllowAnyMethod()
                             .AllowAnyOrigin());


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
