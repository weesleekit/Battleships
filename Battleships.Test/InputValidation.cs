using FluentAssertions;
using System;
using Xunit;

namespace Battleships.Test
{
    public class InputValidation
    {
        [Fact]
        public void Battleships_NullShipsInput_ThrowsArgumentNullException()
        {
            // Arrange
            string[] ships = null;
            string[] guesses = new[] { "7:0", "3:3" };

            // Act
            Action act = () => Game.Play(ships, guesses);

            // Assert
            act.Should().Throw<ArgumentNullException>()
                .WithParameterName("ships");
        }

        [Fact]
        public void Battleships_NullGuessesInput_ThrowsArgumentNullException()
        {
            // Arrange
            var ships = new[] { "3:2,3:5" };
            string[] guesses = null;

            // Act
            Action act = () => Game.Play(ships, guesses);

            // Assert
            act.Should().Throw<ArgumentNullException>()
                .WithParameterName("guesses");
        }


        [Fact]
        public void Battleships_NoShips_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            string[] ships = Array.Empty<string>();
            string[] guesses = new[] { "7:0", "3:3" };

            // Act
            Action act = () => Game.Play(ships, guesses);

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithParameterName("ships");
        }

        [Fact]
        public void Battleships_InvalidShipInput_ThrowsArgumentException()
        {
            // Arrange
            string[] ships = new[] { "asdjasbekfgjbsg" };
            string[] guesses = new[] { "7:0", "3:3" };

            // Act
            Action act = () => Game.Play(ships, guesses);

            // Assert
            act.Should().Throw<ArgumentException>();
        }
    }
}
