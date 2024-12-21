using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Lab3
{
    public static class MenuText
    {
        public enum MenuChoice
        {
            // Main Menu.
            Employees,
            Students,
            Classes,
            Courses,
            RecentlySetGrades,           
            Exit,

            // Employee Menu.
            AllEmployees,
            GetDepartment,
            AddEmployee,
            Return,

            // Student Menu.
            SortByFirstName_ASC, 
            SortByLastName_ASC,
            SortByFirstName_DESC,
            SortByLastName_DESC,
            AddStudent,

            // Class Menu.
            ClassMenu
        }

        // Main Menu Options.
        public static readonly Dictionary<string, MenuChoice> MainMenuText = new()
    {
        { "1: Employees", MenuChoice.Employees },
        { "2: Students", MenuChoice.Students },
        { "3: Classes", MenuChoice.Classes },
        { "4: Information on Courses", MenuChoice.Courses },
        { "5: Recently set grades", MenuChoice.RecentlySetGrades },
        { "0: Exit", MenuChoice.Exit }
    };

        // Employee Menu Options.
        public static readonly Dictionary<string, MenuChoice> EmployeeMenuText = new()
    {
        { "1: All employees", MenuChoice.AllEmployees},
        { "2: Get employees sort by Department", MenuChoice.GetDepartment },       
        { "3: Add Employee", MenuChoice.AddEmployee },
        { "0 Return to MainMenu", MenuChoice.Return }
    };

        // Student Menu Options.
        public static readonly Dictionary<string, MenuChoice> StudentMenuText = new()
    {
        { "1: Sort by First Name, Order by Ascending", MenuChoice.SortByFirstName_ASC },
        { "2: Sort by Last Name, Order by Descending", MenuChoice.SortByLastName_ASC },
        { "3: Sort by First Name, Order by Descending", MenuChoice.SortByFirstName_DESC },
        { "4: Sort by Last Name, Order by Ascending", MenuChoice.SortByLastName_DESC },
        { "5: Add Student", MenuChoice.AddStudent },
        { "0: Return to MainMenu", MenuChoice.Return }
    };

        // Class Menu Options.
        public static readonly Dictionary<string, MenuChoice> ClassMenuText = new()
    {
        {"1: Show class and respective students", MenuChoice.ClassMenu},
        {"0: Return to MainMenu", MenuChoice.Return }
    };
    }
}
