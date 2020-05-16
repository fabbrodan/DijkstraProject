using System;
using System.Collections.Generic;
using System.Drawing;

namespace DijkstraLib
{
    // Node map class, generates nodes according to prerequisites
    public class NodeMap
    {
        /// <summary>
        /// The Nodes available in the current NodeMap instance
        /// </summary>
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
        /// <summary>
        /// Generates a random NodeMap with <paramref name="NumberOfNodes"/> number of Nodes. Max Distance is set to 10
        /// </summary>
        /// <param name="NumberOfNodes">The amount of nodes the NodeMap will contain</param>
        public void GenerateRandomNodes(int NumberOfNodes)
        {
            Random random = new Random();
            Point p = new Point(random.Next(15, 150), random.Next(15, 150));
            for (int i = 0; i < NumberOfNodes; i++)
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
        /// <summary>
        /// Generates a random NodeMap with <paramref name="NumberOfNodes"/> number of Nodes. Max Distance is set to <paramref name="MaxDistance"/>
        /// </summary>
        /// <param name="NumberOfNodes">The number of Nodes the NodeMap will contain</param>
        /// <param name="MaxDistance">The maximum distance between the Nodes</param>
        public void GenerateRandomNodes(int NumberOfNodes, int MaxDistance)
        {
            Random random = new Random();
            List<Point> occupiedPositions = new List<Point>();
            for (int i = 0; i < NumberOfNodes; i++)
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
                    int distance = random.Next(1, MaxDistance + 1);
                    node.ConnectedNodes.AddLast(new KeyValuePair<Node, int>(Nodes[connectedNodeIndex], distance));
                    Nodes[connectedNodeIndex].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(node, distance));
                }
            }
        }

        /// <summary>
        /// Calculates if the point distance on an axis is outside the scope of <paramref name="threshold"/>
        /// </summary>
        /// <param name="threshold">The threshold which cannot be overridden</param>
        /// <param name="value1">Value 1 to compare</param>
        /// <param name="value2">Value 2 to compare</param>
        /// <returns></returns>
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
        /// <summary>
        /// Generates a random NodeMap with <paramref name="NumberOfNodes"/> number of Nodes. Max Distance is set to <paramref name="MaxDistance"/>
        /// </summary>
        /// <remarks>
        /// Used to generate Point references for each node in order to visually display them
        /// </remarks>
        /// <param name="NumberOfNodes">The numder of nodes the NodeMap will contain</param>
        /// <param name="MaxDistance">The maximum distance between nodes</param>
        /// <param name="Height">The height of the visual node</param>
        /// <param name="Width">Thw width of the visual node</param>
        public void GenerateRandomNodes(int NumberOfNodes, int MaxDistance, int Height, int Width)
        {
            Random random = new Random();
            List<Point> occupiedPositions = new List<Point>();
            for (int i = 0; i < NumberOfNodes; i++)
            {
                Point p = new Point();
                int x = random.Next(15, Width - 30);
                int y = random.Next(15, Height - 30);

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
                            x = random.Next(15, Width - 30);
                            y = random.Next(15, Height - 30);
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
                    int distance = random.Next(1, MaxDistance + 1);
                    node.ConnectedNodes.AddLast(new KeyValuePair<Node, int>(Nodes[connectedNodeIndex], distance));
                    Nodes[connectedNodeIndex].ConnectedNodes.AddLast(new KeyValuePair<Node, int>(node, distance));
                }
            }
        }
    }
}