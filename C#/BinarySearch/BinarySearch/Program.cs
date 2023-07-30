namespace BinarySearch
{
    internal class Program
    {
        static int BinSearch(int[] arr, int searchedNum)
        {
            return BinSearchInner(arr, searchedNum, 0, arr.Length - 1);
        }

        static int BinSearchInner(int[] arr, int num, int low, int high)
        {
            // Returns the index of the searched element ("num")

            if (low > high)
            {
                throw new Exception(String.Format("The array does not contain the number {0}", num));
            }

            int mid = (low + high) / 2;

            if (arr[mid] == num)
            {
                return mid;
            }
            if (arr[mid] > num)
            {
                return BinSearchInner(arr, num, low, mid - 1);
            }
            else
            {
                return BinSearchInner(arr, num, mid + 1, high);
            }
        }

        static void Main(string[] args)
        {
            int[] array = {1, 3, 6, 7, 8, 11, 18};
            int result = BinSearch(array, 7);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}