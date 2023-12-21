using API_Pessoa.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Access to the database
var PessoaContextConnectionString = builder.Configuration.GetConnectionString("Trabalho");
builder.Services.AddDbContext<PessoaContext>(o => o.UseSqlServer(PessoaContextConnectionString));
builder.Services.AddDbContext<ClienteContext>(o => o.UseSqlServer(PessoaContextConnectionString));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
