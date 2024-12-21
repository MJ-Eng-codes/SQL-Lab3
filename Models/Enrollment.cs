using System;
using System.Collections.Generic;

namespace SQL_Lab3.Models;

public partial class Enrollment
{
    public int? FkStudentId { get; set; }

    public int? FkCourseId { get; set; }

    public virtual Course? FkCourse { get; set; }

    public virtual Student? FkStudent { get; set; }
}
