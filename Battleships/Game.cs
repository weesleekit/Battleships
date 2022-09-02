using Battleships.Classes;
using Serilog;
using System;

namespace Battleships
{
    // Imagine a game of battleships.
    //   The player has to guess the location of the opponent's 'ships' on a 10x10 grid
    //   Ships are one unit wide and 2-4 units long, they may be placed vertically or horizontally
    //   The player asks if a given co-ordinate is a hit or a miss
    //   Once all cells representing a ship are hit - that ship is sunk.
    public class Game
    {
        //Public Methods

        // ships: each string represents a ship in the form first co-ordinate, last co-ordinate
        //   e.g. "3:2,3:5" is a 4 cell ship horizontally across the 4th row from the 3rd to the 6th column
        // guesses: each string represents the co-ordinate of a guess
        //   e.g. "7:0" - misses the ship above, "3:3" hits it.
        // returns: the number of ships sunk by the set of guesses
        public static int Play(string[] ships, string[] guesses)
        {
            using (var log = new LoggerConfiguration().CreateLogger())
            {
                return Play(ships, guesses, log);
            }
        }

        public static int Play(string[] ships, string[] guesses, ILogger logger)
        {
            Log.Logger = logger;

            Log.Information("Starting: Game");

            ValidateInputData(ships, guesses);

            GameBoard gameBoard = new GameBoard();

            foreach (var shipInput in ships)
            {
                Ship ship = new Ship(shipInput);

                gameBoard.AddShip(ship);
            }

            foreach (var guess in guesses)
            {
                Position incomingGuessPosition = InputParser.ParseCoordinateString(guess);

                gameBoard.HandleGuess(incomingGuessPosition);
            }

            Log.Information("Finished: Game");
            return gameBoard.SunkShipCount;
        }

        // Private Methods

        private static void ValidateInputData(string[] ships, string[] guesses)
        {
            Log.Information("Starting: Validating input data");

            if (ships == null)
            {
                Log.Fatal("Null ships input data");
                throw new ArgumentNullException(nameof(ships));
            }

            if (guesses == null)
            {
                Log.Fatal("Null guesses input data");
                throw new ArgumentNullException(nameof(guesses));
            }

            if (ships.Length == 0)
            {
                Log.Fatal("No ships");
                throw new ArgumentOutOfRangeException(nameof(ships));
            }

            Log.Information("Finished: Validating input data");
        }
    }
}
