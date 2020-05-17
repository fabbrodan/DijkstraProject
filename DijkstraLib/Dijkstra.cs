using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DijkstraLib
{
    // Static dijkstra class
    // algorithm for finding shortest path between nodes
    public class Dijkstra
    {
        private NodeMap nodeMap;
        public List<Node> NodePath = new List<Node>();
        private Node startNode;
        private Node endNode;
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
            if (startNode == null)
            {
                startNode = StartNode;
            }

            if (endNode == null)
            {
                endNode = TargetNode;
            }

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

        public void SetShortestPath()
        {
            NodePath.Add(endNode);

            List<Node> allKeys = (from kvp in endNode.ConnectedNodes select kvp.Key).Distinct().ToList();

            Node minNode = (from min in allKeys orderby min.CurrentCost ascending select min).First();

            NodePath.Add(minNode);

            SetShortestPath(minNode);
        }

        private void SetShortestPath(Node nextNode)
        {
            if (nextNode.CurrentCost == 0)
            {
                return;
            }

            List<Node> allKeys = (from kvp in nextNode.ConnectedNodes select kvp.Key).Distinct().ToList();

            Node minNode = (from min in allKeys orderby min.CurrentCost ascending select min).First();

            NodePath.Add(minNode);

            SetShortestPath(minNode);

        }
    }
}