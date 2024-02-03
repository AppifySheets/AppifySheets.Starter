using AppifySheets.Domain.Common;
using CSharpFunctionalExtensions;

namespace L1.Domain.BaseModels;

public abstract class BaseEntity : AppifySheetsEntity<BasicUser, long>
{
    protected override Result ExpireCore(DateTime expiredOn, BasicUser expiredBy) => throw new NotImplementedException();
    protected override Result RestoreCore() => throw new NotImplementedException();
}

public abstract class AggregateRoot : AggregateRoot<BasicUser, long>
{
    protected override Result ExpireCore(DateTime expiredOn, BasicUser expiredBy) => throw new NotImplementedException();
    protected override Result RestoreCore() => throw new NotImplementedException();
}