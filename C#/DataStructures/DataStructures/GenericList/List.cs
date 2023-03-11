using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class List<T> : IEnumerable<T>
    {
        private class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }

            public Node(T data = default(T), Node next = null)
            {
                (Data, Next) = (data, next);
            }
        }

        private Node head = null;
        private Node end = null;

        private class Enumerator : IEnumerator<T>
        {
            List<T> list = null;
            public Node CurrentNode { get; set; } = null;
            public Enumerator(List<T> list, Node currentNode = null)
            {
                (this.list, this.CurrentNode) = (list, currentNode);
            }

            public T Current => CurrentNode.Data;
            object IEnumerator.Current => CurrentNode.Data;

            public void Dispose() { }

            public bool MoveNext()
            {
                if (list.Empty || Last)
                {
                    return false;
                }
                CurrentNode = (CurrentNode == null) ? list.head : CurrentNode.Next;
                return true;
            }

            public void Reset() => CurrentNode = null;
            public bool Last => (CurrentNode != null) && (CurrentNode.Next == list.end);

            public override bool Equals(object obj)
            {
                var enumerator = obj as Enumerator;
                return (enumerator != null) && (list == enumerator.list)
                && (CurrentNode == enumerator.CurrentNode);
            }

            public static readonly Enumerator ForNull = new Enumerator(null);
        }


        // Construtors
        public List() => head = end = new Node();
        public List(IEnumerable<T> collection) : this()
        {
            foreach (var item in collection)
            {
                AddToEnd(item);
            }
        }
        public List(params T[] array) : this((IEnumerable<T>)array) { }


        // Attributes
        public bool Empty => head == end;
        public int Size { get; private set; } = 0;


        // Methods
        public void AddToStart(T item)
        {
            head = new Node(item, head);
            Size++;
        }

        public void AddToEnd(T item)
        {
            end.Data = item;
            end.Next = new Node();
            end = end.Next;
            Size++;
        }

        public void ClearFromStart()
        {
            if (Empty) throw new InvalidOperationException(
                "Cannot clear first element when list is empty");

            head = head.Next;
            Size--;
        }

        public void ClearAll()
        {
            head = end;
            Size = 0;
        }

        public bool Find(T search, out IEnumerator<T> enumerator)
        {
            enumerator = Enumerator.ForNull;

            if (Empty) return false;

            for (var item = head; item != end; item = item.Next)
            {
                if (item.Data.Equals(search))
                {
                    enumerator = new Enumerator(this, item);
                    return true;
                }
            }
            return false;
        }

        public void ChangeValue(IEnumerator<T> pointOnItem, T newValue)
        {
            ((Enumerator)pointOnItem).CurrentNode.Data = newValue;
        }

        public void PutBehind(IEnumerator<T> pointOnItem, T newValue)
        {
            Node item = ((Enumerator)pointOnItem).CurrentNode;
            item.Next = new Node(newValue);
            Size++;
        }

        public void ClearNode(IEnumerator<T> pointOnItem)
        {
            Node deletedItem = ((Enumerator)pointOnItem).CurrentNode;

            if (deletedItem == head)
            {
                head = head.Next;
            }
            else if (((Enumerator)pointOnItem).Last)
            {
                end = deletedItem;
                end.Next = null;
            }
            else
            {
                deletedItem.Data = deletedItem.Next.Data;
                deletedItem.Next = deletedItem.Next.Next;
            }

            Size--;
        }

        public IEnumerator<T> GetEnumerator() => new Enumerator(this);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
