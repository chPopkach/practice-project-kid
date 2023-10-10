using System;
using System.Collections.Generic;

namespace Kid.Models;

public partial class Charter
{
    public int Id { get; set; }

    public string NameCharter { get; set; } = null!;

    public string DescriptionC { get; set; } = null!;

    public virtual ICollection<EmployeesCharter> EmployeesCharters { get; } = new List<EmployeesCharter>();
}
