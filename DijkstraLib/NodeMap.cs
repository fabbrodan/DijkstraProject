using System;
using System.Collections.Generic;
using System.Drawing;

namespace DijkstraLib
{
    // Node map class, generates nodes according to prerequisites
    public class NodeMap
    {
        public List<Node> Nodes;

        private string[] Letters =
        {
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U",
            "V", "W", "X", "Y", "Z"
        };

        public NodeMap()
        {
            Nodes = new List<Node>();
        }

        // Generate random nodes
        // All nodes will have two or three connections
        // distance/weight will be set to a random value between 1 and 10
        public void GenerateRandomNodes(int numberOfNodes)
        {
            Random random = new Random();
            Point p = new Point(random.Next(15, 150), random.Next(15, 150));
            for (int i = 0; i < numberOfNodes; i++)
            {
                Nodes.Add(new Node(Letters[i]));
            }

            // loop through all nodes
            for (int i = 0; i < Nodes.Count; i++)
            {
                int threshold = Nodes.Count > 3 ? 3 : 2;
                Node node = Nodes[i];
                List<int> usedIndices = new List<int>();

                // add new connections as long as connected nodes are fewer than threshold (2/3)
                while (node.ConnectedNodes.Count < threshold)
                {
                    int connectedNodeIndex = 0;
                    if (Nodes.Count > i + 1)
                    {
                        connectedNodeIndex = random.Next(i + 1, Nodes.Count);
                    }
                    else
                    {
                        connectedNodeIndex = random.Next(0, Nodes.Count);
                    }

                    // if index is already used, create a new index
                    while (usedIndices.Contains(connectedNodeIndex))
                    {
                        connectedNodeIndex = random.Next(0, Nodes.Count);
                    }

                    usedIndices.Add(connectedNodeIndex);
                    int distance = random.Next(1, random.Next(1, 11));
                    node.ConnectedNodes.AddLast(new KeyValuePair<Node, int>(Nodes[connectedNodeIndex], distance));
                    Nodes[connectedNodeIndex].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(node, distance));
                }
            }
        }

        // overload generate random nodes
        // distance/weight will be set to a random value between 1 and maxDistance
        public void GenerateRandomNodes(int numberOfNodes, int maxDistance)
        {
            Random random = new Random();
            List<Point> occupiedPositions = new List<Point>();
            for (int i = 0; i < numberOfNodes; i++)
            {
                Nodes.Add(new Node(Letters[i]));
            }

            // loop through all nodes
            for (int i = 0; i < Nodes.Count; i++)
            {
                int threshold = Nodes.Count > 3 ? 3 : 2;
                Node node = Nodes[i];
                List<int> usedIndices = new List<int>();

                // add new connections as long as connected nodes are fewer than threshold (2/3)
                while (node.ConnectedNodes.Count < threshold)
                {
                    int connectedNodeIndex = 0;
                    if (i + 1 < Nodes.Count)
                    {
                        connectedNodeIndex = random.Next(i + 1, Nodes.Count);
                    }
                    else
                    {
                        connectedNodeIndex = random.Next(0, Nodes.Count);
                    }

                    // if index is already used, create a new index
                    while (usedIndices.Contains(connectedNodeIndex))
                    {
                        connectedNodeIndex = random.Next(0, Nodes.Count);
                    }

                    usedIndices.Add(connectedNodeIndex);
                    int distance = random.Next(1, maxDistance + 1);
                    node.ConnectedNodes.AddLast(new KeyValuePair<Node, int>(Nodes[connectedNodeIndex], distance));
                    Nodes[connectedNodeIndex].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(node, distance));
                }
            }
        }

        
        private bool DistanceThreshold(int threshold, int value1, int value2)
        {
            int diff = value1 - value2;
            int lowerThreshold = -threshold;
            if (Math.Sign(diff) == 1)
            {
                if (diff > threshold)
                {
                    return true;
                }
            }

            else if (Math.Sign(diff) == -1)
            {
                if (diff < lowerThreshold)
                {
                    return true;
                }
            }

            return false;
        }

        // overload generate random nodes
        // distance/weight will be set to a random value between 1 and maxDistance
        // calculate all node positions based on height and width
        public void GenerateRandomNodes(int numberOfNodes, int maxDistance, int height, int width)
        {
            Random random = new Random();
            List<Point> occupiedPositions = new List<Point>();
            for (int i = 0; i < numberOfNodes; i++)
            {
                Point p = new Point();
                int x = random.Next(15, width - 30);
                int y = random.Next(15, height - 30);

                if (i == 0)
                {
                    p = new Point(x, y);
                }
                else
                {
                    foreach (Point pt in occupiedPositions)
                    {
                        while ((!DistanceThreshold(50, x, pt.X)) && (!DistanceThreshold(50, y, pt.Y)))
                        {
                            x = random.Next(15, width - 30);
                            y = random.Next(15, height - 30);
                        }

                        p = new Point(x, y);
                    }
                }

                Nodes.Add(new Node(Letters[i], p));
                occupiedPositions.Add(p);
            }

            // loop through all nodes
            for (int i = 0; i < Nodes.Count; i++)
            {
                int threshold = Nodes.Count > 3 ? 3 : 2;
                Node node = Nodes[i];
                List<int> usedIndices = new List<int>();
                
                // add new connections as long as connected nodes are fewer than threshold (2/3)
                while (node.ConnectedNodes.Count < threshold)
                {
                    int connectedNodeIndex = 0;
                    if (i + 1 < Nodes.Count)
                    {
                        connectedNodeIndex = random.Next(i + 1, Nodes.Count);
                    }
                    else
                    {
                        connectedNodeIndex = random.Next(0, Nodes.Count);
                    }

                    // if index is already used, create a new index
                    while (usedIndices.Contains(connectedNodeIndex))
                    {
                        connectedNodeIndex = random.Next(0, Nodes.Count);
                    }

                    usedIndices.Add(connectedNodeIndex);
                    int distance = random.Next(1, maxDistance + 1);
                    node.ConnectedNodes.AddLast(new KeyValuePair<Node, int>(Nodes[connectedNodeIndex], distance));
                    Nodes[connectedNodeIndex].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(node, distance));
                }
            }
        }
    }
}