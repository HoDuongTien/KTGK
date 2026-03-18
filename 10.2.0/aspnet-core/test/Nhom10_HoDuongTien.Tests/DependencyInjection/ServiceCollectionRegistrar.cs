using Abp.Dependency;
using Nhom10_HoDuongTien.EntityFrameworkCore;
using Nhom10_HoDuongTien.Identity;
using Castle.MicroKernel.Registration;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Nhom10_HoDuongTien.Tests.DependencyInjection;

public static class ServiceCollectionRegistrar
{
    public static void Register(IIocManager iocManager)
    {
        var services = new ServiceCollection();

        IdentityRegistrar.Register(services);

        services.AddEntityFrameworkInMemoryDatabase();

        var serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(iocManager.IocContainer, services);

        var builder = new DbContextOptionsBuilder<Nhom10_HoDuongTienDbContext>();
        builder.UseInMemoryDatabase(Guid.NewGuid().ToString()).UseInternalServiceProvider(serviceProvider);

        iocManager.IocContainer.Register(
            Component
                .For<DbContextOptions<Nhom10_HoDuongTienDbContext>>()
                .Instance(builder.Options)
                .LifestyleSingleton()
        );
    }
}
