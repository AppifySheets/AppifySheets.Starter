using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Http;
using AppifySheets.Barbarosa.Domain.BaseModels;
using AppifySheets.Barbarosa.Domain.Models;
using AppifySheets.Blazor.Module;
using AppifySheets.Domain.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AppifySheets.EfCore.ApplicationBase;
using AppifySheets.Module;
using EfCore.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace AppifySheets.Blazor.Server;

public class Startup : StartupBase<BarbarosaApplication, ApplicationDbContext, ApplicationUser, BasicUser, BarbarosaRole, ApplicationUserLoginInfo>
{
    static readonly HttpClient HttpClient = new();

    public Startup(IConfiguration configuration) : base(configuration)
    {
    }

    protected override IEnumerable<Type> ModulesToAdd => Types.From<AppifySheetsModule, BarbarosaBlazorModule>();

    protected override void UseDbServer(DbContextOptionsBuilder options, string connectionString)
    {
        options.UseNpgsql(connectionString,
            opt =>
            {
                opt.EnableRetryOnFailure(5);
                opt.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
            });
    }

    protected override void ConfigureServicesCore(IServiceCollection services)
    {
        services.AddSingleton(_ => HttpClient);
    }

    protected override void ConfigureCore(IApplicationBuilder app, IWebHostEnvironment env)
    {
        var config = Configuration.GetSection("PathBaseSettings:ApplicationPathBase");

        if (!config.Exists()) return;

        app.UsePathBase(config.Value);
    }
}