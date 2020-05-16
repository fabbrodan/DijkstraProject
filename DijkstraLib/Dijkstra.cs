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
        /// Method to calculate the shortest path from <paramref name="StartNode"/> to <paramref name="TargetNode"/> in the specified <paramref name="NodeMap"/>
        /// </summary>
        /// <param name="NodeMap">The <see cref="NodeMap"/> to search in</param>
        /// <param name="StartNode">The <see cref="Node"/> to start at</param>
        /// <param name="TargetNode">The <see cref="Node"/> to travel to</param>
        public static void DijkstraSearch(NodeMap NodeMap, Node StartNode, Node TargetNode)
        {
            // if start node is same as target node
            if (StartNode.Equals(TargetNode))
            {
                return;
            }

            // loop through all connected nodes who hasn't been visited
            foreach (KeyValuePair<Node, int> connectedNode in StartNode.ConnectedNodes.Where(
                n => n.Key.Visited == false))
            {
                // if
                if (StartNode.CurrentCost + connectedNode.Value < connectedNode.Key.CurrentCost)
                {
                    connectedNode.Key.CurrentCost = StartNode.CurrentCost + connectedNode.Value;
                }

                int index = NodeMap.Nodes.IndexOf(NodeMap.Nodes.Find(n => n.NodeName == connectedNode.Key.NodeName));
                NodeMap.Nodes[index] = connectedNode.Key;
            }

            StartNode.Visited = true;

            Node nextNode;

            int largestCheckedNodeValue = NodeMap.Nodes.Where(n => n.Visited == false)
                .Where(n => n.CurrentCost < Int32.MaxValue).Max().CurrentCost;
            if (NodeMap.Nodes.Where(n => n.Visited == false && n.CurrentCost <= largestCheckedNodeValue).Count() > 0)
            {
                int min = NodeMap.Nodes.Where(n => n.Visited == false && n.CurrentCost <= largestCheckedNodeValue).Min()
                    .CurrentCost;
                nextNode = NodeMap.Nodes.First(n => n.Visited == false && n.CurrentCost == min);
            }
            else
            {
                return;
            }

            DijkstraSearch(NodeMap, nextNode, TargetNode);
            
        }
    }
}