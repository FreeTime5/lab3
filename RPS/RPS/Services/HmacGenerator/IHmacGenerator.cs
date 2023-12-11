using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Services.HmacGenerator;

public interface IHmacGenerator
{
    string GenerateHmac(string move);
}
