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

        public void Add(T item)
        {
            // Balanced adding

            if (root == null)
            {
                root = new TreeNode<T>(item);
                return;
            }

            TreeNode<T> nodeToAdd = new TreeNode<T>(item);
            QueueAsNode<TreeNode<T>> queue = new QueueAsNode<TreeNode<T>>();
            queue.Push(root);

            while(!queue.IsEmpty())
            {
                TreeNode<T> current = queue.Peak();
                queue.Pop();

                if (current.GetLeftChild() == null)
                {
                    current.SetLeftChild(nodeToAdd);
                    return;
                }
                if(current.GetRightChild() == null)
                {
                    current.SetRightChild(nodeToAdd);
                    return;
                }

                queue.Push(current.GetLeftChild());
                queue.Push(current.GetRightChild());
            }
        }

        public T[] DepthFirstValues()
        {
            StackAsNode<TreeNode<T>> stack = new StackAsNode<TreeNode<T>>();
            T[] values = new T[maxNodes];

            stack.Push(root);
            for(int i = 0; !stack.IsEmpty(); i++)
            {
                // Take the top node of the stack
                TreeNode<T> current = stack.Peak();
                stack.Pop();

                // Add the value of current to result array
                values[i] = current.GetData();

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

        public T[] BreadthFirstValues()
        {
            QueueAsNode<TreeNode<T>> queue = new QueueAsNode<TreeNode<T>>();
            T[] values = new T[maxNodes];

            queue.Push(root);
            for(int i = 0; !queue.IsEmpty(); i++)
            {
                TreeNode<T> current = queue.Peak();
                queue.Pop();

                values[i] = current.GetData();

                if(current.GetLeftChild() != null)
                {
                    queue.Push(current.GetLeftChild());
                }
                if(current.GetRightChild() != null)
                {
                    queue.Push(current.GetRightChild());
                }
            }

            return values;
        }

    }
}
