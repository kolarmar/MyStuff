using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class ListNode<T>
    {
        private T data;
        private ListNode<T> child;

        public ListNode(T _data)
        {
            SetData(_data);
            this.child = null;
        }

        public void SetData(T _data) { this.data = _data; }

        public void SetChild(ListNode<T> _child) { this.child = _child; }

        public T GetData() { return this.data; }

        public ListNode<T> GetChild() { return this.child; }

    }

    internal class List<T>
    {
        ListNode<T> head;

        public List()
        {
            head = null;
        }

        public void Add(T _data)
        {
            if (head == null)
            {
                head = new ListNode<T>(_data);
            }
            else
            {

                ListNode<T> prev = GetLast();

                prev.SetChild(new ListNode<T>(_data));
            }
        }
        public T Peak() => GetLast().GetData();

        public bool IsEmpty() => head == null;

        public ListNode<T> GetLast()
        {
            ListNode<T> p = head;
            ListNode<T> prev = null;
            while (p != null)
            {
                prev = p;
                p = p.GetChild();
            }
            return prev;
        }

        public bool Contains(T _data)
        {
            ListNode<T> p = head;
            while(p != null && !p.GetData().Equals(_data))
            {
                p = p.GetChild();
            }
            return p != null;
        }

    }
}
