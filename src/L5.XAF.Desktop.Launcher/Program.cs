using AppifySheets.Desktop.XAF.LauncherBase;
using L1.Domain.BaseModels;
using L2.EfCore.Infrastructure;
using L3.XAF.Common.Module;

namespace L5.XAF.Desktop.Launcher;

public class Program : WinProgramBase<AppifySheetsDesktopApplication, AppifySheetsModule, ApplicationDbContext, ApplicationUser, BasicUser, ApplicationRole, ApplicationUserLoginInfo>
{
    [STAThread]
    public static int Main(string[] arguments) => new Program().MainBase(arguments);

    protected override Func<IServiceProvider, AppifySheetsDesktopApplication> ApplicationFactory => sp => new AppifySheetsDesktopApplication(sp);
}

public class AppifySheetsDesktopApplication : AppifySheetsDesktopApplicationBase<ApplicationDbContext>
{
    public AppifySheetsDesktopApplication(IServiceProvider serviceProvider):base(serviceProvider)
    {
    }
}