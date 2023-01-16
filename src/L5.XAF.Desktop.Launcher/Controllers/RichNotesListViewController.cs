using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Model;

namespace AppifySheets.Desktop.Launcher.Controllers;
public class RichNotesListViewController : ObjectViewController<DevExpress.ExpressApp.ListView, Note> {
    static RichNotesListViewController() {
        RichEditControlCompatibility.DefaultFontName = "Tahoma";
        RichEditControlCompatibility.DefaultFontSize = 8;
    }
    protected override void OnViewControlsCreated() {
        base.OnViewControlsCreated();
        var gridListEditor = View.Editor as GridListEditor;
        if (gridListEditor?.GridView == null) return;
        foreach(GridColumn column in gridListEditor.GridView.Columns) {
            if(column.ColumnEdit is RepositoryItemRichTextEdit editor) {
                editor.VerticalIndent = 2;
            }
            else {
                column.AppearanceCell.Font = new Font("Tahoma", 8);
            }
        }
    }
}
