namespace BinarySearch
{
    internal class Program
    {
        static int BinSearch(int[] arr, int num, int low, int high)
        {
            if (low > high)
            {
                Console.WriteLine("The array does not contain the number {0}", num);
                return -1;
            }
            int mid = (low + high) / 2;
            if (arr[mid] == num)
            {
                return mid;
            }
            if (arr[mid] > num)
            {
                return BinSearch(arr, num, low, mid - 1);
            }
            else
            {
                return BinSearch(arr, num, mid + 1, high);
            }
        }

        static void Main(string[] args)
        {
            int[] array = {1, 3, 6, 7, 8, 11, 18};
            int result = BinSearch(array, 0, 0, array.Length - 1);
            Console.WriteLine(result);
        }
    }
}