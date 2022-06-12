using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using services;
using Services.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace lab3
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
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer= "http://localhost:10661",
                    ValidAudience= "http://localhost:10661",
                    IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))

                };
            });
            services.AddControllers();
            services.AddDbContext<Database>();
            //services.AddScoped<IProductService, ProductService>();
            services.AddCors(options => options.AddPolicy("politykaCors", policy => policy.AllowAnyOrigin().AllowAnyMethod().Build()));
            services.AddCors(options =>
            {
                options.AddPolicy("nowaPolitykaLab9", builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().Build();
                });
            });
            services.AddScoped<IProductService, ProductServiceMemory>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IAuthorizationService, AuthorizationService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "lab3", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "lab3 v1"));
            }

            app.UseRouting();
            //app.UseCors("politykaCors");
            app.UseCors("nowaPolitykaLab9");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
