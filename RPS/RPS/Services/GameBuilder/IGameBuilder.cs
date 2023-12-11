using RPS.Models;
using RPS.Services.GameRunner;


namespace RPS.Services.GameBuilder;

public interface IGameBuilder
{
    (Configuration, IGameRunner) Build(string[] args);
}
