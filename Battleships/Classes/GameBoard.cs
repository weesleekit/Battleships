using System;

namespace Battleships.Classes
{
    internal class GameBoard
    {
        // Constants

        private const int rows = 10;
        private const int columns = 10;

        // Constructor

        internal GameBoard()
        { 

        }

        // Public Methods

        internal void AddShip(Ship ship)
        {
            if (!IsWithinBoardBounds(ship.StartPosition))
            {
                throw new ArgumentException($"Out of bounds start position {ship.StartPosition}");
            }

            if (!IsWithinBoardBounds(ship.EndPosition))
            {
                throw new ArgumentException($"Out of bounds start position {ship.EndPosition}");
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
