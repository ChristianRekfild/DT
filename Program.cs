
//using DT.Mapper;
using AutoMapper;
using DT.Mapper;
using DT.Model;
using DT.Represitory;
using DT.Services;
using DT.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var configuration = builder.Services.BuildServiceProvider().GetService<IConfiguration>();
            if (configuration == null)
                throw new Exception("Not fount progeñt Ñonfiguration.");


            builder.Services.AddDbContext<DataContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            //builder.Services.AddAutoMapper(typeof(AutoMapperDT));
            builder.Services.AddAutoMapper(typeof(AutoMapperDT));

            builder.Services.AddScoped(typeof(DbContext), typeof(DataContext));
            builder.Services.AddScoped<IRegionService, RegionService>();
            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<IRegionRepository, RegionRepository>();
            builder.Services.AddScoped<ICityRepository, CityRepository>();


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
        }
    }
}
