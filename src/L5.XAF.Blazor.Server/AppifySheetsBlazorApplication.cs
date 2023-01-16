using AppifySheets.EfCore.ApplicationBase;
using EfCore.Infrastructure;

namespace L5.XAF.Blazor.Server;

// ReSharper disable once ClassNeverInstantiated.Global
public class AppifySheetsBlazorApplication : AppifySheetsBlazorApplicationBase<ApplicationDbContext>
{
    protected override string ApplicationNameCore => "AppifySheets Template";
}