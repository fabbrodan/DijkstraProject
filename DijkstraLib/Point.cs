using System;

namespace DijkstraLib
{
    // Point class
    public class Point
    {
        public Point(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
