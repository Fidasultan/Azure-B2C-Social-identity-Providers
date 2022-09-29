using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using SharpProg.Tutorials.AzureB2C.Api.AuthPolicy;
using SharpProg.Tutorials.AzureB2C.Core;

namespace SharpProg.Tutorials.AzureB2C.Api
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddMicrosoftIdentityWebApi(options =>
                   {
                       Configuration.Bind(B2CConstants.AzureAdConfigSection, options);

                       options.TokenValidationParameters.NameClaimType = "name";
                   },
           options => { Configuration.Bind(B2CConstants.AzureAdConfigSection, options); });

            //services.AddMicrosoftIdentityWebApiAuthentication(Configuration, B2CConstants.AzureAdConfigSection);

            services.AddControllers();

            services.AddAuthorization(options =>
            {
                // Create policy to check for the scope 'read'
                options.AddPolicy("ReadScope",
                    policy => policy.Requirements.Add(new ScopesRequirement("products.view")));
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
