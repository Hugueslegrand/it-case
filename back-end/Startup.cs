using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using my_new_app.Data;
using my_new_app.Data.Services;
using Newtonsoft.Json.Serialization;

namespace my_new_app
{
    public class Startup
    {
        public string ConnectionString { get; set; }

       
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Configure DbContext with SQL
            //services.AddDbContext<AppBeContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BelgiumConnectionstring"))); //deze lijn moet meermaals terugkomen voor elke db appnlcontext, appbecontext...
            //services.AddDbContext<AppNlContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TestConnectionString"))); //deze lijn moet meermaals terugkomen voor elke db appnlcontext, appbecontext...
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TestConnectionString")));

            //Configure the services
            services.Configure<CookieTempDataProviderOptions>(options => {
                options.Cookie.IsEssential = true;
            });
            services.AddTransient<TablesService>();
            services.AddTransient<ColumnsService>();
            //services.AddSingleton<IDatabaseService, DatabaseService > ();

            services.AddControllersWithViews().
                AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                ).AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
                = new DefaultContractResolver());
            ;

            services.AddControllers();
            // In production, the Angular files will be served from this directory
            /*services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });*/
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "my_books", Version = "v1" });
            });

            //Enable Cors
            /*services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });*/
            services.AddCors(options => options.AddDefaultPolicy(
                builder => builder.AllowAnyOrigin()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors();

            if (env.IsDevelopment())
             {
                 app.UseDeveloperExceptionPage();
                 app.UseSwagger();
                 app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "my_books v1"));
             }
             else
             {
                 app.UseExceptionHandler("/Error");
                 // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                 app.UseHsts();
             }

             app.UseHttpsRedirection();
             app.UseStaticFiles();
             if (!env.IsDevelopment())
             {
                 app.UseSpaStaticFiles();
             }

             app.UseRouting();

             app.UseEndpoints(endpoints =>
             {
                 /*endpoints.MapControllerRoute(
                     name: "default",
                     pattern: "{controller}/{action=Index}/{id?}");*/
            endpoints.MapControllers();
         });

        /* app.UseSpa(spa =>
         {
             // To learn more about options for serving an Angular SPA from ASP.NET Core,
             // see https://go.microsoft.com/fwlink/?linkid=864501

             spa.Options.SourcePath = "ClientApp";

             if (env.IsDevelopment())
             {
                 spa.UseAngularCliServer(npmScript: "start");
                // spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
             }
         });*/
           
          
        }
    }
}
