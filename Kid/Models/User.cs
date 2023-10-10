using System;
using System.Collections.Generic;

namespace Kid.Models;

public partial class User
{
    public int Id { get; set; }

    public string IdentityKey { get; set; } = null!;

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
