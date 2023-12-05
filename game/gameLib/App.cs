using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace gameLib
{
    public class App
    {
        public string[] Turns { get; private set; }
        public App(string[] turns)
        {
            Turns = turns;
        }
        public void Run()
        {
            var computerTurn = Computer.MakeTurn(Turns);
            Turn? playerTurn = null;
            while (true)
            {
                if (playerTurn == null)
                {
                    Console.Clear();
                    Console.WriteLine("HMAC: {0}", computerTurn.Key);
                    ShowMenu();
                    playerTurn = Player.MakeTurn(Turns);
                    continue;
                }
                if (playerTurn.Name == "help")
                {
                    var table = new Table(Turns);
                    table.CreateTable();
                    Console.Write("Enter your turn: ");
                    playerTurn = Player.MakeTurn(Turns);
                }
                break;
            }
            if (playerTurn.Name == "exit")
                return;
            if (playerTurn.Name == "help")
            {
                var table = new Table(Turns);
                table.CreateTable();
            }
            Console.WriteLine($"HMAC: {playerTurn.Key}");
            Console.WriteLine($"Your move: {playerTurn.Name}");
            Console.WriteLine($"Computer move: {computerTurn.Name}");
            Console.WriteLine(Results.GetResult(computerTurn, playerTurn));
        }

        private void ShowMenu()
        {
            Console.WriteLine("Avalible moves:");
            for (var i = 0; i < Turns.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {Turns[i]}");
            }
            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");
            Console.Write("Enter your move:  ");
        }
    }
}
