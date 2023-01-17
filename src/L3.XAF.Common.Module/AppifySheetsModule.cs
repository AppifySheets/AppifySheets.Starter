using AppifySheets.Domain.Common;
using AppifySheets.EfCoreIntegration.ModuleBase;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using DevExpress.Persistent.BaseImpl.EF;
using L1.Domain.Models;
using Updater = AppifySheets.Module.Updater;

namespace L3.XAF.Common.Module;

public sealed class AppifySheetsModule : AppifySheetsEfCoreModuleBase
{
    public AppifySheetsModule()
        : base(typeof(City).Assembly.TypesFromAssembly().Where(t => !t.IsAbstract),
            Types.From<FileData, FileAttachment>())
    {
    }

    public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDb) => new Updater(objectSpace, versionFromDb).ToEnumerable();
}