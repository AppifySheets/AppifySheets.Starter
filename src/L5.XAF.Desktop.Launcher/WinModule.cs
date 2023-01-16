// using System.ComponentModel;
//
// namespace L5.XAF.Desktop.Launcher;
//
// [ToolboxItemFilter("Xaf.Platform.Win")]
// public sealed class MainDemoWinModule : ModuleBase {
//     public MainDemoWinModule() {
//         Description = "MainDemo Win module";
//         ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.MainFormTemplateLocalizer));
//         ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.DetailViewFormTemplateLocalizer));
//         ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.NestedFrameTemplateLocalizer));
//         ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.LookupControlTemplateLocalizer));
//         ResourcesExportedToModel.Add(typeof(DevExpress.ExpressApp.Win.Templates.PopupFormTemplateLocalizer));
//         DevExpress.ExpressApp.Scheduler.Win.SchedulerListEditor.DailyPrintStyleCalendarHeaderVisible = false;
//         DevExpress.ExpressApp.ReportsV2.Win.WinReportServiceController.UseNewWizard = true;
//     }
//
//     public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
//         ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
//         return new ModuleUpdater[] { updater };
//     }
// }
