using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore.Uow;
using Abp.MultiTenancy;
using Nhom10_HoDuongTien.EntityFrameworkCore.Seed.Host;
using Nhom10_HoDuongTien.EntityFrameworkCore.Seed.Tenants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Transactions;

namespace Nhom10_HoDuongTien.EntityFrameworkCore.Seed;

public static class SeedHelper
{
    public static void SeedHostDb(IIocResolver iocResolver)
    {
        WithDbContext<Nhom10_HoDuongTienDbContext>(iocResolver, SeedHostDb);
    }

    public static void SeedHostDb(Nhom10_HoDuongTienDbContext context)
    {
        context.SuppressAutoSetTenantId = true;

        // Host seed
        new InitialHostDbBuilder(context).Create();

        // Default tenant seed (in host database).
        new DefaultTenantBuilder(context).Create();
        new TenantRoleAndUserBuilder(context, 1).Create();
    }

    private static void WithDbContext<TDbContext>(IIocResolver iocResolver, Action<TDbContext> contextAction)
        where TDbContext : DbContext
    {
        using (var uowManager = iocResolver.ResolveAsDisposable<IUnitOfWorkManager>())
        {
            using (var uow = uowManager.Object.Begin(TransactionScopeOption.Suppress))
            {
                var context = uowManager.Object.Current.GetDbContext<TDbContext>(MultiTenancySides.Host);

                contextAction(context);

                uow.Complete();
            }
        }
    }
}
