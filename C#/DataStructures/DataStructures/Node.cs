namespace DataStructures
{
    public abstract class BaseNode<T>
    {
        protected T data;

        public void SetData(T _data)
        {
            this.data = _data;
        }
        
        public T GetData()
        {
            return this.data;
        }
    }

    public class Node<T> : BaseNode<T>
    {
        private Node<T> child;

        public Node(T _data = default(T), BaseNode<T> _child = null)
        {
            SetData(_data);
            SetChild((Node<T>)_child);
        }

        public void SetChild(Node<T> _child)
        {
            this.child = _child;
        }

        public Node<T> GetChild()
        {
            return this.child;
        }
    }

    public class BinaryNode<T> : BaseNode<T>
    {
        private BinaryNode<T> childLeft;
        private BinaryNode<T> childRight;

        public BinaryNode(T _data = default(T), BaseNode<T> _childLeft = null, BaseNode<T> _childRight = null)
        {
            SetData(_data);
            SetLeftChild((BinaryNode<T>)_childLeft);
            SetRightChild((BinaryNode<T>)_childRight);
        }

        public void SetLeftChild(BinaryNode<T> _child)
        {
            this.childLeft = _child;
        }

        public void SetRightChild(BinaryNode<T> _child)
        {
            this.childRight = _child;
        }

        public BinaryNode<T> GetLeftChild()
        {
            return this.childLeft;
        }

        public BinaryNode<T> GetRightChild()
        {
            return this.childRight;
        }
    }
}
