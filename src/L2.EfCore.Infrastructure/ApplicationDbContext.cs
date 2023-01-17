using System.ComponentModel;
using AppifySheets.Common.XAF.Module.Helpers;
using AppifySheets.Domain.Common;
using AppifySheets.EfCore.Infrastructure.DbContext;
using AppifySheets.EfCore.Infrastructure.Postgres;
using AppifySheets.Users.Infrastructure;
using DevExpress.ExpressApp.Blazor.AmbientContext;
using L1.Domain.BaseModels;
using L1.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace L2.EfCore.Infrastructure;

public class ApplicationRole : ApplicationRole<ApplicationUser>
{
}

[DefaultProperty(nameof(DisplayName))]
public class ApplicationUser : ApplicationUserBase<ApplicationUser, BasicUser, ApplicationUserLoginInfo, ApplicationRole>
{
    protected override ApplicationUserLoginInfo Creator() => new();
}

public class ApplicationUserLoginInfo : ApplicationUserLoginInfo<ApplicationUser, BasicUser, ApplicationUserLoginInfo, ApplicationRole>
{
}

public class ApplicationDbContext : AppifySheetsEfCoreDbContextBasePostgres<ApplicationDbContext, ApplicationUser, BasicUser, ApplicationRole, ApplicationUserLoginInfo>
{
    // readonly IMediator _mediator;

    public const string ProductionConnectionString = "Server=localhost;Port=5432;Database=appifysheets;User Id=_appifysheets_user_;Password=ryI^^Tn7%rl39X2TbpI6l";
    public const string DevelopmentConnectionString = "Server=postgres;Port=5432;Database=appifysheets;User Id=_appifysheets_user_;Password=ryI^^Tn7%rl39X2TbpI6l";
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDomainEventDispatcher dispatcher, IDateTime dateTime, HttpClient httpClient) : base(options, dispatcher, dateTime)
    {
    }

    public DbSet<City> Cities => Set<City>();

    protected override Unit OnConfiguringCore(DbContextOptionsBuilder optionsBuilder) => Unit.Value;

    protected override Task SaveChangesCoreAsync() => Task.CompletedTask;

    protected override void OnModelCreatingCore(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(o => o.HasIndex(e => e.CityName));
    }

}