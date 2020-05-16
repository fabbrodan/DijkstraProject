using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DijkstraLib
{
    // Static dijkstra class
    // algorithm for finding shortest path between nodes
    public static class Dijkstra
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeMap"></param>
        /// <param name="startNode"></param>
        /// <param name="targetNode"></param>
        public static void DijkstraSearch(NodeMap nodeMap, Node startNode, Node targetNode)
        {
            // if start node is same as target node
            if (startNode.Equals(targetNode))
            {
                return;
            }

            // loop through all connected nodes who hasn't been visited
            foreach (KeyValuePair<Node, int> connectedNode in startNode.ConnectedNodes.Where(
                n => n.Key.Visited == false))
            {
                // if
                if (startNode.CurrentCost + connectedNode.Value < connectedNode.Key.CurrentCost)
                {
                    connectedNode.Key.CurrentCost = startNode.CurrentCost + connectedNode.Value;
                }

                int index = nodeMap.Nodes.IndexOf(nodeMap.Nodes.Find(n => n.NodeName == connectedNode.Key.NodeName));
                nodeMap.Nodes[index] = connectedNode.Key;
            }

            startNode.Visited = true;

            Node nextNode;

            int largestCheckedNodeValue = nodeMap.Nodes.Where(n => n.Visited == false)
                .Where(n => n.CurrentCost < Int32.MaxValue).Max().CurrentCost;
            if (nodeMap.Nodes.Where(n => n.Visited == false && n.CurrentCost <= largestCheckedNodeValue).Count() > 0)
            {
                int min = nodeMap.Nodes.Where(n => n.Visited == false && n.CurrentCost <= largestCheckedNodeValue).Min()
                    .CurrentCost;
                nextNode = nodeMap.Nodes.First(n => n.Visited == false && n.CurrentCost == min);
            }
            else
            {
                return;
            }

            DijkstraSearch(nodeMap, nextNode, targetNode);
            
        }
    }
}