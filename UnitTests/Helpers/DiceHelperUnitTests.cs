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
    }
}
