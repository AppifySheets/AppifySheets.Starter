using AppifySheets.Common.XAF.Module.Helpers;
using AppifySheets.Domain.Common;
using AppifySheets.EfCore.Infrastructure.DbContext;
using L1.Domain.BaseModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace L2.EfCore.Infrastructure;

public class ConnectionStringInitializer : ConnectionStringStore
{
    protected override string GetConnectionString() => "Server=144.24.160.225;Port=15432;Database=appifysheets;User Id=_appifysheets_user_;Password=ryI^^Tn7%rl39X2TbpI6l";
}

public class ApplicationDbContext : AppifySheetsEfCoreDbContextBaseInMemory<ApplicationDbContext, ApplicationUser, BasicUser, ApplicationRole, ApplicationUserLoginInfo>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDomainEventDispatcher dispatcher, IDateTime dateTime) : base(options, dispatcher, dateTime)
    {
    }

    protected override Unit OnConfiguringCore(DbContextOptionsBuilder optionsBuilder) => Unit.Value;

    protected override Task SaveChangesCoreAsync() => Task.CompletedTask;

    protected override void OnModelCreatingCore(ModelBuilder modelBuilder)
    {
    }
}