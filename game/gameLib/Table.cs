using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace gameLib
{
    internal class Table
    {
        public static string FirstElement { get; set; } = "PC\\User";

        public int MaxLength { get; private set; } = FirstElement.Length;

        private int _rowLength = FirstElement.Length + 2;

        private string[] _turns;

        internal Table(string[] turns)
        {
            _turns = turns;
        }

        internal void CreateTable()
        {
            var columns = new List<string>
            {
                FirstElement
            };
            columns.AddRange(_turns);
            var table = new ConsoleTable(columns.ToArray());
            var rows = new List<string[]>();
            for (var i = 0; i < _turns.Length; i++)
            {
                var turn = new Turn(_turns, i);
                var row = new string[_turns.Length + 1];
                row[0] = _turns[i];
                for (var j = 0; j < _turns.Length; j++)
                {
                    row[j + 1] = Results.GetResult(turn, _turns[j]);
                }
                rows.Add(row);
            }
            foreach (var row in rows)
            {
                table.AddRow(row);
            }
            table.Write(Format.Alternative);
        }
    }
}
