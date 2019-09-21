using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace _03_Threads
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

           


        }


        private void MyFunc(object args)
        {
           label1.Text = "I'm working in thread : " + Thread.CurrentThread.ManagedThreadId;
        }

        private void MyFuncWithoutArgs()
        {
            label1.Text = "I'm working in thread : " + Thread.CurrentThread.ManagedThreadId;         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TimerCallback myFunc = new TimerCallback(MyFunc);
            System.Threading.Timer timer = new System.Threading.Timer(myFunc);
            timer.Change(100, 500);          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThreadStart threadStart = new ThreadStart(MyFuncWithoutArgs);
            Thread thread = new Thread(threadStart);
            thread.Start();
            //  thread.Join();

            for (int i = 0; i < 10000; i++)
            {
                label2.Text = i.ToString();
                //Thread.Sleep(20);
            }
        }
    }
}
