using System;
using System.Collections.Generic;

namespace Kid.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string NameE { get; set; } = null!;

    public string? Patronymic { get; set; }

    public int YearBirth { get; set; }

    public int WorkExperience { get; set; }

    public string Gender { get; set; } = null!;

    public virtual ICollection<EmployeesCharter> EmployeesCharters { get; } = new List<EmployeesCharter>();

    public virtual ICollection<EventsTable> EventsTables { get; } = new List<EventsTable>();

    public virtual ICollection<User> Users { get; } = new List<User>();
}
