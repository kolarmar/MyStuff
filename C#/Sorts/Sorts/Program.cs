using System;
using System.Diagnostics;
using System.Linq;

namespace Sorts
{
    internal class Program
    {
        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Console.Write(arr[i] + ", ");
            }
            Console.Write(arr[arr.Length - 1]);
        }
        static int[] RandomArray(int size, int maxNum)
        {
            int[] arr = new int[size];
            var rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                arr[i] = rnd.Next(maxNum);
            }
            return arr;
        }

        static int FindMinIndex(int[] arr, int i)
        {
            int min = arr[i];
            int minIndex = i;
            for (int j = i;j < arr.Length; j++)
            {
                if (arr[j] < min)
                {
                    min = arr[j];
                    minIndex = j;
                }
            }
            return minIndex;
        }

        static void Swap(ref int e1, ref int e2)
        {
            int temp = e1;
            e1 = e2;
            e2 = temp;
        }

        static int[] BubbleSortV1(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                    }
                }
            }
            return arr;
        }

        static int[] BubbleSortV2(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                bool swapReuqired = false;
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
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
            return arr;
        }

        static int[] ShakerSort(int[] arr)
        {
            bool swapRequired;
            for (int i = 0; i < arr.Length / 2; i++)
            {
                swapRequired = false;
                for (int j = i; j < arr.Length - i - 1; j++)
                {
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
            return arr;
        }

        static int[] InsertSort(int[] arr)
        {
            for(int i = 1; i < arr.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        Swap(ref arr[j - 1], ref arr[j]);
                    }
                }
            }
            return arr;
        }

        static int[] SelectSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int minIndex = FindMinIndex(arr, i);
                Swap(ref arr[i], ref arr[minIndex]);
            }
            return arr;
        }

        static int[] MergeSort(int[] arr, int left, int right)
        {
            if(left < right)
            {
                int mid = left + (right - left) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                MergeBack(arr, left, mid, right);
            }
            return arr;
        }

        static void MergeBack(int[] arr, int left, int mid, int right)
        {
            int leftArrLength = mid - left + 1;
            int rightArrLength = right - mid;
            int[] leftTempArr = new int[leftArrLength];
            int[] rightTempArr = new int[rightArrLength];
            int i, j;

            for(i = 0; i < leftArrLength; i++)
            {
                leftTempArr[i] = arr[left + i];
            }
            for (j = 0; j < rightArrLength; j++)
            {
                rightTempArr[j] = arr[mid + 1 + j];
            }

            i = 0;
            j = 0;
            int k = left;

            while (i < leftArrLength && j < rightArrLength)
            {
                if (leftTempArr[i] <= rightTempArr[j])
                {
                    arr[k++] = leftTempArr[i++];
                }
                else
                {
                    arr[k++] = rightTempArr[j++];
                }
            }
            while(i < leftArrLength)
            {
                arr[k++] = leftTempArr[i++];
            }
            while (j < rightArrLength)
            {
                arr[k++] = rightTempArr[j++];
            }
        }

        static int[] QuickSort(int[] arr, int leftIndex, int rightIndex)
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
                    Swap(ref arr[i], ref arr[j]);
                    i++;
                    j--;
                }
            }
            if (leftIndex < j)
            {
                QuickSort(arr, leftIndex, j);
            }
            if (i < rightIndex)
            {
                QuickSort(arr, i, rightIndex);
            }
            return arr;
        }
    

        static TimeSpan Sort_MeasureSelect(int[] arr)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            SelectSort(arr);
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        static TimeSpan Sort_MeasureQuick(int[] arr)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            QuickSort(arr, 0, arr.Length - 1);
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        static TimeSpan Sort_MeasureInsert(int[] arr)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            InsertSort(arr);
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        static TimeSpan Sort_MeasureBubbleV1(int[] arr)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            BubbleSortV1(arr);
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        static TimeSpan Sort_MeasureBubbleV2(int[] arr)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            BubbleSortV2(arr);
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        static TimeSpan Sort_MeasureShaker(int[] arr)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            ShakerSort(arr);
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }

        static TimeSpan Sort_MeasureMerge(int[] arr)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            MergeSort(arr, 0, arr.Length - 1);
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }



        static void SwapMeasure(ref int e1, ref int e2, ref int swapTimes)
        {
            int temp = e1;
            e1 = e2;
            e2 = temp;
            swapTimes++;
        }

        static int BubbleSortV1Swap(int[] arr)
        {
            int swapTimes = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        SwapMeasure(ref arr[j], ref arr[j + 1], ref swapTimes);
                    }
                }
            }
            return swapTimes;
        }

        static int BubbleSortV2Swap(int[] arr)
        {
            int swapTimes = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                bool swapReuqired = false;
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        SwapMeasure(ref arr[j], ref arr[j + 1], ref swapTimes);
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

        static int ShakerSortSwap(int[] arr)
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
                        SwapMeasure(ref arr[j], ref arr[j + 1], ref swapTimes);
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
                        SwapMeasure(ref arr[j], ref arr[j + 1], ref swapTimes);
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

        static int InsertSortSwap(int[] arr)
        {
            int swapTimes = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        SwapMeasure(ref arr[j - 1], ref arr[j], ref swapTimes);
                    }
                }
            }
            return swapTimes;
        }

        static int SelectSortSwap(int[] arr)
        {
            int swapTimes = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int minIndex = FindMinIndex(arr, i);
                SwapMeasure(ref arr[i], ref arr[minIndex], ref swapTimes);
            }
            return swapTimes;
        }

        static int QuickSortSwap(int[] arr, int leftIndex, int rightIndex, int swapTimes)
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
                    SwapMeasure(ref arr[i], ref arr[j], ref swapTimes);
                    i++;
                    j--;
                }
            }
            if (leftIndex < j)
            {
                return QuickSortSwap(arr, leftIndex, j, swapTimes);
            }
            if (i < rightIndex)
            {
                return QuickSortSwap(arr, i, rightIndex, swapTimes);
            }
            return swapTimes;
        }


        static int BubbleSortV1_CompareSum(int[] arr)
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

        static int BubbleSortV2_CompareSum(int[] arr)
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


        static int ShakerSort_CompareSum(int[] arr)
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

        static int InsertSort_CompareSum(int[] arr)
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

        static int SelectSort_CompareSum(int[] arr)
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


        static int QuickSort_CompareSum(int[] arr, int leftIndex, int rightIndex, int compared)
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
                return QuickSort_CompareSum(arr, leftIndex, j, compared);
            }
            compared++;
            if (i < rightIndex)
            {
                return QuickSort_CompareSum(arr, i, rightIndex, compared);
            }
            return compared;
        }


        static void Sort_CompareTime(int[] array)
        {
            // Make copies of master array
            int[] a = array.ToArray();
            int[] b = array.ToArray();
            int[] c = array.ToArray();
            int[] d = array.ToArray();
            int[] e = array.ToArray();
            int[] f = array.ToArray();
            int[] g = array.ToArray();

            Console.WriteLine("Time taken with SELECT sort: " + Sort_MeasureSelect(a));
            Console.WriteLine("Time taken with QUICK sort: " + Sort_MeasureQuick(b));
            Console.WriteLine("Time taken with INSERT sort: " + Sort_MeasureInsert(c));
            Console.WriteLine("Time taken with BUBBLE V1 sort: " + Sort_MeasureBubbleV1(d));
            Console.WriteLine("Time taken with BUBBLE V2 sort: " + Sort_MeasureBubbleV2(e));
            Console.WriteLine("Time taken with SHAKER sort: " + Sort_MeasureShaker(f));
            Console.WriteLine("Time taken with MERGE sort: " + Sort_MeasureMerge(g));
        }

        static void Sort_CompareComparisons(int[] array)
        {
            // Make copies of master array
            int[] a = array.ToArray();
            int[] b = array.ToArray();
            int[] c = array.ToArray();
            int[] d = array.ToArray();
            int[] e = array.ToArray();
            int[] f = array.ToArray();
            int[] g = array.ToArray();

            Console.WriteLine("Comparisons made with SELECT sort: " + SelectSort_CompareSum(a));
            Console.WriteLine("Comparisons made with QUICK sort: " + QuickSort_CompareSum(b, 0, array.Length - 1, 0));
            Console.WriteLine("Comparisons made with INSERT sort: " + InsertSort_CompareSum(c));
            Console.WriteLine("Comparisons made with BUBBLE V1 sort: " + BubbleSortV1_CompareSum(d));
            Console.WriteLine("Comparisons made with BUBBLE V2 sort: " + BubbleSortV2_CompareSum(e));
            Console.WriteLine("Comparisons made with SHAKER sort: " + ShakerSort_CompareSum(f));
        }

        static void Sort_CompareSwaps(int[] array)
        {
            // Make copies of master array
            int[] a = array.ToArray();
            int[] b = array.ToArray();
            int[] c = array.ToArray();
            int[] d = array.ToArray();
            int[] e = array.ToArray();
            int[] f = array.ToArray();

            Console.WriteLine("Swaps needed for SELECT sort: " + SelectSortSwap(a));
            Console.WriteLine("Swaps needed for QUICK sort: " + QuickSortSwap(b, 0, array.Length - 1, 0));
            Console.WriteLine("Swaps needed for INSERT sort: " + InsertSortSwap(c));
            Console.WriteLine("Swaps needed for BUBBLE V1 sort: " + BubbleSortV1Swap(d));
            Console.WriteLine("Swaps needed for BUBBLE V2 sort: " + BubbleSortV2Swap(e));
            Console.WriteLine("Swaps needed for SHAKER sort: " + ShakerSortSwap(f));


        }


        static void Main(string[] args)
        {
            int[] array = RandomArray(10000, 1000000);
            Sort_CompareTime(array);
            Console.WriteLine();
            Sort_CompareSwaps(array);
            Console.WriteLine();
            Sort_CompareComparisons(array);



            /*

            Quick sort and Insert sort have the same speed at about 130 elements.


            250 elements:
            Time elapsed for select sort: 00:00:00.0003182
            Time elapsed for insert sort: 00:00:00.0003559
            Time elapsed for quick sort: 00:00:00.0001682

            500 elements:
            Time elapsed for select sort: 00:00:00.0006726
            Time elapsed for insert sort: 00:00:00.0008965
            Time elapsed for quick sort: 00:00:00.0002026

            1000 elements:
            Time elapsed for select sort: 00:00:00.0017868
            Time elapsed for insert sort: 00:00:00.0035529
            Time elapsed for quick sort: 00:00:00.0003212

            10000 elements:
            Time elapsed for select sort: 00:00:00.1523438
            Time elapsed for insert sort: 00:00:00.2842147
            Time elapsed for quick sort: 00:00:00.0018829

            50000 elements:
            Time elapsed for select sort: 00:00:03.8075869
            Time elapsed for insert sort: 00:00:06.8326245
            Time elapsed for quick sort: 00:00:00.0088186

            100000 elements:
            Time elapsed for select sort: 00:00:14.5775813
            Time elapsed for insert sort: 00:00:27.2025551
            Time elapsed for quick sort: 00:00:00.0178450

            200000 elements:
            Time elapsed for select sort: 00:01:08.3395374
            Time elapsed for insert sort: 00:02:09.3815292
            Time elapsed for quick sort: 00:00:00.0383943

             */

        }
    }
}