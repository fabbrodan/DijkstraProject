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

            foreach (Node node in Nodes)
            {
                for (int i = 0; i < Nodes.Count; i++)
                {
                    int decider = random.Next(0, 15);
                    int NodeIndex = i + 1;
                    if (decider % 2 == 0)
                    {
                        if (NodeIndex >= Nodes.Count)
                        {
                            NodeIndex = i - 1;
                        }
                        node.ConnectedNodes.AddLast(new KeyValuePair<Node, int>(Nodes[NodeIndex], random.Next(1, 15)));
                    }
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

            foreach (Node node in Nodes)
            {
                for (int i = 0; i < Nodes.Count; i++)
                {
                    int decider = random.Next(0, 15);
                    int NodeIndex = i + 1;
                    if (decider % 2 == 0)
                    {
                        if (NodeIndex >= Nodes.Count)
                        {
                            NodeIndex = i - 1;
                        }
                        node.ConnectedNodes.AddLast(new KeyValuePair<Node, int>(Nodes[NodeIndex], random.Next(1, MaxDistance)));
                    }
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
                int x = random.Next(15, 150);
                int y = random.Next(15, 150);
                
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
                            x = random.Next(15, Width - 15);
                            y = random.Next(15, Height - 15);
                        }
                        p = new Point(x, y);
                    }
                }

                Nodes.Add(new Node(Letters[i], p));
                OccupiedPositions.Add(p);
            }

            foreach (Node node in Nodes)
            {
                for (int i = 0; i < Nodes.Count; i++)
                {
                    int decider = random.Next(0, 15);
                    int NodeIndex = i + 1;
                    if (decider % 2 == 0)
                    {
                        if (NodeIndex >= Nodes.Count)
                        {
                            NodeIndex = i - 1;
                        }
                        node.ConnectedNodes.AddLast(new KeyValuePair<Node, int>(Nodes[NodeIndex], random.Next(1, MaxDistance)));
                    }
                }
            }
        }
    }
}
