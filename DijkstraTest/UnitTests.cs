using NUnit.Framework;
using DijkstraLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DijkstraTest
{
    public class DijkstraUnitTests
    {
        private NodeMap nodeMap;
        private Dijkstra dijkstra;

        [SetUp]
        public void Setup()
        {
            nodeMap = new NodeMap();
            string[] names = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
            foreach (string name in names)
            {
                nodeMap.Nodes.Add(new Node
                {
                    NodeName = name,
                    ConnectedNodes = new LinkedList<KeyValuePair<Node, int>>()
                });
            }

            // A
            nodeMap.Nodes[0].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(nodeMap.Nodes.Find(n => n.NodeName == "b"), 3));
            nodeMap.Nodes[0].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(nodeMap.Nodes.Find(n => n.NodeName == "c"), 2));
            nodeMap.Nodes[0].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(nodeMap.Nodes.Find(n => n.NodeName == "d"), 5));

            // B
            nodeMap.Nodes[1].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(nodeMap.Nodes.Find(n => n.NodeName == "a"), 3));
            nodeMap.Nodes[1].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(nodeMap.Nodes.Find(n => n.NodeName == "e"), 8));

            // C
            nodeMap.Nodes[2].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(nodeMap.Nodes.Find(n => n.NodeName == "a"), 2));
            nodeMap.Nodes[2].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(nodeMap.Nodes.Find(n => n.NodeName == "e"), 6));

            // D
            nodeMap.Nodes[3].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(nodeMap.Nodes.Find(n => n.NodeName == "a"), 5));
            nodeMap.Nodes[3].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(nodeMap.Nodes.Find(n => n.NodeName == "h"), 4));

            // E
            nodeMap.Nodes[4].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(nodeMap.Nodes.Find(n => n.NodeName == "b"), 8));
            nodeMap.Nodes[4].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(nodeMap.Nodes.Find(n => n.NodeName == "c"), 6));
            nodeMap.Nodes[4].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(nodeMap.Nodes.Find(n => n.NodeName == "f"), 1));
            nodeMap.Nodes[4].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(nodeMap.Nodes.Find(n => n.NodeName == "g"), 2));
            nodeMap.Nodes[4].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(nodeMap.Nodes.Find(n => n.NodeName == "h"), 5));
            nodeMap.Nodes[4].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(nodeMap.Nodes.Find(n => n.NodeName == "i"), 7));

            // F
            nodeMap.Nodes[5].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(nodeMap.Nodes.Find(n => n.NodeName == "e"), 1));
            nodeMap.Nodes[5].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(nodeMap.Nodes.Find(n => n.NodeName == "g"), 9));

            // G
            nodeMap.Nodes[6].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(nodeMap.Nodes.Find(n => n.NodeName == "e"), 2));
            nodeMap.Nodes[6].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(nodeMap.Nodes.Find(n => n.NodeName == "h"), 8));

            // H
            nodeMap.Nodes[7].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(nodeMap.Nodes.Find(n => n.NodeName == "d"), 4));
            nodeMap.Nodes[7].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(nodeMap.Nodes.Find(n => n.NodeName == "e"), 5));
            nodeMap.Nodes[7].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(nodeMap.Nodes.Find(n => n.NodeName == "g"), 8));
            nodeMap.Nodes[7].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(nodeMap.Nodes.Find(n => n.NodeName == "i"), 1));

            // I
            nodeMap.Nodes[8].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(nodeMap.Nodes.Find(n => n.NodeName == "e"), 7));
            nodeMap.Nodes[8].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(nodeMap.Nodes.Find(n => n.NodeName == "h"), 1));

            dijkstra = new Dijkstra(nodeMap);
        }

        [Test]
        public void TestSearchAlgorithm()
        {
            // Arrange
            Node startNode = nodeMap.Nodes.Find(n => n.NodeName == "f");
            Node targetNode = nodeMap.Nodes.Find(n => n.NodeName == "i");
            startNode.CurrentCost = 0;

            foreach (Node node in nodeMap.Nodes.Where(n => n.NodeName != startNode.NodeName))
            {
                node.CurrentCost = Int32.MaxValue;
            }


            // Act
            dijkstra.DijkstraSearch(startNode, targetNode);

            // Assert
            Assert.AreEqual(7, targetNode.CurrentCost);
        }

        [Test]
        public void TestRandomNodeMapGeneration()
        {
            // Arrange
            NodeMap nodeMap = new NodeMap();

            // Assert
            nodeMap.GenerateRandomNodes(10);

            // Act
            Assert.IsNotNull(nodeMap.Nodes);
        }

        [Test]
        public void TestNodeMapCount()
        {
            // Arrange
            NodeMap nodeMap = new NodeMap();

            // Act
            nodeMap.GenerateRandomNodes(10);

            // Assert
            Assert.IsTrue(nodeMap.Nodes.Count == 10);
        }

        [Test]
        public void TestNodeMapDistanceGeneration()
        {
            // Arrange
            NodeMap nodeMap = new NodeMap();

            // Act
            nodeMap.GenerateRandomNodes(10, 25);

            // Assert
            foreach (Node node in nodeMap.Nodes)
            {
                foreach (KeyValuePair<Node, int> edge in node.ConnectedNodes)
                {
                    Assert.IsFalse(edge.Value > 25);
                }
            }
        }
    }
}