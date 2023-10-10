using System;
using System.Collections.Generic;

namespace Kid.Models;

public partial class EmployeesCharter
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public int CharterId { get; set; }

    public virtual Charter Charter { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
