using AppifySheets.Common.XAF.Module.Helpers;
using AppifySheets.Domain.Common;
using AppifySheets.EfCore.Infrastructure.DbContext;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using JetBrains.Annotations;
using L1.Domain.BaseModels;
using L2.EfCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace L3.EfCore.Migrations;

[UsedImplicitly]
public class DesignTimeDbContextFactory : DesignTimeDbContextFactoryBase<ApplicationDbContext, ApplicationUser, BasicUser, ApplicationRole, ApplicationUserLoginInfo>
{
    protected override void InitializeDbContext(DbContextOptionsBuilder<ApplicationDbContext> builder)
        => builder.UseNpgsql(ConnectionStringInitializer.GetConnectionString().ConnectionString()
            , b =>
            {
                b.MigrationsAssembly(GetType().Assembly.FullName);
                b.CommandTimeout(90);
            });

    protected override ApplicationDbContext DbContextCreator(DbContextOptions<ApplicationDbContext> options)
        => new(options, DummyDomainEventDispatcher.Empty, DateTimeWrapper.InstancePlus4Hours, new DummySecurityStrategyBase());
}

public class DummyDomainEventDispatcher : IDomainEventDispatcher
{
    public static readonly DummyDomainEventDispatcher Empty = new();

    DummyDomainEventDispatcher()
    {
    }

    public Task Dispatch(IDomainEvent domainEvent) => throw new NotImplementedException();
}

public class DummySecurityStrategyBase : ISecurityStrategyBase
{
    public void Logon(IObjectSpace objectSpace) => throw new NotImplementedException();

    public void Logoff() => throw new NotImplementedException();

    public void ClearSecuredLogonParameters() => throw new NotImplementedException();

    public void ReloadPermissions() => throw new NotImplementedException();

    public Type GetModuleType() => throw new NotImplementedException();

    public IList<Type> GetBusinessClasses() => throw new NotImplementedException();

    public bool IsAuthenticated { get; }
    public Type UserType { get; }
    public object User { get; }
    public string UserName { get; }
    public object UserId { get; }
    public object LogonParameters { get; }
    public bool NeedLogonParameters { get; }
    public bool IsLogoffEnabled { get; }
    public IObjectSpace LogonObjectSpace { get; }
}