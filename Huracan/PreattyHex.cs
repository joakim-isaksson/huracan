using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huracan
{
    public class PreattyHex
    {
        static readonly string lineA = "AAAAAAAAA";
        static readonly string lineB = "BBBBBBBBB";
        static readonly string lineC = "CCCCCCCCC";
        static readonly char fillChar = '#';

        static readonly string templatePointy =
            "       .\n" +
            "    ./'" + fillChar + "`\\.\n" +
            " ./'" + fillChar + "" + fillChar + "" + fillChar + "" + fillChar + "" + fillChar + "" + fillChar + "" + fillChar + "`\\.\n" +
            "|" + fillChar + "" + fillChar + "" + lineA + "" + fillChar + "" + fillChar + "|\n" +
            "|" + fillChar + "" + fillChar + "" + lineB + "" + fillChar + "" + fillChar + "|\n" +
            "|" + fillChar + "" + fillChar + "" + lineC + "" + fillChar + "" + fillChar + "|\n" +
            " `\\." + fillChar + "" + fillChar + "" + fillChar + "" + fillChar + "" + fillChar + "" + fillChar + "" + fillChar + "./'\n" +
            "    `\\." + fillChar + "./'\n" +
            "       '\n";

        static readonly string templateFlat =
            "   /````````\\\n" +
            "  /" + fillChar + "" + fillChar + "" + fillChar + "" + fillChar + "" + fillChar + "" + fillChar + "" + fillChar + "" + fillChar + "" + fillChar + "" + fillChar + "\\\n" +
            " /" + fillChar + "" + lineA + " " + fillChar + "\\\n" +
            "(" + fillChar + "" + fillChar + "" + lineB + " " + fillChar + "" + fillChar + ")\n" +
            " \\" + fillChar + "" + lineC + " " + fillChar + "/\n" +
            "  \\" + fillChar + "" + fillChar + "" + fillChar + "" + fillChar + "" + fillChar + "" + fillChar + "" + fillChar + "" + fillChar + "" + fillChar + "" + fillChar + "/\n" +
            "   \\________/\n";


        public static string CreateString(bool pointy, string line1, string line2, string line3, char fill)
        {
            // Get right template
            string str = pointy ? templatePointy : templateFlat;

            // Add padding and cut given lines to meet the required lenght
            line1 = line1.PadRight(lineA.Length).Substring(0, lineA.Length);
            line2 = line2.PadRight(lineB.Length).Substring(0, lineB.Length);
            line3 = line3.PadRight(lineC.Length).Substring(0, lineC.Length);

            // Replace lines in template to given ones
            str = str.Replace(lineA, line1);
            str = str.Replace(lineB, line2);
            str = str.Replace(lineC, line3);

            // Change fill characters from template to given ones
            str = str.Replace(fillChar, fill);

            return str;
        }
    }
}
