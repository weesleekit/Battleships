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

        // Fields

        private readonly List<Ship> ships = new List<Ship>();

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

            foreach (ShipHullSection shipHullSection in newShip.HullSections)
            {
                foreach (Ship existingShip in ships)
                {
                    if (existingShip.Occupies(shipHullSection.Position))
                    {
                        Log.Fatal("Ship hull section cannot be located in a space that already has a ship: {Position}", shipHullSection.Position);
                        throw new ArgumentException($"Ship hull section cannot be located in a space that already has a ship: {shipHullSection.Position}");
                    }
                }
            }

            ships.Add(newShip);

            Log.Information("Finished: Adding ship");
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
