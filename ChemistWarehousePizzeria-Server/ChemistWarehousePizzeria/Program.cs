using ChemistWarehousePizzeria.Repositories;
using ChemistWarehousePizzeria.Repositories.Interfaces;
using ChemistWarehousePizzeria.Services;
using ChemistWarehousePizzeria.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChemistWarehousePizzeria
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string myAllowSpecificOrigins = "_myAllowSpecificOrigins";

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContextPool<PizzeriaDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddTransient<IPizzaService, PizzaService>();
            builder.Services.AddTransient<IPizzeriaService, PizzeriaService>();

            builder.Services.AddScoped<IPizzeriaRepository, PizzeriaRepository>();
            builder.Services.AddScoped<IPizzaRepository, PizzaRepository>();
            builder.Services.AddScoped<IPriceRepository, PriceRepository>();

            builder.Services.AddCors(options => options.AddPolicy(name: myAllowSpecificOrigins, builder =>
            {
                builder.WithOrigins("http://localhost:3000")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
            }));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseCors(myAllowSpecificOrigins);

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}