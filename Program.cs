using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Projeto_SaneJa.Context;
using Projeto_SaneJa.Mappings;
using Projeto_SaneJa.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// CORS service and policies
var MyAllowOrigins = "_myAllowOrigins";

builder.Services.AddCors(options => 
{
    options.AddPolicy(name: MyAllowOrigins,
                      policy =>
                      {
                        policy.WithOrigins("*")
                        .AllowAnyMethod()
                        .AllowAnyHeader().AllowAnyOrigin();
                      });
});


builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseMySql(mySqlConnection,
            ServerVersion.AutoDetect(mySqlConnection)));

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(MyAllowOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
