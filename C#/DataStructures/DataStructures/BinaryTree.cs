using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class BinaryTree<T>
    {
        private TreeNode<T> root;
        private int maxNodes = 32;

        public BinaryTree()
        {
            root = null;
        }

        public T[] DepthFirstValues()
        {
            StackAsNode<TreeNode<T>> stack = new StackAsNode<TreeNode<T>>();
            T[] values = new T[maxNodes];

            stack.Push(root);
            while(!stack.IsEmpty())
            {
                // Take the top node of the stack
                TreeNode<T> current = stack.Peak();
                stack.Pop();

                // Add the value of current to result array
                values.Append<T>(current.GetData());

                // Push children of current to stack
                if(current.GetRightChild() != null)
                {
                    stack.Push(current.GetRightChild());
                }
                if(current.GetLeftChild() != null)
                {
                    stack.Push(current.GetLeftChild());
                }
            }

            return values;
        }

    }
}
