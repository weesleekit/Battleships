using System;

namespace Battleships.Classes
{
    internal class Ship
    {
        // Properties

        public Position StartPosition { get; }

        public Position EndPosition { get; }

        // Constructor

        /// <summary>
        /// Expected input: "3:2,3:5" is a 4 cell ship horizontally across the 4th row from the 3rd to the 6th column
        /// </summary>
        /// <param name="input"></param>
        /// <exception cref="ArgumentException"></exception>
        public Ship(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input is null, empty or whitespace");
            }

            string[] shipStartEndCoords = input.Split(',');

            if (shipStartEndCoords.Length != 2)
            {
                throw new ArgumentException("Expected separator character , to produce two elements");
            }

            StartPosition = InputParser.ParseCoordinateString(shipStartEndCoords[0]);

            EndPosition = InputParser.ParseCoordinateString(shipStartEndCoords[1]);

            ValidatePositions();
        }

        private void ValidatePositions()
        {
            if (StartPosition.Equals(EndPosition))
            {
                throw new ArgumentException("Ship cannot start and finish on same position");
            }

            Position difference = StartPosition - EndPosition;

            if (difference.row != 0 && difference.column != 0)
            {
                throw new ArgumentException("Ship cannot lie across rows and columns");
            }
        }
    }
}
