using System;
using NASA.Mars.Domain;
using NASA.Mars.Shared.Exceptions;
using Xunit;

namespace NASA.Mars.Tests.Domain
{
    public class ConstraintInstructionsTests
    {
        public const string MessageOfNullEmptyOrWhitespace = "Instructions can not be null or empty";

        public const string MessageFormatOfInvalidInstruction = "Invalid Instruction:";
        public const string TestData = "LRM";

    }
    public class InstructionsTests
    {
        [Theory(DisplayName = "ArgumentException Case(s): null, empty")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("   ")]
        public void InitializeNullEmpty_ThrowArgumentException(string initalizeInstructions)
        {
            //Arrange

            //Action
            Action act = () =>
            {
                _ = new Instructions(initalizeInstructions);
            };

            //Assert
            var ex = Record.Exception(act);

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal(ConstraintInstructionsTests.MessageOfNullEmptyOrWhitespace, ex.Message);

        }

        [Theory(DisplayName = "Invalid Instruction InvalidInstructionException Case(s): not includes L, R, W")]
        [InlineData("L R 2")]
        [InlineData("L R2")]
        [InlineData("L R M")]
        [InlineData("LR2")]
        [InlineData("2 ")]
        [InlineData("Z ")]
        [InlineData("2")]
        [InlineData("Z")]
        [InlineData("T")]
        public void InvalidInstrucions_ThrowsInvalidInstructionException(string initalizeInstructions)
        {
            //Arrange

            //Action
            Action act = () =>
            {
                _ = new Instructions(initalizeInstructions);
            };

            //Assert
            var ex = Record.Exception(act);

            Assert.NotNull(ex);
            Assert.IsType<InvalidInstructionException>(ex);
            Assert.Contains(ConstraintInstructionsTests.MessageFormatOfInvalidInstruction, ex.Message);
        }


        [Theory(DisplayName = "Valid Instruction Case(s): includes L, R, W")]
        [InlineData("LRM")]
        [InlineData("L")]
        [InlineData("R")]
        [InlineData("M")]
        public void ValidInstrucions_true(string initalizeInstructions)
        {
            //Arrange
            var instructions = new Instructions(initalizeInstructions);

            //Action
            var result = instructions.GetInstructions();

            //Assert
            Assert.True(result.Length > 0);


        }
    }
}
