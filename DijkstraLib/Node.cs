using System;
using System.Collections.Generic;
using System.Drawing;

namespace DijkstraLib
{
    // Node class
    public class Node : IComparable
    {
        public int CurrentCost { get; set; }
        public bool Visited { get; set; } = false;
        public string NodeName;
        public LinkedList<KeyValuePair<Node, int>> ConnectedNodes;
        public Point Pos;

        // base constructor
        public Node()
        {
            ConnectedNodes = new LinkedList<KeyValuePair<Node, int>>();
        }
        // constructor with node name
        public Node(string nodeName)
        {
            this.NodeName = nodeName;
            ConnectedNodes = new LinkedList<KeyValuePair<Node, int>>();
        }
        // constructor with node name and node position
        public Node(string nodeName, Point pos)
        {
            this.NodeName = nodeName;
            this.Pos = pos;
            ConnectedNodes = new LinkedList<KeyValuePair<Node, int>>();
        }
        // constructor with node position
        public Node(Point pos)
        {
            this.Pos = pos;
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
