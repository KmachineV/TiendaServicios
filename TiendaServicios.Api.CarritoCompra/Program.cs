using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TiendaServicios.Api.CarritoCompra.Application;
using TiendaServicios.Api.CarritoCompra.Persistence;
using TiendaServicios.Api.CarritoCompra.RemoteInterface;
using TiendaServicios.Api.CarritoCompra.RemoteService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CarritoContexto>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("ConnectionDatabase"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ConnectionDatabase")));
});
builder.Services.AddMediatR(typeof(Nuevo.Manejador).Assembly);
//builder.Services.AddAutoMapper(typeof(Consulta.Manejador));
builder.Services.AddScoped<ILibroService, LibroService>();
builder.Services.AddHttpClient("Libros", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Services:Libros"]);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
