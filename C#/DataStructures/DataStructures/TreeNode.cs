using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class TreeNode<T>
    {
        private T data;
        private TreeNode<T> leftChild, rightChild;

        public TreeNode(T _data)
        {
            SetData(_data);
            leftChild = null;
            rightChild = null;
        }

        public void SetData(T _data) { this.data = _data; }
        public T GetData() { return this.data; }
        public void SetLeftChild(TreeNode<T> _child) { this.leftChild = _child;}
        public void SetRightChild(TreeNode<T> _child) { this.rightChild = _child;}
        public TreeNode<T> GetLeftChild() {  return this.leftChild; }
        public TreeNode<T> GetRightChild() {  return this.rightChild; }

    }
}
