using RPS.Models;
using RPS.Models.Enums;
using System;
using System.Threading.Tasks.Dataflow;
namespace RPS.Services.GameJudge.Implementations;

public class GameJudge : IGameJudge
{
    public GameResult GetResult(Configuration configuration)
    {
        var playerMove = configuration.PlayerDecision;
        var computerMove = configuration.ComputerDecision;
        var moves = configuration.AvailableMoves.ToList();
        var length = moves.Count;
        var winMoves = length / 2;
        var formula = (moves.IndexOf(playerMove!) - moves.IndexOf(computerMove!) + winMoves + length) % length - winMoves;
        var result = (GameResult)(Math.Sign(formula) + 1);
        return result;
    }
}
