using System;

namespace SortAlgorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create random array of given size
            int[] array = Utility.GetRandArray(1000, 1000000);

            // Print out comparison between various sorting algorithms
            SortComparison.CompareTime(array);
            SortComparison.CompareIfs(array);
            SortComparison.CompareSwaps(array);


            Console.ReadLine();
        }
    }
}
