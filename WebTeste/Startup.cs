using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebTeste.Repositories;
using WebTeste.Services;
using WebTeste.Interfaces.Repositories;
using WebTeste.Models;
using FluentValidation;
using WebTeste.Validator;
using Microsoft.OpenApi.Models;

namespace WebTeste
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
            // services.AddControllers();

            // Data Base Connection

            var connectionString = Configuration.GetConnectionString("DefaultConnection"); // Faz conex�o com o Banco Atrav�s do Json

            services.AddDbContext<ApplicationContext>(options =>
                options.UseNpgsql(connectionString) // Faz conex�o com o Banco Atrav�s do Json 
            );

            services.AddMvc();

            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API",
                    Description = "",
                    Contact = new OpenApiContact
                    {
                        Name = "Pablo Gabriel",
                        Email = string.Empty
                    }
                });
            });

            // Habilita Cross-Domain. Libera aplica��o para ser consumida por outros dom�nios.
            services.AddCors(option =>
            {
                option.AddPolicy("AllOrigins",
                    builder =>
                    {
                        builder.AllowAnyHeader()
                        .AllowAnyOrigin()
                        .AllowAnyMethod();
                    });
            });

            // Dependency injection

            services.AddScoped<I_Pokemon_Repository, _Pokemon_Repository>();
            services.AddScoped<ITypesRepository, TypesRepository>();
            services.AddScoped<IPokemon_TypesRepository, Pokemon_TypesRepository>();

            // Validation

            services.AddTransient<IValidator<_Pokemon_>, _Pokemon_Validator>();
            services.AddTransient<IValidator<Types>, TypesValidator>();
            services.AddTransient<IValidator<Pokemon_Types>, Pokemon_TypesValidator>();

            // Token Services

            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseCors("AllOrigins");
            app.UseRouting();

            // Roles
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
