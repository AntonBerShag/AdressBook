using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static AdressBook.Book;

namespace AdressBook
{
    internal class Book
    {
        public delegate void myDelegate();
        //Класс для создание телефонной книги
        public abstract class Person
        {
            public abstract void addContact();
            public abstract void toFile();
        }

        //В классе Contact реализуем абстрактные методы
        public class Contact : Person
        {
            public myDelegate myAction;
            private string Name { get; set; }
            private string Number1 { get; set; }
            private string Number2 { get; set; }
    
            //Список имен
            private List<Contact> Contacts = new List<Contact>();
            public override void addContact()
            {
                string answer;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Введите Имя:");
                    string Name = Console.ReadLine();
                    Console.WriteLine("Номер1(от 4 до 11 символов): ");
                    string number1 = Console.ReadLine();
                    if (number1.Length < 4 || number1.Length > 11)
                    {
                        Console.WriteLine("Ошибка! Введите от 4 до 11 символов.");
                        Console.WriteLine("Нажмите Enter");
                        Console.ReadLine();
                        break;
                    }
                    Console.WriteLine("Номер2(от 4 до 11 символов): ");
                    string number2 = Console.ReadLine();
                    if (number2.Length < 4 || number2.Length > 11)
                    {
                        Console.WriteLine("Ошибка! Введите от 4 до 11 символов.");
                        Console.WriteLine("Нажмите Enter");
                        Console.ReadLine();
                        break;
                    }
                    var contact = new Contact()
                    {
                        Name = Name,
                        Number1 = number1,
                        Number2 = number2
                    };
                    Contacts.Add(contact);
                    Console.WriteLine("Записать еще конакт 1 - Да, 0 - Нет");
                    answer = Console.ReadLine();
                } while (answer != "0");
            }

            public void greeting()
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в телефонную книгу!\n" +
                "1 - создать контакт\n" +
                "Для завершения нажмите 0");
            }

            public void menu(string _number)
            {
                if(_number == "1")
                {
                    myAction += addContact;
                    Console.WriteLine("Контакт сохранен");
                }
                if(_number == "0")
                {
                    myAction += toFile;
                    return;
                }
            }

            public override void toFile()
            {
                string _path = "AdressBook.txt";
                var sw = new StreamWriter(_path, true);
                var sortedContacts = from c in Contacts
                                     orderby c.Name
                                     select c;
                foreach (var c in sortedContacts)
                {
                    sw.WriteLine("Имя: {0}, Номер 1 - {1}, Номер 2 - {2}", c.Name, c.Number1, c.Number2);
                }
                sw.Close();
            }
        }
    }
}
