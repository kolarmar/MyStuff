using System.Collections;
using System.Diagnostics;
using System.Diagnostics.Contracts;

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

        public void CleanFromStart()
        {
            if(Empty) throw new InvalidOperationException(
                "Cannot clean first element when list is empty");

            head = head.Next;
            Size--;
        }

        public void Clean()
        {
            head = end;
            Size = 0;
        }

        public IEnumerator<T> GetEnumerator() => new Enumerator(this);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    internal class Program
    {
        private static void Print<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            List<int> list= new List<int>(1,2,3,4,5);

            list.AddToStart(0);
            list.AddToEnd(6);

            Print<int>(list);

        }
    }
}