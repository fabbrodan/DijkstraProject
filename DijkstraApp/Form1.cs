using System;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DijkstraLib;

namespace DijkstraApp
{
    public partial class Form1 : Form
    {
        private NodeMap NodeMap = new NodeMap();
        private Color[] colors = { Color.Red, Color.Blue, Color.Green, Color.Cyan, Color.Yellow, Color.BlueViolet };
        private List<KeyValuePair<string, GraphicsPath>> gpList = new List<KeyValuePair<string, GraphicsPath>>();
        private Node startNode;
        private Node endNode;
        public Form1()
        {
            InitializeComponent();
            nodeCount_tb.Text = "3";
        }

        private void panel1_mouseMove(object sender, MouseEventArgs e)
        {
            foreach (KeyValuePair<string, GraphicsPath> kvp in gpList)
            {
                if (kvp.Value.IsVisible(new System.Drawing.Point(e.X, e.Y)))
                {
                    StringBuilder sb = new StringBuilder("Node " + kvp.Key + "\nConnected Nodes:\n");

                    foreach (KeyValuePair<Node, int> connectedNode in NodeMap.Nodes.Find(n => n.NodeName == kvp.Key).ConnectedNodes)
                    {
                        sb.Append(connectedNode.Key.NodeName + " - Weight: " + connectedNode.Value + "\n");
                    }

                    nodeToolTip.Show(sb.ToString(), panel1, e.X + 10, e.Y + 10, 2500);
                }
            }
        }

        private void panel_click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            System.Drawing.Point click = new System.Drawing.Point(me.X, me.Y);
            foreach (KeyValuePair<string, GraphicsPath> kvp in gpList)
            {
                if (kvp.Value.IsVisible(click))
                {
                    if (startNode == null)
                    {
                        startNode = NodeMap.Nodes.Find(n => n.NodeName == kvp.Key);
                        comboBox1.SelectedItem = kvp.Key;
                    }
                    else if (endNode == null)
                    {
                        endNode = NodeMap.Nodes.Find(n => n.NodeName == kvp.Key);
                        comboBox2.SelectedItem = kvp.Key;
                    }
                    break;
                }
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (NodeMap.Nodes.Count > 0)
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                int ellipseSize = 30;
                int lineOffset = (int)(ellipseSize /2);
                int textOffset = (int)(ellipseSize * 0.1);
                foreach (Node node in NodeMap.Nodes)
                {
                    int colorRandom = 0;
                    foreach (KeyValuePair<Node, int> connectedNode in node.ConnectedNodes)
                    {
                        g.DrawLine(new Pen(colors[colorRandom], 2),
                            node.Pos.X + lineOffset,
                            node.Pos.Y + lineOffset,
                            connectedNode.Key.Pos.X + lineOffset,
                            connectedNode.Key.Pos.Y + lineOffset);
                        if (colorRandom == 5)
                        {
                            colorRandom = 0;
                        }
                        else
                        {
                            colorRandom++;
                        }
                    }
                }

                foreach (Node node in NodeMap.Nodes)
                {
                    g.FillEllipse(new SolidBrush(Color.Black), new RectangleF(node.Pos.X, node.Pos.Y, ellipseSize, ellipseSize));
                    GraphicsPath gp = new GraphicsPath();
                    gp.AddEllipse(new RectangleF(node.Pos.X, node.Pos.Y, ellipseSize, ellipseSize));
                    KeyValuePair<string, GraphicsPath> kp = new KeyValuePair<string, GraphicsPath>(node.NodeName, gp);
                    gpList.Add(kp);
                    g.DrawString(node.NodeName, new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Red), node.Pos.X + textOffset, node.Pos.Y + textOffset);
                }
            }
        }

        private void generateNodeMap_btn_Click(object sender, EventArgs e)
        {
            int noOfNodes = Int32.Parse(nodeCount_tb.Text);
            int nodeWeight = 0;
            if (noOfNodes < 3)
            {
                MessageBox.Show("You need to enter at least three!");
                return;
            }
            if (noOfNodes > 26)
            {
                MessageBox.Show("You cannot enter more than 26!");
                return;
            }
            try
            {
                nodeWeight = Int32.Parse(maxNodeWeight_tb.Text);
                if (nodeWeight < 5)
                {
                    MessageBox.Show("Minimum weight has to be 5");
                    maxNodeWeight_tb.Text = "5";
                }
            }
            catch (FormatException)
            {
                nodeWeight = 10;
            }
            NodeMap.Nodes.Clear();
            NodeMap.GenerateRandomNodes(noOfNodes, nodeWeight, panel1.Height, panel1.Width);

            foreach (Node node in NodeMap.Nodes)
            {
                comboBox1.Items.Add(node.NodeName);
                comboBox2.Items.Add(node.NodeName);
            }

            panel1.Invalidate();
        }

        private void dijkstra_Btn_Click(object sender, EventArgs e)
        {
            startNode = NodeMap.Nodes.Find(n => n.NodeName == (string)comboBox1.SelectedItem);
            endNode = NodeMap.Nodes.Find(n => n.NodeName == (string)comboBox2.SelectedItem);

            startNode.CurrentCost = 0;

            foreach (Node node in NodeMap.Nodes)
            {
                if (!node.Equals(startNode))
                {
                    node.CurrentCost = Int32.MaxValue;
                }
            }
            Dijkstra.DijkstraSearch(NodeMap, startNode, endNode);
            distance_label.Text = "Distance from node " + startNode.NodeName + " to " + endNode.NodeName + " is " + endNode.CurrentCost;
        }
    }
}
