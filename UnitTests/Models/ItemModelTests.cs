using NUnit.Framework;
using Mine.Models;

namespace UnitTests.Models
{
    /// <summary>
    /// The ItemModelTests class is the structure for Unit Tests of the ItemModel class
    /// </summary>
    [TestFixture]
    public class ItemModelTests
    {
        /// <summary>
        /// Tests the default ItemModel Constructor
        /// </summary>
        [Test]
        public void ItemModel_Constructor_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new ItemModel();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Tests the get and set of the attributes of the  ItemModel object
        /// </summary>
        [Test]
        public void ItemModel_Set_Get_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new ItemModel();
            result.Description = "Description";
            result.Id = "ID";
            result.Text = "Text";
            result.Value = 1;

            // Reset

            // Assert
            Assert.AreEqual("Description", result.Description);
            Assert.AreEqual("ID", result.Id);
            Assert.AreEqual("Text", result.Text);
            Assert.AreEqual(1, result.Value);
        }

        /// <summary>
        /// Tests the default value of the ItemModel class object
        /// </summary>
        [Test]
        public void ItemModel_Get_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new ItemModel();

            // Reset

            // Assert
            Assert.AreEqual(0, result.Value);
        }
    }
}
