using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using SalesSystem.DTOs.Common;
using SalesSystem.Models;
using SalesSystem.Repositories;
using SalesSystem.Repositories.Implements;
using SalesSystem.Services;
using SalesSystem.Services.Implements;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace SalesSystem
{
    public class Startup
    {
        readonly string Cors = "Cors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //DB conextion
            services.AddDbContext<LESAContext>(options =>
            options.UseSqlServer("Server=DESKTOP-9LJ95CE; Database=LESA; Trusted_Connection=True; User=sa; Password=root;"));
            //options.UseSqlServer(Configuration.GetConnectionString("Server=DESKTOP-9LJ95CE; Database=LESA; Trusted_Connection=True; User=sa; Password=root;")));
            
            //AutoMapper
            //services.AddAutoMapper(options => 
            //{
            //    options.CreateMap<ClientDTO, Client>();
            //    options.CreateMap<Client, ClientDTO>();

            //    options.CreateMap<ProductDTO, Product>();
            //    options.CreateMap<Product, ProductDTO>();

            //    options.CreateMap<SaleDTO, Sale>();
            //    options.CreateMap<Sale, SaleDTO>();

            //});
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Repositories/Dependency Inyection
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();

            //Services/Dependency Inyection/esta forma de inyectar, el objeto sirve por cada request
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISaleService, SaleService>();

            //swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Swagger Demo API",
                        Description = "Demo API for showing Swagger",
                        Version = "v1"
                    });
                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
                options.IncludeXmlComments(filePath);
            }
            );

            //Jason Web token JWT
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSetthings>(appSettingsSection);
            //JWT
            var appSettings = appSettingsSection.Get<AppSetthings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(d =>
            {
                d.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                d.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(d => 
                {
                    d.RequireHttpsMetadata = false;
                    d.SaveToken = true;
                    d.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            //CORS configure/ proteccion en los navegadores, es un tipo de proteccion para elementos crusados
            //obtener solicitudes por elementos crusados

            services.AddCors(options =>
            {
                options.AddPolicy(name: Cors,
                                  builder =>
                                  {
                                      builder.WithOrigins("*");
                                  });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(Cors);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(options => 
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo API");
                options.RoutePrefix = "";
            });
            //configure owin
            //app.CreatePerOwinContext(LESAContext.Create);
        }
    }
}
