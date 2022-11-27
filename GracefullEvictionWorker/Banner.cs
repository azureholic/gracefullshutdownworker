using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GracefullEvictionWorker
{
    public static class Banner
    {
        public static void Print()
        {
            
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(@"    ___                        __  __      ___      ");
            Console.WriteLine(@"   /   |____  __  __________  / / / /___  / (_)____ ");
            Console.WriteLine(@"  / /| /_  / / / / / ___/ _ \/ /_/ / __ \/ / / ___/ ");
            Console.WriteLine(@" / ___ |/ /_/ /_/ / /  /  __/ __  / /_/ / / / /__   ");
            Console.WriteLine(@"/_/  |_/___/\__,_/_/   \___/_/ /_/\____/_/_/\___/   ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("            Azure Storage Queue Worker               ");
            Console.ResetColor();
        }

    }
}
