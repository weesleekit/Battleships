namespace Battleships.Classes
{
    internal class ShipHullSection
    {
        // Properties
        
        public Position Position { get; }

        public bool IsHit { get; private set; } = false;

        // Constructor

        public ShipHullSection(Position position)
        {
            Position = position;
        }

        // Public Methods

        public bool IncomingGuessHits(Position incomingGuessPosition)
        {
            if (Position.Equals(incomingGuessPosition))
            {
                IsHit = true;
                return true;
            }

            return false;
        }
    }
}
