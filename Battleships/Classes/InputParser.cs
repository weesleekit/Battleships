using Serilog;
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
            Log.Debug("Starting: To parse coordinate {input}", input);

            if (string.IsNullOrWhiteSpace(input))
            {
                string message = "Input is null, empty or whitespace";
                Log.Fatal(message);
                throw new ArgumentException(message);
            }

            string[] split = input.Split(':');

            if (split.Length != 2)
            {
                string message = "Expected separator character : to produce two elements";
                Log.Fatal(message);
                throw new ArgumentException(message);
            }

            string rowString = split[0];
            string columnString = split[1];

            if (!int.TryParse(rowString, out int row))
            {
                Log.Fatal("Invalid row String {rowString}", rowString);
                throw new ArgumentException($"Invalid row String {rowString}");
            }

            if (!int.TryParse(columnString, out int column))
            {
                Log.Fatal("Invalid column String {columnString}", columnString);
                throw new ArgumentException($"Invalid column String {columnString}");
            }

            return new Position(row, column);
        }

    }
}
