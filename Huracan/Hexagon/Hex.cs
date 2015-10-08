﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace Huracan.Hexagon
{
    // Directions:
    //
    //     D2    O1    D1             D1 .
    //       /````````\            O1 ./' `\. O0
    //   O2 /          \ O0     D2 ./'       `\. D0
    //     /            \         |             |
    // D3 (              ) D0  O2 |             | O5
    //     \            /         |             |
    //   O3 \          / O5     D3 `\.       ./' D5
    //       \________/            O3 `\. ./' O4
    //     D4    O4    D5                ' D4
    //
    public class Hex
    {
        public static readonly Hex Zero = new Hex(0, 0, 0);

        public static readonly Hex O0 = new Hex(1, 0, -1);
        public static readonly Hex O1 = new Hex(1, -1, 0);
        public static readonly Hex O2 = new Hex(0, -1, 1);
        public static readonly Hex O3 = new Hex(-1, 0, 1);
        public static readonly Hex O4 = new Hex(-1, 1, 0);
        public static readonly Hex O5 = new Hex(0, 1, -1);
        public static readonly Hex[] Orthanogal = { O0, O1, O2, O3, O4, O5 };

        public static readonly Hex D0 = new Hex(2, -1, -1);
        public static readonly Hex D1 = new Hex(1, -2, 1);
        public static readonly Hex D2 = new Hex(-1, -1, 2);
        public static readonly Hex D3 = new Hex(-2, 1, 1);
        public static readonly Hex D4 = new Hex(-1, 2, -1);
        public static readonly Hex D5 = new Hex(1, 1, -2);
        public static readonly Hex[] Diagonal = { D0, D1, D2, D3, D4, D5 };

        public readonly int Q;
        public readonly int R;
        public readonly int S;

        public Hex(int q, int r, int s)
        {
            if (q + r + s != 0) throw new ArgumentException("Sum of coordinates must be zero");
            Q = q;
            R = r;
            S = s;
        }

        public Hex Add(Hex hex)
        {
            return new Hex(Q + hex.Q, R + hex.R, S + hex.S);
        }

        public Hex Subtract(Hex hex)
        {
            return new Hex(Q - hex.Q, R - hex.R, S - hex.S);
        }

        public Hex Multiply(int multiplier)
        {
            return new Hex(Q * multiplier, R * multiplier, S * multiplier);
        }

        public int Length()
        {
            return (Math.Abs(Q) + Math.Abs(R) + Math.Abs(S)) / 2;
        }

        public int Distance(Hex hex)
        {
            return Subtract(hex).Length();
        }

        public FractionalHex Lerp(Hex hex, double t)
        {
            return new FractionalHex(Q + (hex.Q - Q) * t, R + (hex.R - R) * t, S + (hex.S - S) * t);
        }

        public List<Hex> LineTo(Hex hex)
        {
            int distance = Distance(hex);
            List<Hex> line = new List<Hex>();
            double step = 1.0 / Math.Max(distance, 1);
            for (int i = 0; i <= distance; ++i)
            {
                line.Add(Lerp(hex, step * i).Round());
            }
            return line;
        }

        public Point ToOffsetQ()
        {
            int offset = (Q % 2 == 0) ? 1 : -1;
            return new Point(Q, R + ((Q + offset * (Q & 1)) / 2));
        }

        public static Hex FromOffsetQ(Point point)
        {
            return FromOffsetX(point.X, point.Y);
        }

        public static Hex FromOffsetX(int x, int y)
        {
            int offset = (x % 2 == 0) ? 1 : -1;
            int r = y - (x + offset * (x & 1)) / 2;
            return new Hex(x, r, -x - r);
        }

        public Point ToOffsetR()
        {
            int offset = (R % 2 == 0) ? 1 : -1;
            return new Point(Q + (R + offset * (R & 1)) / 2, R);
        }

        public static Hex FromOffsetY(Point point)
        {
            return FromOffsetY(point.X, point.Y);
        }

        public static Hex FromOffsetY(int x, int y)
        {
            int offset = (y % 2 == 0) ? 1 : -1;
            int q = x - (y + offset * (y & 1)) / 2;
            return new Hex(q, y, -q - y);
        }

        public List<Hex> Range(int n)
        {
            List<Hex> hexes = new List<Hex>();
            for (int dx = -n; dx <= n; ++dx)
            {
                int dyMin = Math.Max(-n, -dx - n);
                int dyMax = Math.Min(n, -dx + n);
                for (int dy = dyMin; dy <= dyMax; ++dy)
                {
                    int dz = -dx - dy;
                    hexes.Add(Add(new Hex(dx, dy, dz)));
                }
            }
            return hexes;
        }

        public List<Hex> Rechable(int steps, List<Hex> blocked)
        {
            List<Hex> visited = new List<Hex>();
            visited.Add(this);

            List<List<Hex>> fringes = new List<List<Hex>>();
            fringes.Add(new List<Hex>());
            fringes[0].Add(this);

            for (int step = 1; step <= steps; ++step)
            {
                fringes.Add(new List<Hex>());
                foreach (Hex hex in fringes[step - 1])
                {
                    foreach (Hex unit in Orthanogal)
                    {
                        Hex candidate = hex.Add(unit);
                        if (!blocked.Contains(candidate))
                        {
                            visited.Add(candidate);
                            fringes[step].Add(candidate);
                        }
                    }
                }
            }

            return visited;
        }

        public Hex Rotate(int degrees)
        {
            Hex hex = this;
            if (degrees > 0)
            {
                for (int i = 0; i < degrees / 60; ++i)
                {
                    hex = new Hex(-hex.S, -hex.Q, -hex.R);
                }
            }
            else
            {
                for (int i = 0; i < Math.Abs(degrees / 60); ++i)
                {
                    hex = new Hex(-hex.R, -hex.S, -hex.Q);
                }
            }
            return hex;
        }

        public List<Hex> Ring(int radius)
        {
            List<Hex> hexes = new List<Hex>();
            Hex hex = Add(O4.Multiply(radius));
            foreach (Hex unit in Orthanogal)
            {
                for (int i = 0; i < radius; ++i)
                {
                    hexes.Add(hex);
                    hex = hex.Add(unit);
                }
            }
            return hexes;
        }

        public List<Hex> Spiral(int radius)
        {
            List<Hex> hexes = new List<Hex>();
            hexes.Add(this);
            for (int k = 1; k <= radius; ++k)
            {
                hexes.AddRange(Ring(k));
            }
            return hexes;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            Hex hex = (Hex)obj;
            if (hex == null) return false;

            return (Q == hex.Q && R == hex.R && S == hex.S);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            unchecked
            {
                hash = hash * 31 + Q;
                hash = hash * 31 + R;
                hash = hash * 31 + S;
            }
            return hash;
        }

    }
}