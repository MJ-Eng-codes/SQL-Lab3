using Microsoft.EntityFrameworkCore;
using SQL_Lab3.Data;
using SQL_Lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Lab3.TableManager
{
    public static class RetrieveData
    {
       /* private static SchoolContext context = new SchoolContext()*/ //Not recommended way, cuz takes too much memory

        //Hämta personal (användare kan välja se alla eller kolla department)
        public static void GetAllStaff()
        {
            using (SQL_Lab3.Data.SchoolContext context = new SQL_Lab3.Data.SchoolContext())
            {
                var Staffs = context.Staffs
                    .Join(context.Departments, staff => staff.FkDepartmentId,
                    department => department.DepartmentId,
                    (staff, department) => new { staff, department })
                    .Select(s => new
                    {
                        s.staff.FirstName,
                        s.staff.LastName,
                        s.staff.StaffId,
                        s.department.DepartmentName,
                        s.department.DepartmentId
                    });

                foreach (var staff in Staffs)
                {
                    Console.WriteLine($"FullName: {staff.FirstName} {staff.LastName} \n Staff ID: {staff.StaffId} \n DepartmentInfo: {staff.DepartmentName}, DepartmentID: {staff.DepartmentId} ");
                }
            }
        } //Done
        public static void GetStaff_Department (string departmentName) //Department filter
        {
            using (SQL_Lab3.Data.SchoolContext context = new SQL_Lab3.Data.SchoolContext())
            {

                ////Show Existing Departments
                //var Departments = context.Departments
                //    .Select(d => d)
                //    .ToList();
                //Console.WriteLine("Existing Departments: ");

                //foreach (var department in Departments)
                //{
                //    Console.WriteLine(department.DepartmentName);
                //}

                var Staffs = from staffs in context.Staffs
                             join departments in context.Departments                                                   
                             on staffs.FkDepartmentId equals departments.DepartmentId
                             where departments.DepartmentName == departmentName //Filter by departmentName 
                             select new
                             {
                                 Fullname = staffs.FirstName + " " + staffs.LastName + ", StaffID:" + staffs.StaffId,
                                 WorkDeparment = departments.DepartmentName + ", DepartmentID:" + departments.DepartmentId
                             };


                foreach (var Staff in Staffs)
                {
                    Console.WriteLine($"Name: {Staff.Fullname} \n Works in Department: {Staff.WorkDeparment}");
                    Console.WriteLine();
                }
            }
        } //Done

        //Hämta alla elever (får välja för/efternamn, asc/desc)       
        public static void GetStudents(string orderBy, bool ascending)
        {
            using (SQL_Lab3.Data.SchoolContext context = new SQL_Lab3.Data.SchoolContext())
            {
                IQueryable<Student> Students = context.Students;

                if (orderBy.ToLower() == "firstname")
                {
                    Students = ascending ? Students.OrderBy(s => s.FirstName) : Students.OrderByDescending(s => s.FirstName);
                }
                else if (orderBy.ToLower() == "lastname")
                {
                    Students = ascending ? Students.OrderBy(s => s.LastName) : Students.OrderByDescending(s => s.LastName);
                }

                foreach (var Student in Students)
                {
                    Console.WriteLine($"Name: {Student.FirstName} {Student.LastName}");
                }
            }
        } //Done

        //Hämta alla elever beror på klass (visa klass först)
        public static void GetStudent_Class(string className)
        {
            using (SQL_Lab3.Data.SchoolContext context = new SQL_Lab3.Data.SchoolContext())
            {
                ////show classes list
                //var Class = context.ClassTs
                //    .Select(c => c)
                //    .ToList();
                                
                //Console.WriteLine("Existing Classes: ");

                //foreach (var item in Class)
                //{
                //    Console.WriteLine(item.ClassName);
                //}

                var query = context.Students
                    .Join(context.ClassTs, student => student.FkClassId,
                    classId => classId.ClassId,
                    (student, classId) => new { student, classId })
                   .Where(s => s.classId.ClassName == className)
                   .Select(s => new
                   {
                       s.student.FirstName,
                       s.student.LastName,
                       s.classId.ClassName
                   });


                foreach (var student in query)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} {student.ClassName}");
                }
            }
        } //Done

        //----------------------------------------NOT USED-------------------------------------------

        //Hämta alla betyg som satts den senaste månaden
        /* TIDIGARE public void GetResults_thisMonth()
         {
             using (context)
             {
                 var Result = from student in context.Results
                                      .Where(e => e.SetDate.HasValue && e.SetDate.Value.Month == DateTime.Now.Month)
                                      .Select(e => $"{e.FkGrade} {e.FkCourseId} {e.FkStudentId} {e.SetDate}")
                                      .ToList();
                 foreach (var item in Result)
                 {
                     Console.WriteLine(item);
                 }
             }
         }*/

        public static void GetResults_thisMonth()
        {
            using (SQL_Lab3.Data.SchoolContext context = new SQL_Lab3.Data.SchoolContext())
            {
                var Result = from result in context.Results
                             join enrollment in context.Enrollments
                             on result.FkStudentId equals enrollment.FkStudentId
                             join course in context.Courses
                             on enrollment.FkCourseId equals course.CourseId
                             join student in context.Students
                             on enrollment.FkStudentId equals student.StudentId
                             where result.SetDate.HasValue && result.SetDate.Value.Month == DateTime.Now.Month
                             select new
                             {
                                 StudentInfo = student.FirstName + " " + student.FkClassId,
                                 CourseInfo = course.CourseId + " " + course.CourseName,
                                 GradeInfo = result.FkGrade + " " + result.SetDate
                             };



                foreach (var item in Result)
                {
                    Console.WriteLine(item);
                }
            }
        } //Done

        //Hämta en lista med alla kurser och det snittbetyg som elev fick 
        public static void GetCourses()
        {
            using (SQL_Lab3.Data.SchoolContext context = new SQL_Lab3.Data.SchoolContext())
            {
                var Courses =
                    from courses in context.Courses
                    join staffs in context.Staffs
                    on courses.CourseId equals staffs.FkCourseId
                    join results in context.Results
                    on courses.CourseId equals results.FkCourseId
                    group results by new
                    {
                        courses.CourseName,
                        courses.CourseId,
                        staffs.FirstName,
                        staffs.LastName,

                    } into Course_Info
                    select new
                    {
                        CourseInfo = Course_Info.Key.CourseName + " (" + Course_Info.Key.CourseId + ")",
                        Corresponding_Teacher = Course_Info.Key.FirstName + " " + Course_Info.Key.LastName,
                        Average_Grade = Course_Info.Average(e => e.Grade_Percentage)
                    };

                foreach (var course in Courses)
                {
                    Console.WriteLine($"Course: {course.CourseInfo} \n");
                    Console.WriteLine($"Teacher: {course.Corresponding_Teacher} \n");
                    Console.WriteLine($"Average Student Grade: {course.Average_Grade} \n");
                }
            }
        } //Done

        public static void GetActiveCourses()
        {
            using (SQL_Lab3.Data.SchoolContext context = new SQL_Lab3.Data.SchoolContext())
            {
                var activeCourses =
                    from course in context.Courses
                    where course.Status == "Active"
                    select course;

                foreach (var course in activeCourses)
                {
                    Console.WriteLine($"Course ID: {course.CourseId}, Course Name: {course.CourseName}");

                }

            }

        }

    }
}
