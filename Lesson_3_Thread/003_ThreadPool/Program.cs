using System;
using System.Threading;

namespace AsyncProgramming
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Для запуска нажмите любую клавишу");
            Console.ReadKey();

          //  ThreadPoolWorker threadPoolWorker = new ThreadPoolWorker(new Action<object>(StarWriter));
            ThreadPoolWorker threadPoolWorker = new ThreadPoolWorker(StarWriter);
            threadPoolWorker.Start('*');

            for (int i = 0; i < 40; i++)
            {
                Console.Write('-');
                Thread.Sleep(50);
            }

            threadPoolWorker.Wait();

            Console.WriteLine($"Метод Main закончил свою работу.");
        }

        private static void StarWriter(object arg)
        {
            char item = (char)arg;

            for (int i = 0; i < 120; i++)
            {
                Console.Write(item);
                Thread.Sleep(50);
            }
        }
    }
}
