using L1.Domain.BaseModels;

namespace L1.Domain.Models;

public class Patient : AggregateRoot
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required DateTime Birthdate { get; init; }
    public required string IdNumber { get; init; }
    public string? SocialSecurityNumber { get; init; }
    public required string PhoneNumber { get; init; }
    public required Country Citizenship { get; init; }
}

public class Condition : AggregateRoot
{
    public required string ConditionName { get; init; }
    public ICD10? Diagnosis { get; init; }
    public DateTime? DiagnosedOn { get; init; }

    public readonly List<Medication> Medications = new();
}

public class Medication : AggregateRoot
{
    public required string MedicationName { get; init; }
}

public class ICD10 : AggregateRoot
{
    public required string Code { get; init; }
}

public class City : AggregateRoot
{
    public required string CityName { get; init; }
    public required State State { get; init; }
}

public class State : AggregateRoot
{
    public required string StateName { get; init; }
}

public class Country : AggregateRoot
{
    public required string Name { get; init; }
}