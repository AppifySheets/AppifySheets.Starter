using L1.Domain.BaseModels;

namespace L1.Domain.Models;

public class City : AggregateRoot
{
    public required string CityName { get; set; }

    // public required State State { get; set; }
}

// public class State : AggregateRoot
// {
//     public required string StateName { get; set; }
// }

public class Country : AggregateRoot
{
    public required string Name { get; set; }
    public List<City> Cities { get; } = new();
}