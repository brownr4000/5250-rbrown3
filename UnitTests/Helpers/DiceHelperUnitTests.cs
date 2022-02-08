using NUnit.Framework;
using Mine.Models;
using Mine.Helpers;

namespace UnitTests.Helpers
{
    /// <summary>
    /// The DiceHelperUnitTests class is the structure for Unit Tests of the DiceHelper class
    /// </summary>
    [TestFixture]
    public class DiceHelperUnitTests
    {
        /// <summary>
        /// Test to check that a die roll zero times is zero
        /// </summary>
        [Test]
        public void RollDice_Invalid_Roll_Zero_Should_Return_Zero()
        {
            // Arrange

            // Act
            var result = DiceHelper.RollDice(0, 1);

            // Reset

            // Assert
            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// Test to check that a six-sided die returns a result between 1 and 6
        /// </summary>
        [Test]
        public void RollDice_Valid_Roll_1_Dice_6_Should_Return_Between_1_And_6()
        {
            // Arrange

            // Act
            var result = DiceHelper.RollDice(1, 6);

            // Reset

            // Assert
            Assert.AreEqual(true, result >= 1);
            Assert.AreEqual(true, result <= 6);
        }
    }
}
