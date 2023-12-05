using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace gameLib
{
    internal static class Results
    {   
        internal static string GetResult(Turn computer, Turn player)
        {
            if (computer.Name == player.Name)
                return "Draw";
            else if (player.Win.Contains(computer.Name))
                return "You win";
            return "You lose";
        }
        
        internal static string GetResult(Turn turn, string name)
        {
            if (turn.Name == name)
                return "Draw";
            else if (turn.Win.Contains(name))
                return "Win";
            return "Lose";
        }
    }
}
