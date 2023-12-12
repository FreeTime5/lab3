using RPS.Models;
using RPS.Constants;

namespace RPS.Services.InputValidator.Implementations
{
    internal class InputValidator : IInputValidator
    {
        private readonly Configuration configuration;

        public InputValidator(Configuration configuration)
        {
            this.configuration = configuration;
        }

        public bool CheckMoves()
        {
            var moves = configuration.AvailableMoves.ToList();
            if (moves.Count < 3 || moves.Count % 2 != 1) return false;

            var dictionary = new Dictionary<string, bool>();
            foreach (var move in moves)
            {
                if (!dictionary.ContainsKey(move))
                {
                    dictionary.Add(move, true);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public void CheckUserInput(string? input)
        {
            configuration.IsCorrectUserInput = input == ConfigConstants.HelpConstant || input == ConfigConstants.ExitConstant || (int.TryParse(input, out var result) && result >= 1 && result <= configuration.AvailableMoves.Count());
        }
    }
}
