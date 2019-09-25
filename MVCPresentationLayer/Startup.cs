using BusinessLogicalLayer;
using DataAccessLayer;
using DataTypeObject;
using DataTypeObject.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MVCPresentationLayer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });**/

            services.AddDbContext<BatteryCollectorDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<IUSERCRUD, UserBLL>();
            services.AddTransient<IMATERIALCRUD, MaterialBLL>();
            services.AddTransient<IDISCARDCRUD, DiscardBLL>();
            services.AddTransient<IPLACECRUD, PlaceBLL>();
            services.AddTransient<IFEATURE, FeatureHintBLL>();
             services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "kennedyBatteryProject",
                        ValidAudience = "BatteryCollectorUsers",
                        IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(Configuration["SecurityKey"]))
                    };  
                
                });

            services.AddMvc();
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
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
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthentication();

            app.UseMvc();

            /*
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            */
        }
    }
}
