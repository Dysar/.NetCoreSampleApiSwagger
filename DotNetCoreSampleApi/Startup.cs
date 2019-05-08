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
using Swashbuckle.AspNetCore.Swagger;

namespace DotNetCoreSampleApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddApiVersioning(o => {
		        o.ReportApiVersions = true;
		        o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
	        });
            
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c => {  
        c.SwaggerDoc("v1", new Info {  
            Version = "v1",  
                Title = "My First API",  
                Description = "My First ASP.NET Core 2.2 Web API",  
                TermsOfService = "None",  
                Contact = new Contact() {  
                    Name = "Neel Bhatt", Email = "neel.bhatt40@gmail.com", Url = "https://neelbhatt40.wordpress.com/"  
                }  
        });

        c.SwaggerDoc("v2", new Info {  
            Version = "v2",  
                Title = "My Second API",  
                Description = "My Second ASP.NET Core 2.2 Web API",  
                TermsOfService = "None",  
                Contact = new Contact() {  
                    Name = "Neel Bhatt", Email = "neel.bhatt40@gmail.com", Url = "https://neelbhatt40.wordpress.com/"  
                }  
        });  
    });  
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();  
            app.UseSwaggerUI(c => {  
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "My API V2");  
    });  
        }
    }
}
