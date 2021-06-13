using System;
using NASA.Mars.Domain;
using NASA.Mars.Shared.Exceptions;
using Xunit;

namespace NASA.Mars.Tests.Domain
{
    public class ConstraintPositionTests
    {
        public const string MessageOfNullEmpty = "Position can not be null or empty";
        public const string MessageOfNotMatchesOfPosition = "Position not matches with X Y H";

        public const string MessageFormatOfInvalidPosition = "Directions can not be null or empty:";
        public const string MessageFormatOfInvalidDirection = "Invalid Direction:";
        public const string TestData = "0 1 W";
    }
    public class PositionTests
    {
        [Theory(DisplayName = "ArgumentException Case(s): null, empty")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("   ")]
        public void InitializeNullEmpty_ThrowArgumentException(string initalizePosition)
        {
            //Arrange

            //Action
            Action act = () =>
            {
                _ = new Position(initalizePosition);
            };

            //Assert
            var ex = Record.Exception(act);

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal(ConstraintPositionTests.MessageOfNullEmpty, ex.Message);

        }

        [Theory(DisplayName = "Invalid Position InvalidPositionException Case(s): Position not matches with X Y H")]
        [InlineData("N ")]
        [InlineData("N W")]
        [InlineData("N Z W")]
        public void InvalidPosition_ThrowsInvalidPositionException(string initalizePosition)
        {
            //Arrange

            //Action
            Action act = () =>
            {
                _ = new Position(initalizePosition);
            };

            //Assert
            var ex = Record.Exception(act);

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Contains(ConstraintPositionTests.MessageOfNotMatchesOfPosition, ex.Message);
        }



        [Theory(DisplayName = "Valid Position Case(s): Position not matches with X Y H")]
        [InlineData("0 1 W")]
        [InlineData("2 3 N")]
        [InlineData("2 3 N")]
        [InlineData("5 3 S")]
        public void ValidPosition_true(string initalizePosition)
        {
            //Arrange
            var position = new Position(initalizePosition);

            //Action
            var result = position.GetPositionCurrentStatus();

            //Assert
            Assert.Equal(initalizePosition, result.ToString());
        }

        [Theory(DisplayName = "Valid TurnLeft Case(s)")]
        [InlineData("0 1 W S")]
        [InlineData("2 3 N W")]
        [InlineData("2 3 N W")]
        [InlineData("5 3 S E")]
        [InlineData("5 3 E N")]
        public void ValidTurnLeft_true(string testData)
        {

            //Arrange
            var initalizePosition = testData.Substring(0, 6);
            var position = new Position(initalizePosition);
            position.Rotate90LeftSide();

            //Action
            var result = position.GetPositionCurrentStatus();

            //Assert
            Assert.Equal(initalizePosition.Substring(0, 4) + testData.Substring(6, 1), result.ToString());
        }


        [Theory(DisplayName = "Valid TurnRight Case(s)")]
        [InlineData("0 1 W N")]
        [InlineData("2 3 N E")]
        [InlineData("2 3 N E")]
        [InlineData("5 3 S W")]
        [InlineData("5 3 E S")]
        public void ValidTurnRight_true(string testData)
        {

            //Arrange
            var initalizePosition = testData.Substring(0, 6);
            var position = new Position(initalizePosition);
            position.Rotate90RightSide();

            //Action
            var result = position.GetPositionCurrentStatus();

            //Assert
            Assert.Equal(initalizePosition.Substring(0, 4) + testData.Substring(6, 1), result.ToString());
        }



        [Theory(DisplayName = "Valid MoveForward Case(s)")]
        [InlineData("1 1 W 0 1 W")]
        [InlineData("2 3 N 2 4 N")]
        [InlineData("2 3 N 2 4 N")]
        [InlineData("5 3 S 5 2 S")]
        [InlineData("5 3 E 6 3 E")]
        public void ValidMoveForward_true(string testData)
        {

            //Arrange
            var testPositionCompare = testData.Substring(6, 5);


            var initalizePosition = testData.Substring(0, 6);
            var position = new Position(initalizePosition);
            position.MoveForward();

            //Action
            var result = position.GetPositionCurrentStatus();

            //Assert
            Assert.Equal(testPositionCompare, result.ToString());
        }

        [Theory(DisplayName = "Valid IsOnPlateau Case(s)")]
        [InlineData("2 1 W 1 1 W")]
        [InlineData("2 3 N 2 4 N")]
        [InlineData("2 3 N 2 4 N")]
        [InlineData("5 3 S 5 2 S")]
        [InlineData("4 3 E 5 3 E")]
        public void Valid_IsOnPlateau(string testData)
        {

            //Arrange
            Plateau plateau = new Plateau(ConstraintPlateauTests.TestData);

            var testPositionCompare = testData.Substring(6, 5);


            var initalizePosition = testData.Substring(0, 6);
            var position = new Position(initalizePosition);
            position.MoveForward();

            //Action
            var currentStatus = position.GetPositionCurrentStatus();
            var result = position.IsOnPlateau(plateau);

            //Assert
            Assert.Equal(testPositionCompare, currentStatus.ToString());
            Assert.True(result);
        }


        [Theory(DisplayName = "Invalid IsOnPlateau Case(s): There is no space ")]
        [InlineData("0 1 W -1 1 W")]
        [InlineData("5 0 S 5 -1 S")]
        public void InValid_IsOnPlateau(string testData)
        {

            //Arrange
            Plateau plateau = new Plateau(ConstraintPositionTests.TestData);

            var testPositionCompare = testData.Substring(6, 6);


            var initalizePosition = testData.Substring(0, 6);
            var position = new Position(initalizePosition);
            position.MoveForward();

            //Action
            var currentStatus = position.GetPositionCurrentStatus();
            var result = position.IsOnPlateau(plateau);

            //Assert
            Assert.Equal(testPositionCompare, currentStatus.ToString());
            Assert.False(result);
        }
    }
}
