using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03_Semaphor
{
    class Program
    {
        static Semaphore s = new Semaphore(2, 6, "asd-123");
        static void Main(string[] args)
        {            
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Foo);
            }

            Console.ReadKey();
        }


        static void Foo(object o)
        {
            s.WaitOne();
            Console.WriteLine("thread start - "+ Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 100; i++)
            {
                Console.Write("*");
                Thread.Sleep(50);
            }
            Console.WriteLine("thread end - " + Thread.CurrentThread.ManagedThreadId);
            s.Release();
        }
    }
}
