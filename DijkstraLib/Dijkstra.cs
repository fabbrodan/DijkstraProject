using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DijkstraLib
{
    public static class Dijkstra
    {
        public static void DijkstraSearch(NodeMap nodeMap, Node startNode, Node targetNode)
        {
            if (startNode.Equals(targetNode))
            {
                return;
            }

            foreach (KeyValuePair<Node, int> connectedNode in startNode.ConnectedNodes.Where(n => n.Key.Visited == false))
            {
                if (startNode.CurrentCost + connectedNode.Value < connectedNode.Key.CurrentCost)
                {
                    connectedNode.Key.CurrentCost = startNode.CurrentCost + connectedNode.Value;
                }

                nodeMap.Nodes[nodeMap.Nodes.IndexOf(nodeMap.Nodes.Find(n => n.NodeName == connectedNode.Key.NodeName))] =
                    connectedNode.Key;
            }
            startNode.Visited = true;

            Node nextNode;

            int largestCheckedNodeValue = nodeMap.Nodes.Where(n => n.Visited == false).Where(n => n.CurrentCost < Int32.MaxValue).Max().CurrentCost;
            if (nodeMap.Nodes.Where(n => n.Visited == false && n.CurrentCost <= largestCheckedNodeValue).Count() > 0)
            {
                int min = nodeMap.Nodes.Where(n => n.Visited == false && n.CurrentCost <= largestCheckedNodeValue).Min().CurrentCost;
                nextNode = nodeMap.Nodes.Where(n => n.Visited == false && n.CurrentCost == min).First();
            }
            else
            {
                return;
            }

            DijkstraSearch(nodeMap, nextNode, targetNode);
        }
    }
}
