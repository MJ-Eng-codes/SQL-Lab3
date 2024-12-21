using SQL_Lab3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Lab3
{
    public class UserInput
    {
        //UserInput to sort by class
        public static string GetClassName()
        {  
            using (SchoolContext context = new SchoolContext())
            {
                var ListOfClasses = context.ClassTs
                    .Select(s => s.ClassName)
                    .ToList();

                while (true)
                {
                    Console.WriteLine("Please enter class name: ");
                    var className = Console.ReadLine();

                    if (!string.IsNullOrEmpty(className) && ListOfClasses.Contains(className)) return className;
                    Console.WriteLine("Class does not exist!");
                }
            };
        }

        //UserInput to sort staff with department name
        public static string GetDepartmentName()
        {
            using (SchoolContext context = new SchoolContext())
            {
                var DepartmentList = context.Departments
                    .Select(d => d.DepartmentName)
                    .ToList();

                while(true)
                {
                    Console.WriteLine("Please enter department name: ");
                    var departmentName = Console.ReadLine();

                    if (!string.IsNullOrEmpty(departmentName) && DepartmentList.Contains(departmentName)) return departmentName;
                    Console.WriteLine("Department does not exist!");
                }
            }
        }

        //UserInput to choose whether to sort firstName/lastName and/or ascending/descending
        //GetStudents(string orderBy, bool ascending)
        //public static dynamic SortStudentWith()
        //{
        //    using (SchoolContext context = new SchoolContext())
        //    {
        //        var StudentList = context.Students
        //            .Select(s => s)
        //            .ToList();

        //        while(true)
        //        {
        //            Console.WriteLine();
        //        }
        //    }
        //} NEED TO SEE IF NEEDED
    }
}