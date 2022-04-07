using ConsoleTables;

namespace rps
{
    static class Table
    {
        static public void Display(string[] tools)
        {
            int n = tools.Length;
            int half = n / 2;
            string[] line = new string[n + 1];

            // header
            line[0] = "-";
            for (int i = 0; i < n; i++)
                line[i + 1] = tools[i];
            var table = new ConsoleTable(line);

            // data
            for (int i = 0; i < n; i++)
            {
                line[0] = tools[i];
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                        line[j + 1] = "draw";
                    else if (i == half && j < i
                        || i - half < 0 && (j < i || j > i + half)
                        || i + half >= n && (j >= i - half && j < i))
                        line[j + 1] = "win";
                    else
                        line[j + 1] = "lose";
                }
                table.AddRow((string[])line.Clone());
            }

            // output
            table.Write(Format.Alternative);
        }
    }
}
