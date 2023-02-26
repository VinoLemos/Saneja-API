using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.AgentServices;
using Api.Domain.Interfaces.Services.PersonServices;
using Api.Domain.Interfaces.Services.ResidencialPropertyServices;
using Api.Domain.Interfaces.Services.TechnicalVisitServices;
using Api.Service.Services.AgentServices;
using Api.Service.Services.PersonServices;
using Api.Service.Services.ResidencialPropertyServices;
using Api.Service.Services.TechnicalVisitServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MyContext>(options => 
        options.UseMySql(mySqlConnection,
            ServerVersion.AutoDetect(mySqlConnection),
            b => b.MigrationsAssembly("application")));
builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<IPersonService, PersonService>();
builder.Services.AddTransient<IAgentServices, AgentService>();
builder.Services.AddTransient<IResidencialPropertyServices, ResidencialPropertyService>();
builder.Services.AddTransient<ITechnicalVisitServices, TechnicalVisitService>();

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
