using AppifySheets.Domain.Common;
using CSharpFunctionalExtensions;
using L1.Domain.BaseModels;

namespace L1.Domain.Models;

public abstract class AggregateRoot : AggregateRoot<BasicUser>
{
    protected override Result ExpireCore(DateTime expiredOn, BasicUser expiredBy) => throw new NotImplementedException();
    protected override Result RestoreCore() => throw new NotImplementedException();
}

public class City : AggregateRoot
{
    public string CityName { get; set; }
    public State State { get; set; }
}

public class State : AggregateRoot
{
    public string StateName { get; set; }
}