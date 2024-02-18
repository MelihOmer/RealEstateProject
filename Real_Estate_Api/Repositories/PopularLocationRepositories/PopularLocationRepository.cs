using Dapper;
using Real_Estate_Api.Dtos.PopulerLocationDtos;
using Real_Estate_Api.Models.DapperContext;

namespace Real_Estate_Api.Repositories.PopularLocationRepositories
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        private readonly AppDbContext _context;

        public PopularLocationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync()
        {
            string query = "select * from PopularLocation";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopularLocationDto>(query);
                return values.ToList();
            }
        }
    }
}
