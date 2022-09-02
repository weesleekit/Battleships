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

        }

        // Public Methods

        internal void AddShip(Ship newShip)
        {
            if (!IsWithinBoardBounds(newShip.StartPosition))
            {
                throw new ArgumentException($"Out of bounds start position {newShip.StartPosition}");
            }

            if (!IsWithinBoardBounds(newShip.EndPosition))
            {
                throw new ArgumentException($"Out of bounds start position {newShip.EndPosition}");
            }

            foreach (ShipHullSection shipHullSection in newShip.HullSections)
            {
                foreach (Ship existingShip in ships)
                {
                    if (existingShip.Occupies(shipHullSection.Position))
                    {
                        throw new ArgumentException($"Ship hull section cannot be located in a space that already has a ship: {shipHullSection.Position}");
                    }
                }
            }


            ships.Add(newShip);

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
