using L1.Domain.BaseModels;

namespace L1.Domain.Models;

public class Patient : AggregateRoot
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required DateTime Birthdate { get; set; }
    public required string IdNumber { get; set; }
    public string? SocialSecurityNumber { get; set; }
    public required string PhoneNumber { get; set; }
    public required Country Citizenship { get; set; }
    public virtual List<Condition> Conditions { get; } = new();
}

public class Condition : AggregateRoot
{
    public required string ConditionName { get; set; }
    public ICD10? Diagnosis { get; set; }
    public DateTime? DiagnosedOn { get; set; }
    public virtual List<Medication> Medications { get; } = new();
}

public class Medication : AggregateRoot
{
    public required string MedicationName { get; set; }
}

public class ICD10 : AggregateRoot
{
    public required string Code { get; set; }
}

public class City : AggregateRoot
{
    public required string CityName { get; set; }
    public required State State { get; set; }
}

public class State : AggregateRoot
{
    public required string StateName { get; set; }
}

public class Country : AggregateRoot
{
    public required string Name { get; set; }
}