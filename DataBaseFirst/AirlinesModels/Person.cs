using System;
using System.Collections.Generic;

namespace DataBaseFirst.AirlinesModels;

public partial class Person
{
    public long PersonId { get; set; }

    public string Fname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Sname { get; set; } = null!;

    public DateTime WhenBorn { get; set; }

    public short Sex { get; set; }

    public virtual ICollection<Auto> Autos { get; set; } = new List<Auto>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
