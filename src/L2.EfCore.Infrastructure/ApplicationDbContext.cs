using AppifySheets.Common.XAF.Module.Helpers;
using AppifySheets.Domain.Common;
using AppifySheets.EfCore.Infrastructure.ConnectionHelpers;
using AppifySheets.EfCore.Infrastructure.DbContext;
using DevExpress.ExpressApp.Security;
using L1.Domain.BaseModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static AppifySheets.EfCore.Infrastructure.ConnectionHelpers.ServerPort;

namespace L2.EfCore.Infrastructure;

public static class ConnectionStringInitializer
{
    public static PostgresConnectionStringBuilder GetConnectionString()
        => PostgresConnectionStringBuilder.AppifySheets(
            ServerPortChecker.GetFirstAvailable(From("144.24.160.225", 15432)).ThrowOnFailureOrSuccessfulResult(),
            "ryI^^Tn7%rl39X2TbpI6l");
}
public class ApplicationDbContext : AppifySheetsEfCoreDbContextBaseInMemory<ApplicationDbContext, ApplicationUser, BasicUser, ApplicationRole, ApplicationUserLoginInfo>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDomainEventDispatcher dispatcher, IDateTime dateTime, ISecurityStrategyBase securityStrategyBase)
        : base(options, dispatcher, dateTime, securityStrategyBase)
    {
    }

    protected override Unit OnConfiguringCore(DbContextOptionsBuilder optionsBuilder) => Unit.Value;

    protected override Task SaveChangesCoreAsync() => Task.CompletedTask;

    protected override void OnModelCreatingCore(ModelBuilder modelBuilder)
    {
    }
}