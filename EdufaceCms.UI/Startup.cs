using EdufaceCms.BusinessLayer.Managers.EntityFramework;
using EdufaceCms.BusinessLayer.Managers.EntityFramework.Abstract;
using EdufaceCms.DataAccessLayer;
using EdufaceCms.Entities.Concrete;
using EdufaceCms.UI.Migrations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EdufaceCms.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configurationn = configuration;
        }

        public IConfiguration Configurationn { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAntiforgery(options =>
            {
                // Set Cookie properties using CookieBuilder properties.
                options.FormFieldName = "__RequestVerificationToken";
                options.HeaderName = "X-CSRF";
                options.SuppressXFrameOptionsHeader = false;
            });

            services.AddDbContext<DatabaseContext>();

            services.AddIdentity<UserEntity, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcçdefghıijklmnoöprsştuüvyz ";
            })
                                .AddEntityFrameworkStores<DatabaseContext>()
                                .AddDefaultTokenProviders();


            services.ConfigureApplicationCookie(opt => opt.LoginPath = "/Admin/Login");
            services.ConfigureApplicationCookie(opt => opt.LogoutPath = "/Home/Index");

            services.AddSingleton<IUserRepository, EfUserRepository>();

            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});

            services.AddTransient<ITimeRepository, EfTimeRepository>();
            services.AddTransient<ITimeRepository, EfTimeRepository>();
            services.AddTransient<ILevelRepository, EfLevelRepository>();
            services.AddTransient<IBranchRepository, EfBranchRepository>();
            services.AddTransient<IStudentRepository, EfStudentRepository>();
            services.AddTransient<IGuarantorRepository, EfGuarantorRepository>();
            services.AddTransient<IEducationRepository, EfEducationRepository>();
            services.AddTransient<IDataSourceRepository, EfDataSourceRepository>();
            services.AddTransient<IDataQualityRepository, EfDataQualityRepository>();
            services.AddTransient<IPreRegisterRepository, EfPreRegisterRepository>();
            services.AddTransient<IPaymentTypeRepository, EfPaymentTypeRepository>();
            services.AddTransient<IStudentPaymentRepository, EfStudentPaymentRepository>();
            services.AddTransient<IStudentEducationRepository, EfStudentEducationRepository>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "DeleteUserRole",
                    template: "deleteUserRole/{userId}/{RoleName}",
                    defaults: new { controller = "Admin", action = "DeleteUserRole" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //SeedData.Seed(app);
        }
    }
}
