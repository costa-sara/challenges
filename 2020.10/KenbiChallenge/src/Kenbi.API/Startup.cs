using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using IdentityServer4.AccessTokenValidation;
using Kenbi.API.AutoMapperSettings;
using Kenbi.API.Extensions;
using Kenbi.Application.Services.Challenges;
using Kenbi.Data.Repository;
using Kenbi.Domain.Interfaces.Application;
using Kenbi.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Kenbi.API
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
            services.AddControllers();

            services.AddScoped<IChallengeAppService, ChallengeAppService>();

            


            var sqlConnectionString = Configuration?.GetSection("PostgresqlDatabase")?.GetSection("ConnectionString").Value;
            //"Host=db-challenge-herzsache.c9cjyugmuuhc.eu-central-1.rds.amazonaws.com;Username=postgres;Password=u1gdVLPKQjDtmEaPS1Jo;Database=Challenge";//Configuration["PostgreSqlConnectionString"];

            //services.AddDbContext<PostgreSqlContext>(options => options.UseNpgsql(sqlConnectionString));

            services.AddSingleton<IChallengeRepository, ChallengeRepository>();


            //IdentityServer auth config
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = Configuration?.GetSection("IdentityServer")?.GetSection("Authority").Value;  
                    options.ApiName = Configuration?.GetSection("IdentityServer")?.GetSection("ApiName").Value;
                    options.ApiSecret = Configuration?.GetSection("IdentityServer")?.GetSection("ApiSecret").Value;
                });


            //AutoMapper
            services.AddAutoMapper(typeof(Startup));
            var mapper= AutoMapperConfig.RegisterMappings();

            //Swagger config 
            services.AddSwaggerConfiguration(Configuration);

            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Register the Swagger generator and
            app.UseSwagger();

            // Register the Swagger UI middlewares
            app.UseSwaggerUI();

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
