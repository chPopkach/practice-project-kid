using System;
using System.Collections.Generic;

namespace Kid.Models;

public partial class EventsTable
{
    public int Id { get; set; }

    public string NameEvent { get; set; } = null!;

    public string DescriptionE { get; set; } = null!;

    public DateTime DateEvent { get; set; }

    public string IsCompleted { get; set; } = null!;

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<EventsTableSchoolchild> EventsTableSchoolchildren { get; } = new List<EventsTableSchoolchild>();
}
