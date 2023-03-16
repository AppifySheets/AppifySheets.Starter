using AppifySheets.Common.XAF.Module.Helpers;
using AppifySheets.Domain.Common;
using AppifySheets.EfCore.Infrastructure.DbContext;
using L1.Domain.BaseModels;
using L2.EfCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace L3.EfCore.Migrations;

public class DesignTimeDbContextFactory : DesignTimeDbContextFactoryBase<ApplicationDbContext, ApplicationUser, BasicUser, ApplicationRole, ApplicationUserLoginInfo>
{
    protected override void InitializeDbContext(DbContextOptionsBuilder<ApplicationDbContext> builder)
        => builder.UseNpgsql(ConnectionStringStore.AppifySheetsConnectionString
            , b =>
            {
                b.MigrationsAssembly(GetType().Assembly.FullName);
                b.CommandTimeout(90);
            });

    protected override ApplicationDbContext DbContextCreator(DbContextOptions<ApplicationDbContext> options)
        => new(options, DummyDomainEventDispatcher.Empty, DateTimeWrapper.InstancePlus4Hours);
}

public class DummyDomainEventDispatcher : IDomainEventDispatcher
{
    public static readonly DummyDomainEventDispatcher Empty = new();
    DummyDomainEventDispatcher()
    {
        
    }
    public Task Dispatch(IDomainEvent domainEvent)
    {
        throw new NotImplementedException();
    }
}