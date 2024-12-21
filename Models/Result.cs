using System;
using System.Collections.Generic;

namespace SQL_Lab3.Models;

public partial class Result
{
    public int? FkStudentId { get; set; }

    public int? FkCourseId { get; set; }

    public int? FkStaffId { get; set; }

    public string? FkGrade { get; set; }

    public DateOnly? SetDate { get; set; }

    public int? Grade_Percentage { get; set; }

    public virtual Course? FkCourse { get; set; }

    public virtual Grade? FkGradeNavigation { get; set; }

    public virtual Staff? FkStaff { get; set; }

    public virtual Student? FkStudent { get; set; }
}
