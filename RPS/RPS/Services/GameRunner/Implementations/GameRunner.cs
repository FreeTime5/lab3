using RPS.Constants;
using RPS.Models;
using RPS.Services.GameBot;
using RPS.Services.GameJudge;
namespace RPS.Services.GameRunner.Implementations;

public class GameRunner : IGameRunner
{
    private readonly Configuration configuration;
    private readonly IGameBot gameBot;
    private readonly IGameJudge gameJudge;

    public GameRunner(Configuration configuration, IGameBot gameBot, IGameJudge gameJudge)
    {
        this.configuration = configuration;
        this.gameBot = gameBot;
        this.gameJudge = gameJudge;
    }

    public void BotRun()
    {
        if (!configuration.IsPlayerTurn)
        {
            (configuration.ComputerDecision, configuration.ComputerHmac) = gameBot.MakeMove(configuration.AvailableMoves);
        }
    }

    public void Run(string userEnter)
    {
        switch (userEnter)
        {
            case ConfigConstants.ExitConstant:
                configuration.IsEnded = true;

                return;
            case ConfigConstants.HelpConstant:
                configuration.IsHelpRequired = true;
                configuration.IsPlayerTurn = true;

                return;
            default:
                configuration.PlayerDecision = configuration.AvailableMoves.ElementAt(int.Parse(userEnter) - 1);
                configuration.IsPlayerTurn = false;
                configuration.Result = gameJudge.GetResult(configuration);

                break;
        }
    }
}
