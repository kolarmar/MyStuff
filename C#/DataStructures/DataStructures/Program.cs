using System;

namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<string> tree = new BinaryTree<string>();
            tree.Add("a");
            tree.Add("b");
            tree.Add("c");
            tree.Add("d");
            tree.Add("e");
            tree.Add("f");

            string[] list = tree.DepthFirstValues();

            foreach (string value in list)
            {
                Console.WriteLine(value);
            }
            


            Console.ReadLine();
        }
    }
}
