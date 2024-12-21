using SQL_Lab3.Data;
using SQL_Lab3.TableManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Lab3
{
    public static class Menu
    {
        public static void MainMenu()
        {
            bool exit = false;
            while (!exit)
            {
                ShowMainMenu(); // Display Main Menu
                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    //if (MenuText.MainMenuText.ContainsKey(input))
                    //{
                    //    MenuText.MenuChoice choice = MenuText.MainMenuText[input];

                    switch (input)
                    {
                        
                        case 1:
                            ShowEmployeeMenu();
                            break;
                        case 2:
                            ShowStudentMenu();
                            break;
                        case 3:
                            ShowClassMenu();
                            break;
                        case 4:
                            RetrieveData.GetCourses();
                            break;
                        case 5:
                            RetrieveData.GetResults_thisMonth();
                            break;
                        //case 6:
                        //    Console.WriteLine("Add student");
                        //    InsertData.AddStudent();
                        //    break;
                        //case 7:
                        //    Console.WriteLine("Add employee");
                        //    InsertData.AddStaff();
                        //    break;
                        case 0:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input, please enter a number.");
                }
            }
        }

        public static void ShowMainMenu()
        {
            
            Console.WriteLine("Main Menu:");
            foreach (var option in MenuText.MainMenuText.Keys)
            {
                Console.WriteLine(option);
            }
            Console.Write("Choose an option: ");
            
           
        }

        public static void ShowEmployeeMenu()
        {
            Console.Clear();
            Console.WriteLine("Employee Menu:");
            foreach (var option in MenuText.EmployeeMenuText.Keys)
            {
                Console.WriteLine(option);
            }
            Console.Write("Choose an option: ");
           
            if (int.TryParse(Console.ReadLine(), out int input))
            {
                switch (input)
                {
                    case 1:
                        RetrieveData.GetAllStaff();
                        break;
                    case 2:
                        using (SchoolContext context = new SchoolContext())
                        {

                            //Show Existing Departments
                            var Departments = context.Departments
                                .Select(d => d)
                                .ToList();
                            Console.WriteLine("Existing Departments: ");

                            foreach (var department in Departments)
                            {
                                Console.WriteLine(department.DepartmentName);
                            }
                        }
                        RetrieveData.GetStaff_Department(UserInput.GetDepartmentName());
                        break;

                    case 3:
                        InsertData.AddStaff();
                        break;
                    case 0:
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input, please enter a number.");
            }
        }

        public static void ShowStudentMenu()
        {
            Console.Clear();
            Console.WriteLine("Student Menu:");
            foreach (var option in MenuText.StudentMenuText.Keys)
            {
                Console.WriteLine(option);
            }
            Console.Write("Choose an option: ");

            if (int.TryParse(Console.ReadLine(), out int input))
            {
                switch (input)
                {
                    case 1:
                        RetrieveData.GetStudents("FirstName",true);
                        break;
                    case 2:
                        RetrieveData.GetStudents("LastName", true);
                        break;
                    case 3:
                        RetrieveData.GetStudents("FirstName", false);
                        break;
                    case 4:
                        RetrieveData.GetStudents("LastName", false);
                        break;
                    case 5:
                        InsertData.AddStudent();
                        break;
                    case 0:
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input, please enter a number.");
            }
        }

        public static void ShowClassMenu()
        {
            Console.Clear();  
            Console.WriteLine("Class Menu:");
            foreach (var option in MenuText.ClassMenuText.Keys)
            {
                Console.WriteLine(option);
            }
            Console.Write("Choose an option: ");

            //Show Existing classes
            using (SchoolContext context = new SchoolContext())
            {
                //show classes list
                var Class = context.ClassTs
                    .Select(c => c)
                    .ToList();

                Console.WriteLine("Existing Classes: ");

                foreach (var item in Class)
                {
                    Console.WriteLine(item.ClassName);
                }
            }

                if (int.TryParse(Console.ReadLine(), out int input))
            {
                switch (input)
                {
                    case 1:
                        RetrieveData.GetStudent_Class(UserInput.GetClassName());
                        break;
                    case 0:
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input, please enter a number.");
            }

        }
    }

}

