using RPS.Models;
using RPS.Models.Enums;
namespace RPS.Services.GameJudge;

public interface IGameJudge
{
    GameResult GetResult(Configuration configuration);
}
