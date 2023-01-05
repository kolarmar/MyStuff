using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node n1 = new Node(10);
            Node n2 = new Node(20);

            n1.next = n2;

            Console.WriteLine(n1.next.value);

        }
    }
}
