using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson_5
{
    class Program
    {
        private static Mutex mutex = new Mutex(false, "asd123-456");
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(HardWorkInThread);
                threads[i].Start();
            }

            Console.ReadKey();
           // thread1.Join();
        }

        static void HardWorkInThread(object param)
        {
            mutex.WaitOne();
            Console.WriteLine("Hard work Started: " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
            for (int i = 0; i < 10; i++)
            {
                Console.Write("*");
                Thread.Sleep(50);
            }
            Console.WriteLine("Hard work End: " + Thread.CurrentThread.ManagedThreadId);
            mutex.ReleaseMutex();

            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                Console.Write(r.Next(1,10));
            }
            Console.WriteLine();
        }
    }
}
