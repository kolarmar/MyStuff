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

            //string[] list = tree.DepthFirstValues();

            //foreach (string value in list)
            //{
            //    Console.WriteLine(value);
            //}
            
            BinaryNode<string> binNode = new BinaryNode<string>("a");
            Node<string> node = new Node<string>("xd", binNode);
            Console.WriteLine(node.GetChild());

            Console.ReadLine();
        }
    }
}
