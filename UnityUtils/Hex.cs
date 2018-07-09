using System;
using UnityEngine;

namespace Util
{
    // Cube coordinate system for pointy topped hexagon grid
    //
    //            N                 Odd-Offset:             Even-Offset:
    //      NW ./`'`\. NE
    //  WNW ./'       `\. ENE       (0, 0)(1, 0)               (0, 0)(1, 0)
    //     |             |             (0, 1)(1, 1)         (0, 1)(1, 1)
    //   W |             | E        (0, 2)(1, 2)               (0, 2)(1, 2)
    //     |             |             (0, 3)(1, 3)         (0, 3)(1, 3)
    //  WSW `\.       ./' ESE       (0, 4)(1, 4)               (0, 4)(1, 4)
    //      SW `\.,./' SE
    //            S
    //
    public struct Hex : IEquatable<Hex>
    {
        public static readonly Hex Zero = new Hex(0, 0, 0);

        public static readonly Hex East = new Hex(1, -1, 0);
        public static readonly Hex EastNorthEast = new Hex(2, -1, -1);
        public static readonly Hex NorthEast = new Hex(1, 0, -1);
        public static readonly Hex North = new Hex(1, 1, -2);
        public static readonly Hex NorthWest = new Hex(0, 1, -1);
        public static readonly Hex WestNorthWest = new Hex(-1, 2, -1);
        public static readonly Hex West = new Hex(-1, 1, 0);
        public static readonly Hex WestSouthWest = new Hex(-2, 1, 1);
        public static readonly Hex SouthWest = new Hex(-1, 0, 1);
        public static readonly Hex South = new Hex(-1, -1, -2);
        public static readonly Hex SouthEast = new Hex(0, -1, 1);
        public static readonly Hex EastSouthEast = new Hex(1, -2, 1);
        
        public static readonly Hex[] Directions = {East, NorthEast, NorthWest, West, SouthWest, SouthEast};
        public static readonly Hex[] Diagonals = {EastNorthEast, North, WestNorthWest, WestSouthWest, South, EastSouthEast};

        public readonly int X;
        public readonly int Y;
        public readonly int Z;

        public Hex(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Hex FromOddOffset(int col, int row)
        {
            var x = col - (row - (row & 1)) / 2;
            var z = row;
            var y = -x - z;
            return new Hex(x, y, z);
        }

        public IntVector2 ToOddOffset()
        {
            var col = X + (Z - (Z & 1)) / 2;
            var row = Z;
            return new IntVector2(col, row);
        }
        
        public static Hex FromEvenOffset(int col, int row)
        {
            var x = col - (row + (row & 1)) / 2;
            var z = row;
            var y = -x - z;
            return new Hex(x, y, z);
        }

        public IntVector2 ToEvenOffset()
        {
            var col = X + (Z + (Z & 1)) / 2;
            var row = Z;
            return new IntVector2(col, row);
        }

        public Hex Add(Hex other)
        {
            return new Hex(X + other.X, Y + other.Y, Z + other.Z);
        }

        public Hex Subtract(Hex other)
        {
            return new Hex(X - other.X, Y - other.Y, Z - other.Z);
        }

        public Hex Multiply(int multiplier)
        {
            return new Hex(X * multiplier, Y * multiplier, Z * multiplier);
        }
        
        public int Magnitude()
        {
            return (Mathf.Abs(X) + Mathf.Abs(Y) + Mathf.Abs(Z)) / 2;
        }

        public int Distance(Hex other)
        {
            return Subtract(other).Magnitude();
        }

        public Hex[] Neighbors()
        {
            var neighbors = new Hex[Directions.Length];
            for (var i = 0; i < neighbors.Length; ++i)
            {
                neighbors[i] = Add(Directions[i]);
            }
            return neighbors;
        }
        
        public static Vector3 Lerp(Hex a, Hex b, float t)
        {
            return new Vector3(a.X + (b.X - a.X) * t, a.Y + (b.Y - a.Y) * t, a.Z + (b.Z - a.Z) * t);
        }
        
        public static Hex Round(Vector3 point)
        {
            var x = (int)Mathf.Round(point.x);
            var y = (int)Mathf.Round(point.y);
            var z = (int)Mathf.Round(point.z);

            var xd = Mathf.Abs(x - point.x);
            var yd = Mathf.Abs(y - point.y);
            var zd = Mathf.Abs(z - point.z);

            if (xd > yd && xd > zd) x = -y - z;
            else if (yd > zd) y = -x - z;
            else z = -x - y;

            return new Hex(x, y, z);
        }
        
        public Hex[] LineTo(Hex other)
        {
            var distance = Distance(other);
            var line = new Hex[distance];
            var step = 1f / Mathf.Max(distance, 1);
            for (var i = 0; i <= distance; ++i)
            {
                line[i] = Round(Lerp(this, other, step * i));
            }
            return line;
        }
        
        public static Hex operator +(Hex a, Hex b)
        {
            return a.Add(b);
        }
        
        public static Hex operator -(Hex a, Hex b)
        {
            return a.Subtract(b);
        }
        
        public static Hex operator *(Hex a, int multiplier)
        {
            return a.Multiply(multiplier);
        }

        public bool Equals(Hex other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return obj is Hex && Equals((Hex) obj);
        }

        public override int GetHashCode()
        {
            var hash = 17;
            unchecked
            {
                hash = hash * 31 + X;
                hash = hash * 31 + Y;
                hash = hash * 31 + Z;
            }
            return hash;
        }

        public override string ToString()
        {
            return "{" + X + ", " + Y + ", " + Z + "}";
        }
    }
}