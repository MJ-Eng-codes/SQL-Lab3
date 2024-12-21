using System;
using System.Collections.Generic;

namespace SQL_Lab3.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? PersonalNumber { get; set; }

    public byte? FkDepartmentId { get; set; }

    public int? FkCourseId { get; set; }

    public virtual Course? FkCourse { get; set; }

    public virtual Department? FkDepartment { get; set; }
}
