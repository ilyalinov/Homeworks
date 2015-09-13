using System;
using System.IO;
    
namespace TreeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            TextReader textReader = new StreamReader(@"Text.txt");
            string buffer = textReader.ReadLine();
            BinaryTree binaryTree = new BinaryTree(buffer);
            Console.WriteLine("Result: " + binaryTree.Count());
            binaryTree.PrintTree();
        }
    }
}
