using System;
using System.Collections.Generic;
using AppifySheets.Blazor.XAF.EfCore.ApplicationBase.Postgres;
using AppifySheets.Domain.Common;
using AppifySheets.EfCore.ApplicationBase;
using CSharpFunctionalExtensions;
using L1.Domain.BaseModels;
using L2.EfCore.Infrastructure;
using L3.XAF.Common.Module;
using L4.XAF.Blazor.Module;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace L5.XAF.Blazor.Server;

public class Program : BlazorProgramBase<Startup>
{
    public static int Main(string[] args) => new Program().MainBase(args);
    protected override Maybe<Type> OneTypeFromProxyTypesAssembly => Maybe.None;
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

    protected override void ConfigureServicesCore(IServiceCollection services)
    {
    }
}