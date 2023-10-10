using System;
using System.Collections.Generic;

namespace Kid.Models;

public partial class Schoolchild
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string NameE { get; set; } = null!;

    public string? Patronymic { get; set; }

    public int YearBirth { get; set; }

    public string Gender { get; set; } = null!;

    public virtual ICollection<EventsTableSchoolchild> EventsTableSchoolchildren { get; } = new List<EventsTableSchoolchild>();
}
