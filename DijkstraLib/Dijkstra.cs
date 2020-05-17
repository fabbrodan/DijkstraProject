using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DijkstraLib
{
    // Static dijkstra class
    // algorithm for finding shortest path between nodes
    public class Dijkstra
    {
        private NodeMap nodeMap;
        /// <summary>
        /// Creates a new instance of the Dijkstra class
        /// </summary>
        /// <param name="NodeMap">The <see cref="NodeMap"/> that belongs to this instance</param>
        public Dijkstra(NodeMap NodeMap)
        {
            nodeMap = NodeMap;
        }

        /// <summary>
        /// Method to calculate the shortest path from <paramref name="StartNode"/> to <paramref name="TargetNode"/> in the specified <paramref name="NodeMap"/>
        /// </summary>
        /// <param name="NodeMap">The <see cref="NodeMap"/> to search in</param>
        /// <param name="StartNode">The <see cref="Node"/> to start at</param>
        /// <param name="TargetNode">The <see cref="Node"/> to travel to</param>
        public void DijkstraSearch(Node StartNode, Node TargetNode)
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
            }

            StartNode.Visited = true;

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

            DijkstraSearch(nextNode, TargetNode);
            
        }
    }
}