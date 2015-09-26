using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huracan
{
    public class Layout
    {
        public static readonly Orientation Pointy = new Orientation(
            Math.Sqrt(3.0), Math.Sqrt(3.0) / 2.0, 0.0, 3.0 / 2.0,
            Math.Sqrt(3.0) / 3.0, -1.0 / 3.0, 0.0, 2.0 / 3.0,
            0.5
        );

        public static readonly Orientation Flat = new Orientation(
            3.0 / 2.0, 0.0, Math.Sqrt(3.0) / 2.0, Math.Sqrt(3.0),
            2.0 / 3.0, 0.0, -1.0 / 3.0, Math.Sqrt(3.0) / 3.0,
            0.0
        );

        public readonly Orientation Orientation;
        public readonly Point2D Size;
        public readonly Point2D Origin;

        public Layout(Orientation orientation, Point2D size, Point2D origin)
        {
            Orientation = orientation;
            Size = size;
            Origin = origin;
        }

        public Point2D HexToPixel(Hex hex)
        {
            double x = (Orientation.f0 * hex.Q + Orientation.f1 * hex.R) * Size.X;
            double y = (Orientation.f2 * hex.Q + Orientation.f3 * hex.R) * Size.Y;
            return new Point2D(x + Origin.X, y + Origin.Y);
        }

        public FractionalHex PixelToHex(Point2D point)
        {
            Point2D pt = new Point2D((point.X - Origin.X) / Size.X, (point.Y - Origin.Y) / Size.Y);
            double q = Orientation.b0 * pt.X + Orientation.b1 * pt.Y;
            double r = Orientation.b2 * pt.X + Orientation.b3 * pt.Y;
            return new FractionalHex(q, r, -q - r);
        }

        public Point2D HexCornerOffset(int corner)
        {
            double angle = 2.0 * Math.PI * (corner + Orientation.start_angle) / 6;
            return new Point2D(Size.X * Math.Cos(angle), Size.Y * Math.Sin(angle));
        }

        public List<Point2D> PolygonCorners(Hex hex)
        {
            List<Point2D> corners = new List<Point2D> { };
            Point2D center = HexToPixel(hex);
            for (int i = 0; i < 6; ++i)
            {
                Point2D offset = HexCornerOffset(i);
                corners.Add(new Point2D(center.X + offset.X, center.Y + offset.Y));
            }
            return corners;
        }

    }
}
