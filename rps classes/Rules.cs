using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rps
{
    static class Rules
    {
        // 0 - draw, 1 - win, -1 - lose
        static public int move(int first, int second, int length)
        {
            if (first == second)
                return 0;

            int half = length / 2;

            return ((first == half && first - second > 0)
                || (first - half < 0 && second >= first + half)
                || (first + half >= length && second >= first - half)
                ) ? 1 : -1;
        }
    }
}
