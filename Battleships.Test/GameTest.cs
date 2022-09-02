using System;
using FluentAssertions;
using Xunit;

namespace Battleships.Test
{
    public class GameTest
    {
        [Fact]
        public void TestPlay()
        {
            var ships = new[] { "3:2,3:5" };
            var guesses = new[] { "7:0", "3:3" };
            Game.Play(ships, guesses).Should().Be(0);
        }

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

    }
}
