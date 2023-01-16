using AppifySheets.Barbarosa.Domain.BaseModels;
using AppifySheets.Barbarosa.Domain.Models;
using AppifySheets.EfCore.Infrastructure.DbContext;
using EfCore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AppifySheets.EFCore.Migrations;

public class DesignTimeDbContextFactory : DesignTimeDbContextFactoryBase<ApplicationDbContext, ApplicationUser, BasicUser, BarbarosaRole, ApplicationUserLoginInfo>
{
    protected override void InitializeDbContext(DbContextOptionsBuilder<ApplicationDbContext> builder)
        => builder.UseNpgsql("Server=170.187.184.94;Port=15432;Database=appifysheets;User Id=_appifysheets_user_;Password=wKypbnBt3*yK^72AjM;Include Error Detail=True;"
            // => builder.UseNpgsql("Server=localhost;Port=15432;Database=barbarosa;User Id=barbarosa;Password=Barbarosa1;");
            // => builder.UseNpgsql("Server=li2056-83.members.linode.com;Port=5432;Database=barbarosa;User Id=postgres;Password=asdfqwer1234!@#$;",
            , b =>
            {
                b.MigrationsAssembly(GetType().Assembly.FullName);
                b.CommandTimeout(90);
            });
    // => builder.UseNpgsql(connectionString);

    protected override ApplicationDbContext DbContextCreator(DbContextOptions<ApplicationDbContext> options)
        => new(options, null, null, null, null);
}