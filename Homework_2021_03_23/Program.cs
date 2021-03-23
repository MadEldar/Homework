using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Homework_2021_03_23
{
    class Program
    {
        static async Task Main(string[] args)
        {
            PrintIntList(await PrimeFinder.FindInRange(1, 100));
        }

        public static void PrintIntList(List<int> list) {
            foreach (int i in list) {
                Console.WriteLine(i);
            }
        }
    }
}
