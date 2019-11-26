using InciCafe.BLL.Service;
using InciCafe.DAL;
using InciCafe.DAL.Repositories;
using InciCafe.DAL.UnitOfWork;
using InciOneSoft.BLL.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using System;
using System.IdentityModel.Tokens.Jwt;




namespace InciCafe.Api
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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .WithExposedHeaders("content-disposition")
                    .AllowAnyHeader()
                    
                    .SetPreflightMaxAge(TimeSpan.FromSeconds(3600)));
            });
            IdentityModelEventSource.ShowPII = true;
            services.AddDbContext<InciCafeDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("InciCafeDbConnection")));

            services.AddTransient<ICoffeeService, CoffeeService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IOrderService,OrderService>();
            services.AddTransient<IServiceBase, ServiceBase>();
            
            //services.AddTransient<IStatusService, StatusService>();
            services.AddTransient<IStatusRepository, StatusRepository>();

            services.AddSignalR();
         
        


            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICoffeeRepository, CoffeeRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<DbContext, InciCafeDbContext>();

            services.AddTransient<IServiceBase, ServiceBase>();
            services.AddTransient<IAutoMapperService, AutoMapperService>();
            services.AddSignalR();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies")
            .AddOpenIdConnect("oidc", options =>
            {
                options.Authority = "http://localhost:5000";
                options.RequireHttpsMetadata = false;

                options.ClientId = "oid1.incicafeclient";
                options.SaveTokens = true;
            });
          
            services.AddControllersWithViews();
      
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("CorsPolicy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseCors();
          
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
         
            
      
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseEndpoints(endpoints =>
            {
              
                endpoints.MapHub<ChatHub>("/chatHub");
            });


        }
    }
}
