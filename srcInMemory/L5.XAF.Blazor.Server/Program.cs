using System;
using System.Collections.Generic;
using AppifySheets.Blazor.XAF.EfCore.ApplicationBase.Postgres;
using AppifySheets.Common.XAF.Module.Extra;
using AppifySheets.Domain.Common;
using AppifySheets.EfCore.ApplicationBase;
using CSharpFunctionalExtensions;
using L1.Domain.BaseModels;
using L2.EfCore.Infrastructure;
using L3.XAF.Common.Module;
using L4.XAF.Blazor.Module;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace L5.XAF.Blazor.Server;

public class Program : BlazorProgramBase<Startup>
{
    public static int Main(string[] args) => new Program().MainBase(args);
    protected override Maybe<Type> OneTypeFromProxyTypesAssembly => typeof(CityProxy);
}

// ReSharper disable once ClassNeverInstantiated.Global
public class AppifySheetsBlazorApplication : AppifySheetsBlazorApplicationBase<ApplicationDbContext>
{
    protected override void CheckCompatibilityCore()
    {
        base.CheckCompatibilityCore();
    }

    protected override string ApplicationNameCore => "AppifySheets Template";
}

// ReSharper disable once ClassNeverInstantiated.Global
public class Startup : StartupBase<AppifySheetsBlazorApplication, ApplicationDbContext, ApplicationUser, BasicUser, ApplicationRole, ApplicationUserLoginInfo>
{
    public Startup(IConfiguration configuration) : base(configuration)
    {
    }

    protected override IEnumerable<Type> ModulesToAdd => Types.From<AppifySheetsModule, BlazorModule>();

    protected override void ConfigureCoreBefore(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UsePathBase("/appify1");
    }

    protected override void UseDbServer(DbContextOptionsBuilder options, string connectionString)
    {
        options.UseInMemoryDatabase("InMemory");
    }

    protected override void ConfigureServicesCore(IServiceCollection services)
    {
    }
}