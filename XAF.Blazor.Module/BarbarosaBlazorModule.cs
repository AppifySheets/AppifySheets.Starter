using AppifySheets.Barbarosa.Domain.Models;
using AppifySheets.Blazor.Common.XAF.Module.Editors;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;


namespace AppifySheets.Blazor.Module;

public sealed class BarbarosaBlazorModule : ModuleBase
{
    const string PropertyEditorType = nameof(PropertyEditorType);

    public override void CustomizeTypesInfo(ITypesInfo typesInfo)
    {
        base.CustomizeTypesInfo(typesInfo);
    }
}