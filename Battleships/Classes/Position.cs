using Newtonsoft.Json;
using System;

namespace Battleships.Classes
{
    internal struct Position : IEquatable<Position>
    {
        public int row;
        public int column;

        internal Position(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        public bool Equals(Position other)
        {
            return (column == other.column
                && row == other.row);
        }

        internal Position ReduceToLength_1_ForEitherDimension()
        {
            return new Position(Normalise(row), Normalise(column));
        }

        private int Normalise(int value)
        {
            if (value == 0)
            {
                return 0;
            }

            return value / Math.Abs(value);
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

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
