namespace SupplyPoint.Test.Application.Queries
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SupplyPoint.Application.Queries;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [TestClass]
    public class ProductQueriesTests
    {
        [TestMethod]
        public async Task GetProductsTest()
        {
            // Arrange
            ProductQueries queries = new ProductQueries("Data Source=SupplyPoint.db");

            // Act
            IEnumerable<ProductDto> result = await queries.GetProductsAsync();

            // Assert
            Assert.IsNotNull(result);
            List<ProductDto> resultList = result.ToList();
            Assert.AreEqual(2, resultList.Count());
            Assert.AreEqual("Product 1", resultList[0].Name);
            Assert.AreEqual("Product 2", resultList[1].Name);
        }
    }
}