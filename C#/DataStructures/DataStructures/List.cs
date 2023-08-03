using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    class List<T> : IEnumerable<T>
    {
        private Node<T> head = null;
        private Node<T> end = null;

        private class Enumerator : IEnumerator<T>
        {
            List<T> list = null;
            public Node<T> CurrentNode { get; set; } = null;
            public Enumerator(List<T> list, Node<T> currentNode = null)
            {
                (this.list, this.CurrentNode) = (list, currentNode);
            }

            public T Current => CurrentNode.GetData();
            object IEnumerator.Current => CurrentNode.GetData();

            public void Dispose() { }

            public bool MoveNext()
            {
                if (list.Empty || Last)
                {
                    return false;
                }
                CurrentNode = (CurrentNode == null) ? list.head : CurrentNode.GetChild();
                return true;
            }

            public void Reset() => CurrentNode = null;
            public bool Last => (CurrentNode != null) && (CurrentNode.GetChild() == list.end);

            public override bool Equals(object obj)
            {
                var enumerator = obj as Enumerator;
                return (enumerator != null) && (list == enumerator.list)
                && (CurrentNode == enumerator.CurrentNode);
            }

            public static readonly Enumerator ForNull = new Enumerator(null);
        }


        // Construtors
        public List() => head = end = new Node<T>();
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
            head = new Node<T>(item, head);
            Size++;
        }

        public void AddToEnd(T item)
        {
            end.SetData(item);
            end.SetChild(new Node<T>());
            end = end.GetChild();
            Size++;
        }

        public void ClearFromStart()
        {
            if (Empty) throw new InvalidOperationException(
                "Cannot clear first element when list is empty");

            head = head.GetChild();
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

            for (var item = head; item != end; item = item.GetChild())
            {
                if (item.GetData().Equals(search))
                {
                    enumerator = new Enumerator(this, item);
                    return true;
                }
            }
            return false;
        }

        public void ChangeValue(IEnumerator<T> pointOnItem, T newValue)
        {
            ((Enumerator)pointOnItem).CurrentNode.SetData(newValue);
        }

        public void PutBehind(IEnumerator<T> pointOnItem, T newValue)
        {
            Node<T> item = ((Enumerator)pointOnItem).CurrentNode;
            item.SetChild(new Node<T>(newValue));
            Size++;
        }

        public void ClearNode(IEnumerator<T> pointOnItem)
        {
            Node<T> deletedItem = ((Enumerator)pointOnItem).CurrentNode;

            if (deletedItem == head)
            {
                head = head.GetChild();
            }
            else if (((Enumerator)pointOnItem).Last)
            {
                end = deletedItem;
                end.SetChild(null);
            }
            else
            {
                deletedItem.SetData(deletedItem.GetChild().GetData());
                deletedItem.SetChild(deletedItem.GetChild().GetChild());
            }

            Size--;
        }

        public IEnumerator<T> GetEnumerator() => new Enumerator(this);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
