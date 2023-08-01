using System;

namespace DataStructures
{
    internal class StackAsNode<T>
    {
        private Node<T> topNode;
        private int size;

        public StackAsNode() 
        {
            topNode = null;
            size = 0;
        }

        public void Push(T item)
        {
            Node<T> newNode = new Node<T>(item, topNode);
            topNode = newNode;
            size++;
        }

        public void Pop()
        {
            if (topNode != null)
            {
                topNode = topNode.child;
                size--;
            }
        }

        public T Peak()
        {
            if (topNode != null) return topNode.data;

            else return default(T);
        }

        public bool IsEmpty()
        {
            return topNode == null;
        }

        public void Print()
        {
            // Creates a copy of topNode and iterates until the last node
            Node<T> newTop = topNode;

            for (int i = 0; i < size; i++)
            {
                Console.Write(newTop.data + " ");
                newTop = newTop.child;
            }

            Console.WriteLine();
        }

    }
}
