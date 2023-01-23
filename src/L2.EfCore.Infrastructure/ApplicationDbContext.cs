using AppifySheets.Common.XAF.Module.Helpers;
using AppifySheets.Domain.Common;
using AppifySheets.EfCore.Infrastructure.Postgres;
using L1.Domain.BaseModels;
using L1.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace L2.EfCore.Infrastructure;

public class ApplicationDbContext : AppifySheetsEfCoreDbContextBasePostgres<ApplicationDbContext, ApplicationUser, BasicUser, ApplicationRole, ApplicationUserLoginInfo>
{
    // readonly IMediator _mediator;

    public const string ProductionConnectionString = "Server=144.24.160.225;Port=15432;Database=appifysheets;User Id=_appifysheets_user_;Password=ryI^^Tn7%rl39X2TbpI6l";
    public const string DevelopmentConnectionString = "Server=postgres;Port=15432;Database=appifysheets;User Id=_appifysheets_user_;Password=ryI^^Tn7%rl39X2TbpI6l";
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDomainEventDispatcher dispatcher, IDateTime dateTime, HttpClient httpClient) : base(options, dispatcher, dateTime)
    {
    }

    public DbSet<City> Cities => Set<City>();
    public DbSet<Patient> Patients => Set<Patient>();

    protected override Unit OnConfiguringCore(DbContextOptionsBuilder optionsBuilder) => Unit.Value;

    protected override Task SaveChangesCoreAsync() => Task.CompletedTask;

    protected override void OnModelCreatingCore(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(o => o.HasIndex(e => e.CityName));
    }

}