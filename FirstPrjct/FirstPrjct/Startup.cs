using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BL;
using DL;
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

namespace FirstPrjct
{
    public class Startup
    {

        ILogger<Startup> _logger;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IUserDL, UserDL>();
            services.AddScoped<IUserBL, UserBL>();
            services.AddScoped<ICategoriesBL, CategoriesBL>();
            services.AddScoped<ICategoriesDL, CategoriesDL>();
            services.AddScoped<IProductsDL, ProductsDL>();
            services.AddScoped<IProductsBL, ProductsBL>();
            services.AddScoped<IOrdersDL, OrdersDL>();
            services.AddScoped<IOrdersBL, OrdersBL>();
            services.AddScoped<IRatingBL, RatingBL>();
            services.AddScoped<IRatingDL, RatingDL>();
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<AmericanDolllContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("AmericanDolll")), ServiceLifetime.Scoped);
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" }); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            _logger = logger;

            _logger.LogInformation("The application alive now");

            app.UseErrorMiddleware();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.Map("/api", app2=> 
            {
                app2.UseRouting();

                app2.UseMiddleware();

                app2.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            });

            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c => { 
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); 
            });
        }
    }
}
