
namespace SortAlgorithms
{
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
}
