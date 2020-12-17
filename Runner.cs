using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace dismodos
{
    internal static class Runner
    {
        private static void Main(string[] args)
        {
            var q = new Queue<string>();
            q.Enqueue("Joseph");
            q.Enqueue("Verron");
            q.Enqueue("Louise");


            var thread = new Thread(QueueReading);
            thread.Start(q);

            Console.WriteLine("Whatever");
            
            q.Enqueue("Pascal");
            q.Enqueue("Isabelle");
            q.Enqueue("Munoz");
            
            Console.ReadLine();
            thread.Interrupt();
        }

        private static void QueueReading(object obj)
        {
            if (!(obj is Queue<string> queue)) 
                return;
            
            Console.WriteLine("Hello, World!");
            while (queue.Count > 0)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Hello, " + queue.Dequeue());
            }
        }
    }
}