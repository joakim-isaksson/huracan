using System;
using System.Windows;

namespace Huracan.Hexagon
{
    // TODO: Comment public methods
    public class Layout
    {
        public readonly Orientation Orientation;
        public readonly Point Size;
        public readonly Point Origin;

        public Layout(Orientation orientation, Point size, Point origin)
        {
            Orientation = orientation;
            Size = size;
            Origin = origin;
        }

        public Point HexToPoint(Hex hex)
        {
            double x = (Orientation.F0 * hex.Q + Orientation.F1 * hex.R) * Size.X;
            double y = (Orientation.F2 * hex.Q + Orientation.F3 * hex.R) * Size.Y;
            return new Point(x + Origin.X, y + Origin.Y);
        }

        public FractionalHex PointToHex(Point point)
        {
            Point pt = new Point((point.X - Origin.X) / Size.X, (point.Y - Origin.Y) / Size.Y);
            double q = Orientation.B0 * pt.X + Orientation.B1 * pt.Y;
            double r = Orientation.B2 * pt.X + Orientation.B3 * pt.Y;
            return new FractionalHex(q, r, -q - r);
        }

        public Point CornerOffset(int corner)
        {
            double angle = 2.0 * Math.PI * (corner + Orientation.StartAngle) / 6;
            return new Point(Size.X * Math.Cos(angle), Size.Y * Math.Sin(angle));
        }

        public Point[] Corners(Hex hex)
        {
            Point[] corners = new Point[6];
            Point center = HexToPoint(hex);
            for (int i = 0; i < corners.Length; ++i)
            {
                Point offset = CornerOffset(i);
                corners[i] = new Point(center.X + offset.X, center.Y + offset.Y);
            }
            return corners;
        }

    }
}
