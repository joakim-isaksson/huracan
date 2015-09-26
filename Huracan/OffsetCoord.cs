using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huracan
{
    public struct OffsetCoord
    {
        public readonly int col;
        public readonly int row;

        static public int EVEN = 1;
        static public int ODD = -1;

        public OffsetCoord(int col, int row)
        {
            this.col = col;
            this.row = row;
        }

        static public OffsetCoord QoffsetFromCube(int offset, Hex h)
        {
            int col = h.Q;
            int row = h.R + (int)((h.Q + offset * (h.Q & 1)) / 2);
            return new OffsetCoord(col, row);
        }

        static public Hex QoffsetToCube(int offset, OffsetCoord h)
        {
            int q = h.col;
            int r = h.row - (int)((h.col + offset * (h.col & 1)) / 2);
            int s = -q - r;
            return new Hex(q, r, s);
        }

        static public OffsetCoord RoffsetFromCube(int offset, Hex h)
        {
            int col = h.Q + (int)((h.R + offset * (h.R & 1)) / 2);
            int row = h.R;
            return new OffsetCoord(col, row);
        }

        static public Hex RoffsetToCube(int offset, OffsetCoord h)
        {
            int q = h.col - (int)((h.row + offset * (h.row & 1)) / 2);
            int r = h.row;
            int s = -q - r;
            return new Hex(q, r, s);
        }

    }

}
