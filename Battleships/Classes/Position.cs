using Newtonsoft.Json;
using System;

namespace Battleships.Classes
{
    internal struct Position : IEquatable<Position>
    {
        // Properties

        public int row;
        public int column;

        // Constructor

        internal Position(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        // Public Methods

        public bool Equals(Position other)
        {
            return (column == other.column
                && row == other.row);
        }

        public static Position operator -(Position x, Position y)
        {
            return new Position(x.row - y.row,
                                x.column - y.column);
        }

        public static Position operator +(Position x, Position y)
        {
            return new Position(x.row + y.row,
                                x.column + y.column);
        }

        // Internal Methods

        internal Position ReduceToLength_1_ForEitherDimension()
        {
            return new Position(Normalise(row), Normalise(column));
        }

        // Private Methods

        private int Normalise(int value)
        {
            if (value == 0)
            {
                return 0;
            }

            return value / Math.Abs(value);
        }

        // Overriden Methods

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
