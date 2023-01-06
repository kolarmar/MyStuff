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
            StackAsNode stack = new StackAsNode(0);

            for(int i = 1; i< 25; i++)
            {
                stack.Push(i);
            }

            stack.Print();

        }
    }
}
