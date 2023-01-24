using System.ComponentModel.DataAnnotations;
using System.Reflection;
using AppifySheets.Domain.Common;
using AppifySheets.EfCoreIntegration.ModuleBase;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Updating;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using L1.Domain.BaseModels;
using L1.Domain.Models;
using Updater = L3.XAF.Common.Module.Updater;

namespace L3.XAF.Common.Module;

public sealed class AppifySheetsModule : AppifySheetsEfCoreModuleBase
{
    public AppifySheetsModule()
        : base(typeof(City).Assembly.TypesFromAssembly().Where(t => !t.IsAbstract),
            Types.From<FileData, FileAttachment>())
    {
    }

    public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDb) => new Updater(objectSpace, versionFromDb).ToEnumerable();
    
    public override void CustomizeTypesInfo(ITypesInfo typesInfo)
    {
        base.CustomizeTypesInfo(typesInfo);

        typesInfo
            .PersistentTypes
            .Where(pt => !pt.IsAbstract && pt.AssemblyInfo.Assembly == typeof(BasicUser).Assembly)
            .ForEach(t =>
            {
                t.OwnMembers.ForEach(m =>
                {
                    if (m.FindAttribute<RequiredAttribute>() != null || (t.Type.GetProperty(m.Name)?.PropertyIsNotNullable() ?? false))
                        m.AddAttribute(new RuleRequiredFieldAttribute());
                });
            });
    }
}

public static class CheckNullableExtensions
{
    static readonly NullabilityInfoContext Context = new();

    // ReSharper disable once MemberCanBePrivate.Global
    public static bool PropertyIsNullable(this PropertyInfo propertyInfo)
    {
        var propertyInfoContext = Context.Create(propertyInfo);
        return propertyInfoContext.ReadState == NullabilityState.Nullable;
    }

    public static bool PropertyIsNotNullable(this PropertyInfo propertyInfo) => !PropertyIsNullable(propertyInfo);
}