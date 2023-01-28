using System;

namespace DataStructures
{
    internal class StackAsNode
    {
        private Node topNode;
        private int size;

        public StackAsNode(int iNum) 
        {
            topNode = new Node(iNum);
            size = 1;
        }

        public void Push(int iNum)
        {
            Node newNode = new Node(iNum, topNode);
            topNode = newNode;
            size++;
        }

        public void Pop()
        {
            if (topNode != null)
            {
                topNode = topNode.next;
                size--;
            }
        }

        public int Peak()
        {
            if (topNode != null) return topNode.value;

            else return -1;
        }

        public void Print()
        {
            // Creates a copy of topNode and iterates until the last node
            Node newTop = topNode;

            for (int i = 0; i < size; i++)
            {
                Console.Write(newTop.value + " ");
                newTop = newTop.next;
            }

            Console.WriteLine();
        }

    }
}
