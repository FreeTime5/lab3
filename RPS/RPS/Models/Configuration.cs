using ConsoleTables;
using RPS.Models.Enums;


namespace RPS.Models;

public class Configuration
{
    public string? PlayerDecision { get; set; }

    public string? ComputerDecision { get; set; }

    public string? ComputerHmac { get; set; }

    public GameResult? Result { get; set; }

    public IEnumerable<string> AvailableMoves { get; set; }

    public ConsoleTable? Table { get; set; }

    public bool IsCorrectUserInput { get; set; }

    public bool IsPlayerTurn { get; set; }

    public bool IsEnded { get; set; }

    public bool IsHelpRequired { get; set; }

    public void ReloadGame()
    {
        PlayerDecision = null;
        if (!IsPlayerTurn)
        {
            ComputerDecision = null;
            ComputerHmac = null;
        }
        Result = null;
        IsHelpRequired = false;
        IsCorrectUserInput = false;
    }
}

