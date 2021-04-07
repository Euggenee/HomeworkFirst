using DataAccessLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BusinessLogicLayer.AuthService;
using BusinessLogicLayer.PublicDataService;
using BusinessLogicLayer.PrivateDataService;
using BusinessLogicLayer.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BusinessLogicLayer.Filters;
using System.Linq;
using DataAccessLayer.Entities;
using BusinessLogicLayer.DataProviderProfilerService;
using Microsoft.OpenApi.Models;

namespace PresentationLayer
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
            
            //Filter
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(ApiRequestsLogAttribute));
            });

            //JWT
            services.AddAuthentication(opt=> {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            
            }).AddJwtBearer(opt=>{
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = "https://localhost:5001",
                    ValidAudience = "https://localhost:5001",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KeyHIUYM@12345678"))
                };
            });

            //Db 
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration["SqlServerConnectionString"], b => b.MigrationsAssembly("DataAccessLayer"));
            });

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>(); //настроили внедрение зависимости 
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPublicDataService, PublicDataService>();
            services.AddScoped<IPrivateDataService, PrivateDataService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDataProviderProfilerService, DataProviderProfilerService>();

            //Filter
            services.AddScoped<ApiRequestsLogAttribute>();


            //Swager
            services.AddSwaggerGen(sw =>
            {
                sw.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger API", Version = "version 1" });
                /*     sw.SwaggerDoc("v2", new OpenApiInfo {Title = "Swager API", Version = "version 2"});*/
            });


            services.AddControllersWithViews();
          
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();                   //  генерит док для описания swagger
                app.UseSwaggerUI(sw =>
                {
                    sw.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1");  // путь к док который нужно сгенерир
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
            SeedDefault(app);
        }
        private void SeedDefault(IApplicationBuilder app)
        {
            var ScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var scope = ScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                if (dbContext.Employes.FirstOrDefault(u => u.Name == "Name 1") == null)
                {
                    for (int i = 1; i <= 5000; i++)
                        dbContext.Employes.Add(new Employe { Name = "Name " + i, Surname = "Surname " + i });
                }
                if (dbContext.HiringHistoris.FirstOrDefault(u => u.Name == "Name 1") == null)
                {
                    var emploes = dbContext.Employes.ToList();
                    int count = 0;
                    for (int j = 1; j <= 2; j++)
                        for (int i = 0; i < emploes.Count; i++) 
                        {
                            count++;
                            dbContext.HiringHistoris.Add(new HiringHistori { Name = "Name " + count, EmployeId = emploes[i].Id });
                        }
                }
                if (dbContext.Achievements.FirstOrDefault(u => u.Description == "Description 1") == null)
                {
                    var hiringHistoris = dbContext.HiringHistoris.ToList();
                    int count = 0;
                    for (int k = 1; k <= 2; k++)
                        for (int i = 0; i < hiringHistoris.Count; i++)
                        {
                            count++;
                            dbContext.Achievements.Add(new Achievement { Description = "Description " + count,  HiringHistoriId = hiringHistoris[i].Id });
                        }
                }
                dbContext.SaveChanges();
            }
        }

    }


   
}
