using System;

namespace Stack
{
    internal class StackAsNode
    {
        private Node topNode;
        private int size;

        /// <summary>
        /// Instance of StackAsNode class is initialized by taking an integer as the initial value.
        /// </summary>
        /// <param name="iNum"></param>
        public StackAsNode(int iNum) 
        {
            topNode = new Node(iNum);
            size = 1;
        }

        public bool Push(int iNum)
        {
            Node newNode = new Node(iNum, topNode);
            topNode = newNode;
            size++;

            return true;
        }

        public bool Pop()
        {
            topNode = topNode.next;
            size--;

            return true;
        }

        public int Peak()
        {
            return topNode.value;
        }

        public bool Print()
        {
            // Creates a copy of topNode and iterates until the last node
            Node newTop = topNode;

            int[] printArray= new int[size];

            for (int i = 0; i < size; i++) 
            {
                printArray[i] = newTop.value;
                newTop = newTop.next;
            }

            for (int i = size - 1; i >= 0; i--)
            {
                Console.WriteLine(printArray[i]);
            }


            return true;
        }

    }
}
