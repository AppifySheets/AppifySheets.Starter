using System;
using System.Collections.Generic;
using System.Net.Http;
using AppifySheets.Blazor.Module;
using AppifySheets.Domain.Common;
using AppifySheets.EfCore.ApplicationBase;
using AppifySheets.Module;
using EfCore.Infrastructure;
using L1.Domain.BaseModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace L5.XAF.Blazor.Server;

public class Startup : StartupBase<AppifySheetsBlazorApplication, ApplicationDbContext, ApplicationUser, BasicUser, ApplicationRole, ApplicationUserLoginInfo>
{
    static readonly HttpClient HttpClient = new();

    public Startup(IConfiguration configuration) : base(configuration)
    {
    }

    protected override IEnumerable<Type> ModulesToAdd => Types.From<AppifySheetsModule, BlazorModule>();

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

    protected override string ConnectionString => ApplicationDbContext.ProductionConnectionString;

    protected override void ConfigureCore(IApplicationBuilder app, IWebHostEnvironment env)
    {
        var config = Configuration.GetSection("PathBaseSettings:ApplicationPathBase");

        if (!config.Exists()) return;

        app.UsePathBase(config.Value);
    }
}