using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Semaphores
{
    class Reader
    {
        static Semaphore sem = new Semaphore(3, 3);
        Thread myThread;

        public Reader(int i)
        {
            myThread = new Thread(Read);
            myThread.Name = $"Студент {i}";
            myThread.Start();
        }

        public void Read()
        {
            sem.WaitOne();

            Console.WriteLine($"{Thread.CurrentThread.Name} входит в аудиторию.");

            Console.WriteLine($"{Thread.CurrentThread.Name} учится.");
            Thread.Sleep(1000);

            Console.WriteLine($"{Thread.CurrentThread.Name} покидает аудиторию.");

            sem.Release();

            Thread.Sleep(1000);
        }
    }
}
