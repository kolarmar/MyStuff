using System;

namespace DataStructures
{
    class QueueAsNode<T>
    {
        // This queue uses binary nodes to for a doubly linked list, 
        // left child is the direction from head to end,
        // right child is the direction from end to head.

        private BinaryNode<T> head;
        private BinaryNode<T> end;

        public QueueAsNode()
        {
            head = null;
            end = null;
            Size = 0;
        }

        public bool Empty => head == null;
        public int Size { get; private set; } = 0;

        public void Push(T item)
        {
            if (Empty)
            {
                head = end = new BinaryNode<T>(item);
            }
            else
            {
                BinaryNode<T> temp = new BinaryNode<T>(item, head);
                head.SetRightChild(temp);
                head = temp;
            }

            Size++;
        }

        public void Pop()
        {
            if (!Empty)
            {
                // Check if queue has only 1 element
                if (head == end)
                {
                    head = end = null;
                }
                else
                {
                    end = end.GetRightChild();
                    end.SetLeftChild(null);
                }
            }
        }

        public T Peak()
        {
            return end.GetData();
        }

        public void Print()
        {
            for(BinaryNode<T> newEnd = end; end != head; end = end.GetRightChild())
            {
                Console.Write(end.GetData().ToString() + " ");
            }

            Console.WriteLine();
        }
    }
}
