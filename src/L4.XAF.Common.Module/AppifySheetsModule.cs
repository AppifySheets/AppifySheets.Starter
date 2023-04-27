using AppifySheets.EfCoreIntegration.ModuleBase;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using L1.Domain.BaseModels;

namespace L4.XAF.Common.Module;

public sealed class AppifySheetsModule : AppifySheetsEfCoreModuleBase
{
    public AppifySheetsModule() : base(typeof(BasicUser).Assembly)
    {
    }

    public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDb) => new Updater(objectSpace, versionFromDb).ToEnumerable();
}