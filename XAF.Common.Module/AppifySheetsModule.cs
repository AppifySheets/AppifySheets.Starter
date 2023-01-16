using System.ComponentModel;
using AppifySheets.Barbarosa.Domain.Models;
using AppifySheets.Domain.Common;
using AppifySheets.EfCoreIntegration.ModuleBase;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using DevExpress.Persistent.BaseImpl.EF;

namespace AppifySheets.Module;

public sealed class AppifySheetsModule : AppifySheetsEfCoreModuleBase
{
    public AppifySheetsModule()
        : base(Types.From<City>(),
            Types.From<FileData, FileAttachment>())
    {
    }

    public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDb) => new Updater(objectSpace, versionFromDb).ToEnumerable();
}