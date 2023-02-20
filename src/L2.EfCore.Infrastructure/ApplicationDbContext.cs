using AppifySheets.Common.XAF.Module.Helpers;
using AppifySheets.Domain.Common;
using AppifySheets.EfCore.Infrastructure.DbContext;
using AppifySheets.EfCore.Infrastructure.Postgres;
using L1.Domain.BaseModels;
using L1.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace L2.EfCore.Infrastructure;

public class ConnectionStringInitializer : ConnectionStringStore
{
    protected override string GetConnectionString() => "Server=144.24.160.225;Port=15432;Database=appifysheets;User Id=_appifysheets_user_;Password=ryI^^Tn7%rl39X2TbpI6l";
}

public class ApplicationDbContext : AppifySheetsEfCoreDbContextBasePostgres<ApplicationDbContext, ApplicationUser, BasicUser, ApplicationRole, ApplicationUserLoginInfo>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDomainEventDispatcher dispatcher, IDateTime dateTime) : base(options, dispatcher, dateTime)
    {
    }

    // public DbSet<City> Cities => Set<City>();
    //
    // public DbSet<Patient> Patients => Set<Patient>();
    // public DbSet<Country> Countries => Set<Country>();

    protected override Unit OnConfiguringCore(DbContextOptionsBuilder optionsBuilder) => Unit.Value;

    protected override Task SaveChangesCoreAsync() => Task.CompletedTask;

    protected override void OnModelCreatingCore(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(o => o.HasIndex(e => e.CityName));

        modelBuilder.Entity<Entity>()
            .HasMany(e => e.EntityCollectionMembers)
            .WithOne(ecm => ecm.ParentEntity);

        modelBuilder.Entity<Entity>()
            .HasMany(e => e.EntityMembers)
            .WithOne(ecm => ecm.ParentEntity);
    }
}