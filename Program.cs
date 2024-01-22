using API_Pessoa.Data.Context;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
//using API_Pessoa.Core.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

var builder = WebApplication.CreateBuilder(args);

// Access to the database
//var PessoaContextConnectionString = builder.Configuration.GetConnectionString("Casa");

builder.Services.AddDbContext<DBContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString(nameof(DBContext))));

// Add services to the container.
//builder.Services.AddAutoMapper(typeof(PessoaProfile));


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
