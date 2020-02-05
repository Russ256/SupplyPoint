namespace SupplyPoint.Test.Application.Commands.Product
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using SupplyPoint.Application.Commands.Products;
    using SupplyPoint.Domain.AggregateModel;
    using System;

    [TestClass]
    public class CreateHandlerTests
    {
        [TestMethod]
        public void HandleTest()
        {
            // Arrange
            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(m => m.Add(It.IsAny<Product>())).Returns((Product p) => p);
            MyCreateHandler sut = new MyCreateHandler(mockProductRepository.Object);
            string name = "Product Name";
            string text = "Product Text";
            CreateRequest request = new CreateRequest(name,text);

            // Act
            CreateResponse result = sut.Test_Handle(request);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreNotEqual(Guid.Empty, result.Id);
            Assert.AreEqual(name, result.Name);
            Assert.AreEqual(text, result.Text);
        }

        private class MyCreateHandler : CreateHandler
        {
            public MyCreateHandler(IProductRepository repo) : base(repo)
            {
            }

            public CreateResponse Test_Handle(CreateRequest request)
            {
                return this.Handle(request);
            }
        }
    }
}