using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _04_THreadConsole
{
    class Program
    {
        Action action;

        static int number1 = 0;
        static int number2 = 0;
        static void Main(string[] args)
        {
            //ThreadStart threadStart = new ThreadStart(MyFuncWithoutArgs);
            //ParameterizedThreadStart threadStart = new ParameterizedThreadStart(MyFuncWithoutArgs);

            //Thread thread = new Thread(threadStart, 3);
            //thread.Start("Hello");




            //Thread[] threads = new Thread[10];
            //for (int i = 0; i < 10; i++)
            //{
            //    threads[i] = new Thread(threadStart);
            //    threads[i].Start("POSITION STARTED: "+i.ToString());
            //    threads[i].Join();
            //}
            //for (int i = 0; i < 50; i++)
            //{
            //    Console.WriteLine(i);
            //    Console.WriteLine("MAIN : " + Thread.CurrentThread.ManagedThreadId);
            //}



            //   thread.Join();


            ParameterizedThreadStart threadStart = new ParameterizedThreadStart(MyFuncWithCallback);
            Thread thread = new Thread(threadStart);
            Action act1 = new Action(CallbackAction1);
            thread.Start((object)act1);
            Thread.Sleep(50);


            ParameterizedThreadStart threadStart1 = new ParameterizedThreadStart(MyFuncWithCallback);
            Thread thread1 = new Thread(threadStart);
            Action act2 = new Action(CallbackAction2);
            thread1.Start((object)act2);


            Console.WriteLine("RESULT FROM THREADS");

            thread.Join();
            Console.WriteLine(number1);
            thread1.Join();
            Console.WriteLine(number2);
        }


        static private void MyFuncWithoutArgs(object obj)
        {

            string parametrs = (string)obj;
            Console.WriteLine("I'm working in thread : " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(parametrs);
            //for (int i = 0; i < 100; i++)
            //{
            //   // Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("+"+i);
            //    Thread.Sleep(20);
            //    Console.ResetColor();
            //}
        }



        static private void MyFuncWithCallback(object obj)
        {
            Action parametrs = (Action)obj;
            Console.WriteLine("I'm working in thread : " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(parametrs);
            Random r = new Random();
          
            for (int i = 0; i < r.Next(10,100); i++)
            {
              //  Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("+" + i);
                Thread.Sleep(100);
                Console.ResetColor();
            }
            parametrs.Invoke();
        }


        private static void CallbackAction1()
        {
            Console.WriteLine("I m finished!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            number1 = 55;
        }


        private static void CallbackAction2()
        {
            Console.WriteLine("Oooooooooooooooooo, i will miss you");
            number2 = 38;
        }
    }
}
