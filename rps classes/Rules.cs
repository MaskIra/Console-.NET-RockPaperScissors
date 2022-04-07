namespace rps
{
    static class Rules
    {
        // 0 - draw, 1 - win, -1 - lose
        static public int GetMoveResult(int first, int second, int toolsLength)
        {
            if (first == second)
                return 0;

            int half = toolsLength / 2;

            return ((first == half && first > second)
                || (first - half < 0 && (second >= first + half || second < first))
                || (first + half >= toolsLength && second >= first - half && second < first)
                ) ? 1 : -1;
        }
    }
}
