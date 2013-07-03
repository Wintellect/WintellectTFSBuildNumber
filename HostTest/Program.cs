using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostTest
{
    using System.Diagnostics;

    class Program
    {
        static void Main(string[] args)
        {
            ProcessModule exe = Process.GetCurrentProcess().Modules[0];
            Console.WriteLine("Program version : {0}", exe.FileVersionInfo.FileVersion);
        }
    }
}
