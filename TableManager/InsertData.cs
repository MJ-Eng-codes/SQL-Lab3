using SQL_Lab3.Data;
using SQL_Lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Lab3.TableManager
{
    public static class InsertData
    {
        //Lägga till nya elever, Användare får möjlighet att mata in uppgifter
        // om en ny elev och den datan sparas då ner i databasen
        public static void AddStudent()
        {
          
            using (SchoolContext context = new SchoolContext())
            {
                // Gather student information
                Console.WriteLine("Enter student first name:");
                string firstName = Console.ReadLine();

                Console.WriteLine("Enter student last name:");
                string lastName = Console.ReadLine();

                Console.WriteLine("Enter student Personal Number: ");
                int persNum = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter enrolled class number: 1-6");
                int classId = Convert.ToInt32(Console.ReadLine());

                // Create a new student object
                Student newStudent = new Student
                {
                    FirstName = firstName,
                    LastName = lastName,
                    PersonalNum = persNum,
                    FkClassId = classId                    
                };

                // Add the student to the context
                context.Students.Add(newStudent);

                // Save changes to the database
                context.SaveChanges();

                Console.WriteLine("Student added successfully.");
            }
        
        } //Done

        //Lägga till ny personal, mata in uppgifter om en ny anställd och data sparas i DB
        public static void AddStaff()
        {
            using (SchoolContext context = new SchoolContext())
            {
                // Gather student information
                Console.WriteLine("Enter staff first name:");
                string firstName = Console.ReadLine();

                Console.WriteLine("Enter staff last name:");
                string lastName = Console.ReadLine();

                Console.WriteLine("Enter staff Personal Number: ");
                int persNum = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter staff's department: ");
                Console.WriteLine("1: Teacher; 2: Administrator; 3: Rektor");
                byte dept = Convert.ToByte(Console.ReadLine());

                Console.WriteLine("Enter course overseen by teacher: ");
                Console.WriteLine("10:Matematik; 20:Svenska; 30:Fysik; 40:Engelska; 50:Biologi; 60:Samhällskunskap; 70:Historia");
                int courseId = Convert.ToInt32(Console.ReadLine());

                // Create a new student object
                Staff newStaff = new Staff
                {
                    FirstName = firstName,
                    LastName = lastName,
                    PersonalNumber = persNum,
                    FkDepartmentId = dept,
                    FkCourseId = courseId
                };

                // Add the student to the context
                context.Staffs.Add(newStaff);

                // Save changes to the database
                context.SaveChanges();

                Console.WriteLine("Staff added successfully.");
            }

        } //Done
    }
}
