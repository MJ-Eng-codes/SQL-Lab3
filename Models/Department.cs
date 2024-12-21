using System;
using System.Collections.Generic;

namespace SQL_Lab3.Models;

public partial class Department
{
    public byte DepartmentId { get; set; }

    public string? DepartmentName { get; set; }

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
