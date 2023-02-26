using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class TreeNode
    {
        public int value;
        public TreeNode leftChild, rightChild;

        public TreeNode(int value, TreeNode leftChild = null, TreeNode rightChild = null)
        {
            this.value = value;
            this.leftChild = leftChild;
            this.rightChild = rightChild;
        }
    }
}
