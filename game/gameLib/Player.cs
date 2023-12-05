using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameLib
{
    internal static class Player
    {
        public static Turn? MakeTurn(string[] allTurns)
        {
            var input = Console.ReadLine();
            if (int.TryParse(input, out int turn) && turn >= 0 && turn <= allTurns.Length)
            {
                if (turn == 0)
                    return new Turn("exit");
                return new Turn(allTurns, turn - 1);
            }
            if (input == "?")
                return new Turn("help");

            return null;
        }
    }
}
