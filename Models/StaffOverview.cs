using System;
using System.Collections.Generic;

namespace SQL_Lab3.Models;

public partial class StaffOverview
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? PersonalNumber { get; set; }

    public byte? FkDepartmentId { get; set; }

    public int StaffId { get; set; }

    public DateOnly? StartDate { get; set; }

    public decimal? Salary { get; set; }

    public string? DepartmentName { get; set; }
}
