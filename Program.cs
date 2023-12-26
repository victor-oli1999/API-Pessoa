using API_Pessoa.cad_Cliente.Persistence;
using API_Pessoa.cad_Pessoa.Persistence;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using API_Pessoa.cad_Pessoa.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

var builder = WebApplication.CreateBuilder(args);

// Access to the database
var PessoaContextConnectionString = builder.Configuration.GetConnectionString("Trabalho");
builder.Services.AddDbContext<PessoaContext>(o => o.UseSqlServer(PessoaContextConnectionString));
builder.Services.AddDbContext<ClienteContext>(o => o.UseSqlServer(PessoaContextConnectionString));
// Add services to the container.
builder.Services.AddAutoMapper(typeof(PessoaProfile));


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
