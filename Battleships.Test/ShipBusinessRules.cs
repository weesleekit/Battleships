using FluentAssertions;
using System;
using Xunit;

namespace Battleships.Test
{
    public class ShipBusinessRules
    {
        [Fact]
        public void Battleships_ShipStartsAndEndsSameSpace_ThrowsArgumentException()
        {
            // Arrange
            string[] ships = new[] { "3:5,3:5" };
            string[] guesses = new[] { "7:0", "3:3" };

            // Act
            Action act = () => Game.Play(ships, guesses);

            // Assert
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Battleships_ShipNotHorizontalOrVertical_ThrowsArgumentException()
        {
            // Arrange
            string[] ships = new[] { "2:2,3:5" };
            string[] guesses = new[] { "7:0", "3:3" };

            // Act
            Action act = () => Game.Play(ships, guesses);

            // Assert
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Battleships_ShipTooShort_ThrowsArgumentException()
        {
            // Arrange
            string[] ships = new[] { "3:2,3:2" };
            string[] guesses = new[] { "7:0", "3:3" };

            // Act
            Action act = () => Game.Play(ships, guesses);

            // Assert
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Battleships_ShipTooLong_ThrowsArgumentException()
        {
            // Arrange
            string[] ships = new[] { "3:2,3:6" };
            string[] guesses = new[] { "7:0", "3:3" };

            // Act
            Action act = () => Game.Play(ships, guesses);

            // Assert
            act.Should().Throw<ArgumentException>();
        }
    }
}
