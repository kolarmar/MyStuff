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

        static void Main(string[] args)
        {
            int[] array = RandomArray(500);
            array = MergeSort(array, 0, array.Length - 1);
            PrintArray(array);
        }
    }
}