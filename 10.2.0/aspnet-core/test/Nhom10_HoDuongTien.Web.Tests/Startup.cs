using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Dependency;
using Nhom10_HoDuongTien.Authentication.JwtBearer;
using Nhom10_HoDuongTien.Configuration;
using Nhom10_HoDuongTien.EntityFrameworkCore;
using Nhom10_HoDuongTien.Identity;
using Nhom10_HoDuongTien.Web.Resources;
using Nhom10_HoDuongTien.Web.Startup;
using Castle.MicroKernel.Registration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Nhom10_HoDuongTien.Web.Tests;

public class Startup
{
    private readonly IConfigurationRoot _appConfiguration;

    public Startup(IWebHostEnvironment env)
    {
        _appConfiguration = env.GetAppConfiguration();
    }

    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        services.AddEntityFrameworkInMemoryDatabase();

        services.AddMvc();

        IdentityRegistrar.Register(services);
        AuthConfigurer.Configure(services, _appConfiguration);

        services.AddScoped<IWebResourceManager, WebResourceManager>();

        //Configure Abp and Dependency Injection
        return services.AddAbp<Nhom10_HoDuongTienWebTestModule>(options =>
        {
            options.SetupTest();
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
    {
        UseInMemoryDb(app.ApplicationServices);

        app.UseAbp(); //Initializes ABP framework.

        app.UseExceptionHandler("/Error");

        app.UseStaticFiles();
        app.UseRouting();

        app.UseAuthentication();

        app.UseJwtTokenMiddleware();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
        });
    }

    private void UseInMemoryDb(IServiceProvider serviceProvider)
    {
        var builder = new DbContextOptionsBuilder<Nhom10_HoDuongTienDbContext>();
        builder.UseInMemoryDatabase(Guid.NewGuid().ToString()).UseInternalServiceProvider(serviceProvider);
        var options = builder.Options;

        var iocManager = serviceProvider.GetRequiredService<IIocManager>();
        iocManager.IocContainer
            .Register(
                Component.For<DbContextOptions<Nhom10_HoDuongTienDbContext>>()
                    .Instance(options)
                    .LifestyleSingleton()
            );
    }
}