using System;
using System.Collections.Generic;
using System.Text;

namespace DijkstraLib
{
    public class NodeMap
    {
        public List<Node> Nodes;
        private string[] Letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        public NodeMap()
        {
            Nodes = new List<Node>();
        }

        public void GenerateRandomNodes(int NumberOfNodes)
        {
            Random random = new Random();
            Point p = new Point(random.Next(15, 150), random.Next(15, 150));
            for (int i = 0; i < NumberOfNodes; i++)
            {
                Nodes.Add(new Node(Letters[i], p));
            }

            for (int i = 0; i < Nodes.Count; i++)
            {
                int threshold = Nodes.Count > 3 ? 3 : 2;
                Node node = Nodes[i];
                List<int> usedIndices = new List<int>();
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

        public void GenerateRandomNodes(int NumberOfNodes, int MaxDistance)
        {
            Random random = new Random();
            List<Point> OccupiedPOsitions = new List<Point>();
            for (int i = 0; i < NumberOfNodes; i++)
            {
                Point p = new Point(random.Next(15, 150), random.Next(15, 150));
                Nodes.Add(new Node(Letters[i], p));
            }

            for (int i = 0; i < Nodes.Count; i++)
            {
                int threshold = Nodes.Count > 3 ? 3 : 2;
                Node node = Nodes[i];
                List<int> usedIndices = new List<int>();
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

        private bool DistanceThreshold(int Threshold, int Value1, int Value2)
        {
            int diff = Value1 - Value2;
            int lowerThreshold = -Threshold;
            if (Math.Sign(diff) == 1)
            {
                if (diff > Threshold)
                {
                    return true;
                }
            }

            if (Math.Sign(diff) == -1)
            {
                if (diff < lowerThreshold)
                {
                    return true;
                }
            }

            return false;
        }
        public void GenerateRandomNodes(int NumberOfNodes, int MaxDistance, int Height, int Width)
        {
            Random random = new Random();
            List<Point> OccupiedPositions = new List<Point>();
            for (int i = 0; i < NumberOfNodes; i++)
            {
                Point p = null;
                int x = random.Next(15, Width - 30);
                int y = random.Next(15, Height - 30);
                
                if (i == 0)
                {
                    p = new Point(x, y);
                }
                else
                {
                    foreach (Point pt in OccupiedPositions)
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
                OccupiedPositions.Add(p);
            }

            for (int i = 0; i < Nodes.Count; i++)
            {
                int threshold = Nodes.Count > 3 ? 3 : 2;
                Node node = Nodes[i];
                List<int> usedIndices = new List<int>();
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
