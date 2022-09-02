using FluentAssertions;
using System;
using Xunit;

namespace Battleships.Test
{
    public class GuessesRules
    {
        [Fact]
        public void Battleships_NoGuesses_NoShipSunk()
        {
            // Arrange
            string[] ships = new[] { "3:2,3:5" };
            string[] guesses = Array.Empty<string>();

            // Act
            int sunkShips = Game.Play(ships, guesses);

            // Assert
            sunkShips.Should().Be(0);
        }

        [Fact]
        public void Battleships_PartialHits_NoShipSunk()
        {
            // Arrange
            string[] ships = new[] { "3:2,3:5" };
            var guesses = new[] { "3:2", "3:3", "3:4" };

            // Act
            int sunkShips = Game.Play(ships, guesses);

            // Assert
            sunkShips.Should().Be(0);
        }

        [Fact]
        public void Battleships_FullyHitShip_OneShipSunk()
        {
            // Arrange
            string[] ships = new[] { "3:2,3:5" };
            var guesses = new[] { "3:2", "3:3", "3:4", "3:5" };

            // Act
            int sunkShips = Game.Play(ships, guesses);

            // Assert
            sunkShips.Should().Be(1);
        }

        [Theory]
        [InlineData(0, new string[] { "3:2,3:5" }, new string[] { "7:0", "3:3" })]
        [InlineData(1, new string[] { "3:5,3:2" }, new string[] { "3:2", "3:3", "3:4", "3:5" })]
        [InlineData(1, new string[] { "3:2,3:5", "0:0,3:0" }, new string[] { "3:2", "3:3", "3:4", "3:5" })]
        [InlineData(2, new string[] { "3:2,3:5", "0:0,3:0" }, new string[] { "3:2", "3:3", "3:4", "3:5", "0:0", "1:0", "2:0", "3:0" })]
        [InlineData(2, new string[] { "3:2,3:5", "3:0,0:0" }, new string[] { "3:2", "3:3", "3:4", "3:5", "0:0", "1:0", "2:0", "3:0" })]
        [InlineData(2, new string[] { "3:2,3:5", "0:0,3:0", "9:8,8:8" }, new string[] { "3:2", "3:3", "3:4", "3:5", "0:0", "1:0", "2:0", "3:0" })]
        [InlineData(3, new string[] { "3:2,3:5", "0:0,3:0", "8:8,9:8" }, new string[] { "9:8", "8:8", "3:2", "3:3", "3:4", "3:5", "0:0", "1:0", "2:0", "3:0" })]
        public void Battleships_VarietyOfScenarios_AppropriateShipsSunk(int numberShipsSunk, string[] ships, string[] guesses)
        {
            // Arrange

            // Act
            int sunkShips = Game.Play(ships, guesses);

            // Assert
            sunkShips.Should().Be(numberShipsSunk);
        }

    }
}
