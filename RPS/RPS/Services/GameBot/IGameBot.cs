using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Services.GameBot;

public interface IGameBot
{
    (string, string) MakeMove(IEnumerable<string> avaliableMoves);
}
