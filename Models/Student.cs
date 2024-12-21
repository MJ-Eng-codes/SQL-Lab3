using System;
using System.Collections.Generic;

namespace SQL_Lab3.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? PersonalNum { get; set; }

    public int? FkClassId { get; set; }

    public virtual ClassT? FkClass { get; set; }
}
