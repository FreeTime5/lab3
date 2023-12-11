using RPS.Models;
using RPS.Services.GameBot;
using RPS.Services.GameJudge;
using RPS.Services.GameRunner;
using RPS.Services.HmacGenerator;
using RPS.Services.TableCreator;


namespace RPS.Services.GameBuilder.Implementations;

public class GameBuilder : IGameBuilder
{

    public (Configuration, IGameRunner) Build(string[] args)
    {
        IGameJudge gameJudge = new GameJudge.Implementations.GameJudge();
        var configuration = CreateConfiguration(args, gameJudge);
        var runner = CreaateRunner(configuration, gameJudge);

        return (configuration, runner);
    }

    private Configuration CreateConfiguration(string[] args, IGameJudge gameJudge)
    {
        ITableCreator tableCreator = new TableCreator.Implementations.TableCreator();
        var table = tableCreator.CreateTable(args, gameJudge);
        return new Configuration
        {
            AvailableMoves = args,
            Table = table,
            PlayerDecision = null,
            ComputerDecision = null,
            IsEnded = false,
            IsHelpRequired = false
        };
    }

    private IGameRunner CreaateRunner(Configuration configuration, IGameJudge gameJudge)
    {
        IHmacGenerator hmacGeneratoer = new HmacGenerator.Implementaions.HmacGenerator();
        IGameBot gameBot = new GameBot.Implementations.GameBot(hmacGeneratoer);
        IGameRunner runner = new GameRunner.Implementations.GameRunner(configuration, gameBot, gameJudge);

        return runner;
    }
}
