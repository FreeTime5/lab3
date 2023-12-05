using gameLib;
using System.Security.Cryptography;

namespace game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length >= 3 && args.Length % 2 == 1)
            {
                for (var i = 0; i < args.Length; i++)
                {
                    
                    if (Array.IndexOf(args, args[i]) != Array.LastIndexOf(args, args[i]))
                    {
                        Console.WriteLine("Input must be unque");
                        return;
                    }
                }
                var app = new App(args);
                app.Run();
            }
            else
                Console.WriteLine("Incorrect args length");
        }
    }
}
