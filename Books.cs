using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Text;
using System.Configuration;
using System.Xml.Linq;

namespace library2
{
    internal class Books
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime DateRegistered { get; set; }

        public string BookUsers { get; set; }
        public string BookStatus { get; set; }

        public static List<Books> tools = new List<Books>();

        public static void AddBookToInventory()
        {
            Console.WriteLine("---------------------Add books to inventory----------------------");
            Console.ReadKey();
            Console.WriteLine("Name of book to be added: ");
            string ADnameOfBook = Console.ReadLine();

            Console.WriteLine("Book author: ");
            string ADnameOfAuthor = Console.ReadLine();
            Console.WriteLine("date registered is : ");
            DateTime dateTime = DateTime.Now;
            Console.WriteLine($"{dateTime}");
            tools.Add(new Books { Name = ADnameOfBook, Author= ADnameOfAuthor, DateRegistered = dateTime, BookStatus= "OnShelf", BookUsers = "none"});
            tools.Count();

            Console.WriteLine("------------------------------Book added successfully!----------------------------");
            Program.adminOptions();

           


        }

        public static void ViewAllBooks()
        {
            foreach (var tool in tools)

            {
                Console.WriteLine($"{tool.Name} by {tool.Author}, {tool.DateRegistered}");
            }
            
        }

        public static void EditBook(string name, string author)
        {
            string status = "";
            foreach (var tool in tools)
            {
                if (tool.Name == name && tool.Author == author)
                {
                    Console.WriteLine("input new name: ");
                    string newName = Console.ReadLine();

                    Console.WriteLine("input new author: ");
                    string newAuthor = Console.ReadLine();

                    if (newName == "")
                    {
                        Console.WriteLine("--------------------------------Book name not changed------------------------");
                    }else
                    {
                        tool.Name = newName;
                    }
                    if (newAuthor == "")
                    {
                        Console.WriteLine("--------------------------------Book Author not changed----------------------------");
                    }else
                    {
                        tool.Author = newAuthor;

                    }
                    status = "success";
                    
                }
                else
                {
                    status = "failed";
                    continue;
                }
               
            }
            if (status == "success")
            {
                Console.WriteLine("----------------------------Book changed successfully-------------------------");

            }
            else
            {
                Console.WriteLine("------------wrong input------------");
            }
            
            Console.ReadKey();


        }

        public static void DeleteBook(string name, string author)
        {
            Console.WriteLine("------------------------------------------The book has been deleted sucessfully!---------------------------");
            tools.RemoveAll(tool => tool.Name == name);

        }

        public static string BorrowBook()
        {
            string status = "";
            Console.WriteLine("Please enter the name of book you wish to borrow: ");
            string borrowBook = Console.ReadLine();
            while(borrowBook == "")
            {
                Console.WriteLine("Wrong input, Enter book name");
                borrowBook = Console.ReadLine();
            }
            foreach (var tool in tools)
            {
                if (tool.Name == borrowBook)
                {
                    if (tool.BookStatus == "OnShelf")
                    {
                        tool.BookUsers = Logins.Name;
                        tool.BookStatus = "borrowed";
                        Console.WriteLine("Book borrowed successfully");
                        status = "good";
                        Users.changeStart("borrow",Logins.Name);
                        return status;
                    }
                    else
                    {
                        Console.WriteLine("Book has been borrowed");
                        status = "bad";
                    }

                }
                else
                {
                    status = "bad";
                    continue;

                }
            }return status;
        }

        public static string ReturnBook()
        {
            string status = "";
            Console.WriteLine("Please enter the name of book you wish to return: ");
            string returnBook = Console.ReadLine();
            while(returnBook == "")
            {
                Console.WriteLine("Wrong input, Enter book name");
                returnBook = Console.ReadLine();
            }

            foreach (var tool in tools)
            {
                if (tool.Name == returnBook)
                {
                    if (tool.BookStatus == "borrowed" && tool.BookUsers == Logins.Name)
                    {
                        tool.BookUsers = "none";
                        tool.BookStatus = "OnShelf";
                        Console.WriteLine("Book returned successfully");
                        status = "returned";
                        Users.changeStart("return", Logins.Name);
                        return status;
                    }
                    else
                    {
                        Console.WriteLine("Book is not in your possession");
                        status = "not returned";
                    }

                }
                else
                {
                    status = "not returned";
                    continue;

                }
            }
            return status;
        }


    }
    
}
