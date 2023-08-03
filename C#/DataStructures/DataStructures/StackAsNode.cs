using System;

namespace DataStructures
{
    class StackAsNode<T>
    {
        private Node<T> head;

        public StackAsNode() 
        {
            head = null;
            Size = 0;
        }

        public bool Empty => head == null;
        public int Size { get; private set; } = 0;

        public void Push(T item)
        {
            head = new Node<T>(item, head);
            Size++;
        }

        public void Pop()
        {
            if (!Empty)
            {
                head = head.GetChild();
                Size--;
            }
        }

        public T Peak()
        {
            if (!Empty)
            {
                return head.GetData();
            }

            else throw new InvalidOperationException("Cannot peak at stack when empty.");
        }

        public void Print()
        {
            // Creates a copy and iterates until the last node
            Node<T> newHead = head;

            for (int i = 0; i < Size; i++)
            {
                Console.Write(newHead.GetData() + " ");
                newHead = newHead.GetChild();
            }

            Console.WriteLine();
        }

    }
}
