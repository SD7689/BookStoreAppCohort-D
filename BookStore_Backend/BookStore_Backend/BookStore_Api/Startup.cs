using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreBussinessLayer.BookManager;
using BookStoreBussinessLayer.CartManager;
using BookStoreBussinessLayer.CustomerManager;
using BookStoreBussinessLayer.LoginManager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using BookStoreRepositoryLayer;
using BookStoreRepositoryLayer.BookRepo;
using BookStoreRepositoryLayer.CartRepo;
using BookStoreRepositoryLayer.CustomerRepo;
using BookStoreRepositoryLayer.LoginRepo;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            services.AddTransient<ICustomerRL, CustomerImpRL>();
            services.AddTransient<ICartManagerBL, ImpCartManagerBL>();
            services.AddTransient<ICartRepoRL, ImpCartRepoRL>();
            services.AddTransient<ILoginRepoRL, LoginRepoRL>();
            services.AddTransient<ILoginManagerBL, LoginMangerBL>();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
               options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = Configuration["Jwt:Issuer"],
                   ValidAudience = Configuration["Jwt:Issuer"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
               }
           );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "BookStorWeb API", Version = "v1" });
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[0] }
                };
                c.AddSecurityDefinition(name:"Bearer",new ApiKeyScheme { 
                    Description="JWT Authorization header using bearer scheme",
                    Name="Authorization",
                    In="header",
                    Type="apiKey"
                });
                c.AddSecurityRequirement(security);
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
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStoreWeb API");
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
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
