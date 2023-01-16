using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using AppifySheets.EfCore.Infrastructure.Controllers;
using DevExpress.ExpressApp.Blazor.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql.Logging;
using Serilog;
using Serilog.Events;

namespace AppifySheets.Blazor.Server;

class NpgsqlLoggingProvider : INpgsqlLoggingProvider
{
    public NpgsqlLogger CreateLogger(string name) => new NLogLogger();
}

class NLogLogger : NpgsqlLogger
{
    // readonly Logger _log;
    //
    // internal NLogLogger(string name)
    // {
    //     _log = LogManager.GetLogger(name);
    // }

    // public override bool IsEnabled(NpgsqlLogLevel level)
    // {
    //     return _log.IsEnabled(ToNLogLogLevel(level));
    // }

    public override bool IsEnabled(NpgsqlLogLevel level) => true;

    public override void Log(NpgsqlLogLevel level, int connectorId, string msg, Exception exception = null)
    {
        // var ev = new LogEventInfo(ToNLogLogLevel(level), "", msg);

        // if (exception != null)
        //     ev.Exception = exception;
        // if (connectorId != 0)
        //     ev.Properties["ConnectorId"] = connectorId;
        if (msg.Contains("Context 'BarbarosaContext2' started tracking")) return;
        Serilog.Log.Write(ToNLogLogLevel(level), exception, "Npgsql {Message}", msg);

        //_log.Log(ev);
    }

    static LogEventLevel ToNLogLogLevel(NpgsqlLogLevel level)
    {
        return level switch
        {
            NpgsqlLogLevel.Trace => LogEventLevel.Information,
            NpgsqlLogLevel.Debug => LogEventLevel.Information,
            NpgsqlLogLevel.Info => LogEventLevel.Information,
            NpgsqlLogLevel.Warn => LogEventLevel.Warning,
            NpgsqlLogLevel.Error => LogEventLevel.Error,
            NpgsqlLogLevel.Fatal => LogEventLevel.Fatal,
            _ => throw new ArgumentOutOfRangeException("level")
        };
    }
}

public class Program
{
    static bool ContainsArgument(string[] args, string argument) =>
        (args ?? Enumerable.Empty<string>()).Any(arg => string.Equals(arg.TrimStart('/').TrimStart('-'), argument, StringComparison.CurrentCultureIgnoreCase));

    public static int Main(string[] args)
    {
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        
        // if (Debugger.IsAttached)
        //     NpgsqlLogManager.Provider = new NpgsqlLoggingProvider();
        static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
            => Log.Error(e.ExceptionObject as Exception ?? new Exception(e.ExceptionObject.ToString()), nameof(CurrentDomainOnUnhandledException));

        AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException; // AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        // ProxiesType.AssemblyProxyTypeSet(typeof(SheetsV1));

        DevExpress.ExpressApp.Blazor.BlazorApplication.EnableDefaultSelectionDependencyType = false;

        if (ContainsArgument(args, "help") || ContainsArgument(args, "h"))
        {
            Console.WriteLine(@"Updates the database when its version does not match the application's version.");
            Console.WriteLine();
            Console.WriteLine($@"    {Assembly.GetExecutingAssembly().GetName().Name}.exe --updateDatabase [--forceUpdate --silent]");
            Console.WriteLine();
            Console.WriteLine(@"--forceUpdate - Marks that the database must be updated whether its version matches the application's version or not.");
            Console.WriteLine(@"--silent - Marks that database update proceeds automatically and does not require any interaction with the user.");
            Console.WriteLine();
            Console.WriteLine($@"Exit codes: 0 - {DBUpdater.StatusUpdateCompleted}");
            Console.WriteLine($@"            1 - {DBUpdater.StatusUpdateError}");
            Console.WriteLine($@"            2 - {DBUpdater.StatusUpdateNotNeeded}");
        }
        else
        {
            DevExpress.ExpressApp.FrameworkSettings.DefaultSettingsCompatibilityMode = DevExpress.ExpressApp.FrameworkSettingsCompatibilityMode.Latest;
            var host = CreateHostBuilder(args).Build();

            if (ContainsArgument(args, "updateDatabase"))
            {
                using var serviceScope = host.Services.CreateScope();

                var updateResult = serviceScope.ServiceProvider.GetRequiredService<IDBUpdater>().Update(ContainsArgument(args, "forceUpdate"), ContainsArgument(args, "silent"));

                if (updateResult != 0 && Debugger.IsAttached)
                {
                    Debugger.Break();
                }
            }

            host.Run();
        }

        return 0;
    }

    
    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseSerilog((context, lc) =>
                lc
                    .Enrich.WithProperty("ApplicationVersion", AssemblyInfo_GeneralModules.ApplicationVersion)
                    .Enrich.WithProperty("Application", "Barbarosa" + (Debugger.IsAttached ? "-Debug-" : ""))
                    .Enrich.WithProperty("MachineName", Environment.MachineName)
                    .MinimumLevel.Information()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                    .MinimumLevel.Override("DevExpress", LogEventLevel.Warning)
                    .WriteTo.Console()
#if DEBUG
#else
         .WriteTo.Seq("http://seq:5341")
#endif
                )
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
}