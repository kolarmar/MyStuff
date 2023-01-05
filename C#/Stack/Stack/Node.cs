using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    internal class Node
    {
        public int value;
        public Node next;

        public Node(int iValue)
        {
            value = iValue;
            next = null;
        }
    }
}
