using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library2
{
    internal class Users
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Pin { get; set; }
        public string Address { get; set; }
        public int NumberOfBooksInCustody { get; set; }


        public static List<Users> students = new List<Users>();


        public static void changeStart(string action, string name)
        {
            
            foreach (var student in students)
            {
                if (student.Name == name)
                {
                    if (action == "borrow")
                    {
                        student.NumberOfBooksInCustody++;
                    }
                    else
                    {
                        student.NumberOfBooksInCustody--;
                    }
                    return;
                }
                else
                {
                    continue;
                }
            }
        }

        public static void AddUserInputsToUserDetails()
        {
            Console.WriteLine("=======================");
            Console.WriteLine("Student inputs will be added to user details");
            Console.WriteLine("=======================");
            Console.WriteLine("Please input your details");
            Console.Write("Name : "); string studentName = Console.ReadLine();

            Console.Write("Age : "); int studentAge = Convert.ToInt32(Console.ReadLine());

            Console.Write("Password : "); string password = Console.ReadLine();

            Console.Write("Email Address : "); string studentAdress = Console.ReadLine();

            
            


            

            students.Add(new Users { Name = studentName, Age = studentAge, Address = studentAdress, Pin = password, NumberOfBooksInCustody= 0 });
            


            students.Count();

            Console.WriteLine("------------------------------User inputs added successfully!----------------------------");
        }





        public static void ViewUsersdetails()
        {
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name} is {student.Age} years old, and email is {student.Address},NumberOfBooksInCustody = { student.NumberOfBooksInCustody}");
            }
        }

       
        public static void DeleteUsers()
        {
            Console.Write("Name of user you want to delete: ");
            string name = Console.ReadLine();

            while (name == "")
            {
                Console.WriteLine("****please do what you're supposed to do****");
                name = Console.ReadLine();
            }
            bool set = true;
            

            foreach (var student in students)
            {
                if (student.Name == name)
                {
                     if (student.NumberOfBooksInCustody >0)
                    {
                        Console.WriteLine("------------User is in possession of a book--------------");
                        set = false;

                    }
                    else
                    {
                        set = true;
                        students.Remove(student);
                        Console.WriteLine("--------------User deleted successfully-----------------");
                    }
                    return;
                }
                else
                {
                    set = false;
                    continue;
                }
            }
            if (set == true)
            {
                Console.WriteLine("-------------------------User deleted successfully---------------------------");
               
            }
            else
            {
                Console.WriteLine("******Delete failed*****");
            }
        }


        public static void user()
        {
            students.Add(new Users { Name = "Namjoon", Age = 29, Address = "joony@gmail.com", NumberOfBooksInCustody = 1 });
            students.Add(new Users { Name = "Min Yoongi", Age = 29, Address = "suga@gmail.com", NumberOfBooksInCustody = 0 });
            students.Add(new Users { Name = "Jimin", Age = 28, Address = "jim@gmail.com", NumberOfBooksInCustody = 3 });
        }

        public static string Login()
        {
            
            Console.WriteLine("-------Input Login details---------");

            Console.Write("Username: ");
            string username = Console.ReadLine().ToLower();

            Console.Write("Password: ");
            string password = Console.ReadLine().ToLower();


            foreach (var students in students)
            {
                if (students.Name == username && students.Pin == password)
                {
                    Logins.Name = students.Name;
                    Logins.Pin = students.Pin;
                    Logins.Address = students.Address;
                    Logins.Age = students.Age;
                    Console.WriteLine("login successful");

                    Program.userOptions();
                    return "true";


                }
                else
                {
                    continue;
                    
                }
                

            }
            Console.WriteLine("login failed");
            return "false";

        }
    }
}
