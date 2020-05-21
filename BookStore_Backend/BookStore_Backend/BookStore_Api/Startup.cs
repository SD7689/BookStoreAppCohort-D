using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manager.BookManager;
using Manager.CartManager;
using Manager.CustomerManager;
using Manager.LoginManager;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Repository;
using Repository.BookRepo;
using Repository.CartRepo;
using Repository.CustomerRepo;
using Repository.LoginRepo;
using Swashbuckle.AspNetCore.Swagger;
[assembly: OwinStartup(typeof(BookStore_Api.Startup))]
namespace BookStore_Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            services.AddDbContextPool<BookStoreDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("UserDbConnection")));
            services.AddTransient<IManagerBL, ImpBookManagerBL>();
            services.AddTransient<IBookRL, BookImpRL>();
            services.AddTransient<ICustomerManagerBL, ImpCustomerManagerBL>();
            services.AddTransient<ICustomerRL, ImpCustomerRL>();
            services.AddTransient<ICartManagerBL, ImpCartManagerBL>();
            services.AddTransient<ICartRepoRL, ImpCartRepo>();
            services.AddTransient<ILoginRepoRL, LoginRepoRL>();
            services.AddTransient<ILoginManagerBL, LoginMangerBL>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "BookStorWeb_API", Version = "v1" });
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = Configuration["Jwt:Issuer"],
            ValidAudience = Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
        };
    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI V1");
                });
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            });
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();

        }
    }
}
