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

        public static Position operator -(Position x, Position y)
        {
            return new Position(x.row - y.row,
                                x.column - y.column);
        }
    }
}
