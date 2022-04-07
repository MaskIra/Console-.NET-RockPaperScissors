using System;
using System.Linq;

namespace rps
{
    class Program
    {
        static void Main(string[] args)
        {
            int qty = args.Length;

            // check
            if (qty % 2 == 0)
                Console.WriteLine("Even (or 0) number of moves (arguments) are given, you should specify an odd number greater than or equal to three (>=3)");
            else if (qty < 3)
                Console.WriteLine("Too few moves (arguments) are given, you should specify an odd number greater than or equal to three (>=3)");
            else if (qty != args.Distinct().Count())
                Console.WriteLine("Moves have duplicate values, please remove duplicates");

            // loop
            else for (int step = 1; step <= qty; step++)
                {
                    Console.WriteLine(new string('-', 10));

                    // calc
                    int Cmove = MakeMove(qty);
                    Key key = new Key(32, args[Cmove]);

                    // show HMAC
                    Console.WriteLine("HMAC: " + Key.GetBytesToString(key.Gethash()));

                    // menu
                    Console.WriteLine("Available moves:");
                    for (int i = 1; i <= qty; i++)
                        Console.WriteLine(i + " - " + args[i - 1]);
                    Console.WriteLine("0 - exit");
                    Console.WriteLine("-1 - help");

                    // input
                    Console.WriteLine("Enter your move: ");
                    int Umove;
                    if (!int.TryParse(Console.ReadLine(), out Umove) || Umove < 0 || Umove > qty)
                    {
                        if (Umove == -1)
                            Table.Display(args);
                        step--;
                        continue;
                    }

                    // exit
                    if (Umove == 0)
                    {
                        Console.WriteLine("Are you sure? (yes)");
                        if (Console.ReadLine().Trim().ToLower() == "yes")
                            return;
                    }

                    Umove--;
                    // results
                    Console.WriteLine("Your move: " + args[Umove]);
                    Console.WriteLine("Computer move: " + args[Cmove]);

                    switch (Rules.GetMoveResult(Umove, Cmove, qty))
                    {
                        case 0:
                            Console.WriteLine("You have a draw!");
                            break;
                        case 1:
                            Console.WriteLine("You win!");
                            break;
                        case -1:
                            Console.WriteLine("You lose!");
                            break;
                    }

                    Console.WriteLine("HMAC key: " + Key.GetBytesToString(key.GetKey()));
                }
        }

        public static int MakeMove(int max)
        {
            return new Random().Next(max);
        }
    }
}
