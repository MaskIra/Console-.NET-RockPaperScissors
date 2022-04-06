using System;

namespace rps
{
    static class Table
    {
        static public void show(string[] tools)
        {
            int n = tools.Length;
            int half = n / 2;

            // header
            Console.Write(String.Format(" {0,-10} ", ""));
            for (int i = 0; i < n; i++)
                Console.Write(String.Format(" {0,-10} ", tools[i]));
            Console.WriteLine();

            // table
            for (int i = 0; i < n; i++)
            {
                Console.Write(String.Format(" {0,-10} ", tools[i]));
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                        Console.Write(String.Format(" {0,-10} ", "draw"));
                    else if (i == half && j < i
                        || i - half < 0  && (j < i || j > i + half)
                        || i + half >= n && (j >= i - half && j < i))
                        Console.Write(String.Format(" {0,-10} ", "win"));
                    else
                        Console.Write(String.Format(" {0,-10} ", "lose"));
                }
                Console.WriteLine();
            }
        }
    }
}
