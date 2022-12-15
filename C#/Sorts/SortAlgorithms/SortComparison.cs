using System;
using System.Linq;

namespace SortAlgorithms
{
    public class SortComparison : Measure
    {
        public static void CompareTime(int[] array)
        {
            // Make copies of master array
            int[] a = array.ToArray();
            int[] b = array.ToArray();
            int[] c = array.ToArray();
            int[] d = array.ToArray();
            int[] e = array.ToArray();
            int[] f = array.ToArray();
            int[] g = array.ToArray();

            Console.WriteLine("Time taken with BUBBLE V1 sort: " + Time_BubbleV1(a));
            Console.WriteLine("Time taken with BUBBLE V2 sort: " + Time_BubbleV2(b));
            Console.WriteLine("Time taken with SHAKER sort: " + Time_Shaker(c));
            Console.WriteLine("Time taken with INSERT sort: " + Time_Insert(d));
            Console.WriteLine("Time taken with SELECT sort: " + Time_Select(e));
            Console.WriteLine("Time taken with QUICK V1 sort: " + Time_QuickV1(f));
            Console.WriteLine("Time taken with QUICK V2 sort: " + Time_QuickV2(g));

            //Console.WriteLine("Time taken with MERGE sort: " + Time_Merge(g));

            Console.WriteLine();
        }

        public static void CompareIfs(int[] array)
        {
            // Make copies of master array
            int[] a = array.ToArray();
            int[] b = array.ToArray();
            int[] c = array.ToArray();
            int[] d = array.ToArray();
            int[] e = array.ToArray();
            int[] f = array.ToArray();
            int[] g = array.ToArray();

            Console.WriteLine("Comparisons made with BUBBLE V1 sort: " + Compare_BubbleV1(a));
            Console.WriteLine("Comparisons made with BUBBLE V2 sort: " + Compare_BubbleV2(b));
            Console.WriteLine("Comparisons made with SHAKER sort: " + Compare_Shaker(c));
            Console.WriteLine("Comparisons made with INSERT sort: " + Compare_Insert(d));
            Console.WriteLine("Comparisons made with SELECT sort: " + Compare_Select(e));
            Console.WriteLine("Comparisons made with QUICK V1 sort: " + Compare_QuickV1(f, 0, f.Length - 1, 0));
            Console.WriteLine("Comparisons made with QUICK V2 sort: " + Compare_QuickV2(g, 0, g.Length - 1, 0));

            Console.WriteLine();
        }

        public static void CompareSwaps(int[] array)
        {
            // Make copies of master array
            int[] a = array.ToArray();
            int[] b = array.ToArray();
            int[] c = array.ToArray();
            int[] d = array.ToArray();
            int[] e = array.ToArray();
            int[] f = array.ToArray();
            int[] g = array.ToArray();

            Console.WriteLine("Swaps required with BUBBLE V1 sort: " + Swap_BubbleV1(a));
            Console.WriteLine("Swaps required with BUBBLE V2 sort: " + Swap_BubbleV2(b));
            Console.WriteLine("Swaps required with SHAKER sort: " + Swap_Shaker(c));
            Console.WriteLine("Swaps required with INSERT sort: " + Swap_Insert(d));
            Console.WriteLine("Swaps required with SELECT sort: " + Swap_Select(e));
            Console.WriteLine("Swaps required with QUICK V1 sort: " + Swap_QuickV1(f, 0, f.Length - 1, 0));
            Console.WriteLine("Swaps required with QUICK V2 sort: " + Swap_QuickV2(g, 0, g.Length - 1, 0));

            Console.WriteLine();
        }
    }
}
