using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DijkstraLib;

namespace DijkstraProject
{
    class Program
    {
        static void Main(string[] args)
        {
            NodeMap map = new NodeMap();
            string[] names = new string[] { "a", "b", "c", "d", "e" };
            foreach (string name in names)
            {
                map.Nodes.Add(new Node
                {
                    NodeName = name,
                    ConnectedNodes = new LinkedList<KeyValuePair<Node, int>>()
                });
            }

            // A
            map.Nodes[0].ConnectedNodes.AddFirst(new KeyValuePair<Node, int>(map.Nodes.Find(n => n.NodeName == "b"), 3));
            map.Nodes[0].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(map.Nodes.Find(n => n.NodeName == "c"), 1));

            // B
            map.Nodes[1].ConnectedNodes.AddFirst(new KeyValuePair<Node, int>(map.Nodes.Find( n => n.NodeName == "a"), 3));
            map.Nodes[1].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(map.Nodes.Find(n => n.NodeName == "c"), 7));
            map.Nodes[1].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(map.Nodes.Find(n => n.NodeName == "d"), 5));
            map.Nodes[1].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(map.Nodes.Find(n => n.NodeName == "e"), 1));

            // C
            map.Nodes[2].ConnectedNodes.AddFirst(new KeyValuePair<Node, int>(map.Nodes.Find(n => n.NodeName == "a"), 1));
            map.Nodes[2].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(map.Nodes.Find(n => n.NodeName == "b"), 7));
            map.Nodes[2].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(map.Nodes.Find(n => n.NodeName == "d"), 2));

            // D
            map.Nodes[3].ConnectedNodes.AddFirst(new KeyValuePair<Node, int>(map.Nodes.Find(n => n.NodeName == "b"), 5));
            map.Nodes[3].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(map.Nodes.Find(n => n.NodeName == "c"), 2));
            map.Nodes[3].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(map.Nodes.Find(n => n.NodeName == "e"), 7));

            // E
            map.Nodes[4].ConnectedNodes.AddFirst(new KeyValuePair<Node, int>(map.Nodes.Find(n => n.NodeName == "b"), 1));
            map.Nodes[4].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(map.Nodes.Find(n => n.NodeName == "d"), 7));

            Node startNode = map.Nodes[3];
            Node targetNode = map.Nodes[4];
            startNode.CurrentCost = 0;

            foreach (Node node in map.Nodes.Where(n => n.NodeName != startNode.NodeName))
            {
                node.CurrentCost = Int32.MaxValue;
            }

            Dijkstra dijkstra = new Dijkstra(map);

            dijkstra.DijkstraSearch(startNode, targetNode);

            Console.WriteLine("The shortest distance from node " + startNode.NodeName + " to node " + targetNode.NodeName + " is " + targetNode.CurrentCost);

            Console.ReadLine();
        }
    }
}
