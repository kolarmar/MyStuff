using System;
using System.Diagnostics;


namespace SortAlgorithms
{
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
}
