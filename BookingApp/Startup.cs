using AutoMapper;
using BookingApp.Classes;
using BookingApp.DTOs;
using BookingApp.Interfaces;
using BookingApp.Repositories;
using BookingApp.Services;
using BookingApp.Unit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BookingApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookingAppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("BookingAppCs"));
            });
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IBookingRepository, BookingRepository>();
            services.AddTransient<ITablePlacesRepository, TablePlacesRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IBookingService, BookingService>();
            services.AddTransient<ITableService, TableService>();
            services.AddControllers();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookingApp", Version = "v1" });
            });

            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new AutoMappingProfile());
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookingApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
