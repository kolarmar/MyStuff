using System;

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
}
