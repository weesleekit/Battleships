using System;

namespace Battleships.Classes
{
    internal static class InputParser
    {
        /// <summary>
        /// Expected input: "3:2"
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        internal static Position ParseCoordinateString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input is null, empty or whitespace");
            }

            string[] split = input.Split(':');

            if (split.Length != 2)
            {
                throw new ArgumentException("Expected separator character : to produce two elements");
            }

            string rowString = split[0];
            string columnString = split[1];

            if (!int.TryParse(rowString, out int row))
            {
                throw new ArgumentException($"Invalid row String {rowString}");
            }

            if (!int.TryParse(columnString, out int column))
            {
                throw new ArgumentException($"Invalid row String {columnString}");
            }

            return new Position(row, column);
        }

    }
}
