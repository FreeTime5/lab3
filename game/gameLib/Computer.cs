using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace gameLib
{
    internal static class Computer
    {

        public static Turn MakeTurn(string[] allTurns)
        {
            var randomTurnIndex = RandomNumberGenerator.GetInt32(allTurns.Length - 1);
            var turn = new Turn(allTurns, randomTurnIndex);
            return turn;
        }
    }
}
