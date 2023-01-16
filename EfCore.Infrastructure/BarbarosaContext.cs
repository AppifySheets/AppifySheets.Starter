using System.ComponentModel;
using AppifySheets.Barbarosa.Domain.BaseModels;
using AppifySheets.Barbarosa.Domain.Models;
using AppifySheets.Common.XAF.Module.Helpers;
using AppifySheets.Domain.Common;
using AppifySheets.EfCore.Infrastructure.DbContext;
using AppifySheets.Users.Infrastructure;
using DevExpress.ExpressApp.Blazor.AmbientContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Infrastructure;

public class BarbarosaRole : ApplicationRole<ApplicationUser>
{
}

[DefaultProperty(nameof(DisplayName))]
public class ApplicationUser : ApplicationUserBase<ApplicationUser, BasicUser, ApplicationUserLoginInfo, BarbarosaRole>
{
    protected override ApplicationUserLoginInfo Creator() => new();
}

public class ApplicationUserLoginInfo : ApplicationUserLoginInfo<ApplicationUser, BasicUser, ApplicationUserLoginInfo, BarbarosaRole>
{
}

public class ApplicationDbContext : AppifySheetsEfCoreDbContextBase<ApplicationDbContext, ApplicationUser, BasicUser, BarbarosaRole, ApplicationUserLoginInfo>
{
    readonly IMediator _mediator;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDomainEventDispatcher dispatcher, IDateTime dateTime, HttpClient httpClient, IMediator mediator)
        : base(options, dispatcher, dateTime)
    {
        _mediator = mediator;
        
        var currentUserName = ValueManagerContext.IsActive
            ? "Users".Use(s => s.IsNullOrEmpty() ? "NoUser" : s)
            : "ValueManagerIsNotActive";

        var connection = Database?.GetDbConnection();
        if (connection == null) return;
        connection.ConnectionString += $";Application Name='{currentUserName}'";
    }

    public DbSet<City> Cities => Set<City>();

    protected override void OnConfiguringCore(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override Task SaveChangesCoreAsync()
    {
        return Task.CompletedTask;
    }

    protected override void OnModelCreatingCore(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(o =>
        {
            o.HasIndex(e => e.CityName);
        });

    }

    protected override void DbSpecificRowVersioningSetup<TEntity>(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TEntity>()
            .Property<uint>("xmin")
            .HasColumnType("xid")
            .ValueGeneratedOnAddOrUpdate()
            .IsConcurrencyToken();
    
        // modelBuilder.Entity<TEntity>()
        //     .UseXminAsConcurrencyToken();
    }
}