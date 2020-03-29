using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Semaphores
{
    class Program
    {
        static Semaphore semaphore = new Semaphore(1, 5);
        static Thread[] threads = new Thread[5];

        static void Main(string[] args)
        {
            for (int i = 0, k = 1; i < 5; i++, k++)
            {
                threads[i] = new Thread(StudentAction);
                threads[i].Name = $"Студент {k}";
                threads[i].Start();
            }

            for(int i = 0; i < 5; i++)
            {
                threads[i].Join();
            }

            Console.WriteLine("\nАудитория закрывается.");
            Console.ReadLine();
        }

        static private void StudentAction()
        {
            semaphore.WaitOne();

            Console.WriteLine($"{Thread.CurrentThread.Name} входит в аудиторию.");

            Console.WriteLine($"{Thread.CurrentThread.Name} учится.");
            Thread.Sleep(1000);

            Console.WriteLine($"{Thread.CurrentThread.Name} покидает аудиторию.");

            semaphore.Release();

            Thread.Sleep(1000);
        }
    }
}
