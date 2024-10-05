
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
            if (configuration is null)
                throw new Exception("Not fount project Configuration.");


            builder.Services.AddDbContext<DataContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAutoMapper(typeof(AutoMapperDT));

            builder.Services.AddScoped(typeof(DbContext), typeof(DataContext));
            builder.Services.AddScoped<IRegionService, RegionService>();
            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<IRegionRepository, RegionRepository>();
            builder.Services.AddScoped<ICityRepository, CityRepository>();

            // Нужно для избегания циклического преобразования объектов в JSON (у города есть регион,  у региона есть город, давай крутить это в json до переполнения стэка!)
            builder.Services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );


            // а вот тут, судя по книге должен быть класс Startup. Забавное
            var app = builder.Build();

            // Что забавно - похоже конвеер (middleware) так же прописывается ниже.
            // Главное, что стоит там помнить - порядок важен. Добавленный вновь сервис имеет доступ к данным, которые идут до него.
            // и "пошёл нафиг" от элементов, добавленных после

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage(); // Может что интересное увижу? Мой проект - хочу увидеть взрослые штуки - буду смотреть!
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
