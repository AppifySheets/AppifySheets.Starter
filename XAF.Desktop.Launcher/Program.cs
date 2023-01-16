using System.Reflection;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Win.EasyTest;
using DevExpress.ExpressApp.Win.Utils;
using DevExpress.Persistent.Base;
using DevExpress.XtraEditors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AppifySheets.Desktop.Launcher;

public class Program
{
    static bool ContainsArgument(string[] args, string argument)
    {
        return args.Any(arg => arg.TrimStart('/').TrimStart('-').ToLower() == argument.ToLower());
    }

    // static IConfiguration Configuration { get; }

    

    static IHostBuilder CreateDefaultBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration(app => { app.AddJsonFile("appsettings.json"); })
            .ConfigureServices((hostBuilder, services) => Startup.ConfigureServices(services, hostBuilder.Configuration));
    }

    [STAThread]
    public static int Main(string[] arguments)
    {
        if (ContainsArgument(arguments, "help") || ContainsArgument(arguments, "h"))
        {
            Console.WriteLine("Updates the database when its version does not match the application's version.");
            Console.WriteLine();
            Console.WriteLine($"    {Assembly.GetExecutingAssembly().GetName().Name}.exe --updateDatabase [--forceUpdate --silent]");
            Console.WriteLine();
            Console.WriteLine("--forceUpdate - Marks that the database must be updated whether its version matches the application's version or not.");
            Console.WriteLine("--silent - Marks that database update proceeds automatically and does not require any interaction with the user.");
            Console.WriteLine();
            Console.WriteLine($"Exit codes: 0 - {DBUpdaterStatus.UpdateCompleted}");
            Console.WriteLine($"            1 - {DBUpdaterStatus.UpdateError}");
            Console.WriteLine($"            2 - {DBUpdaterStatus.UpdateNotNeeded}");
            return 0;
        }

        Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);

        FrameworkSettings.DefaultSettingsCompatibilityMode = FrameworkSettingsCompatibilityMode.Latest;
        WindowsFormsSettings.LoadApplicationSettings();
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        DevExpress.Utils.ToolTipController.DefaultController.ToolTipType = DevExpress.Utils.ToolTipType.SuperTip;


        // Setup Host
        var host = CreateDefaultBuilder().Build();

        // var services = new ServiceCollection();
        //
        // ConfigureServices(services);

        // using (var serviceProvider = services.BuildServiceProvider())
        // {
        //     var form1 = serviceProvider.GetRequiredService<Form1>();
        //     Application.Run(form1);
        // }

        // InitializeTracing();
        // var connectionString = GetConnectionString(arguments);
        using var scope = host.Services.CreateScope(); // ApplicationBuilder.BuildApplication(connectionString, services.BuildServiceProvider());
        var winApplication = scope.ServiceProvider.GetRequiredService<WinApplication>();

        if (ContainsArgument(arguments, "updateDatabase"))
        {
            using var dbUpdater = new WinDBUpdater(() => winApplication);
            return dbUpdater.Update(
                forceUpdate: ContainsArgument(arguments, "forceUpdate"),
                silent: ContainsArgument(arguments, "silent"));
        }

#if DEBUG
        EasyTestRemotingRegistration.Register();
#endif

        try
        {
            winApplication.Setup();
            winApplication.Start();
        }
        catch (Exception e)
        {
            winApplication.StopSplash();
            winApplication.HandleException(e);
        }

        return 0;
    }

    static void InitializeTracing()
    {
        if (Tracing.GetFileLocationFromSettings() == DevExpress.Persistent.Base.FileLocation.CurrentUserApplicationDataFolder)
        {
            Tracing.LocalUserAppDataPath = Application.LocalUserAppDataPath;
        }

        Tracing.Initialize();
    }
}