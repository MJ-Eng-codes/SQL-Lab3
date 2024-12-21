using System;
using System.Collections.Generic;

namespace SQL_Lab3.Models;

public partial class ClassT
{
    public int ClassId { get; set; }

    public string? ClassName { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
