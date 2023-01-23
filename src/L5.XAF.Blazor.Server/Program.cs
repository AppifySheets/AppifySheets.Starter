using System;
using System.Collections.Generic;
using AppifySheets.Blazor.Module;
using AppifySheets.Blazor.XAF.EfCore.ApplicationBase.Postgres;
using AppifySheets.Common.XAF.Module.Extra;
using AppifySheets.Domain.Common;
using AppifySheets.EfCore.ApplicationBase;
using L1.Domain.BaseModels;
using L2.EfCore.Infrastructure;
using L3.XAF.Common.Module;
using L4.XAF.Blazor.Module;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace L5.XAF.Blazor.Server;

public class Program : BlazorProgramBase<Startup>
{
    public static int Main(string[] args) => new Program().MainBase(args);
}

public class AppifySheetsBlazorApplication : AppifySheetsBlazorApplicationBase<ApplicationDbContext>
{
    protected override string ApplicationNameCore => "AppifySheets Template";
}

public class Startup : StartupBasePostgres<AppifySheetsBlazorApplication, ApplicationDbContext, ApplicationUser, BasicUser, ApplicationRole, ApplicationUserLoginInfo>
{
    public Startup(IConfiguration configuration) : base(configuration)
    {
    }

    protected override IEnumerable<Type> ModulesToAdd => Types.From<AppifySheetsModule, BlazorModule>();
    protected override string ConnectionString => ApplicationDbContext.ProductionConnectionString;
    protected override Unit ConfigureCore(IApplicationBuilder app, IWebHostEnvironment env) => Unit.Default;
    protected override Unit ConfigureServicesCore(IServiceCollection services) => Unit.Default;
}

