using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Manager.BookManager;
using Manager.CartManager;
using Manager.CustomerManager;
using Manager.LoginManager;
using Microsoft.AspNetCore.Authentication.Twitter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Repository;
using Repository.BookRepo;
using Repository.CartRepo;
using Repository.CustomerRepo;
using Repository.LoginRepo;
using Swashbuckle.AspNetCore.Swagger;

namespace BookStore_Api
{
    public class Startup
    {    //  [assembly :OwinStartup(typeof(WebApiisTokenAuth.Startup))]
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
            services.AddTransient<ICartRL, ImpCartRL>();
            services.AddTransient<ILoginRL, LoginRL>();
            services.AddTransient<ILoginManagerBL, LoginMangerBL>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "BookStorWeb API", Version = "v1" });
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
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStore API");
                });
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
           /* app.UseCors(Microsoft.Owin.Cors.CorsOption.AllowAll);
            var myProvider = new AuthorizationServerProvider();
            OAuthorizationServerOption options = new OAuthorizationServerOption
            {
                AllowInsecureHttp = true,
                TokenEndPointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
                ProviderAliasAttribute = myProvider,
                RefreshTokenProvider = new RefreshTokenProvider()
            };
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(
                new OAuthBearerAuthenticationOptions());
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);*/
        }
    }
}
