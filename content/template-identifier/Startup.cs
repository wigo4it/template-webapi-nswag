using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NJsonSchema;
using NSwag.AspNetCore;
using System.Reflection;
using NSwag;
using NSwag.SwaggerGeneration.Processors.Security;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNet.OData.Extensions;
using template_identifier.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNet.OData.Formatter;

namespace template_identifier
{
    public class YamlOutputFormatter : OutputFormatter
    {
        public YamlOutputFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/yaml"));
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context) => Task.CompletedTask;
    }

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
            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("datacontext"));
            services.AddOData();
            services.AddMvc(options =>
            {
                options.OutputFormatters.Add(new YamlOutputFormatter());
                // Add odata output supported mediatypes, needed for redoc
                foreach (var outputFormatter in options.OutputFormatters.OfType<ODataOutputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
                }
                foreach (var inputFormatter in options.InputFormatters.OfType<ODataInputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
                    
                }
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwaggerUi3(typeof(Startup).GetTypeInfo().Assembly, settings =>
            {
                settings.GeneratorSettings.DocumentProcessors.Add(new SecurityDefinitionAppender("API_HEADER", new SwaggerSecurityScheme
                {
                    Type = SwaggerSecuritySchemeType.ApiKey,
                    Name = "API-KEY",
                    In = SwaggerSecurityApiKeyLocation.Header,
                    Description = "X-API-KEY"
                }));

                settings.GeneratorSettings.DefaultPropertyNameHandling = 
                    PropertyNameHandling.CamelCase;
                settings.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "template-identifier WEB API";
                    document.Info.Description = "A templated ASP.NET Core web API";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.SwaggerContact
                    {
                        Name = "Insert Contact Name Here",
                        Email = string.Empty,
                        Url = "http://example.com/contact"
                    };
                    document.Info.License = new NSwag.SwaggerLicense
                    {
                        Name = "Use under LICX",
                        Url = "https://example.com/license"
                    };
                };
            });

            // Enable the Swagger UI middleware and the Swagger generator
            app.UseSwaggerReDocWithApiExplorer(s =>
            {
                s.SwaggerRoute = "/redoc/v1/swagger.json";
                s.SwaggerUiRoute = "/redoc";
            });
            app.UseHttpsRedirection();
            app.UseMvc(options =>
            {
                options.MapODataServiceRoute("odata", "odata", template_identifier.Models.DTO.SampleModelDTO.GetEdmModel());
            });

        }
    }
}
