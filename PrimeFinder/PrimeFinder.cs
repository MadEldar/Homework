using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Homework_2021_03_23
{
    public static class PrimeFinder
    {
        public static async Task<List<int>> FindInRange(int start, int end)
        {
            List<int> list = new List<int>();
            
            do {
                if (await IsPrime(start)) {
                    list.Add(start);
                }
            }
            while (start++ < end);

            return list;
        }

        public static Task<bool> IsPrime(int number) {
            return Task.Run(() => {
                if (number <= 0) return false;
                else if (number <= 3) return true;

                for (int i = 2; i <= Math.Sqrt(number); i++) {
                    if (number % i == 0) {
                        return false;
                    }
                }
                
                return true;
            });
        }
    }
}