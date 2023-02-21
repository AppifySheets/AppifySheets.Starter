using AppifySheets.Domain.Common.Attributes;
using L1.Domain.BaseModels;

namespace L1.Domain.Models;

public class Entity : AggregateRoot
{
    public required string EntityName { get; set; }
    public List<EntityMember> EntityMembers { get; } = new();
    public List<EntityCollectionMember> EntityCollectionMembers { get; } = new();
}

public class EntityMemberTypePredefined : AggregateRoot
{
    public required string EntityMemberTypePredefinedName { get; set; }
}

public class EntityMember : AggregateRoot
{
    public required string EntityMemberName { get; set; }
    public required bool IsRequired { get; set; }
    public EntityMemberTypePredefined? EntityMemberOfPredefinedType { get; set; }

    [AllowEditFalse] public required Entity ParentEntity { get; set; }

    public Entity? EntityMemberOfAnotherEntityType { get; set; }
}

public class EntityCollectionMember : AggregateRoot
{
    public required string EntityMemberName { get; set; }
    [AllowEditFalse] public required Entity ParentEntity { get; set; }
    public required Entity EntityMemberTypeAnotherEntity { get; set; }
    public bool EnableInLineEditingInListView { get; set; }
    public bool ShowMasterDetailViewForListView { get; set; }
    public bool DisableRowFiltrationInListView { get; set; }
    public bool EnableExportToExcelFromListView { get; set; }

    public int? MinimumNumberOfItemsRequired { get; set; }
    public int? MaximumNumberOfItemsAllowed { get; set; }
}