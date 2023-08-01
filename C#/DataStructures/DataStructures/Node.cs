namespace DataStructures
{
    internal class Node<T>
    {
        public T data;
        public Node<T> child;

        public Node(T _data, Node<T> _child = null)
        {
            this.data = _data;
            this.child = _child;
        }
    }
}
