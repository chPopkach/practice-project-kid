using System;
using System.Collections.Generic;

namespace Kid.Models;

public partial class EventsTableSchoolchild
{
    public int Id { get; set; }

    public int EventId { get; set; }

    public int SchoolchildId { get; set; }

    public virtual EventsTable Event { get; set; } = null!;

    public virtual Schoolchild Schoolchild { get; set; } = null!;
}
