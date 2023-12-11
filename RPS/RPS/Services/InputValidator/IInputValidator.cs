using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Services.InputValidator;

public interface IInputValidator
{
    bool CheckMoves();

    void CheckUserInput(string? input);
}
