using NUnit.Framework;
using DijkstraLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DijkstraTest
{
    class DijkstraIntegrationsTests
    {
        [Test]
        public void TestMapGenerationAndSearch()
        {
            // Arrange NodeMap
            NodeMap nodeMap = new NodeMap();
            
            // Act NodeMap
            nodeMap.GenerateRandomNodes(10);

            // Assert NodeMap
            Assert.IsTrue(nodeMap.Nodes.Count == 10);
            foreach (Node node in nodeMap.Nodes)
            {
                foreach (KeyValuePair<Node, int> edge in node.ConnectedNodes)
                {
                    Assert.IsFalse(edge.Value > 10);
                }
            }

            // Arrange Dijkstra
            Node startNode = nodeMap.Nodes.Find(n => n.NodeName == "A");
            Node endNode = new Node("K");
            nodeMap.Nodes.Add(endNode);
            KeyValuePair<Node, int> kvp = new KeyValuePair<Node, int>(endNode, 1);

            startNode.ConnectedNodes.AddLast(kvp);

            startNode.CurrentCost = 0;

            foreach (Node node in nodeMap.Nodes)
            {
                if (!node.Equals(startNode))
                {
                    node.CurrentCost = Int32.MaxValue;
                }
            }

            // Act Dijkstra
            Dijkstra.DijkstraSearch(nodeMap, startNode, endNode);

            // ASsert Dijkstra
            Assert.AreEqual(1, endNode.CurrentCost);

        }
    }
}
