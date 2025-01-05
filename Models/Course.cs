using System;
using System.Collections.Generic;

namespace SQL_Lab3.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string? CourseName { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
