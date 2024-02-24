using Dapper;
using Real_Estate_Api.Models.DapperContext;

namespace Real_Estate_Api.Repositories.StatisticRepositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly AppDbContext _context;

        public StatisticRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> ActiveCategoryCount()
        {
            string query = "select count(Id) from category where status=1";
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query);
                return values;
            }
        }

        public async Task<int> ActiveEmployeeCount()
        {
            string query = "select count(Id) from employee where status=1";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query);
                return values;
            }
        }

        public async Task<int> ApartmentCount()
        {
            string query = "select count(p.Id) from product p where p.Title like '%Daire%'";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query);
                return values;
            }
        }

        public async Task<decimal> AverageProductPriceByRent()
        {
            string query = "select avg(p.Price) from product p where p.Type = 'Kiralık'";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<decimal>(query);
                return values;
            }
        }

        public async Task<decimal> AverageProductPriceBySale()
        {
            string query = "select avg(p.Price) from product p where p.Type = 'Satılık'";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<decimal>(query);
                return values;
            }
        }

        public async Task<int> AverageRoomCount()
        {
            string query = "select avg(pd.RoomCount) from ProductDetails pd ";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query);
                return values;
            }
        }

        public async Task<int> CategoryCount()
        {
            string query = "select count(Id) from category";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query);
                return values;
            }
        }

        public async Task<string> CategoryNameByMaxProductCount()
        {
            string query = "select top(1)c.Name,count(*) toplam from product p join Category c on" +
                " c.Id = p.CategoryId group by c.Name order by count(p.CategoryId) desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<string>(query);
                return values;
            }
        }

        public async Task<string> CityNameByMaxProductCount()
        {
            string query = "select top(1)city,count(*) as 'ilan_Sayisi' from product  group by city order by ilan_Sayisi desc ";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<string>(query);
                return values;
            }
        }

        public async Task<int> DifferentCityCount()
        {
            string query = "select count(distinct p.City) from product p";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query);
                return values;
            }
        }

        public async Task<string> EmployeeNameByMaxProductCount()
        {
            string query = "select top(1) e.name,count(*) 'product_count' from product p join Employee e on e.Id=p.EmployeeId group by e.Name order by product_count desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<string>(query);
                return values;
            }
        }

        public async Task<decimal> LastProductPrice()
        {
            string query = "select top(1)p.Price from product p order by p.Id desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<decimal>(query);
                return values;
            }
        }

        public async Task<string> NewestBuildingYear()
        {
            string query = "select top(1)pd.BuildYear from ProductDetails pd order by pd.BuildYear desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<string>(query);
                return values;
            }
        }

        public async Task<string> OldestBuildingYear()
        {
            string query = "select top(1)pd.BuildYear from ProductDetails pd order by pd.BuildYear asc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<string>(query);
                return values;
            }
        }

        public async Task<int> PassiveCategoryCount()
        {
            string query = "select count(Id) from category where status=0";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query);
                return values;
            }
        }

        public async Task<int> ProductCount()
        {
            string query = "select count(Id) from product";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<int>(query);
                return values;
            }
        }
    }
}
