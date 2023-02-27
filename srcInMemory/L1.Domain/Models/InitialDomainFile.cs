using L1.Domain.BaseModels;

namespace L1.Domain.Models;

public class City : AggregateRoot
{
    public required string CityName { get; set; }
}