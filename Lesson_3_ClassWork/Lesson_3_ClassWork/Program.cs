using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson_3_ClassWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread started");

            ThreadShow();

            for (int i = 0; i < 10; i++)
            {
             //   ThreadPool.QueueUserWorkItem(WorkinMethod, i);
                ThreadPool.QueueUserWorkItem(new WaitCallback(WorkinMethod), i);

            }

            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
                Console.Write("*");
            }
            ThreadShow();

            Console.ReadKey();
            ThreadShow();
        }


        static void WorkinMethod(object args)
        {
            Console.WriteLine("THREAD START - Id: " + Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
                Console.Write((int)args);
            }
            Console.WriteLine();
        }


        static void ThreadShow()
        {
            int maxIOThreads = 0;
            ThreadPool.GetMaxThreads(out int maxThreads, out maxIOThreads);
            Console.WriteLine($"maxThreads   {maxThreads}, maxIOThreads   {maxIOThreads}  ");
            ThreadPool.GetAvailableThreads(out int availableThreads, out int availableIOThreads);
            Console.WriteLine($"availableThreads   {availableThreads}, availableIOThreads   {availableIOThreads}  ");
        }
    }
}
