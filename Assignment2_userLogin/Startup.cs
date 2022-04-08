using Assignment2_RegisterAndLogin;
using Assignment2_RegisterAndLogin.DTOMapping;
using Assignment2_RegisterAndLogin.Repository;
using Assignment2_RegisterAndLogin.Repository.IRepository;
using Assignment2_userLogin.Models;
using Assignment2_userLogin.Utility;
using Assignment2_userLogin.Utility.Services;
using Assignment2_userLogin.Utility.Services.IServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NationalParkwithAsp.netcorewebapi;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_userLogin
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
            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Myconnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddControllers();
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            //---Gmail
            var from = Configuration.GetSection("Email")["From"];

            var gmailSender = Configuration.GetSection("Gmail")["Sender"];
            var gmailPassword = Configuration.GetSection("Gmail")["Password"];
            var gmailPort = Convert.ToInt32(Configuration.GetSection("Gmail")["Port"]);

            services
                .AddFluentEmail(gmailSender, from)
                .AddRazorRenderer()
                .AddSmtpSender(new SmtpClient("smtp.gmail.com")
                {
                    UseDefaultCredentials = false,
                    Port = gmailPort,
                    Credentials = new NetworkCredential(gmailSender, gmailPassword),
                    EnableSsl = true,
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Assignment2_userLogin", Version = "v1" });
            });
            services.AddCors(options =>
            {
                options.AddPolicy(name: "MyPolicy", builder =>
                {
                    builder.WithOrigins("https://localhost:4200")
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                }
                );
            });
            //Add Services
            services.AddIManagerServices();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                //options.Cookie.HttpOnly = true;
                //options.Cookie.IsEssential = true;
            });
            //JWT Authentication
            var appSettingSection = Configuration.GetSection("AppSetting");
            services.Configure<AppSetting>(appSettingSection);
            var appSetting = appSettingSection.Get<AppSetting>();
            var key = Encoding.ASCII.GetBytes(appSetting.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Assignment2_userLogin v1"));
            }
            app.UseHttpsRedirection();
            app.UseCors("MyPolicy");
            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
