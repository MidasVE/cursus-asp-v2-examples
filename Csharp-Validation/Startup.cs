using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Csharp_Validation.DataContext;
using Csharp_Validation.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Csharp_Validation
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
      services.Configure<CookiePolicyOptions>(options =>
      {
        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
      });
      services.AddDbContext<KittenDbContext>(options => options.UseInMemoryDatabase("Kittens"));

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, KittenDbContext context)
    {
      context.Kittens.Add(new Kitten { Name = "Loki", DateOfBirth = new DateTime(2014, 04, 02), NiceScale = 10, IsMale = true });
      context.Kittens.Add(new Kitten { Name = "Marie", DateOfBirth = new DateTime(2016, 04, 02), NiceScale = 4, IsMale = false });
      context.Kittens.Add(new Kitten { Name = "Josefina", DateOfBirth = DateTime.Now.AddDays(-1), NiceScale = 4, IsMale = false });
      context.SaveChanges();

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
      }

      app.UseStaticFiles();
      app.UseCookiePolicy();

      app.UseMvc(routes =>
      {
        routes.MapRoute(
                  name: "default",
                  template: "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}
