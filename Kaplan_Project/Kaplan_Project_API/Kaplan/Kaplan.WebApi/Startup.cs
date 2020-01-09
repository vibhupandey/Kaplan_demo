using Kaplan.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Order_Kitting.Infrastructure;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Kaplan.Business.Contracts;
using Kaplan.DataAccess.Contracts;
using Kaplan.DataAccess.Service;
using Kaplan.Business.Service;

namespace Kaplan.WebApi
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        { 

            services.AddCors(options =>
                            {
                                options.AddPolicy("AllowAll",
                                    builder =>
                                    {
                                        builder
                                        .AllowAnyOrigin()
                                        .AllowAnyMethod()
                                        .AllowAnyHeader()
                                        .AllowCredentials();
                                    });
                            });
        
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Register the Swagger generator, defining 1 or more Swagger documents
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Kaplan", Version = "v1" }); 
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath); 
            });
            
            services.AddTransient<ITrainningService, TrainningService>();
            services.AddTransient<ITrainningRepository, TrainningRepostory>();

            // this will be used when we do communication to db for tranning data . as of now json is used 

            string connectionString = Configuration.GetSection("ConnectionStrings")["DefaultConnection"];
            object[] obj = { connectionString };
            services.AddSingleton<IAppSettings>(op => ActivatorUtilities.CreateInstance<AppSettings>(op, obj));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowAll");
            app.UseSwagger();
            if (env.IsDevelopment())
            {
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kaplan V1");
                });
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            } 
            app.UseHttpsRedirection(); 
            app.UseMvc();
        }


    }

   
}
