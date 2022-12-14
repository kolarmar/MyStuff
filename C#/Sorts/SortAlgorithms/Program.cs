using System;
using System.Diagnostics;
using System.Linq;

namespace SortAlgorithms
{
    public class Utility
    {
        public static void Swap(ref int e1, ref int e2)
        {
            int temp = e1;
            e1 = e2;
            e2 = temp;
        }

        public static void MeasureSwap(ref int e1, ref int e2, ref int swapTimes)
        {
            int temp = e1;
            e1 = e2;
            e2 = temp;
            swapTimes++;
        }

        public static int[] GetRandArray(int size, int maxNum)
        {
            int[] arr = new int[size];
            var rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                arr[i] = rnd.Next(maxNum);
            }
            return arr;
        }

        public static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Console.Write(arr[i] + ", ");
            }
            Console.Write(arr[arr.Length - 1]);
        }

        public static int FindMinIndex(int[] arr, int i)
        {
            int min = arr[i];
            int minIndex = i;
            for (int j = i; j < arr.Length; j++)
            {
                if (arr[j] < min)
                {
                    min = arr[j];
                    minIndex = j;
                }
            }
            return minIndex;
        }
    }




    public class Sort : Utility
    {
        public static int[] BubbleV1(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
            return array;
        }
        public static int[] BubbleV2(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                bool swapReuqired = false;
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swapReuqired = true;
                    }
                }
                if (swapReuqired == false)
                {
                    break;
                }
            }
            return array;
        }
        public static int[] Shaker(int[] array)
        {
            bool swapRequired;
            for (int i = 0; i < array.Length / 2; i++)
            {
                swapRequired = false;
                for (int j = i; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swapRequired = true;
                    }
                }
                if (swapRequired == false)
                {
                    break;
                }
                swapRequired = false;
                for (int j = array.Length - i - 2; j > i; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        Swap(ref array[j - 1], ref array[j]);
                        swapRequired = true;
                    }
                }
                if (swapRequired == false)
                {
                    break;
                }
            }
            return array;
        }

        public static int[] Insert(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        Swap(ref array[j - 1], ref array[j]);
                    }
                }
            }
            return array;
        }

        public static int[] Select(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int minIndex = FindMinIndex(array, i);
                Swap(ref array[i], ref array[minIndex]);
            }
            return array;
        }

        public static int[] QuickV1(int[] array, int leftIndex, int rightIndex)
        {
            int i = leftIndex;
            int j = rightIndex;
            int pivot = array[leftIndex];

            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }
                while (pivot < array[j])
                {
                    j--;
                }
                if (i <= j)
                {
                    Swap(ref array[i], ref array[j]);
                    i++;
                    j--;
                }
            }
            if (leftIndex < j)
            {
                QuickV1(array, leftIndex, j);
            }
            if (i < rightIndex)
            {
                QuickV1(array, i, rightIndex);
            }
            return array;
        }

        public static int[] QuickV2(int[] array, int leftIndex, int rightIndex)
        {
            int i = leftIndex;
            int j = rightIndex;
            int pivot = array[leftIndex];

            // When the subarray is under 130 elements, it is faster to use insertion sort.
            // This makes this sort about twice as fast for huge arrays, though a bit slower for small arrays.
            if (rightIndex - leftIndex < 130)
            {
                for (int k = leftIndex; k < rightIndex - leftIndex + 1; k++)
                {
                    for (int l = k; l > 0; l--)
                    {
                        if (array[l - 1] > array[l])
                        {
                            Swap(ref array[l - 1], ref array[l]);
                        }
                    }
                }
                return array;
            }

            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }
                while (pivot < array[j])
                {
                    j--;
                }
                if (i <= j)
                {
                    Swap(ref array[i], ref array[j]);
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
            {
                QuickV2(array, leftIndex, j);
            }
            if (i < rightIndex)
            {
                QuickV2(array, i, rightIndex);
            }

            return array;
        }

        public static int[] Merge(int[] array, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                Merge(array, left, mid);
                Merge(array, mid + 1, right);
                MergeBack(array, left, mid, right);
            }
            return array;
        }

        private static void MergeBack(int[] array, int left, int mid, int right)
        {
            int leftArrLength = mid - left + 1;
            int rightArrLength = right - mid;
            int[] leftTempArr = new int[leftArrLength];
            int[] rightTempArr = new int[rightArrLength];
            int i, j;

            for (i = 0; i < leftArrLength; i++)
            {
                leftTempArr[i] = array[left + i];
            }
            for (j = 0; j < rightArrLength; j++)
            {
                rightTempArr[j] = array[mid + 1 + j];
            }

            i = 0;
            j = 0;
            int k = left;

            while (i < leftArrLength && j < rightArrLength)
            {
                if (leftTempArr[i] <= rightTempArr[j])
                {
                    array[k++] = leftTempArr[i++];
                }
                else
                {
                    array[k++] = rightTempArr[j++];
                }
            }
            while (i < leftArrLength)
            {
                array[k++] = leftTempArr[i++];
            }
            while (j < rightArrLength)
            {
                array[k++] = rightTempArr[j++];
            }
        }
    }

    public class Measure : Sort
    {

        public static TimeSpan Time_BubbleV1(int[] array)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            BubbleV1(array);
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
        public static TimeSpan Time_BubbleV2(int[] array)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            BubbleV2(array);
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        public static TimeSpan Time_Shaker(int[] array)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Shaker(array);
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        public static TimeSpan Time_Insert(int[] array)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Insert(array);
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        public static TimeSpan Time_Select(int[] array)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Select(array);
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        public static TimeSpan Time_QuickV1(int[] array)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            QuickV1(array, 0, array.Length - 1);
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
        public static TimeSpan Time_QuickV2(int[] array)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            QuickV2(array, 0, array.Length - 1);
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        public static int Compare_BubbleV1(int[] arr)
        {
            int compared = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    compared++;
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                    }
                }
            }
            return compared;
        }

        public static int Compare_BubbleV2(int[] arr)
        {
            int compared = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                bool swapReuqired = false;
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    compared++;
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                        swapReuqired = true;
                    }
                }
                if (swapReuqired == false)
                {
                    break;
                }
            }
            return compared;
        }

        public static int Compare_Shaker(int[] arr)
        {
            bool swapRequired;
            int compared = 0;
            for (int i = 0; i < arr.Length / 2; i++)
            {
                swapRequired = false;
                for (int j = i; j < arr.Length - i - 1; j++)
                {
                    compared++;
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                        swapRequired = true;
                    }
                }
                if (swapRequired == false)
                {
                    break;
                }
                swapRequired = false;
                for (int j = arr.Length - i - 2; j > i; j--)
                {
                    compared++;
                    if (arr[j - 1] > arr[j])
                    {
                        Swap(ref arr[j - 1], ref arr[j]);
                        swapRequired = true;
                    }
                }
                if (swapRequired == false)
                {
                    break;
                }
            }
            return compared;
        }

        public static int Compare_Insert(int[] arr)
        {
            int compared = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    compared++;
                    if (arr[j - 1] > arr[j])
                    {
                        Swap(ref arr[j - 1], ref arr[j]);
                    }
                }
            }
            return compared;
        }

        public static int Compare_Select(int[] arr)
        {
            int compared = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int min = arr[i];
                int minIndex = i;
                for (int j = i; j < arr.Length; j++)
                {
                    compared++;
                    if (arr[j] < min)
                    {
                        min = arr[j];
                        minIndex = j;
                    }
                }
                Swap(ref arr[i], ref arr[minIndex]);
            }
            return compared;
        }


        public static int Compare_QuickV1(int[] arr, int leftIndex, int rightIndex, int compared)
        {
            int i = leftIndex;
            int j = rightIndex;
            int pivot = arr[leftIndex];

            while (i <= j)
            {
                while (arr[i] < pivot)
                {
                    compared++;
                    i++;
                }
                while (pivot < arr[j])
                {
                    compared++;
                    j--;
                }
                compared++;
                if (i <= j)
                {
                    Swap(ref arr[i], ref arr[j]);
                    i++;
                    j--;
                }
            }
            compared++;
            if (leftIndex < j)
            {
                return Compare_QuickV1(arr, leftIndex, j, compared);
            }
            compared++;
            if (i < rightIndex)
            {
                return Compare_QuickV1(arr, i, rightIndex, compared);
            }
            return compared;
        }
        public static int Compare_QuickV2(int[] array, int leftIndex, int rightIndex, int compared)
        {
            int i = leftIndex;
            int j = rightIndex;
            int pivot = array[leftIndex];

            compared++;
            if (rightIndex - leftIndex < 130)
            {
                for (int k = leftIndex; k < rightIndex - leftIndex + 1; k++)
                {
                    for (int l = k; l > 0; l--)
                    {
                        compared++;
                        if (array[l - 1] > array[l])
                        {
                            Swap(ref array[l - 1], ref array[l]);
                        }
                    }
                }
                return compared;
            }

            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    compared++;
                    i++;
                }
                while (pivot < array[j])
                {
                    compared++;
                    j--;
                }
                compared++;
                if (i <= j)
                {
                    Swap(ref array[i], ref array[j]);
                    i++;
                    j--;
                }
            }
            compared++;
            if (leftIndex < j)
            {
                Compare_QuickV2(array, leftIndex, j, compared);
            }
            compared++;
            if (i < rightIndex)
            {
                Compare_QuickV2(array, i, rightIndex, compared);
            }

            return compared;
        }

        public static int Swap_BubbleV1(int[] arr)
        {
            int swapTimes = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        MeasureSwap(ref arr[j], ref arr[j + 1], ref swapTimes);
                    }
                }
            }
            return swapTimes;
        }

        public static int Swap_BubbleV2(int[] arr)
        {
            int swapTimes = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                bool swapReuqired = false;
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        MeasureSwap(ref arr[j], ref arr[j + 1], ref swapTimes);
                        swapReuqired = true;
                    }
                }
                if (swapReuqired == false)
                {
                    break;
                }
            }
            return swapTimes;
        }

        public static int Swap_Shaker(int[] arr)
        {
            int swapTimes = 0;
            bool swapRequired;
            for (int i = 0; i < arr.Length / 2; i++)
            {
                swapRequired = false;
                for (int j = i; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        MeasureSwap(ref arr[j], ref arr[j + 1], ref swapTimes);
                        swapRequired = true;
                    }
                }
                if (swapRequired == false)
                {
                    break;
                }
                swapRequired = false;
                for (int j = arr.Length - i - 2; j > i; j--)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        MeasureSwap(ref arr[j], ref arr[j + 1], ref swapTimes);
                        swapRequired = true;
                    }
                }
                if (swapRequired == false)
                {
                    break;
                }
            }
            return swapTimes;
        }

        public static int Swap_Insert(int[] arr)
        {
            int swapTimes = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        MeasureSwap(ref arr[j - 1], ref arr[j], ref swapTimes);
                    }
                }
            }
            return swapTimes;
        }

        public static int Swap_Select(int[] arr)
        {
            int swapTimes = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int minIndex = FindMinIndex(arr, i);
                MeasureSwap(ref arr[i], ref arr[minIndex], ref swapTimes);
            }
            return swapTimes;
        }

        public static int Swap_QuickV1(int[] arr, int leftIndex, int rightIndex, int swapTimes)
        {
            int i = leftIndex;
            int j = rightIndex;
            int pivot = arr[leftIndex];

            while (i <= j)
            {
                while (arr[i] < pivot)
                {
                    i++;
                }
                while (pivot < arr[j])
                {
                    j--;
                }
                if (i <= j)
                {
                    MeasureSwap(ref arr[i], ref arr[j], ref swapTimes);
                    i++;
                    j--;
                }
            }
            if (leftIndex < j)
            {
                return Swap_QuickV1(arr, leftIndex, j, swapTimes);
            }
            if (i < rightIndex)
            {
                return Swap_QuickV1(arr, i, rightIndex, swapTimes);
            }
            return swapTimes;
        }

        public static int Swap_QuickV2(int[] array, int leftIndex, int rightIndex, int swapTimes)
        {
            int i = leftIndex;
            int j = rightIndex;
            int pivot = array[leftIndex];

            if (rightIndex - leftIndex < 130)
            {
                for (int k = leftIndex; k < rightIndex - leftIndex + 1; k++)
                {
                    for (int l = k; l > 0; l--)
                    {
                        if (array[l - 1] > array[l])
                        {
                            MeasureSwap(ref array[l - 1], ref array[l], ref swapTimes);
                        }
                    }
                }
                return swapTimes;
            }

            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }
                while (pivot < array[j])
                {
                    j--;
                }
                if (i <= j)
                {
                    MeasureSwap(ref array[i], ref array[j], ref swapTimes);
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
            {
                Swap_QuickV2(array, leftIndex, j, swapTimes);
            }
            if (i < rightIndex)
            {
                Swap_QuickV2(array, i, rightIndex, swapTimes);
            }

            return swapTimes;
        }

    }

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
            Console.WriteLine("Comparisons made with QUICK V1 sort: " + Compare_QuickV1(f, 0, f.Length -  1, 0));
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

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Utility.GetRandArray(20000, 1000000);
            //Sort.QuickV2(array, 0, array.Length - 1);
            //Utility.PrintArray(array);

            SortComparison.CompareTime(array);
            SortComparison.CompareIfs(array);
            SortComparison.CompareSwaps(array);


            Console.ReadLine();
        }
    }
}
