using War.Objects;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;

namespace War
{
    class Program
    {

        static readonly ConcurrentDictionary<int, int> _countByTurns = new ConcurrentDictionary<int, int>();

        static void Main()
        {
            
            string player1name = "Justin";
            string player2name = "Mike";
            
            var sw = new Stopwatch();
            
            sw.Start();
            //Create game

            Console.WriteLine("Starting a game of War!");
            Game game = new Game(player1name, player2name, 0);
            while (!game.IsEndOfGame())
            {
                game.PlayTurn();
            }
            
            sw.Stop();

            Console.WriteLine("The game has finished in {0} milliseconds!", sw.ElapsedMilliseconds);
            Console.Read();
        }
    }
}