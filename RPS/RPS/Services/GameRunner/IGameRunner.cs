using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Services.GameRunner;

public interface IGameRunner
{
    void Run(string userEnter);

    void BotRun();
}
