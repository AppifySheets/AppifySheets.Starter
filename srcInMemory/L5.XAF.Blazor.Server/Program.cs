using System;
using System.Collections.Generic;
using AppifySheets.Domain.Common;
using AppifySheets.EfCore.ApplicationBase;
using CSharpFunctionalExtensions;
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
    protected override Maybe<Type> OneTypeFromProxyTypesAssembly => typeof(CityProxy);
}

// ReSharper disable once ClassNeverInstantiated.Global
public class AppifySheetsBlazorApplication : AppifySheetsBlazorApplicationBase<ApplicationDbContext>
{
    protected override string ApplicationNameCore => "AppifySheets In-Memory Demo";
}

// ReSharper disable once ClassNeverInstantiated.Global
public class Startup : StartupBaseInMemory<AppifySheetsBlazorApplication, ApplicationDbContext, ApplicationUser, BasicUser, ApplicationRole, ApplicationUserLoginInfo>
{
    public Startup(IConfiguration configuration) : base(configuration)
    {
    }

    protected override IEnumerable<Type> ModulesToAdd => Types.From<AppifySheetsModule, BlazorModule>();

    protected override void ConfigureCoreBefore(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UsePathBase("/appify1");
    }

    protected override void ConfigureServicesCore(IServiceCollection services)
    {
    }
}