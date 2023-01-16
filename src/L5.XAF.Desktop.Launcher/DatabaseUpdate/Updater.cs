using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;

namespace AppifySheets.Desktop.Launcher.DatabaseUpdate;
public class Updater : ModuleUpdater {
    public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
}
