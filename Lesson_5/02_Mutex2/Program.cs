using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02_Mutex2
{
    class Program
    {
        static Mutex m;
        static void Main(string[] args)
        {
           try
           {
                m = Mutex.OpenExisting("myMutex");
                Console.WriteLine("The application was already opened");
                Console.ReadKey();
           }
           catch
           {
                m = new Mutex(false, "myMutex");
                Console.WriteLine("FIRST START");
           }
            Console.ReadKey();
        }


    }
}
