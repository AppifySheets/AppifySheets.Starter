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
    }
}