using RPS.Services.GameBuilder;
using RPS.Services.GameBuilder.Implementations;
using RPS.Services.GamePrinter;
using RPS.Services.GamePrinter.Implementations;
using RPS.Services.InputValidator;
using RPS.Services.InputValidator.Implementations;

IGameBuilder builder= new GameBuilder();
(var configuration, var runner) = builder.Build(args);
IInputValidator validator = new InputValidator(configuration);
IGamePrinter printer = new ConsoleGamePrinter(configuration);
if (!validator.CheckMoves())
{
    printer.PrintErrorMessage();
    return;
}

printer.PrintMenu();

while (!configuration.IsEnded)
{
    configuration.ReloadGame();
    runner.BotRun();
    printer.PrintComputerHmac();
    string? userInput;
    do
    {
        printer.PrintEnterForUser();
        userInput = Console.ReadLine();
        printer.PrintErrorMessage();
        validator.CheckUserInput(userInput);
    }
    while (!configuration.IsCorrectUserInput);
    
    runner.Run(userInput!);
    printer.PrintRunResult();
}
