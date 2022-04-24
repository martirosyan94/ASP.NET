using System;
using System.Collections.Generic;

namespace Interview
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> numbers1 = new HashSet<int>() { 1, 5, 7, 11, 24 };
            HashSet<int> numbers2 = new HashSet<int>() { 11, 51, 24, 12, 24 };
            List<int> exclueded = new List<int>();
            foreach (int i in numbers1)
            {
                if (numbers2.Contains(i))
                    exclueded.Add(i);
            }
        }
    }
}
