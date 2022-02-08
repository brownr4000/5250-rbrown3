using NUnit.Framework;
using Mine.Models;

namespace UnitTests.Models
{
    /// <summary>
    /// The HomeMenuItemTests class is the structure for Unit Tests of the HomeMenuItem class
    /// </summary>
    [TestFixture]
    public class HomeMenuItemTests
    {
        /// <summary>
        /// Tests the default HomeMenuItem Constructor
        /// </summary>
        [Test]
        public void HomeMenuItem_Constructor_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new HomeMenuItem();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Tests the get and set of the attributes of the HomeMenuItem object
        /// </summary>
        [Test]
        public void HomeMenuItem_Set_Get_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new HomeMenuItem();
            result.Id = MenuItemType.About;
            result.Title = "Title";

            // Reset

            // Assert
            Assert.AreEqual(MenuItemType.About, result.Id);
            Assert.AreEqual("Title", result.Title);
        }
    }
}
