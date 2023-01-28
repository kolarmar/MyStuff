using System;

namespace DataStructures
{
    internal class QueueAsNode
    {
        private Node topNode;
        private int size;

        public QueueAsNode(int iNum)
        {
            topNode = new Node(iNum);
            size = 1;
        }

        public void Push(int iNum)
        {
            if (size > 0)
            {
                Node newNode = new Node(iNum, topNode);
                topNode = newNode;
                size++;
            }
            if (size == 0)
            {
                topNode = new Node(iNum);
                size = 1;
            }
        }

        public void Pop()
        {
            if (size > 0) size--;
        }

        public int Peak()
        {
            if (size <= 0) return -1;

            Node newTop = topNode;
            for(int i = 0; i < size - 1; i++)
            {
                newTop = newTop.next;
            }
            return newTop.value;
        }

        public void Print()
        {
            // Creates an array of values from the queue and prints them
            int[] printArray = new int[size];
            Node newTop = topNode;

            if (size < 1) return; 

            for(int i = 0; i < size; i++)
            {
                printArray[i] = newTop.value;
                newTop = newTop.next;
            }

            for (int i = 0; i < size; i++)
            {
                Console.Write(printArray[size - i - 1] + " ");
            }

            Console.WriteLine();
        }
    }
}
