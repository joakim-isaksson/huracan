using Huracan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PreattyHex.CreateString(true, "Helloooooooooooooooo", "Worldddddddddddddddddd", "Yeahaaaaaaaaaaaaaaa", ' '));
            Console.WriteLine();
            Console.WriteLine(PreattyHex.CreateString(true, "Helloooooooooooooooo", "Worldddddddddddddddddd", "Yeahaaaaaaaaaaaaaaa", ' '));
        }
    }
}
