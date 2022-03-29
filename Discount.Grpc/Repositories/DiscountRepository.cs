using Dapper;
using Discount.Grpc.Entities;
using Npgsql;

namespace Discount.Grpc.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        private NpgsqlConnection GetConnectionPostgreSql()
        {
            return new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        }

        public async Task<Coupon> GetDiscount(string productName)
        {
            var connection = GetConnectionPostgreSql();
            var sql = @"SELECT *
                          FROM Coupon
                         WHERE ProductName = @ProductName";
            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>(sql, new Coupon
            {
                ProductName = productName
            });

            if (coupon is null)
            {
                return new Coupon
                {
                    ProductName = "No Discount",
                    Amount = 0,
                    Description = "No Discount Description"
                };
            }

            return coupon;
        }

        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            var connection = GetConnectionPostgreSql();
            var sql = @"INSERT INTO Coupon (
                               ProductName,
                               Description,
                               Amount
                       ) VALUES (
                               @ProductName,
                               @Description,
                               @Amount
                       )";

            var affected = await connection.ExecuteAsync(sql, new Coupon
            {
                ProductName = coupon.ProductName,
                Description = coupon.Description,
                Amount = coupon.Amount
            });

            if (affected == 0)
                return false;

            return true;
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            var connection = GetConnectionPostgreSql();
            var sql = @"UPDATE Coupon
                           SET ProductName=@ProductName,
                               Description=@Description,
                               Amount=@Amount
                         WHERE Id = @Id";

            var affected = await connection.ExecuteAsync(sql, new Coupon
            {
                Id = coupon.Id,
                ProductName = coupon.ProductName,
                Description = coupon.Description,
                Amount = coupon.Amount
            });

            if (affected == 0)
                return false;

            return true;
        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            var connection = GetConnectionPostgreSql();
            var sql = @"DELETE FROM Coupon
                         WHERE ProductName = @ProductName";

            var affected = await connection.ExecuteAsync(sql, new Coupon
            {
                ProductName = productName
            });

            if (affected == 0)
                return false;

            return true;
        }
    }
}
