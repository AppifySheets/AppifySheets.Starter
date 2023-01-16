using System.Globalization;
using AppifySheets.Common.XAF.Module;
using AppifySheets.Common.XAF.Module.EfCore;
using AppifySheets.DatabaseModel.EfCore;
using AppifySheets.Module;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ApplicationBuilder;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Templates.ActionControls;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Win.ApplicationBuilder;
using DevExpress.ExpressApp.Win.Templates;
using DevExpress.ExpressApp.Win.Templates.Bars.ActionControls;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using EfCore.Infrastructure;

namespace AppifySheets.Desktop.Launcher;

public class ApplicationBuilder : IDesignTimeApplicationFactory
{
    public static WinApplication BuildApplication(string connectionString, IServiceProvider serviceProvider)
    {
        ArgumentNullException.ThrowIfNull(connectionString);
        var builder = WinApplication.CreateBuilder();

        builder.UseApplication<AppifySheetsDesktopApplication>(serviceProvider);
        builder.Modules
            .AddAuditTrailEFCore()
            .AddConditionalAppearance()
            // .AddFileAttachments()
            .AddNotifications()
            // .AddOffice()
            // .AddPivotChart()
            .AddReports(options =>
            {
                options.EnableInplaceReports = true;
                options.ReportDataType = typeof(DevExpress.Persistent.BaseImpl.EF.ReportDataV2);
                options.ReportStoreMode = DevExpress.ExpressApp.ReportsV2.ReportStoreModes.XML;
            })
            // .AddScheduler()
#if DEBUG
            // .AddScriptRecorder()
#endif
            .AddValidation(options => { options.AllowValidationDetailsAccess = false; })
            .AddViewVariants()
            // .Add<AppifySheetsBlazorModule>()
            .Add<AppifySheets_DatabaseModelModule_EfCore>()
            .Add<AppifySheetsCommonXafModule>()
            .Add<AppifySheetsCommonXafModuleEfCore>()
            .Add<AppifySheetsModule>();
        // builder.ObjectSpaceProviders
            // .AddSecuredEFCore()
            // .WithAuditedDbContext(contexts =>
            // {
            //     contexts.Configure<AppifySheetsEfCoreDbContext, AppifySheetsAuditingDbContext>(
            //         (application, businessObjectDbContextOptions) =>
            //         {
            //             
            //             businessObjectDbContextOptions.UseSqlServer(connectionString);
            //         },
            //         (application, auditHistoryDbContextOptions) => { auditHistoryDbContextOptions.UseSqlServer(connectionString); });
            // })
            // .AddNonPersistent()
            ;
        builder.Security
            .UseIntegratedMode(options =>
            {
                options.RoleType = typeof(ApplicationRole);
                options.UserType = typeof(ApplicationUser);
                options.UserLoginInfoType = typeof(ApplicationUserLoginInfo);
            })
            .UsePasswordAuthentication(options => options.IsSupportChangePassword = true);
        builder.AddBuildStep(application =>
        {
            // ((WinApplication)application).SplashScreen = new DevExpress.ExpressApp.Win.Utils.DXSplashScreen(
            //     typeof(XafDemoSplashScreen),
            //     new DefaultOverlayFormOptions());

            application.ApplicationName = @"AppifySheetsDesktopApplication";
            application.CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema;
//#if DEBUG
            //if(System.Diagnostics.Debugger.IsAttached) {
            application.DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;
            //}
//#endif
            // Subscriptions.AddSubscription(nameof(application.DatabaseVersionMismatch));
            application.DatabaseVersionMismatch += (s, e) =>
            {
                // e.Updater.Update();
                e.Handled = true;
            };
            
            // Subscriptions.AddSubscription(nameof(application.LastLogonParametersRead));
            
            application.LastLogonParametersRead += (s, e) =>
            {
                if (e.LogonObject is AuthenticationStandardLogonParameters logonParameters && string.IsNullOrEmpty(logonParameters.UserName))
                {
                    logonParameters.UserName = "Admin";
                }
            };
            // application.CustomizeFormattingCulture += winApplication_CustomizeFormattingCulture;
            // application.LastLogonParametersReading += winApplication_LastLogonParametersReading;
            // application.CustomizeTemplate += WinApplication_CustomizeTemplate;
            application.ConnectionString = connectionString;
        });

        return builder.Build();
    }

    // static void WinApplication_CustomizeTemplate(object? sender, CustomizeTemplateEventArgs e)
    // {
    //     if (e.Context == TemplateContext.ApplicationWindow || e.Context == TemplateContext.View)
    //     {
    //         var ribbonForm = e.Template as RibbonForm;
    //         var actionControlsSite = ribbonForm as IActionControlsSite;
    //         if (ribbonForm == null || actionControlsSite == null) return;
    //         var filtersActionControlContainer = actionControlsSite.ActionContainers.FirstOrDefault<IActionControlContainer>(x => x.ActionCategory == "Filters");
    //         if (filtersActionControlContainer is BarLinkActionControlContainer)
    //         {
    //             var barFiltersActionControlContainer = (BarLinkActionControlContainer)filtersActionControlContainer;
    //             var barFiltersItem = barFiltersActionControlContainer.BarContainerItem;
    //             var ribbonControl = ribbonForm.Ribbon;
    //             foreach (RibbonPage page in ribbonControl.Pages)
    //             {
    //                 foreach (RibbonPageGroup group in page.Groups)
    //                 {
    //                     var barFiltersItemLink = group.ItemLinks.FirstOrDefault<BarItemLink>(x => x.Item == barFiltersItem);
    //                     if (barFiltersItemLink != null)
    //                     {
    //                         group.ItemLinks.Remove(barFiltersItemLink);
    //                     }
    //                 }
    //             }
    //
    //             ribbonForm.Ribbon.PageHeaderItemLinks.Add(barFiltersItem);
    //         }
    //     }
    //     else if (e.Context == TemplateContext.LookupControl || e.Context == TemplateContext.LookupWindow)
    //     {
    //         var lookupControlTemplate = e.Template as LookupControlTemplate;
    //         if (lookupControlTemplate == null && e.Template is LookupForm)
    //         {
    //             lookupControlTemplate = ((LookupForm)e.Template).FrameTemplate;
    //         }
    //
    //         if (lookupControlTemplate != null)
    //         {
    //             lookupControlTemplate.ObjectsCreationContainer.ContainerId = "LookupNew";
    //             lookupControlTemplate.SearchActionContainer.ContainerId = "LookupFullTextSearch";
    //         }
    //     }
    // }
    //
    // static void winApplication_CustomizeFormattingCulture(object? sender, CustomizeFormattingCultureEventArgs e)
    // {
    //     e.FormattingCulture = CultureInfo.GetCultureInfo("en-US");
    // }

    // static void winApplication_LastLogonParametersReading(object? sender, LastLogonParametersReadingEventArgs e)
    // {
    //     if (string.IsNullOrWhiteSpace(e.SettingsStorage.LoadOption("", "UserName")))
    //     {
    //         e.SettingsStorage.SaveOption("", "UserName", "Sam");
    //     }
    // }

    XafApplication IDesignTimeApplicationFactory.Create()
        => throw new NotImplementedException();
}

public static class WinApplicationBuilderExtensions
{
    public static IWinApplicationBuilder UseApplication<TApplication>(
        this IWinApplicationBuilder builder, IServiceProvider serviceProvider)
        where TApplication : AppifySheetsDesktopApplication
    {
        builder.ApplicationFactory = (Func<AppifySheetsDesktopApplication>) (() => new AppifySheetsDesktopApplication(serviceProvider));
        return builder;
    }
}