using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Classes
{
    internal class Ship
    {

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

            Vector2 startPosition = InputParser.ParseCoordinateString(shipStartEndCoords[0]);

            Vector2 endPosition = InputParser.ParseCoordinateString(shipStartEndCoords[1]);
        }
    }
}
