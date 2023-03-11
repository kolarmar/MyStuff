using System.Collections;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace GenericList
{
    internal class Program
    {
        private static void Print<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            List<int> list= new List<int>(1,2,3,4,5);
            IEnumerator<int> enumerator;
            list.Find(2, out enumerator);
            enumerator.MoveNext();
            list.ChangeValue(enumerator, 14);

            Print<int>(list);
        }
    }
}