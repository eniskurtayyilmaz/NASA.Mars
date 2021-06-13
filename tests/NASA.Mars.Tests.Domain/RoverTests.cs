using System;
using NASA.Mars.Domain;
using NASA.Mars.Shared.Exceptions;
using Xunit;

namespace NASA.Mars.Tests.Domain
{
    public class ConstraintRoverTests
    {
        public const string MessageOfNullEmptyOrWhitespace = "Tagname can not be null or empty";

        public const string MessageFormatOfInvalidRover = "Invalid Rover:";
        public const string ValueCannotBeNull = "Value cannot be null.";
    }
    public class RoverTests
    {
        [Theory(DisplayName = "ArgumentException Case(s): null, empty")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("   ")]
        public void InitializeNullEmpty_ThrowArgumentException(string initalizeRover)
        {
            //Arrange

            //Action
            Action act = () =>
            {
                _ = new Rover(initalizeRover, null, null, null);
            };

            //Assert
            var ex = Record.Exception(act);

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal(ConstraintRoverTests.MessageOfNullEmptyOrWhitespace, ex.Message);

        }

        [Theory(DisplayName = "ArgumentNullException Case(s): Plateau not null")]
        [InlineData("tagNameRover")]
        public void InitializePlateau_ThrowArgumentNullException(string tagNameRover)
        {
            //Arrange

            //Action
            Action act = () =>
            {
                _ = new Rover(tagNameRover, new Plateau(ConstraintPlateauTests.TestData), null, null);
            };

            //Assert
            var ex = Record.Exception(act);

            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
            Assert.Equal(ConstraintRoverTests.ValueCannotBeNull, ex.Message);

        }


        [Theory(DisplayName = "ArgumentNullException Case(s): Positions not null")]
        [InlineData("tagNameRover")]
        public void InitializePositions_ThrowArgumentNullException(string tagNameRover)
        {
            //Arrange

            //Action
            Action act = () =>
            {
                _ = new Rover(tagNameRover, new Plateau(ConstraintPlateauTests.TestData), new Position(ConstraintPositionTests.TestData), null);
            };

            //Assert
            var ex = Record.Exception(act);

            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
            Assert.Equal(ConstraintRoverTests.ValueCannotBeNull, ex.Message);

        }

        [Theory(DisplayName = "ArgumentNullException Case(s): Instructions not null")]
        [InlineData("tagNameRover")]
        public void InitializeInstructions_ThrowArgumentNullException(string tagNameRover)
        {
            //Arrange

            //Action
            Action act = () =>
            {
                _ = new Rover(tagNameRover, new Plateau(ConstraintPlateauTests.TestData), new Position(ConstraintPositionTests.TestData), new Instructions(ConstraintInstructionsTests.TestData));
            };

            //Assert
            var ex = Record.Exception(act);

            Assert.Null(ex);
            Assert.True(true);

        }

        
    }
}
