using System;
using System.IO.Compression;
using System.Text;
using App.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.OpenApi.Models;

namespace App.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = long.MaxValue;
                o.MultipartBoundaryLengthLimit = int.MaxValue;
                o.MultipartHeadersCountLimit = int.MaxValue;
                o.MultipartHeadersLengthLimit = int.MaxValue;
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "App.Api", Version = "v1" });
            });
            //services.AddMvc()
            //    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
            //    .AddNewtonsoftJson(options =>
            //    {
            //        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //    });

            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
            });

            services.AddDbContext<AppDbContext>(options =>
                options
                    .UseNpgsql(Configuration.GetConnectionString("AppDb"))
            );

            services.AddCors();
            services.AddOptions();

            Persistence.DependencyInjectionConfig.Inject(services);
            Application.DependencyInjectionConfig.Inject(services);
            Infrastructure.DependencyInjectionConfig.Inject(services);
        }

        public void Configure(IApplicationBuilder Autenticador, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                Autenticador.UseDeveloperExceptionPage();
                Autenticador.UseSwagger();
                Autenticador.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "App.Api v1"));
            }
            else
            {
                Autenticador.UseHsts();
            }

            Autenticador.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
            );

            Autenticador.UseHttpsRedirection();
            Autenticador.UseRouting();
            Autenticador.UseAuthentication();
            Autenticador.UseAuthorization();
            Autenticador.UseResponseCompression();

            Autenticador.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            Autenticador.Use(async (context, next) =>
            {
                context.Features.Get<IHttpMaxRequestBodySizeFeature>().MaxRequestBodySize = null;
                await next.Invoke();
            });
        }
    }
}
