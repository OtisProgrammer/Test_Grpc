using Application.Person.AutoMapper;
using Application.Person.Interfaces;
using Application.Person.Services;
using Domain.Person.Interfaces;
using Grpc.Person.Services;
using Infrastructure.Person.Context;
using Infrastructure.Person.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddAutoMapper(typeof(Mapper).Assembly);
builder.Services.AddDbContext<PersonDbContext>(c => c.UseSqlServer(builder.Configuration.GetConnectionString("PersonDbConnection")));
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<PeopleService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
