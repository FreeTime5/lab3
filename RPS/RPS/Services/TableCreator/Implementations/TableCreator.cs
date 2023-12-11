using ConsoleTables;
using RPS.Models;
using RPS.Services.GameJudge;
using RPS.Services.TableCreator.Constans;
namespace RPS.Services.TableCreator.Implementations;

public class TableCreator : ITableCreator
{
    public ConsoleTable CreateTable(string[] args, IGameJudge judge)
    {
        var columns = new List<string>
            {
                TableConstans.FirstColumn
            };
        columns.AddRange(args);
        var table = new ConsoleTable(columns.ToArray());
        var rows = new List<string[]>();
        var config = new Configuration() { AvailableMoves = args};
        for (var i = 0; i < args.Length; i++)
        {
            rows.Add(new string[args.Length + 1]);
            rows[i][0] = config.PlayerDecision = args[i];
            
            for (var j = 0; j < args.Length; j++)
            {
                config.ComputerDecision = args[j];
                rows[i][j + 1] = judge.GetResult(config).ToString();
            }
            
        }
        foreach (var row in rows)
        {
            table.AddRow(row);
        }
        return table;
    }
}
