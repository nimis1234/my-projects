using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShop.Model;

namespace OnlineShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // add entityframework-dbcontext service

            // using configuration we are calling default connection that present in the appstring
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            //used to add identity services for authentication
            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AppDbContext>();


            // here we can register our own services and their interfaces using Addscoped
            //service-MockCategoryRepository,IcategoryRepository
            //services.AddScoped<ICategoryRepository, MockCategoryRepository>();
            //services.AddScoped<IPieRepository, MockPieReposioty>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPieRepository, PieRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            // we are adding shopping cart and passing service to getcart
            services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp));
      

            // these two are used to get session
            services.AddHttpContextAccessor();
            services.AddSession();


            //services.AddTransient();
            //services.AddSingleton();
            // these are two services  singleton create a single instance and reuse the instance for entire application
            //add transient used to create a instance each time and destory once outside the scope



            //to get MVC structure
            services.AddControllersWithViews();
            //services.AddMvc(); would also work still

            services.AddRazorPages();
            // used to add razor pages for user authentication


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //to run only in https
            app.UseHttpsRedirection();

            //to run javascript , css, image add statiscfile middleware pipeline
            app.UseStaticFiles();
            app.UseSession();
            //please keep in mind Usesession should used before userouting

            app.UseRouting();
            //routinga nd endpoints used to respond to incomming request

            app.UseAuthentication();

            // used to add authentication and authoization

            // to purchase item only for authorized peoples
            app.UseAuthorization();

            // here we are passing the url or routing otherwise this will call localhost
            //if we have mutliple matches or endpoint, then first match will return

            app.UseEndpoints(endpoints =>
            {
                // calling to home controller/index method
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                // map razor pages to work identity 
                endpoints.MapRazorPages();
        
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
            //app.UseEndpoints(endpoints =>
            ////{
            ////    // calling to home controller/index method
            ////    endpoints.MapControllerRoute(
            ////        name: "default",
            ////        pattern: "{controller=Pie}/{action=List}/{id?}");


            ////});
        }
    }
}
