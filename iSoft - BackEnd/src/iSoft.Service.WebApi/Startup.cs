using iSoft.Service.WebApi.Modules.Authentication;
using iSoft.Service.WebApi.Modules.Feature;
using iSoft.Service.WebApi.Modules.Injection;
using iSoft.Service.WebApi.Modules.Mapper;
using iSoft.Service.WebApi.Modules.Swagger;
using iSoft.Service.WebApi.Modules.Validator;

namespace iSoft.Service.WebApi
{
  public class Startup
  {

    readonly string myPolicy = "policy_iSoft";
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMapper();
      services.AddFeature(this.Configuration);
      services.AddInjection(this.Configuration);
      services.AddAuthentication(this.Configuration);
      services.AddSwagger();
      services.AddValidator();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();
      // Enable middleware to serve generated Swagger as a JSON endpoint.
      app.UseSwagger();

      // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
      // specifying the Swagger JSON endpoint.
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API Ecommerce V1");
      });

      app.UseCors(myPolicy);
      app.UseAuthentication();
      app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }

  }
}
