using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.XtraGrid.Columns;

namespace AppifySheets.Desktop.Launcher.Controllers;
public class WinTooltipController : ViewController<DevExpress.ExpressApp.ListView> {
    public WinTooltipController() {
        this.ViewControlsCreated += new System.EventHandler(this.WinTooltipController_ViewControlsCreated);
    }

    void WinTooltipController_ViewControlsCreated(object? sender, EventArgs e) {
        var listEditor = View.Editor as GridListEditor;
        if (listEditor == null) return;
        foreach(GridColumn column in listEditor.GridView.Columns) {
            column.ToolTip = "Click to sort by " + column.Caption;
        }
    }
}
