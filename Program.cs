using System;
using System.Collections.Generic;  
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace library2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Users users = new Users();
            Users.user();
            Console.WriteLine("Welcome to Royalty's Library");
            Console.ReadKey();
            landing();
           
            
        }
        static void landing()
        {
            Console.WriteLine("Please identify yourself");
            Console.WriteLine("1. Student \n2. Admin");
            String identify = Console.ReadLine();

            Console.WriteLine("=================================================");
            
            if (identify.ToLower() == "student" || identify == "1")
            {
                welcome();
                Console.Clear();
                Console.WriteLine("=================================================");
                Console.WriteLine($"Heyy there ");
                Console.ReadKey();
                Console.WriteLine("What do you want to do in our library today ? ");
                Console.WriteLine("=================================================");

                userOptions();
                
            }
            else if (identify.ToLower() == "admin" || identify == "2")
            {
            AdLog_Reg:
                Console.WriteLine("1. Login\n2. Register");
                String LogReg = Console.ReadLine().ToLower();
                Console.WriteLine("-------------------------------------------------------");
                if (LogReg == "2" || LogReg == "register")
                {
                    goto admin_part;
                }
                else if (LogReg == "1" || LogReg == "login")
                {
                    string adlog = Admin.Login();
                    if (adlog == "good")
                    {
                        adminOptions();
                    }
                    else
                    {
                        landing();
                    }
                }
                else
                {
                    Console.WriteLine("Please choose from the above options");
                    goto AdLog_Reg;
                }
            admin_part:
                Console.WriteLine("Enter Verification code or \t Enter 2222 to exit the app \n ");
                identify = Console.ReadLine();

                if (identify == "2468")
                {
                    Books book = new Books();

                    Admin admin = new Admin("admin", "password");


                    Console.WriteLine("Please fill in your details");
                admin_name:
                    Console.Write("Name : ");
                    string adminName = Console.ReadLine();

                admin_password:
                    Console.Write("Personal Pin or password : ");
                    string pin = Console.ReadLine();
                    if (adminName == "")
                    {
                        Console.WriteLine("=======================");
                        goto admin_name;
                    }
                    else if (pin == "")
                    {
                        Console.WriteLine("please enter your password");
                        goto admin_password;
                    }

                    Admin.register(adminName, pin);

                    Books.AddBookToInventory();
                    Console.ReadKey();


                    adminOptions();



                }
                else if (identify == "2222")
                {
                    Environment.Exit(1);
                }
                else
                {
                    Console.WriteLine("choose an option");
                    goto admin_part;
                }
            }
            else
            {
                Console.WriteLine("Please choose from the above optons");
                
                landing();
            }
        }

        
        static void welcome()
        {
            Console.WriteLine("1. Login\n2. Register");
            String LogReg = Console.ReadLine().ToLower();
            if (LogReg == "1" || LogReg == "login")
            {
                string login = Users.Login();
                if (login == "false")
                {
                    landing();
                }
            }
            else if (LogReg == "2" || LogReg == "register")
            {
                Users.AddUserInputsToUserDetails();
            }
            else
            {
                Console.WriteLine("Please choose from the above optons");
                welcome();
            }
        }

        public static void userOptions()
        {

            Console.WriteLine("1. Borrow book \n2. Return Book \n3. View all books in the inventory\n4. Log Out");
            string stAns = Console.ReadLine();

            if (stAns.ToLower() == "borrow book" || stAns == "1")
            {

                string borrow = Books.BorrowBook();
                if (borrow == "bad")
                {
                    Console.WriteLine("----------------------Erorr borrowing book------------------");
                }
                userOptions();
            }
            else if (stAns.ToLower() == "return book" || stAns == "2")
            {
                Books.ReturnBook();
                userOptions();
            }
            else if (stAns.ToLower() == "view all books in the inventory" || stAns == "3")
            {

                
                Console.WriteLine("list of books in inventory");
                Books.ViewAllBooks();
                Console.WriteLine("*************************************************");
                Console.WriteLine("Do you want to go back to your menu or exit the app");
                Console.WriteLine("1. Go back to Menu\n2. Exit");
                string Exstay = Console.ReadLine();
                if (Exstay.ToLower() == "1" || Exstay.ToLower() == "go back to menu")
                {
                    Console.WriteLine("Dashboard: ");
                    userOptions();
                }
                else if (Exstay.ToLower() == "2" || Exstay.ToLower() == "exit")
                {
                    Console.WriteLine($"Byee");
                    Environment.Exit(0);
                }

            }
            else if (stAns.ToLower() == "log out" || stAns == "4")
            {
                Console.WriteLine("-------You've logged out---------");

                landing();
            }
            else
            {
                Console.WriteLine("Please enter an option");

                userOptions();
            }
        }

       
        public static void adminOptions()
        {
            Console.WriteLine("****************************************************************************");
            Console.WriteLine("****************************************************************************");
            Console.ReadKey();
            Console.WriteLine("Admin Dashboard");
            Console.WriteLine("*********************");

            Console.WriteLine("1. Add books to inventory");
            Console.WriteLine("2. View all books in inventory");
            Console.WriteLine("3. Modify or delete any book from inventory");
            Console.WriteLine("4. Delete users");
            Console.WriteLine("5. View users details");
            Console.WriteLine("6. Log Out");

            string AdminOptions = Console.ReadLine();

            if (AdminOptions.ToLower() == "1" || AdminOptions.ToLower() == "add books to inventory")
            {
                Books.AddBookToInventory();
            }
            else if (AdminOptions.ToLower() == "2" || AdminOptions.ToLower() == "view all books in inventory")
            {
                Console.WriteLine("*************************************************");
                Console.WriteLine("These are the books in the inventory: ");
                Books.ViewAllBooks();
                Console.WriteLine("*************************************************");

                adminOptions();

            }
            else if (AdminOptions.ToLower() == "3" || AdminOptions.ToLower() == "modify or delete any book from inventory")
            {
                Console.WriteLine("---------------------------------Please fill in the details of the book you want to modify or delete------------------------------------");
                Console.WriteLine("****************************************************************************************************************************************");
                Console.ReadKey();
                Console.WriteLine("Name of book: ");
                string DEname = Console.ReadLine();
                Console.WriteLine("Name of Author: ");
                string DEauthor = Console.ReadLine();
                Console.ReadKey();
                Console.WriteLine("=======================");
                Console.WriteLine("1. Edit\n2. Delete");
                string MoDel = Console.ReadLine();

                if (MoDel.ToLower() == "1" || MoDel.ToLower() == "edit")
                {
                    Books.EditBook(DEname, DEauthor);
                    Console.ReadKey();
                    adminOptions();
                }
                else if (MoDel.ToLower() == "2" || MoDel.ToLower() == "delete")
                {
                    Books.DeleteBook(DEname, DEauthor);

                    Console.ReadKey();
                    adminOptions();
                }

            }
            else if (AdminOptions.ToLower() == "4" || AdminOptions.ToLower() == "delete users")
            {
                Users.DeleteUsers();
                adminOptions();
            }
            else if (AdminOptions.ToLower() == "5" || AdminOptions.ToLower() == "view users details")
            {
                Console.WriteLine("These are the users details");
                Users.ViewUsersdetails();
                Console.WriteLine("****************************************************************");
                adminOptions();
            }
            else if (AdminOptions.ToLower() == "6" || AdminOptions.ToLower() == "log out")
            {
                landing();
            }
            else
            {
                Console.WriteLine("Wrong input");
                landing();
            }
        }
    }

    
}
