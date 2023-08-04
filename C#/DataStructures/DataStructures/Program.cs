using System;

namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BinaryTree<string> tree = new BinaryTree<string>();
            //tree.Add("a");
            //tree.Add("b");
            //tree.Add("c");
            //tree.Add("d");
            //tree.Add("e");
            //tree.Add("f");

            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Add(2);
            tree.Add(3);
            tree.Add(4);
            tree.Add(5);
            tree.Add(-15);

            Console.WriteLine(tree.IntegerMin());

            Console.ReadLine();
        }
    }
}
