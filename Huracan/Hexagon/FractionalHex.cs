using System;

namespace Huracan.Hexagon
{
    public class FractionalHex
    {
        public readonly double Q;
        public readonly double R;
        public readonly double S;

        public FractionalHex(double q, double r, double s)
        {
            Q = q;
            R = r;
            S = s;
        }

        public Hex Round()
        {
            int q = (int)Math.Round(Q);
            int r = (int)Math.Round(R);
            int s = (int)Math.Round(S);

            double qDiff = Math.Abs(q - Q);
            double rDiff = Math.Abs(r - R);
            double sDiff = Math.Abs(s - S);

            if (qDiff > rDiff && qDiff > sDiff) q = -r - s;
            else if (rDiff > sDiff) r = -q - s;
            else s = -q - r;

            return new Hex(q, r, s);
        }
    }
}
