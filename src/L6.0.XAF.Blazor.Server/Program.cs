using System;
using System.Collections.Generic;
using AppifySheets.Domain.Common;
using AppifySheets.EfCore.ApplicationBase;
using AppifySheets.EfCore.Infrastructure.ConnectionHelpers;
using CSharpFunctionalExtensions;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Utils;
using L1.Domain.BaseModels;
using L2.EfCore.Infrastructure;
using L4.XAF.Blazor.Module;
using L4.XAF.Common.Module;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace L6.XAF.Blazor.Server;

public class Program : BlazorProgramBase<Startup>
{
    public static int Main(string[] args) => new Program().MainBase(args);
    protected override Maybe<Type> OneTypeFromProxyTypesAssembly => Maybe.None;
    protected override ServerPort SeqAddress => DefaultSeqAddress;
}

// ReSharper disable once ClassNeverInstantiated.Global
public class AppifySheetsBlazorApplication : AppifySheetsBlazorApplicationBase<ApplicationDbContext>
{
    public AppifySheetsBlazorApplication()
    {
        LastLogonParametersRead += (s, e) =>
        {
            if (e.LogonObject is AuthenticationStandardLogonParameters logonParameters && string.IsNullOrEmpty(logonParameters.UserName)) logonParameters.UserName = "Admin";
        };
    }

    protected override string ApplicationNameCore => StaticSettings.ApplicationName;
    protected override SettingsStorage CreateLogonParameterStoreCore() => new EmptySettingsStorage();

    class EmptySettingsStorage : SettingsStorage
    {
        public override string LoadOption(string optionPath, string optionName) => null;

        public override void SaveOption(string optionPath, string optionName, string optionValue)
        {
        }
    }
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
    }

    protected override void ConfigureServicesCore(IServiceCollection services)
    {
    }

    protected override int HoursOffsetFromUtc => 4;
}