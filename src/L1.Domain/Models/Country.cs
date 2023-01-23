using System.ComponentModel.DataAnnotations;

namespace L1.Domain.Models;

public class Country : AggregateRoot
{
    [Required] public string Name { get; set; }
}