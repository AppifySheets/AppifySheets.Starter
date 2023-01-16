using AppifySheets.EfCore.Infrastructure.DbContext;
using EfCore.Infrastructure;
using L1.Domain.BaseModels;
using Microsoft.EntityFrameworkCore;

namespace AppifySheets.EFCore.Migrations;

public class DesignTimeDbContextFactory : DesignTimeDbContextFactoryBase<ApplicationDbContext, ApplicationUser, BasicUser, ApplicationRole, ApplicationUserLoginInfo>
{
    protected override void InitializeDbContext(DbContextOptionsBuilder<ApplicationDbContext> builder)
        => builder.UseNpgsql(ApplicationDbContext.ProductionConnectionString
            , b =>
            {
                b.MigrationsAssembly(GetType().Assembly.FullName);
                b.CommandTimeout(90);
            });

    protected override ApplicationDbContext DbContextCreator(DbContextOptions<ApplicationDbContext> options)
        => new(options, null, null, null);
}