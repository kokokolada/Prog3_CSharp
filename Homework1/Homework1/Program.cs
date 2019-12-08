using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;

            while (i < 100)
            {
                if (i % 3 == 0)
                {
                   Console.WriteLine($"Number {i} jagub kolmega");
                }
                i++;
            }
        }
    }
}
