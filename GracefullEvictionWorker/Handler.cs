using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GracefullEvictionWorker
{
    internal class Handler
    {
        public Task DoWork(string body)
        {
            Console.WriteLine("DoWork {0} has been called", body);
            Thread.Sleep(5000);
            Console.WriteLine("DoWork {0} has finished", body);
            return Task.CompletedTask;
        }
    }
}
