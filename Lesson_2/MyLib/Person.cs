using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class Person
    {
        public Person(string n)
        {
            Name = n;
        }
        public string Name { get; set; }

        public void ShowInfoAboutPerson()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("PERSON");
            Console.WriteLine(Name);
            Console.ResetColor();
        }
    }
}
