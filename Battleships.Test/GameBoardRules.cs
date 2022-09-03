using FluentAssertions;
using System;
using Xunit;

namespace Battleships.Test
{
    public class GameBoardRules
    {
        [Theory]
        // Testing -1
        [InlineData("-1:2,3:5")]
        [InlineData("3:-1,3:5")]
        [InlineData("3:2,-1:5")]
        [InlineData("3:2,3:-1")]
        // Testing 10
        [InlineData("10:2,3:5")]
        [InlineData("3:10,3:5")]
        [InlineData("3:2,10:5")]
        [InlineData("3:2,3:10")]
        public void Battleships_OutOfBoundsShipInput_ThrowsArgumentException(string input)
        {
            // Arrange
            string[] ships = new[] { input };
            string[] guesses = new[] { "7:0", "3:3" };

            // Act
            Action act = () => Game.Play(ships, guesses);

            // Assert
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Battleships_OnlyOneShipToAGridCell_ThrowsArgumentException()
        {
            // Arrange
            string[] ships = new[] { "3:2,3:5", "3:2,3:5" };
            string[] guesses = new[] { "7:0", "3:3" };

            // Act
            Action act = () => Game.Play(ships, guesses);

            // Assert
            act.Should().Throw<ArgumentException>();
        }

        [Theory]
        // Testing -1
        [InlineData(0, new string[] { "-1:2" })]
        [InlineData(0, new string[] { "2:-1" })]
        // Testing 10
        [InlineData(0, new string[] { "10:2" })]
        [InlineData(0, new string[] { "2:10" })]
        public void Battleships_OutOfBoundsGuessInput_ThrowsArgumentException(int value, string[] guesses)
        {
            // Arrange
            var ships = new[] { "3:2,3:5" };

            // Act
            Action act = () => Game.Play(ships, guesses);

            // Assert
            act.Should().Throw<ArgumentException>();
        }
    }
}
