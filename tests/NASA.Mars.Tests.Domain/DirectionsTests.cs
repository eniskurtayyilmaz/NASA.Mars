using System;
using NASA.Mars.Domain;
using NASA.Mars.Shared.Exceptions;
using Xunit;

namespace NASA.Mars.Tests.Domain
{
    public class ConstraintDirectionsTests
    {
        public const string MessageOfNullEmptyOrWhitespace = "Directions can not be null or empty";

        public const string MessageFormatOfInvalidDirection = "Invalid Direction:";
    }
    public class DirectionsTests
    {
        [Theory(DisplayName = "ArgumentException Case(s): null, empty")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("   ")]
        public void InitializeNullEmpty_ThrowArgumentException(string initalizeDirections)
        {
            //Arrange

            //Action
            Action act = () =>
            {
                _ = new Directions(initalizeDirections);
            };

            //Assert
            var ex = Record.Exception(act);

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal(ConstraintDirectionsTests.MessageOfNullEmptyOrWhitespace, ex.Message);

        }

        [Theory(DisplayName = "Invalid Direction InvalidDirectionException Case(s): not includes N, W, E, S")]
        [InlineData("N ")]
        [InlineData("N W")]
        public void InvalidDirections_ThrowsInvalidDirectionException(string initalizeDirections)
        {
            //Arrange

            //Action
            Action act = () =>
            {
                _ = new Directions(initalizeDirections);
            };

            //Assert
            var ex = Record.Exception(act);

            Assert.NotNull(ex);
            Assert.IsType<InvalidDirectionException>(ex);
            Assert.Contains(ConstraintDirectionsTests.MessageFormatOfInvalidDirection, ex.Message);
        }


        [Theory(DisplayName = "Valid Direction Case(s): includes InvalidDirectionException Case(s): includes N, W, E, S")]
        [InlineData("N")]
        [InlineData("W")]
        [InlineData("E")]
        [InlineData("S")]
        public void ValidDirections_true(string initalizeDirections)
        {
            //Arrange
            var directions = new Directions(initalizeDirections);

            //Action
            var result = directions.GetCurrenctDirection();

            //Assert
            Assert.Equal(initalizeDirections, result.ToString().Substring(0, 1));


        }
    }
}
