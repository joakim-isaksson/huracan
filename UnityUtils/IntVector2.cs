using System;
using UnityEngine;

namespace Util
{
    [Serializable]
    public struct IntVector2 : IEquatable<IntVector2>
    {
        public readonly int X;
        public readonly int Y;

        public IntVector2(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public IntVector2 Add(IntVector2 other)
        {
            return new IntVector2(X + other.X, Y + other.Y);
        }

        public IntVector2 Subtract(IntVector2 other)
        {
            return new IntVector2(X - other.X, Y - other.Y);
        }

        public IntVector2 Multiply(int multiplier)
        {
            return new IntVector2(X * multiplier, Y * multiplier);
        }
        
        public float Magnitude()
        {
            if (X == 0) return Y;
            if (Y == 0) return X;
            return Mathf.Sqrt(X * X + Y * Y);
        }
        
        public static IntVector2 operator +(IntVector2 a, IntVector2 b)
        {
            return a.Add(b);
        }
        
        public static IntVector2 operator -(IntVector2 a, IntVector2 b)
        {
            return a.Subtract(b);
        }
        
        public static IntVector2 operator *(IntVector2 a, int multiplier)
        {
            return a.Multiply(multiplier);
        }

        public bool Equals(IntVector2 other)
        {
            return X == other.X && Y == other.Y;
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return obj is IntVector2 && Equals((IntVector2) obj);
        }

        public override int GetHashCode()
        {
            var hash = 17;
            unchecked
            {
                hash = hash * 31 + X;
                hash = hash * 31 + Y;
            }
            return hash;
        }

        public override string ToString()
        {
            return "{" + X + ", " + Y + "}";
        }
    }
}