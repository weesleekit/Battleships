namespace Battleships.Classes
{
    internal struct Position
    {
        public int row;
        public int column;

        internal Position(int row, int column)
        {
            this.row = row;
            this.column = column;
        }
    }
}
