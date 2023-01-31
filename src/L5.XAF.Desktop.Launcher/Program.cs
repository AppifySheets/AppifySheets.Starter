using AppifySheets.Desktop.XAF.LauncherBase;
using L1.Domain.BaseModels;
using L2.EfCore.Infrastructure;
using L3.XAF.Common.Module;

namespace L5.XAF.Desktop.Launcher;

public class Program : WinProgramBase<AppifySheetsDesktopApplication, AppifySheetsModule, ApplicationDbContext, ApplicationUser, BasicUser, ApplicationRole, ApplicationUserLoginInfo>
{
    [STAThread]
    public static int Main(string[] arguments)
    {
        var environment = arguments.SingleOrDefault()?.ToLower() == "production" ? "Production" : "Development";

        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", environment);
        try
        {
            return new Program().MainBase(arguments);
        }
        catch (Exception ex)
        {
            var innerException = ex.InnerException ?? ex;

            MessageBox.Show(innerException.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return -1;
        }
    }

    protected override Func<IServiceProvider, AppifySheetsDesktopApplication> ApplicationFactory => sp => new AppifySheetsDesktopApplication(sp);
}

public class AppifySheetsDesktopApplication : AppifySheetsDesktopApplicationBase<ApplicationDbContext>
{
    public AppifySheetsDesktopApplication(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}