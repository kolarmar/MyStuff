using System;

namespace DataStructures
{
    internal class QueueAsNode<T>
    {
        private Node<T> topNode;
        private int size;

        public QueueAsNode()
        {
            topNode = null;
            size = 0;
        }

        public void Push(T item)
        {
            if (size > 0)
            {
                Node<T> newNode = new Node<T>(item, topNode);
                topNode = newNode;
                size++;
            }
            if (size == 0)
            {
                topNode = new Node<T>(item);
                size = 1;
            }
        }

        public void Pop()
        {
            if (size > 0) size--;
        }

        public T Peak()
        {
            if (size == 0) return default(T);

            Node<T> newTop = topNode;
            for(int i = 0; i < size - 1; i++)
            {
                newTop = newTop.child;
            }
            return newTop.data;
        }

        public void Print()
        {
            // Creates an array of values from the queue and prints them
            T[] printArray = new T[size];
            Node<T> newTop = topNode;

            if (size < 1) return; 

            for(int i = 0; i < size; i++)
            {
                printArray[i] = newTop.data;
                newTop = newTop.child;
            }

            for (int i = 0; i < size; i++)
            {
                Console.Write(printArray[size - i - 1] + " ");
            }

            Console.WriteLine();
        }
    }
}
