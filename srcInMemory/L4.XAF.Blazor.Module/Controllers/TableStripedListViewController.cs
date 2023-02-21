using DevExpress.Blazor;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor.Editors;

namespace AppifySheets.Blazor.Module.Controllers;

public class TableStripedListViewController : ViewController<ListView>
{
    protected override void OnViewControlsCreated()
    {
        base.OnViewControlsCreated();
        if (View.Editor is not DxGridListEditor gridListEditor) return;
        var adapter = gridListEditor.GetGridAdapter();

        if (View.IsRoot)
            adapter.GridModel.CssClass += " root-table text-truncate";

        adapter.GridModel.CssClass += " alternating-colors";

        if (!View.IsRoot)
            adapter.GridModel.CustomizeElement = e =>
            {
                // ReSharper disable once SwitchStatementMissingSomeEnumCasesNoDefault

                // e.Style += "cursor: pointer";

                // switch (e.ElementType)
                // {
                //     case GridElementType.DataRow when e.VisibleIndex % 2 == 1:
                //         e.CssClass = "alt-item";
                //         break;
                //     // case GridElementType.HeaderCell:
                //     //     e.Style = "background-color: rgba(0, 0, 0, 0.1)";
                //     //     e.CssClass = "header-bold";
                //     //     break;
                // }
            };
    }
}