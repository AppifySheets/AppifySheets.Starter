using AppifySheets.Barbarosa.Domain.BaseModels;
using AppifySheets.Domain.Common;
using CSharpFunctionalExtensions;

namespace AppifySheets.Barbarosa.Domain.Models;

public abstract class BarbarosaAggregateRoot : AggregateRoot<BasicUser>{}

public class City : BarbarosaAggregateRoot
{
    public City()
    {
    }

    protected override Result ExpireCore(DateTime expiredOn, BasicUser expiredBy) => throw new NotImplementedException();

    protected override Result RestoreCore() => throw new NotImplementedException();

    public string? CityName { get; set; }
}