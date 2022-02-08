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

        /// <summary>
        /// Tests that the die can be forced to a certain value
        /// </summary>
        [Test]
        public void RollDice_Invalid_Roll_1_Forced_1_Should_Return_1()
        {
            // Arrange
            DiceHelper.ForceRollsToNotRandom = true;
            DiceHelper.ForcedRandomValue = 1;

            // Act
            var result = DiceHelper.RollDice(1, 1);

            // Reset
            DiceHelper.ForceRollsToNotRandom = false;

            // Assert
            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// Tests to check that the value of two six-sided dice being rolled is between 2 and 12
        /// </summary>
        [Test]
        public void RollDice_Valid_Roll_2_Dice_6_Should_Return_Between_2_and_12()
        {
            // Arrange

            // Act
            var result = DiceHelper.RollDice(2, 6);

            // Reset

            // Assert
            Assert.AreEqual(true, result >= 2);
            Assert.AreEqual(true, result <= 12);
        }

        /// <summary>
        /// Test to check that a ten-sided die rolled zero times returns 0
        /// </summary>
        [Test]
        public void RollDice_InValid_Roll_0_Dice_10_Should_Return_Zero()
        {
            // Arrange

            // Act
            var result = DiceHelper.RollDice(0, 10);

            // Reset

            // Assert
            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// Test to check that a zero-sided die rolled one times returns 0
        /// </summary>
        [Test]
        public void RollDice_InValid_Roll_1_Dice_0_Should_Return_Zero()
        {
            // Arrange

            // Act
            var result = DiceHelper.RollDice(1, 0);

            // Reset

            // Assert
            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// Tests that a ten-sided die rolled once can be forced to a value of 5
        /// </summary>
        [Test]
        public void RollDice_Valid_Roll_1_Dice_10_Fixed_5_Should_Return_5()
        {
            // Arrange
            DiceHelper.ForceRollsToNotRandom = true;
            DiceHelper.ForcedRandomValue = 5;

            // Act
            var result = DiceHelper.RollDice(1, 10);

            // Reset
            DiceHelper.ForceRollsToNotRandom = false;

            // Assert
            Assert.AreEqual(5, result);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void RollDice_Valid_Roll_3_Dice_10_Fixed_5_Should_Return_15()
        {
            // Arrange
            DiceHelper.ForceRollsToNotRandom = true;
            DiceHelper.ForcedRandomValue = 5;

            // Act
            var result = DiceHelper.RollDice(3, 10);

            // Reset
            DiceHelper.ForceRollsToNotRandom = false;

            // Assert
            Assert.AreEqual(15, result);
        }

    }
}
