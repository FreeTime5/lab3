using RPS.Services.HmacGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Services.GameBot.Implementations;

public class GameBot : IGameBot
{
    private readonly IHmacGenerator hmacGenerator;

    public GameBot(IHmacGenerator hmacGenerator)
    {
        this.hmacGenerator = hmacGenerator;
    }

    public (string, string) MakeMove(IEnumerable<string> avaliableMoves)
    {
        var moves = avaliableMoves.ToList();
        var index = new Random().Next(0, moves.Count);
        var computerChoice = moves.ElementAt(index);
        var hmacCode = hmacGenerator.GenerateHmac(computerChoice);

        return (computerChoice, hmacCode);
    }
}
