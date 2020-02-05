namespace SupplyPoint.Test.Domain.AggregateModel
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SupplyPoint.Domain.AggregateModel;
    using System;
    using System.Collections.Generic;
    using System.Text;

    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void CreateSuccessTest()
        {
            // Arrange
            string name = "Product Name";
            string text = "Product Text ";

            // Act
            Product sut = new Product(name, text);

            // Assert
            Assert.AreEqual(name, sut.Name);
            Assert.AreEqual(text, sut.Text);
        }

        [TestMethod]
        public void CreateNoNameTest()
        {
            // Arrange

            // Act
            ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new Product(null, null);
            }
            );

            // Assert
            Assert.AreEqual("name", exception.ParamName);
        }
    }
}
