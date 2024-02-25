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

        public async Task CreatePopularLocationAsync(CreatePopularLocationDto createPopularLocationDto)
        {
            string query = "insert into PopularLocation (CityName,ImageUrl) values (@cityName,@imageUrl)";
            var parameters = new DynamicParameters();
            parameters.Add("@cityName", createPopularLocationDto.CityName);
            parameters.Add("@imageUrl", createPopularLocationDto.ImageUrl);
            using (var connection = _context.CreateConnection())
            {
                var execute = await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeletePopularLocationAsync(int id)
        {
            string query = "delete from popularlocation where Id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

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

        public async Task<GetByIdPopularLocationDto> GetPopularLocationByIdAsync(int id)
        {
            string query = "select * from PopularLocation where Id = @id";
            var param = new DynamicParameters();
            param.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdPopularLocationDto>(query, param);
                return values;
            }
        }

        public async Task UpdatePopularLocationAsync(UpdatePopularLocationDto updatePopularLocationDto)
        {
            string query = "update  PopularLocation set CityName=@cityName,ImageUrl=@imageUrl where Id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@cityName", updatePopularLocationDto.CityName);
            parameters.Add("@imageUrl", updatePopularLocationDto.ImageUrl);
            parameters.Add("@id", updatePopularLocationDto.Id);
            using (var connection = _context.CreateConnection())
            {
                var execute = await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
