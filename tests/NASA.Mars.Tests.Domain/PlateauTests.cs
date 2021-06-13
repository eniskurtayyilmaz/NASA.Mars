using System;
using NASA.Mars.Domain;
using NASA.Mars.Shared.Exceptions;
using Xunit;

namespace NASA.Mars.Tests.Domain
{
    public class ConstraintPlateauTests
    {
        public const string MessageOfNullEmptyOrWhitespace = "Dimensions can not be null or empty";

        public const string MessageFormatOfInvalidPlateau = "Invalid Plateau:";
        public const string MessageFormatOfDimensionConvert = "Invalid Dimension Convert:";
        public const string TestData = "5 5";
    }
    public class PlateauTests
    {
        [Theory(DisplayName = "ArgumentException Case(s): null, empty")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("   ")]
        public void InitializeNullEmpty_ThrowArgumentException(string initalizePlateau)
        {
            //Arrange

            //Action
            Action act = () =>
            {
                _ = new Plateau(initalizePlateau);
            };

            //Assert
            var ex = Record.Exception(act);

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            Assert.Equal(ConstraintPlateauTests.MessageOfNullEmptyOrWhitespace, ex.Message);

        }

        [Theory(DisplayName = "Invalid Plateau InvalidDimensionConvertException Case(s): not greater than or equal of 0")]
        [InlineData("0 -1")]
        [InlineData("-1 0")]
        public void InvalidPlateau_ThrowsInvalidDimensionConvertException(string initalizePlateau)
        {
            //Arrange

            //Action
            Action act = () =>
            {
                _ = new Plateau(initalizePlateau);
            };

            //Assert
            var ex = Record.Exception(act);

            Assert.NotNull(ex);
            Assert.IsType<InvalidDimensionConvertException>(ex);
            Assert.Contains(ConstraintPlateauTests.MessageFormatOfDimensionConvert, ex.Message);
        }



        [Theory(DisplayName = "Valid Plateau Case(s): includes InvalidPlateauException Case(s): includes 5 5 or X X")]
        [InlineData("5 5")]
        [InlineData("6 6")]
        [InlineData("1 1")]
        public void ValidPlateau_true(string initalizePlateau)
        {
            //Arrange

            //Action
            var Plateau = new Plateau(initalizePlateau);

            //Assert
            Assert.True(true);
        }
    }
}
