using Serilog;
using System;
using System.Collections.Generic;

namespace Battleships.Classes
{
    internal class GameBoard
    {
        // Constants

        private const int rows = 10;
        private const int columns = 10;

        // Properties

        public int SunkShipCount { get { return sunkShips.Count; } }

        // Fields

        private readonly List<Ship> allShips = new List<Ship>();
        private readonly List<Ship> afloatShips = new List<Ship>();
        private readonly List<Ship> sunkShips = new List<Ship>();

        // Constructor

        internal GameBoard()
        {
            Log.Information("Game board created: {rows} {columns}", rows, columns);
        }

        // Public Methods

        internal void AddShip(Ship newShip)
        {
            Log.Information("Starting: To add ship {@ship}", newShip);

            if (!IsWithinBoardBounds(newShip.StartPosition))
            {
                Log.Fatal("Out of bounds start position {Position}", newShip.StartPosition);
                throw new ArgumentException($"Out of bounds start position {newShip.StartPosition}");
            }

            if (!IsWithinBoardBounds(newShip.EndPosition))
            {
                Log.Fatal("Out of bounds end position {Position}", newShip.EndPosition);
                throw new ArgumentException($"Out of bounds end position {newShip.EndPosition}");
            }

            foreach (ShipHullSection shipHullSection in newShip.ShipHullSections)
            {
                foreach (Ship existingShip in allShips)
                {
                    if (existingShip.Occupies(shipHullSection.Position))
                    {
                        Log.Fatal("Ship hull section cannot be located in a space that already has a ship: {Position}", shipHullSection.Position);
                        throw new ArgumentException($"Ship hull section cannot be located in a space that already has a ship: {shipHullSection.Position}");
                    }
                }
            }

            allShips.Add(newShip);
            afloatShips.Add(newShip);

            Log.Information("Finished: Adding ship");
        }

        internal void HandleGuess(Position incomingGuessPosition)
        {
            for (int i = 0; i < afloatShips.Count; i++)
            {
                Ship ship = afloatShips[i];

                ship.HandleGuess(incomingGuessPosition, out bool isSunk, out bool isAHit);
                
                if (isSunk)
                {
                    Log.Information("Ship has been sunk, {@ship}", ship);
                    afloatShips.Remove(ship);
                    sunkShips.Add(ship);
                }

                if (isSunk || isAHit)
                {
                    return;
                }
            }
        }

        // Private Methods

        private bool IsWithinBoardBounds(Position position)
        {
            return (position.row >= 0
                && position.column >= 0
                && position.row < rows
                && position.column < columns);
        }

    }
}
