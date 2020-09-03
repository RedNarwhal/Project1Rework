using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjRework.Logic.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProjRework.DataAccess.Model;
using Microsoft.Extensions.Configuration;
using ProjRework.DataAccess.Repositories;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ProjRework
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<ProjReworkContext>(options => options.UseNpgsql(Configuration.GetConnectionString("Context"), options => 
      {
        options.EnableRetryOnFailure(3);
      }));
      
      services.AddScoped<ICustomerRepository, CustomerRepository>();
      services.AddScoped<IStoreRepository, StoreRepository>();
      //services.AddScoped<IOrderRepository, OrderRepository>();
      services.AddSwaggerGen();

      services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();
      ///
      //Change route information as it does not match this application
      ///
      app.UseSwagger();
      app.UseSwaggerUI(options =>
      {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        options.RoutePrefix = string.Empty;
      });

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
