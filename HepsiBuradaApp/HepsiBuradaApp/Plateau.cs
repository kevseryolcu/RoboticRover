using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBuradaApp
{
    public class Plateau
    {
        public Coordinate LowerLeftCorner { get; set; }
        public Coordinate LowerRightCorner { get; set; }
        public Coordinate UpperRightCorner { get; set; }

        private readonly int originX = 0;
        private readonly int originY = 0;

        public Plateau()
        {
            this.LowerLeftCorner = new Coordinate(originX, originY);
        }
        public Plateau(int x, int y)
        {
            this.LowerLeftCorner = new Coordinate(originX, originY);
            this.LowerRightCorner = new Coordinate(x, originY);
            this.UpperRightCorner = new Coordinate(x, y);
        }

        // Used Barycentric Coordinate System
        public bool IsInsidePlateau(int x, int y) {
            var (x1, y1) = (this.LowerLeftCorner.X, this.LowerLeftCorner.Y);
            var (x2, y2) = (this.LowerRightCorner.X, this.LowerRightCorner.Y);
            var (x3, y3) = (this.UpperRightCorner.X, this.UpperRightCorner.Y);

            var denominator = (x1 * (y2 - y3) + y1 * (x3 - x2) + x2 * y3 - y2 * x3);
            
            var t1 = (double)(x * (y3 - y1) + y * (x1 - x3) - x1 * y3 + y1 * x3) / denominator;
            var t2 = (double)(x * (y2 - y1) + y * (x1 - x2) - x1 * y2 + y1 * x2) / -denominator;
            var s = t1 + t2;

            return 0 <= t1 && t1 <= 1 && 0 <= t2 && t2 <= 1 && s <= 1;
        }
    }
}
