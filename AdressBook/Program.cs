using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdressBook.Book;

namespace AdressBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var contact = new Contact();
            string answer;
            do
            {
                contact.greeting();
                answer = Console.ReadLine();
                if (answer == "1")
                    contact.addContact();
                if (answer == "0")
                    contact.toFile();
            } while (answer != "0");
            
        }
    }
}
