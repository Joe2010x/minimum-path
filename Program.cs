using System;
using System.Collections.Generic;

namespace MyApp;
    public class Program
    {
        static void Main(string[] args)
        {
            var LR = new Node(null, null, 2);
            var L = new Node(null, LR, 5);
            var RRL = new Node(null, null, -1);
            var RR = new Node(RRL, null, 1);
            var R = new Node(null, RR, 5);
            var Head = new Node(L, R, 10);

            var allPathValues = new List<List<int>>();
            Calculate(Head, new List<int>(), allPathValues);
            Console.WriteLine("Minimal Path value is "+ allPathValues.Select(p=> p.Sum()).Min());
        }

        private static void Calculate(Node current, List<int> currentPath, List<List<int>> allPaths)
        {
            if (current == null)
            {
                return;
            }

            // Add the current node's value to the current path
            currentPath.Add(current.Value);

            // If it's a leaf node, add the current path to the list of all paths
            if (current.Left == null && current.Right == null)
            {
                allPaths.Add(new List<int>(currentPath));
                Console.WriteLine($"End of path: {string.Join(", ", currentPath)}");
            }
            else
            {
                // Traverse the left subtree
                if (current.Left != null)
                {
                    Calculate(current.Left, new List<int>(currentPath), allPaths);
                }

                // Traverse the right subtree
                if (current.Right != null)
                {
                    Calculate(current.Right, new List<int>(currentPath), allPaths);
                }
            }
        }
    }

    public class Node
    {
        public Node? Left { get; set; }
        public Node? Right { get; set; }
        public int Value { get; set; }

        public Node(Node? left, Node? right, int value)
        {
            Left = left;
            Right = right;
            Value = value;
        }
    }

