using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace library2
{
    internal class Admin
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }


        public Admin(string name, string password)
        {
        Name = name;
        Password = password;
        
        }


        public static List<Admin> client = new List<Admin>();

        public static void register(string name, string pin)
        {
            client.Add(new Admin(name,pin));
        }
        /* public static void register(string Name, string Password, string Address)
         {
             Console.WriteLine("Please fill in your details");
             Console.Write("Name : "); string adminName = Console.ReadLine();

             Console.Write("Personal Pin or password : "); string pin = Console.ReadLine();

             Console.WriteLine("Add books to inventory");
             Console.ReadKey();
             Console.WriteLine("Name of book to be added: ");
             string ADnameOfBook = Console.ReadLine();

             Console.WriteLine("Book author: ");
             string ADnameOfAuthor = Console.ReadLine();
         }*/

        public static string Login()
        {
            Console.WriteLine("Input Login details");

            Console.Write("Username: ");
            string username = Console.ReadLine().ToLower();
           
            Console.Write("Password: ");
            string password = Console.ReadLine().ToLower();

            foreach (var client in client)
            {
                if (client.Name == username && client.Password == password)
                {
                    Logins.Name = client.Name;
                    Logins.Pin = client.Password;
                    Logins.Address = null;
                    Logins.Age = 0;
                    Console.WriteLine("login successful");
                    
                    return "good";

                }

                else
                {
                    continue;
					
				}
            }
            Console.WriteLine("login failed");
            return "bad";

        }

    }
}
