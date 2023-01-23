namespace L1.Domain.Models;

public class Patient : AggregateRoot
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    public string IdNumber { get; set; }
}
