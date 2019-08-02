using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Contexts.Data;
using Backend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Backend
{
    public class Startup
    {
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    //builder.AllowAnyOrigin();
                    builder.WithOrigins("http://localhost:8080", "http://localhost:3000")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod()
                                        .AllowAnyOrigin();
                                        
                    
                });
            });

            services.AddDbContext<TestDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("LocalDatabase")));
            services.AddTransient<PassHashService>();
            services.AddTransient<JwtService>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                //var signingKey = Convert.FromBase64String(Configuration["Jwt:SigningSecret"]);
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,             
                    ValidateAudience = true,         
                    ValidateLifetime = true,

                    ValidIssuer = "https://localhost:5001",
                    ValidAudience = "https://localhost:5001",

                    ValidateIssuerSigningKey = true,    
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sflkadjhfjhueh#asdkfjh@laksjdfksk.askdfhm,aksdhfsdf"))
            };

            });

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //        .AddJwtBearer(Options =>
            //        {
            //            Options.TokenValidationParameters = new TokenValidationParameters
            //            {
            //                ValidateIssuer = true,
            //                ValidateAudience = true,
            //                ValidateLifetime = true,
            //                ValidateIssuerSigningKey = true,

            //                ValidIssuer = "http://localhost:5000",
            //                ValidAudience = "http://localhost:5000",
            //                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sflkadjhfjhueh#asdkfjh@laksjdfksk.askdfhm,aksdhfsdf"))
            //            };
            //        });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
