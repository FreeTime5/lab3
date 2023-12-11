using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Services.GamePrinter;

public interface IGamePrinter
{
    void PrintMenu();

    void PrintEnterForUser();

    void PrintComputerHmac();

    void PrintRunResult();

    void PrintErrorMessage();
}
