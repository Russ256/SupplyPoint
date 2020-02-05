namespace SupplyPoint.Application.Queries
{
    using Dapper;
    using Microsoft.Data.Sqlite;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProductQueries : IProductQueries
    {
        private readonly string connectionString;

        public ProductQueries(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            using (SqliteConnection connection = new SqliteConnection(this.connectionString))
            {
                await connection.OpenAsync();

                IEnumerable<ProductDto> result = await connection.QueryAsync<ProductDto>(
                   @"select id, name, text
                        FROM products"
                    );

                return result;
            }
        }
    }
}