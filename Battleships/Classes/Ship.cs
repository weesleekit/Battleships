using Serilog;
using System;
using System.Collections.Generic;

namespace Battleships.Classes
{
    internal class Ship
    {
        // Constants

        private const int minimumLength = 2;

        private const int maximumLength = 4;

        // Properties

        public Position StartPosition { get; }

        public Position EndPosition { get; }

        public List<ShipHullSection> HullSections { get; } = new List<ShipHullSection>();

        // Constructor

        /// <summary>
        /// Expected input: "3:2,3:5" is a 4 cell ship horizontally across the 4th row from the 3rd to the 6th column
        /// </summary>
        /// <param name="input"></param>
        /// <exception cref="ArgumentException"></exception>
        public Ship(string input)
        {
            Log.Information("Starting: To create Ship {input}", input);

            if (string.IsNullOrWhiteSpace(input))
            {
                string message = "Input is null, empty or whitespace";
                Log.Fatal(message);
                throw new ArgumentException(message);
            }

            string[] shipStartEndCoords = input.Split(',');

            if (shipStartEndCoords.Length != 2)
            {
                string message = "Expected separator character , to produce two elements";
                Log.Fatal(message);
                throw new ArgumentException(message);
            }

            StartPosition = InputParser.ParseCoordinateString(shipStartEndCoords[0]);

            EndPosition = InputParser.ParseCoordinateString(shipStartEndCoords[1]);

            ValidatePositions();

            GenerateHullSections();

            Log.Information("Finished: Creating Ship");
        }

        // Internal Methods

        internal bool Occupies(Position position)
        {
            foreach (ShipHullSection shipHullSection in HullSections)
            {
                if (shipHullSection.Position.Equals(position))
                {
                    return true;
                }
            }

            return false;
        }

        // Private Methods

        private void GenerateHullSections()
        {
            Position displacement = EndPosition - StartPosition;

            Position displacementStep = displacement.ReduceToLength_1_ForEitherDimension();

            Position currentPosition = StartPosition;

            HullSections.Add(new ShipHullSection(currentPosition));

            do
            {
                currentPosition += displacementStep;

                HullSections.Add(new ShipHullSection(currentPosition));
            }
            while (!currentPosition.Equals(EndPosition));
        }

        private void ValidatePositions()
        {
            if (StartPosition.Equals(EndPosition))
            {
                string message = "Ship cannot start and finish on same position";
                Log.Fatal(message);
                throw new ArgumentException(message);
            }

            Position displacement = StartPosition - EndPosition;

            if (displacement.row != 0 && displacement.column != 0)
            {
                string message = "Ship cannot lie across rows and columns";
                Log.Fatal(message);
                throw new ArgumentException(message);
            }

            int shipLength = Math.Abs(displacement.row > 0 ? displacement.row : displacement.column) + 1;

            if (shipLength < minimumLength)
            {
                Log.Fatal("Ship is too short, length of {shipLength} needs to be at least {minimumLength}", shipLength, minimumLength);
                throw new ArgumentException($"Ship is too short, length of {shipLength} needs to be at least {minimumLength}");
            }

            if (shipLength > maximumLength)
            {
                Log.Fatal("Ship is too long, length of {shipLength} needs to be at most {maximumLength}", shipLength, maximumLength);
                throw new ArgumentException($"Ship is too long, length of {shipLength} needs to be at most {maximumLength}");
            }
        }
    }
}
