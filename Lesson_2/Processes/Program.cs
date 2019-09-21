using MyLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Processes
{
    class Program
    {
        const uint WM_SETTEXT = 0x0C;
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hwnd, uint Msg, int wParam,
        [MarshalAs(UnmanagedType.LPStr)]string lParam);

        static void Main(string[] args)
        {
            Assembly asm = Assembly.Load(AssemblyName.GetAssemblyName("MyLib.dll"));
            Module module = asm.GetModule("MyLib.dll");
            Type [] types = module.GetTypes();
            foreach (var item in types)
            {
                Console.WriteLine(item.Name);
            }

            Type type = module.GetType("MyLib.Person");
            var obj = Activator.CreateInstance(type, new Object [] { "Oleg" });
            type.GetMethod("ShowInfoAboutPerson").Invoke(obj, null);


            Console.WriteLine("------------------------------------");

            //----GET ALL EXE FILES IN PROJECT----
            var filesExe = Directory.GetFiles(@"D:\STEP\системне\SystemProgramming_2019\Lesson_2\Processes\bin\Debug", "*.exe");
            foreach (var item in filesExe)
            {
                Console.WriteLine(item);
            }


            //---START EXE MyWPFApp
            Assembly asmExe = Assembly.Load(AssemblyName.GetAssemblyName("MyWpfApp.exe"));
            Process process = Process.Start("MyWpfApp");

            string msg = Console.ReadLine();
            process.EnableRaisingEvents = true;
            SendMessage(process.MainWindowHandle, WM_SETTEXT, 0, msg);

            //  Person person = new Person("Vasja");
            Console.ReadKey();
        }
    }
}
