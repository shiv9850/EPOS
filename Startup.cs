using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_POS.DBContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace E_POS
{
    public class Startup
    {
        private readonly string corsPolicy = "myCorsPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(option=> {
                option.AddPolicy(corsPolicy, builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                    .WithMethods("GET", "POST", "PUT", "DELETE")
                    .WithHeaders("Content-Type");
                });
            });
            services.AddDbContext<PosContext>(option => option.UseSqlServer(@"Server=CSNB0340\SQLEXPRESS;Database=EPOSDB;Trusted_Connection=True;"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerDocument();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseOpenApi();
                app.UseSwaggerUi3();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors(corsPolicy);
           // app.UseHttpsRedirection();
            app.UseMvc();
            
        }
    }
}
