using ConsoleTables;
using RPS.Models;
using RPS.Services.GameJudge;

namespace RPS.Services.TableCreator;

public interface ITableCreator
{
    ConsoleTable CreateTable(string[] args, IGameJudge judge);
}
