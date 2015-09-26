using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huracan
{
    //      
    //     /````````\
    //    /          \
    //   /            \
    //  (              )
    //   \            /
    //    \          /
    //     \________/
    //       
    //         .
    //      ./' `\.
    //   ./'       `\.
    //  |             |
    //  |             |
    //  |             |
    //   `\.       ./'
    //      `\. ./'
    //         '
    public class Hex
    {
        public static readonly Hex Zero = new Hex(0, 0, 0);

        public static readonly Hex[] Unit = {
            new Hex(2, -1, -1),
            new Hex(1, 0, -1),
            new Hex(1, -2, 1),
            new Hex(1, -1, 0),
            new Hex(0, -1, 1),
            new Hex(-1, -1, 2), 
            new Hex(-1, 0, 1),
            new Hex(-2, 1, 1),
            new Hex(-1, 1, 0),
            new Hex(-1, 2, -1),
            new Hex(0, 1, -1),
            new Hex(1, 1, -2)
        };

        /*
        public static readonly Hex[] Unit = {
            0  new Hex(2, -1, -1),
            1  new Hex(1, 0, -1),
            2  new Hex(1, -2, 1),
            3  new Hex(1, -1, 0),
            4  new Hex(0, -1, 1),
            5  new Hex(-1, -1, 2),
            6  new Hex(-1, 0, 1),
            7  new Hex(-2, 1, 1),
            8  new Hex(-1, 1, 0),
            9  new Hex(-1, 2, -1),
            10 new Hex(0, 1, -1),
            11 new Hex(1, 1, -2)
        };
        */

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
