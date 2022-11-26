using System.Net.Http.Headers;

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
        static int[] RandomArray(int size)
        {
            int[] arr = new int[size];
            int maxNum = size;
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

        static void Swap(ref int e1, ref int e2)
        {
            int temp = e1;
            e1 = e2;
            e2 = temp;
        }

        static int[] BubbleSort(int[] arr)
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
        static void Main(string[] args)
        {
            int[] array = RandomArray(500);
            array = SelectSort(array);
            PrintArray(array);
        }
    }
}