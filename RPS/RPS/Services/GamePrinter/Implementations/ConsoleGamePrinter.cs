using RPS.Models;
using RPS.Models.Enums;

namespace RPS.Services.GamePrinter.Implementations;

public class ConsoleGamePrinter : IGamePrinter
{
    private readonly Configuration configuration;

    public ConsoleGamePrinter(Configuration configuration)
    {
        this.configuration = configuration;
    }

    public void PrintComputerHmac()
    {
        Console.WriteLine($"Computed Hmac: {configuration.ComputerHmac}");
    }

    public void PrintEnterForUser()
    {
        Console.Write("Enter your move: ");
    }

    public void PrintMenu()
    {
        Console.WriteLine("Avaliabel moves:");
        for (var i = 0; i < configuration.AvailableMoves.Count(); i++)
        {
            Console.WriteLine($"{i + 1} - {configuration.AvailableMoves.ElementAt(i)}");
        }
        Console.WriteLine("0 - exit");
        Console.WriteLine("? - help");
    }

    public void PrintRunResult()
    {
        if (configuration.IsHelpRequired)
        {
            PrintHelp();
            return;
        }

        if (configuration.IsEnded)
        {
            PrintEndGame();
            return;
        }

        PrintResult();
    }

    private void PrintResult()
    {
        Console.WriteLine($"Computer move: {configuration.ComputerDecision}");
        Console.WriteLine($"Your move: {configuration.PlayerDecision}");

        switch (configuration.Result)
        {
            case GameResult.Draw:
                Console.WriteLine("DRAW!");
                return;
            case GameResult.Win:
                Console.WriteLine("YOU WIN!");
                return;
            case GameResult.Lose:
                Console.WriteLine("YOU LOSE!");
                return;
        }
    }

    private void PrintHelp()
    {
        configuration.Table.Write(ConsoleTables.Format.Alternative);
    }

    private void PrintEndGame()
    {
        Console.WriteLine("Game was ended");
    }

    public void PrintErrorMessage()
    {
        if (!configuration.IsCorrectUserInput)
        {
            Console.WriteLine("Incorrect input");
        }
    }
}
