using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.TreeTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            int nodesCount = int.Parse(Console.ReadLine());

            var nodes = new Node<int>[nodesCount];

            for (var i = 0; i < nodesCount; i++ )
            {
                nodes[i] = new Node<int>(i);
            }

            for (var i = 0; i < nodesCount - 1; i++)
            {
                var connection = Console.ReadLine();
                var parentChildParts = connection.Split(' ');
                var parent = int.Parse(parentChildParts[0]);
                var child = int.Parse(parentChildParts[1]);

                nodes[parent].AddChild(nodes[child]);
            }

            //01. Find the root Node
            Node<int> rootNode = FindTheRootNode(nodes);
            Console.WriteLine("The root node is " + rootNode.Value);

            //02. Find all leaf nodes
            List<Node<int>> leafNodes = FindAllLeafNodes(nodes);
            Console.Write("Leafs : ");
            foreach (var leaf in leafNodes)
            {
                Console.Write(leaf.Value + " ");
            }
            Console.WriteLine();

            //03. Find all middle nodes
            List<Node<int>> middleNodes = FindAllMiddleNodes(nodes);
            Console.Write("Middles : ");
            foreach (var node in middleNodes)
            {
                Console.Write(node.Value + " ");
            }
            Console.WriteLine();
            
            //04. Find the longest path in the tree
            int longestPath = FindTheLongestPath(FindTheRootNode(nodes));
            Console.WriteLine("The Longest Path in the tree is " + longestPath);

            //05. Find all paths in the tree with given sum S of their nodes
            int sum = nodesCount - 1;
            

        }

        private static int FindTheLongestPath(Node<int> root)
        {
            if (root.Children.Count == 0)
            {
                return 0;
            }

            int maxPath = 0;

            foreach (var node in root.Children)
            {
                maxPath = Math.Max(maxPath, FindTheLongestPath(node));
            }

            return maxPath + 1;
        }

        private static List<Node<int>> FindAllMiddleNodes(Node<int>[] nodes)
        {
            var middles = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.HasParent && node.Children.Count > 0)
                {
                    middles.Add(node);
                }
            }

            return middles;
        }

        private static List<Node<int>> FindAllLeafNodes(Node<int>[] nodes)
        {
            var leafs = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.Children.Count == 0)
                {
                    leafs.Add(node);
                }
            }

            return leafs;
        }



        private static Node<int> FindTheRootNode(Node<int>[] nodes)
        {
            foreach(var node in nodes)
            {
                if (!node.HasParent)
                {
                    return node;
                }
            }

            throw new ArgumentException("The tree doesn't have a root node");
        }
    }
}
