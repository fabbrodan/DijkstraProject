using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DijkstraLib;

namespace DijkstraApp
{
    public partial class Form1 : Form
    {
        private NodeMap NodeMap = new NodeMap();
        public Form1()
        {
            InitializeComponent();
            NodeMap.GenerateRandomNodes(10, 10, panel1.Height, panel1.Width);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (Node node in NodeMap.Nodes)
            {
                g.DrawEllipse(new Pen(Color.Blue), new RectangleF(node.Position.X, node.Position.Y, 20, 20));
                g.DrawString(node.NodeName, new Font("Arial", 12), new SolidBrush(Color.Red), node.Position.X, node.Position.Y);
                foreach (KeyValuePair<Node, int> connectedNode in node.ConnectedNodes)
                {
                    g.DrawLine(new Pen(Color.Black, 1), node.Position.X + 10, node.Position.Y + 10, connectedNode.Key.Position.X + 10, connectedNode.Key.Position.Y + 10);
                    //g.DrawString(connectedNode.Value.ToString(), new Font("Arial", 12), new SolidBrush(Color.Red), new PointF((node.Position.X + connectedNode.Key.Position.X) / 2, (node.Position.Y + connectedNode.Key.Position.Y) / 2));
                }
            }
        }
    }
}
