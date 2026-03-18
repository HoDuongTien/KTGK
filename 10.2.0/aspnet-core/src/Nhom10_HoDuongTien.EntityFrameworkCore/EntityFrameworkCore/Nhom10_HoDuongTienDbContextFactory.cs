using Nhom10_HoDuongTien.Configuration;
using Nhom10_HoDuongTien.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Nhom10_HoDuongTien.EntityFrameworkCore;

/* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
public class Nhom10_HoDuongTienDbContextFactory : IDesignTimeDbContextFactory<Nhom10_HoDuongTienDbContext>
{
    public Nhom10_HoDuongTienDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<Nhom10_HoDuongTienDbContext>();

        /*
         You can provide an environmentName parameter to the AppConfigurations.Get method. 
         In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
         Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
         https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
         */
        var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

        Nhom10_HoDuongTienDbContextConfigurer.Configure(builder, configuration.GetConnectionString(Nhom10_HoDuongTienConsts.ConnectionStringName));

        return new Nhom10_HoDuongTienDbContext(builder.Options);
    }
}
