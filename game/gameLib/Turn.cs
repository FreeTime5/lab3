using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameLib
{
    public class Turn
    {
        public string Name { get; private set; }
        public string Key { get; private set; }
        public List<string> Win { get; private set; }

        internal Turn (string name)
        {
            Name = name;
            Key = "";
            Win = new List<string>();
        }

        internal Turn(string[] allTurns, int turnIndex)
        {
            Name = allTurns[turnIndex];
            Key = HMAC.CreateHMAC(Name);
            Win = new List<string>();
            SetDependencies(allTurns, turnIndex);
        }

        private void SetDependencies(string[] allTurns, int turnIndex)
        {
            for (var i = 1; i <= allTurns.Length / 2; i++)
            {
                Win.Add(allTurns[(turnIndex + i) % allTurns.Length]);
            }
        }
    }
}
