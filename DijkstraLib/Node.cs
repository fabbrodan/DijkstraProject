using System;
using System.Collections.Generic;
using System.Text;

namespace DijkstraLib
{
    public class Node : IComparable
    {
        public int CurrentCost { get; set; }
        public bool Visited { get; set; } = false;
        public string NodeName;
        public LinkedList<KeyValuePair<Node, int>> ConnectedNodes;
        public Point Position;

        public Node()
        {
            ConnectedNodes = new LinkedList<KeyValuePair<Node, int>>();
        }
        public Node(string NodeName)
        {
            this.NodeName = NodeName;
            ConnectedNodes = new LinkedList<KeyValuePair<Node, int>>();
        }
        public Node(string NodeName, Point Position)
        {
            this.NodeName = NodeName;
            this.Position = Position;
            ConnectedNodes = new LinkedList<KeyValuePair<Node, int>>();
        }
        public Node(Point Position)
        {
            this.Position = Position;
            ConnectedNodes = new LinkedList<KeyValuePair<Node, int>>();
        }
        public int CompareTo(object obj)
        {
            if (obj is Node n)
            {
                return CurrentCost.CompareTo(n.CurrentCost);
            }
            return -1;
        }

        public override bool Equals(object obj)
        {
            if (obj is Node n)
            {
                if (n.NodeName == NodeName && ConnectedNodes.Equals(n.ConnectedNodes))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
