using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DijkstraLib;

namespace DijkstraApp
{
    public partial class Form1 : Form
    {
        private NodeMap NodeMap = new NodeMap();
        private Color[] colors = { Color.Red, Color.Blue, Color.Green, Color.Cyan, Color.Yellow, Color.BlueViolet };
        public Form1()
        {
            InitializeComponent();
            nodeCount_tb.Text = "3";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (NodeMap.Nodes.Count > 0)
            {
                Graphics g = e.Graphics;
                int ellipseSize = 30;
                int lineOffset = (int)(ellipseSize /2);
                int textOffset = (int)(ellipseSize * 0.1);
                foreach (Node node in NodeMap.Nodes)
                {
                    int colorRandom = 0;
                    foreach (KeyValuePair<Node, int> connectedNode in node.ConnectedNodes)
                    {
                        g.DrawLine(new Pen(colors[colorRandom], 2),
                            node.Position.X + lineOffset,
                            node.Position.Y + lineOffset,
                            connectedNode.Key.Position.X + lineOffset,
                            connectedNode.Key.Position.Y + lineOffset);
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
                    g.FillEllipse(new SolidBrush(Color.Black), new RectangleF(node.Position.X, node.Position.Y, ellipseSize, ellipseSize));
                    g.DrawString(node.NodeName, new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Red), node.Position.X + textOffset, node.Position.Y + textOffset);
                }
            }
        }

        private void generateNodeMap_btn_Click(object sender, EventArgs e)
        {
            int noOfNodes = Int32.Parse(nodeCount_tb.Text);
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
            NodeMap.Nodes.Clear();
            NodeMap.GenerateRandomNodes(noOfNodes, 10, panel1.Height, panel1.Width);

            panel1.Invalidate();
        }
    }
}
