using AutoMapper;
using CvApi.Helper;
using CvApi.Helper.ErrorHandler;
using CvApi.Models.Contexts;
using CvApi.Services.ApplicationService;
using CvApi.Services.CompanyService;
using CvApi.Services.ExperienceService;
using CvApi.Services.JobAdvertisementService;
using CvApi.Services.JobSkillsService;
using CvApi.Services.SkillsService;
using CvApi.Services.UserService;
using CvApi.Services.UserSkillsService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CvApi
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
            services.AddDbContext<CVContext>(opt =>
               opt.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddCors();
            services.AddControllers();
            services.AddMvc();
            services.AddAutoMapper(typeof(AutoMapperProfile));

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                        var userId = new Guid(context.Principal.Identity.Name);
                        var user = userService.GetById(userId);
                        if (user == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
                options.AddPolicy("Users", policy => policy.RequireClaim(ClaimTypes.Role, "User"));
                options.AddPolicy("Company", policy => policy.RequireClaim(ClaimTypes.Role, "CompanyWorker"));
            });

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ISkillsService, SkillsService>();
            services.AddScoped<IExperienceService, ExperienceService>();
            services.AddScoped<IJobSkillsService, JobSkillsService>();
            services.AddScoped<IUserSkillsService, UserSkillsService>();
            services.AddScoped<IJobAdvertisementService, JobAdvertisementService>();
            services.AddScoped<IErrorHandler, ErrorHandler>();
            services.AddScoped<IApplicationService, ApplicationService>();

            services.AddSwaggerDocument(config =>
                { config.Title = "Jobster API"; config.Description = "An API used to manipulate data in the Jobster project"; }
            );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(
                options => options.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader()
            ); ;

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}
